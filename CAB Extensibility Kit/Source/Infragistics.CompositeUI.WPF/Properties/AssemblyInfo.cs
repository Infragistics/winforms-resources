using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyConfiguration(AssemblyRef.Configuration)]
[assembly: AssemblyDescription(AssemblyRef.AssemblyDescriptionBase + " - " + AssemblyRef.Configuration + " Version")]
[assembly: AssemblyTitle(AssemblyRef.AssemblyName + AssemblyRef.ProductTitleSuffix)]
[assembly: AssemblyProduct(AssemblyRef.AssemblyProduct + AssemblyRef.ProductTitleSuffix)]

[assembly: AssemblyCompany("Infragistics, Inc")]
[assembly: AssemblyCopyright("Copyright © 2005-"+Infragistics.Shared.AssemblyVersion.EndCopyrightYear+ " Infragistics, Inc.")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("a0bfce1d-cac6-4b54-b77f-bac13fc77e47")]

[assembly: System.Resources.NeutralResourcesLanguageAttribute("en-US")]
[assembly: System.CLSCompliant(true)]
[assembly: System.Security.AllowPartiallyTrustedCallers()]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion(AssemblyRef.Version)]
[assembly: AssemblyFileVersion(AssemblyRef.Version)]
[assembly: System.Resources.SatelliteContractVersion("1.0.0.0")]

class AssemblyRef
{
	internal const string Version = "1.0." + Infragistics.Shared.AssemblyVersion.Build + "." + Infragistics.Shared.AssemblyVersion.Revision;

	internal const string AssemblyName = "Infragistics.Practices.CompositeUI.WPF.v" + Infragistics.Shared.AssemblyVersion.MajorMinor;
	internal const string AssemblyProduct = "Infragistics.Practices.CompositeUI.WPF";
	internal const string AssemblyDescriptionBase = "Infragistics Composite UI WPF Application Block";

#if TRIAL
	internal const string Configuration = "Trial";
#elif RELEASE
	internal const string Configuration = "Release";
#elif DEBUG
	internal const string Configuration = "Debug";
#elif BETA
	internal const string Configuration = "Beta";
#endif

#if RELEASE
	internal const string ProductTitleSuffix = "";
#else
	internal const string ProductTitleSuffix = " [" + AssemblyRef.Configuration + "]";
#endif
}