using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Win.UltraWinStatusBar;
using Microsoft.Practices.CompositeUI.UIElements;
using Microsoft.Practices.CompositeUI.Utility;

namespace Infragistics.Practices.CompositeUI.WinForms.UIElements
{
	/// <summary>
	/// An adapter that wraps the <see cref="UltraStatusPanelsCollection"/> of an <see cref="UltraStatusBar"/> for use as an <see cref="IUIElementAdapter"/>.
	/// </summary>
	public class StatusPanelsCollectionUIAdapter : UIElementAdapter<UltraStatusPanel>
	{
		#region Member Variables

		private UltraStatusPanelsCollection panels;

		#endregion //Member Variables

		#region Constructor
		/// <summary>
		/// Initializes a new <see cref="StatusPanelsCollectionUIAdapter"/>
		/// </summary>
		/// <param name="panels">Panels collection of an ultraStatusBar represented by the ui adapter</param>
		public StatusPanelsCollectionUIAdapter(UltraStatusPanelsCollection panels)
		{
			Guard.ArgumentNotNull(panels, "panels");

			this.panels = panels;
		}
		#endregion //Constructor

		#region Properties

		#region Panels
		/// <summary>
		/// The <see cref="UltraStatusPanelsCollection"/> that is represented by the adapter.
		/// </summary>
		protected UltraStatusPanelsCollection Panels
		{
			get { return this.panels; }
		}
		#endregion //Panels

		#endregion //StatusBar

		#region Methods

		#region Add
		/// <summary>
		/// Adds an <see cref="UltraStatusPanel"/> to the <see cref="UltraStatusBar"/> associated with the adapter.
		/// </summary>
		/// <param name="uiElement">Status panel to add to the UltraStatusBar</param>
		/// <returns>The item that was added.</returns>
		protected override UltraStatusPanel Add(UltraStatusPanel uiElement)
		{
			this.panels.Insert(this.GetNewElementIndex(uiElement), uiElement);

			return uiElement;
		}

		#endregion //Add

		#region GetNewElementIndex
		/// <summary>
		/// Returns the index at which an item will be added.
		/// </summary>
		/// <param name="panel">Panel to evaluate</param>
		/// <returns>By default, panels are added at the end of the associated <see cref="Panels"/> collection.</returns>
		protected virtual int GetNewElementIndex(UltraStatusPanel panel)
		{
			return this.Panels.Count;
		}
		#endregion //GetNewElementIndex

		#region Remove
		/// <summary>
		/// Removes the specified <see cref="UltraStatusPanel"/> from the associated <see cref="UltraStatusBar"/>
		/// </summary>
		/// <param name="uiElement">Status panel that should be removed.</param>
		protected override void Remove(UltraStatusPanel uiElement)
		{
			if (this.panels.Disposed == false)
				this.panels.Remove(uiElement);
		}
		#endregion //Remove

		#endregion // Methods
	}
}
