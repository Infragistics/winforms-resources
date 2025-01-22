using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.CompositeUI.Commands;
using System.Reflection;
using Microsoft.Practices.CompositeUI.Utility;
using System.Diagnostics;

namespace Infragistics.Practices.CompositeUI.WinForms.Commands
{
	/// <summary>
	/// Abstract base class for a command adapter that associates a single command with a single uielement event.
	/// </summary>
	/// <typeparam name="TInvoker">Type of invoker for which the command adapter is associated</typeparam>
	public abstract class CommandAdapterBase<TInvoker> : CommandAdapter
		where TInvoker : class
	{
		#region Member Variables

		// associated command
		private Command command;

		// uielement & event info
		private TInvoker invoker;
		private string eventName;
		private object eventSource;

		private IUIElement logicalInvoker;

		#endregion //Member Variables

		#region Constructor
		internal CommandAdapterBase()
		{
		}
		#endregion //Constructor

		#region Properties

		#region Command
		/// <summary>
		/// Returns the command associated with the command adapter.
		/// </summary>
		public Command Command
		{
			get { return this.command; }
		}
		#endregion //Command

		#region Invoker
		/// <summary>
		/// Returns the invoker object associated with the command adapter.
		/// </summary>
		internal protected TInvoker Invoker
		{
			get { return this.invoker; }
		}

		#endregion //Invoker

		#region InvokerKey
#if DEBUG
		/// <summary>
		/// Returns the object that will be used to identify the item in the master list.
		/// </summary>
#endif
		private IUIElement LogicalInvoker
		{
			get { return this.logicalInvoker; }
		}
		#endregion //InvokerKey

		#endregion //Properties

		#region Base class overrides

		#region AddInvoker
		/// <summary>
		/// Invoked to associated the command adapter with an object whose event will trigger the execution of the associated command.
		/// </summary>
		/// <param name="invoker">Object whose event will be hooked</param>
		/// <param name="eventName">Name of the event to hook</param>
		public override void AddInvoker(object invoker, string eventName)
		{
			Guard.ArgumentNotNull(invoker, "invoker");
			Guard.ArgumentNotNullOrEmptyString(eventName, "eventName");
			ThrowIfWrongType(invoker);

			if (this.invoker != null)
				throw new InvalidOperationException(Properties.Resources.AdapterAlreadyHasInvoker);

			// get the specific invoker
			TInvoker specificInvoker = (TInvoker)invoker;

			// get the object whose event will be caught
			object eventSource = this.GetEventSource(specificInvoker, eventName);

			if (eventSource == null)
				throw new InvalidOperationException(Properties.Resources.InvalidInvokerEvent);

			// hook the event of the event source. we do this first
			// in case the event doesn't exist, etc.
			this.HookEvent(eventSource, eventName);

			// then cache the information so we can unhook
			this.eventName = eventName;			// name of the event hooked
			this.invoker = specificInvoker;		// element associated with the adapter
			this.eventSource = eventSource;		// object whose event we caught

			// create an object that is used to identify the item
			// we do this so if someone creates multiple adapters for the
			// same logical object, we have all the commands associated 
			// with that object
			this.logicalInvoker = this.CreateLogicalInvoker(specificInvoker);

			// register the invoker key and adapter
			CommandAdapterManager.RegisterAdapter(this, this.logicalInvoker);
		}
		#endregion //AddInvoker

		#region BindCommand
		/// <summary>
		/// Informs the <see cref="CommandAdapter"/> that has been adapted to the <see cref="Command"/>.
		/// </summary>
		/// <param name="command">The <see cref="Command"/> to bind to.</param>
		public override void BindCommand(Command command)
		{
			// let the base class bind to the command
			base.BindCommand(command);

			// let the master list know that the adapter is associated with a command since it may affect the state of the associated elements
			CommandAdapterManager.NotifyCommandChanged(this, this.command, command);

			// store a reference to the command
			this.command = command;

			// let the derived class know since the element state
			// may need to be updated
			this.OnCommandChanged(command);
		}
		#endregion //BindCommand

		#region ContainsInvoker
		/// <summary>
		/// Indicates if the specified invoker is associated with the command adapter.
		/// </summary>
		/// <param name="invoker">Object to evaluate</param>
		/// <returns>True if the command adapter is associated with the specified invoker.</returns>
		public override bool ContainsInvoker(object invoker)
		{
			return invoker != null && this.invoker == invoker;
		}
		#endregion //ContainsInvoker

		#region Dispose
		/// <summary>
		/// Disposes the invoker.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.invoker != null)
					this.RemoveInvoker(this.invoker, this.eventName);
			}

			base.Dispose(disposing);
		}
		#endregion //Dispose

		#region InvokerCount
		/// <summary>
		/// Returns the number of invokers associated with the command adapter.
		/// </summary>
		public override int InvokerCount
		{
			get { return this.invoker == null ? 0 : 1; }
		}

		#endregion //InvokerCount

		#region OnCommandChanged
		/// <summary>
		/// Called when a binded <see cref="Command"/> fired the Changed event.
		/// </summary>
		/// <param name="command">The Command that fired the Changed event or null if the adapter is no longer associated with a command.</param>
		protected override void OnCommandChanged(Command command)
		{
			// ignore and let the static object manage this?
		}

		#endregion //OnCommandChanged

		#region RemoveInvoker
		/// <summary>
		/// Invoked to unhook an object from the command adapter.
		/// </summary>
		/// <param name="invoker">Object whose event will be unhooked</param>
		/// <param name="eventName">Name of the event to unhook</param>
		public override void RemoveInvoker(object invoker, string eventName)
		{
			Guard.ArgumentNotNull(invoker, "invoker");
			Guard.ArgumentNotNullOrEmptyString(eventName, "eventName");
			ThrowIfWrongType(invoker);

			// get the specific invoker
			TInvoker specificInvoker = (TInvoker)invoker;

			if (this.invoker != specificInvoker)
				throw new InvalidOperationException(Properties.Resources.DifferentInvoker);

			// unhook the event of the cached invoker
			this.UnhookEvent(this.eventSource, eventName);

			// unregister the invoker key & command adapter
			CommandAdapterManager.UnregisterAdapter(this, this.logicalInvoker);

			// release all references regarding the invoker and the events
			this.eventName = null;
			this.invoker = null;
			this.eventSource = null;
			this.logicalInvoker = null;
		}
		#endregion //RemoveInvoker

		#region UnbindCommand
		/// <summary>
		/// Informs the <see cref="CommandAdapter"/> that has been unbinded from the <see cref="Command"/>.
		/// </summary>
		/// <param name="command">The <see cref="Command"/> from with to unbind.</param>
		public override void UnbindCommand(Command command)
		{
			// let the base class unbind the command
			base.UnbindCommand(command);

			// let the master list know that the adapter is no longer associated with a command since it may affect the state of the associated elements
			CommandAdapterManager.NotifyCommandChanged(this, this.command, null);

			// release the reference to the command
			this.command = null;

			// let the derived class know since the element state
			// may need to be updated
			this.OnCommandChanged(null);
		}
		#endregion //UnbindCommand

		#endregion //Base class overrides

		#region Methods

		#region CreateLogicalInvoker

#if DEBUG
		/// <summary>
		/// Implemented by a derived command adapter to create an object used to identify any instance of the invoking item.
		/// </summary>
		/// <param name="invoker">Object for which the invoker key should be created.</param>
		/// <returns>An object that can be used as a key into a hashtable that can be used to compare to other instances of the invoker.</returns>
#endif
		internal abstract IUIElement CreateLogicalInvoker(TInvoker invoker);

		#endregion //CreateLogicalInvoker

		#region GetEventSource

#if DEBUG
		/// <summary>
		/// Returns the object whose event should be used to invoke the associated <see cref="Command"/>.
		/// </summary>
		/// <param name="invoker">Invoker being added to the command adapter.</param>
		/// <param name="eventName">Name of the event being caught</param>
		/// <returns>The object whose event is to be caught.</returns>
#endif
		internal abstract object GetEventSource(TInvoker invoker, string eventName);

		#endregion //GetEventSource

		#region Hook/Unhook Event
#if DEBUG
		/// <summary>
		/// Used to hook an event for use in invoking the adapter's ExecuteCommand event.
		/// </summary>
		/// <seealso cref="UnhookEvent"/>
#endif
		private void HookEvent(object eventSource, string eventName)
		{
			EventInfo eventInfo = eventSource.GetType().GetEvent(eventName);

			if (eventInfo == null)
				throw new InvalidOperationException(Properties.Resources.InvalidInvokerEvent);

			Delegate handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, this, typeof(CommandAdapterBase<TInvoker>).GetMethod("OnEventInvoked", BindingFlags.NonPublic | BindingFlags.Instance));
			eventInfo.AddEventHandler(eventSource, handler);
		}

#if DEBUG
		/// <summary>
		/// Used to unhook an event for use in invoking the adapter's ExecuteCommand event.
		/// </summary>
		/// <seealso cref="HookEvent"/>
#endif
		private void UnhookEvent(object eventSource, string eventName)
		{
			EventInfo eventInfo = eventSource.GetType().GetEvent(eventName);

			if (eventInfo == null)
				throw new InvalidOperationException(Properties.Resources.InvalidInvokerEvent);

			Delegate handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, this, typeof(CommandAdapterBase<TInvoker>).GetMethod("OnEventInvoked", BindingFlags.NonPublic | BindingFlags.Instance));
			eventInfo.RemoveEventHandler(eventSource, handler);
		}
		#endregion //Hook/Unhook Event

		#region OnEventInvoked

#if DEBUG
		/// <summary>
		/// Invoked when a method on the invoker has been raised.
		/// </summary>
		/// <param name="sender">Object whose event was raised</param>
		/// <param name="e">Event arguments for the raised event.</param>
#endif
		internal abstract void OnEventInvoked(object sender, EventArgs e);

		#endregion //OnEventInvoked

		#region OnInvokerStateChanged

		/// <summary>
		/// Invoked when the state of the associated invoker has been changed due to a command change.
		/// </summary>
		protected virtual void OnInvokerStateChanged()
		{
		}
		#endregion //OnInvokerStateChanged

		#region ThrowIfWrongType
		private void ThrowIfWrongType(object invoker)
		{
			if (typeof(TInvoker).IsAssignableFrom(invoker.GetType()) == false)
				throw new ArgumentException(string.Format(Properties.Resources.InvalidInvokerType, typeof(TInvoker)));
		}
		#endregion //ThrowIfWrongType

		#endregion //Methods

		#region IUIElement
		internal interface IUIElement
		{
			/// <summary>
			/// Invoked when the state of the associated element needs to be updated
			/// </summary>
			/// <param name="newStatus">New command state</param>
			void UpdateState(CommandStatus newStatus);
		} 
		#endregion //IUIElement

		#region CommandAdapterManager class
		/// <summary>
		/// Manages the state of 
		/// </summary>
		internal static class CommandAdapterManager
		{
			#region Member Variables

			// keeps a list of the adapters which represent a particular element
			private static Dictionary<IUIElement, List<CommandAdapterBase<TInvoker>>> adapters = new Dictionary<IUIElement, List<CommandAdapterBase<TInvoker>>>();

			// keeps a list of the adapters which represent a particular element
			private static Dictionary<CommandAdapterBase<TInvoker>, IUIElement> adapterKey = new Dictionary<CommandAdapterBase<TInvoker>, IUIElement>();

			// keep a list of the logical elements associated with a particular command
			private static Dictionary<Command, List<IUIElement>> cmdElements = new Dictionary<Command, List<IUIElement>>();

			// keep a list of the commands associated with a particular logical element
			private static Dictionary<IUIElement, List<Command>> elementCommands = new Dictionary<IUIElement, List<Command>>();

			#endregion //Member Variables

			#region RegisterAdapter
			internal static void RegisterAdapter(CommandAdapterBase<TInvoker> adapter, IUIElement key)
			{
				List<CommandAdapterBase<TInvoker>> invokers;

				// if this is the first time we've seen this key, create a list for the adapters
				if (adapters.TryGetValue(key, out invokers) == false)
				{
					invokers = new List<CommandAdapterBase<TInvoker>>();
					adapters.Add(key, invokers);
				}

				// store a reference to the adapter in the list
				invokers.Add(adapter);

				// also store the key using the adapter as the key
				adapterKey.Add(adapter, key);

				Command command = adapter.Command;

				if (null != command)
				{
					// add command and verify element state
					AddCommand(command, key);
				}

				// verify/update the state of the key
				VerifyCommandState(key);
			}
			#endregion //RegisterAdapter

			#region NotifyCommandChanged
			internal static void NotifyCommandChanged(CommandAdapterBase<TInvoker> adapter, Command oldCommand, Command newCommand)
			{
				IUIElement logicalElement;

				// we only need to worry about it if, the adapter has been associated with an invoker/element
				if (adapterKey.TryGetValue(adapter, out logicalElement))
				{
					if (null != oldCommand)
						RemoveCommand(oldCommand, logicalElement);

					if (null != newCommand)
						AddCommand(newCommand, logicalElement);

					VerifyCommandState(logicalElement);
				}
			}
			#endregion //NotifyCommandChanged

			#region Add/Remove Command
			private static void RemoveCommand(Command command, IUIElement element)
			{
				Debug.Assert(command != null, "Expected a valid command");
				Debug.Assert(element != null, "Expected a valid element");

				// MD 10/23/09 - TFS24083
				// This was implemented incorrectly. The dictionary's value is a list of elements. We should remove the 
				// event handler and dictionary entry when that list is empty.
				//if (cmdElements.ContainsKey(command))
				//	command.Changed -= new EventHandler(OnCommandChanged);
				List<IUIElement> elements;
				if ( cmdElements.TryGetValue( command, out elements ) )
				{
					elements.Remove( element );

					if ( elements.Count == 0 )
					{
						cmdElements.Remove( command );
						command.Changed -= new EventHandler( OnCommandChanged );
					}
				}
				else
					Debug.Fail("The specified command does not exist.");

				List<Command> commands;

				if (elementCommands.TryGetValue(element, out commands) == true)
				{
					commands.Remove(command);

					if (commands.Count == 0)
						elementCommands.Remove(element);
				}
				else
					Debug.Fail("The specified element does not exist in the command elements table.");
			}

			private static void AddCommand(Command command, IUIElement element)
			{
				Debug.Assert(command != null, "Expected a valid command");
				Debug.Assert(element != null, "Expected a valid element");

				List<IUIElement> elements;

				if (cmdElements.TryGetValue(command, out elements) == false)
				{
					command.Changed += new EventHandler(OnCommandChanged);
					elements = new List<IUIElement>();
					cmdElements.Add(command, elements);
				}

				elements.Add(element);

				List<Command> commands;

				if (elementCommands.TryGetValue(element, out commands) == false)
				{
					commands = new List<Command>();
					elementCommands.Add(element, commands);
				}

				commands.Add(command);
			}
			#endregion //Add/Remove Command

			#region OnCommandChanged
			private static void OnCommandChanged(object sender, EventArgs e)
			{
				Command command = sender as Command;

				List<IUIElement> elements;

				if (cmdElements.TryGetValue(command, out elements) == true)
				{
					for (int i = 0, len = elements.Count; i < len; i++)
					{
						IUIElement element = elements[i];
						VerifyCommandState(element);
					}
				}
			}
			#endregion //OnCommandChanged

			#region VerifyCommandState
			private static void VerifyCommandState(IUIElement logicalElement)
			{
				List<Command> commands;
				CommandStatus status = CommandStatus.Unavailable;
				Command commandWithStatus = null;

				// if we have commands associated with the element...
				if (elementCommands.TryGetValue(logicalElement, out commands))
				{
					for (int i = 0, len = commands.Count; i < len; i++)
					{
						Command cmd = commands[i];

						if (cmd.Status == CommandStatus.Disabled)
						{
							status = CommandStatus.Disabled;
							commandWithStatus = cmd;
						}
						else if (cmd.Status == CommandStatus.Enabled)
						{
							status = CommandStatus.Enabled;
							break;
						}
					}
				}

				logicalElement.UpdateState(status);

				// invoke a method on the command adapters so
				// derived command adapters can react to the change
				List<CommandAdapterBase<TInvoker>> cmdAdapters;

				if (adapters.TryGetValue(logicalElement, out cmdAdapters))
				{
					for (int i = 0, len = cmdAdapters.Count; i < len; i++)
					{
						CommandAdapterBase<TInvoker> cmdAdapter = cmdAdapters[i];

						cmdAdapter.OnInvokerStateChanged();
					}
				}
			}
			#endregion //VerifyCommandState

			#region UnregisterAdapter
			internal static void UnregisterAdapter(CommandAdapterBase<TInvoker> adapter, IUIElement key)
			{
				List<CommandAdapterBase<TInvoker>> invokers;

				if (adapters.TryGetValue(key, out invokers) == false)
					throw new InvalidOperationException(Properties.Resources.UnrecognizedAdapterKey);

				Debug.Assert(invokers.Contains(adapter), "The specified adapter is not associated with the specified key.");

				// if this is the last invoker...
				if (invokers.Count == 1)
				{
					if (invokers[0] != adapter)
						throw new InvalidOperationException(Properties.Resources.InvalidAdapterForKey);

					// remove the key as well
					adapters.Remove(key);
				}
				else
					invokers.Remove(adapter);

				// remove the dictionary which relates the adapter to the key
				adapterKey.Remove(adapter);

				Command command = adapter.Command;

				if (null != command)
				{
					// add command and verify element state
					RemoveCommand(command, key);

					// verify/update the state of the key
					VerifyCommandState(key);
				}
			}
			#endregion //UnregisterAdapter
		} 
		#endregion //CommandAdapterManager class
	}
}