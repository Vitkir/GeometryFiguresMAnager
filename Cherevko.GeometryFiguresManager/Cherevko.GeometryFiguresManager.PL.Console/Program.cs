using Cherevko.GeometryFiguresManager.Common.DependencyInjection;
using Cherevko.GeometryFiguresManager.Common.Entities.Figures;
using Ninject;
using System;
using Terminal = System.Console;

namespace Cherevko.GeometryFiguresManager.PL.Console
{
	class Program
	{
		private static IKernel kernel;
		private static ConsoleUI consoleUI;

		static void Main(string[] args)
		{
			kernel = new StandardKernel(new DependencyManager());
			consoleUI = kernel.Get<ConsoleUI>();
			MainMenu();
		}

		private static void MainMenu()
		{
			ConsoleKeyInfo input = default;
			Menu menu = default;
			do
			{
				try
				{
					ShowEnum(menu);
					input = ShowInputCommand("Select action :> ");
					menu = (Menu)ParseToDigit(input);
					switch (menu)
					{
						case Menu.Create:
							Create();
							break;
						case Menu.Delete:
							Delete();
							break;
						case Menu.GetAll:
							GetAll();
							break;
						case Menu.Update:
							Update();
							break;
						case Menu.RestoreCache:
							RestoreCache();
							break;
						case Menu.Exit:
							return;
					}
				}
				catch (Exception e)
				{
					Terminal.WriteLine(e.Message);
				}
			}
			while (input.Key != ConsoleKey.Escape);
		}

		private static void Create()
		{
			ConsoleKeyInfo input;
			FigureTypes type = default;
			do
			{
				ShowEnum(type);
				input = ShowInputCommand("Select figure :> ");
				if (Enum.IsDefined(typeof(Menu), ParseToDigit(input)))
				{
					type = (FigureTypes)ParseToDigit(input);
					consoleUI.Create(type);

					Terminal.WriteLine($"Saved");
					break;
				}
			}
			while (input.Key != ConsoleKey.Escape);

		}

		private static void Delete()
		{
			Terminal.WriteLine("Enter id");
			var input = InputInt();
			consoleUI.Delete(input);
		}

		private static void Update()
		{
			ConsoleKeyInfo input;
			FigureTypes type = default;
			do
			{
				ShowEnum(type);
				input = ShowInputCommand("Select figure :> ");
				if (Enum.IsDefined(typeof(Menu), ParseToDigit(input)))
				{
					type = (FigureTypes)ParseToDigit(input);

					consoleUI.Update(type);
					Terminal.WriteLine($"update");
					break;
				}
			}
			while (input.Key != ConsoleKey.Escape);

		}

		private static void GetAll()
		{
			consoleUI.GetAll();
		}

		private static void ShowEnum(Enum @enum)
		{
			var type = @enum.GetType();
			foreach (var name in Enum.GetNames(type))
			{
				Terminal.WriteLine($"{(int)Enum.Parse(type, name)}: {name}");
			}
		}

		private static void RestoreCache()
		{
			consoleUI.RestoreCache();
		}

		private static int ParseToDigit(ConsoleKeyInfo input)
		{
			int digit;
			int.TryParse(input.KeyChar.ToString(), out digit);
			return digit;
		}

		private static int InputInt()
		{
			int input;

			while (!int.TryParse(Terminal.ReadLine(), out input))
			{
				Terminal.WriteLine("Invalid input ");
			}
			return input;
		}

		private static ConsoleKeyInfo ShowInputCommand(string text)
		{
			ConsoleKeyInfo input;
			Terminal.Write(text);
			input = Terminal.ReadKey();
			Terminal.WriteLine();
			return input;
		}
	}
}
