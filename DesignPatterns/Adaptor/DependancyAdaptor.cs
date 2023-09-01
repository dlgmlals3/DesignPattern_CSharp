using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Csharp.DesignPatterns.Adaptor
{
	public interface ICommand
	{
		void Execute();
	}

	class SaveCommand : ICommand
	{
		public void Execute()
		{
			Console.WriteLine("Saving a File");
		}
	}

	class OpenCommand : ICommand
	{
		public void Execute()
		{
			Console.WriteLine("Opening a file");
		}
	}

	public class Button
	{
		public ICommand command;
		public Button(ICommand command)
		{
			Console.WriteLine("Button constructor : ");
			if (command == null)
			{
				throw new ArgumentNullException(paramName: nameof(command));
			}
			this.command = command;
		}
		public void Click()
		{
			command.Execute();
		}
	}

	public class Editor
	{
		private IEnumerable<Button> buttons;
		public Editor(IEnumerable<Button> buttons)
		{
			Console.WriteLine("Editor constructor : " + buttons.Count());
			if (buttons == null)
			{
				throw new ArgumentNullException(paramName: nameof(buttons));
			}
			this.buttons = buttons;
		}

		public void ClickAll()
		{
			foreach (var button in buttons)
			{
				button.Click();
			}
		}

		/// <summary>
		/// ContainerBuilder 사용법 익히자.!!!
		/// </summary>
		public static class DependancyAdaptor
		{
			public static void Test()
			{
				Console.WriteLine("\n DependancyAdaptor");
				var b = new ContainerBuilder();
				b.RegisterType<SaveCommand>().As<ICommand>();
				//b.RegisterType<OpenCommand>().As<ICommand>();
				b.RegisterType<Button>();
				b.RegisterType<Editor>();
				using (var c = b.Build())
				{
					var editor = c.Resolve<Editor>();
					editor.ClickAll();
				}
			}
		}
	}
}
