using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI;
using System.Windows.Forms;
using Infragistics.Win;
using System.Reflection;
using System.ComponentModel;
using System.IO;

namespace Infragistics.Practices.CompositeUI.WinForms
{
	/// <summary>
	/// Strategy that adds ink provider capability to container controls in the application.
	/// </summary>
	public class InkProviderStrategy : BuilderStrategy
	{
		#region Member Variables

		private static object InkProviderLock = new object();
		private static Dictionary<Control, IInkProvider> inkProviders = new Dictionary<Control, IInkProvider>(); 
		private static readonly string InkAssemblyName;

		private static readonly bool isInkRecognitionAvailable;

		#endregion //Member Variables

		#region Static Constructor
		static InkProviderStrategy()
		{
			#region InkAssemblyName

			string InkAssemblyNamev1 =
				"Infragistics2.Win.UltraWinInkProvider.v" +
				Infragistics.Shared.AssemblyVersion.MajorMinor +
				", Version=" +
				Infragistics.Shared.AssemblyVersion.Version +
				", Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb";

			string InkAssemblyNamev17 =
				"Infragistics2.Win.UltraWinInkProvider.Ink17.v" +
				Infragistics.Shared.AssemblyVersion.MajorMinor +
				", Version=" +
				Infragistics.Shared.AssemblyVersion.Version +
				", Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb";

			if (LoadInkAssembly(InkAssemblyNamev17))
				InkAssemblyName = InkAssemblyNamev17;
			else if (LoadInkAssembly(InkAssemblyNamev1))
				InkAssemblyName = InkAssemblyNamev1;
			else
				InkAssemblyName = null; 

			#endregion //InkAssemblyName

			#region IsInkRecognitionAvailable

			// There were some alternative approaches to check
			// if ink recognition is available but its better
			// just to create an ink provider and check with it.
			//
			// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/tpcsdk10/lonestar/managed_ovw/tbconapisamptpcinfo.asp
			// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/tpcsdk10/lonestar/gettingstarted/tbconfreqaskedquestions.asp
			if (null != InkAssemblyName)
			{
				IInkProvider inkProvider = CreateInkProvider();

				try
				{
					PropertyDescriptor propDescriptor = TypeDescriptor.GetProperties(inkProvider)["IsInkRecognitionAvailable"];
					isInkRecognitionAvailable = (bool)propDescriptor.GetValue(inkProvider);
				}
				finally
				{
					if (inkProvider is IDisposable)
						((IDisposable)inkProvider).Dispose();
				}
			}
			else
				isInkRecognitionAvailable = false; 

			#endregion //IsInkRecognitionAvailable
		} 
		#endregion //Static Constructor

		#region Base Class Overrides
		/// <summary>
		/// Walks the control hierarchy and adds the relevant elements to the <see cref="WorkItem"/>.
		/// </summary>
		public override object BuildUp(IBuilderContext context, Type typeToBuild, object existing, string idToBuild)
		{
			// handle ownedforms, ultradockmanager panes, ultratoolbarmgr forms
			if (existing is ContainerControl)
				this.ProcessAddControl(existing as ContainerControl);

			return base.BuildUp(context, typeToBuild, existing, idToBuild);
		}

		/// <summary>
		/// Walks the control hierarchy removing the relevant elements from the <see cref="WorkItem"/>.
		/// </summary>
		public override object TearDown(IBuilderContext context, object item)
		{
			// handle ownedforms, ultradockmanager panes, ultratoolbarmgr forms
			if (item is ContainerControl)
				this.ProcessRemoveControl(item as ContainerControl);

			return base.TearDown(context, item);
		}
		#endregion //Base Class Overrides

		#region Properties

		#region IsInkAssemblyLoaded
		internal static bool IsInkAssemblyLoaded
		{
			get { return InkAssemblyName != null; }
		}
				#endregion //IsInkAssemblyLoaded

		#region IsInkRecognitionAvailable
		internal static bool IsInkRecognitionAvailable
		{
			get { return isInkRecognitionAvailable; }
		} 
		#endregion //IsInkRecognitionAvailable

		#endregion //Properties

		#region Methods

		#region CreateInkProvider
		private static IInkProvider CreateInkProvider()
		{
			System.Runtime.Remoting.ObjectHandle handle = Activator.CreateInstance(InkAssemblyName, "Infragistics.Win.Ink.UltraInkProvider");
			return handle.Unwrap() as IInkProvider;
		}

		#endregion //CreateInkProvider

		#region LoadInkAssembly
		/// <summary>
		/// Attempts to load the ink provider assembly with the specified name.
		/// </summary>
		/// <param name="inkAssemblyName">Name of the fully qualified wininkprovider assembly to load.</param>
		/// <returns>Returns true if the specified assembly was loaded; otherwise false is returned.</returns>
		private static bool LoadInkAssembly(string inkAssemblyName)
		{
			// Note: it is expected that this may cause an exception -
			// either because the ink provider dll is not installed or 
			// available or because the associated tablet pc ink sdk
			// (which is required to use the inkprovider) is not 
			// available. So this may generate a first chance exception
			// when attempting to load the assembly.
			//
			try
			{
				Assembly assembly = Assembly.Load(inkAssemblyName);
				List<string> processedAssemblies = new List<string>();
				LoadReferencedAssemblies(assembly, processedAssemblies);
				return true;
			}
			catch (FileNotFoundException)
			{
				return false;
			}
		} 
		#endregion //LoadInkAssembly

		#region LoadReferencedAssemblies
		private static void LoadReferencedAssemblies(Assembly assembly, List<string> processedAssemblies)
		{
			foreach (AssemblyName assemblyName in assembly.GetReferencedAssemblies())
			{
				if (processedAssemblies.Contains(assemblyName.FullName))
					continue;

				processedAssemblies.Add(assemblyName.FullName);

				Assembly referencedAssembly = Assembly.Load(assemblyName.FullName);

				LoadReferencedAssemblies(referencedAssembly, processedAssemblies);
			}
		}
		#endregion //LoadReferencedAssemblies

		#region ProcessAddControl
		private void ProcessAddControl(ContainerControl control)
		{
			// do not try to create an ink provider for these derived container control types
			if (control is PropertyGrid			||
				control is SplitContainer		||
				control is ToolStripContainer	||
				control is ToolStripPanel		||
				control is UpDownBase)
				return;

			if (Infragistics.Win.InkProviderManager.GetInkProvider(control) == null)
			{
				lock(InkProviderLock)
				{
					if (inkProviders.ContainsKey(control) == false)
					{
						IInkProvider inkProvider = CreateInkProvider();

						if (null != inkProvider)
						{
							inkProviders.Add(control, inkProvider);

							// associate it with the container control - this will in turn
							// register the container control with the ink provider
							TypeDescriptor.GetProperties(inkProvider)["ContainingControl"].SetValue(inkProvider, control);

							// if the system doesn't support ink recognition
							// then default to showing the keyboard instead of 
							// the ink collector panel
							if (IsInkRecognitionAvailable == false)
								TypeDescriptor.GetProperties(inkProvider)["InputMode"].SetValue(inkProvider, 1);
						}
					}
				}
			}
		}
		#endregion //ProcessAddControl

		#region ProcessRemoveControl
		private void ProcessRemoveControl(ContainerControl control)
		{
			lock(InkProviderLock)
			{
				if (inkProviders.ContainsKey(control))
				{
					IInkProvider inkProvider = inkProviders[control];
					inkProviders.Remove(control);

					if (inkProvider is IDisposable)
						((IDisposable)inkProvider).Dispose();
				}
			}
		}
		#endregion //ProcessRemoveControl

		#endregion //Methods
	}
}
