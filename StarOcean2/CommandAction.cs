using System;
using System.Windows.Input;

namespace StarOcean2
{
	internal class CommandAction : ICommand
	{
#pragma warning disable CS0067
		// no use
		public event EventHandler? CanExecuteChanged;
#pragma warning restore CS0067
		private readonly Action<Object?> mAction;

		public CommandAction(Action<Object?> action) => mAction = action;
		public bool CanExecute(object? parameter) => true;
		public void Execute(object? parameter) => mAction(parameter);
	}
}
