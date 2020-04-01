using Cherevko.GeometryFiguresManager.BLL.Contract;
using Cherevko.GeometryFiguresManager.Common.Entities.Contracts;
using Cherevko.GeometryFiguresManager.Common.Entities.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using Rectangle = Cherevko.GeometryFiguresManager.Common.Entities.Figures.Rectangle;
using Terminal = System.Console;

namespace Cherevko.GeometryFiguresManager.PL.Console
{
	internal class ConsoleUI
	{
		private readonly ILogic logic;

		public ConsoleUI(ILogic logic)
		{
			this.logic = logic;
		}

		internal IFigure Create(FigureTypes type)
		{
			IFigure result = SelectType(type);

			if (result != null)
			{
				return logic.Create(result);
			}

			return result;
		}

		internal void Delete(int id)
		{
			logic.Delete(id);
		}

		internal IFigure Update(FigureTypes type)
		{
			int id = InputInt(nameof(id));

			if (!logic.ContainsFigure(id, type))
			{
				throw new ArgumentException("Such object doesn't exist");
			}

			IFigure result = SelectType(type);

			if (result == null)
			{
				throw new ArgumentNullException();
			}
			result.Id = id;
			return logic.Update(result);
		}

		internal void GetAll()
		{
			foreach (var item in logic.GetAll())
			{
				Terminal.WriteLine($"{item.GetFigureType()} {Environment.NewLine}" +
					$"{item} {Environment.NewLine}");
			}
		}

		internal void RestoreCache()
		{
			logic.RestoreCache();
		}

		#region creation methods

		private IFigure SelectType(FigureTypes type)
		{
			switch (type)
			{
				case FigureTypes.Round:
					return CreateRound();

				case FigureTypes.Circle:
					return CreateCircle();

				case FigureTypes.Square:
					return CreateSquare();

				case FigureTypes.Rectangle:
					return CreateRectangle();

				case FigureTypes.Triangle:
					return CreateTriangle();

				case FigureTypes.RegularPoligon:
					return CreateRegularPolygon();
			}

			return null;
		}

		private Circle CreateCircle()
		{
			var point = InputPoint();
			double radius = InputDouble(nameof(radius));

			var figure = new Circle(point, radius);
			return (Circle)ConfirmCreate(figure);
		}

		private Round CreateRound()
		{
			var point = InputPoint();
			double radius = InputDouble(nameof(radius));

			var figure = new Round(point, radius);
			return (Round)ConfirmCreate(figure);
		}

		private Square CreateSquare()
		{
			var point = InputPoint();
			double side = InputDouble(nameof(side));

			var figure = new Square(point, side);
			return (Square)ConfirmCreate(figure);
		}

		private Rectangle CreateRectangle()
		{
			var point = InputPoint();
			double width = InputDouble(nameof(width));
			double height = InputDouble(nameof(height));

			var figure = new Rectangle(point, height, width);
			return (Rectangle)ConfirmCreate(figure);
		}

		private Triangle CreateTriangle()
		{
			var point = InputPoint();
			double angle = InputDouble(nameof(angle));
			double firstSide = InputDouble(nameof(firstSide));
			double secondSide = InputDouble(nameof(secondSide));

			var figure = new Triangle(point, angle, secondSide, firstSide);
			return (Triangle)ConfirmCreate(figure);
		}

		private RegularPolygon CreateRegularPolygon()
		{
			var point = InputPoint();
			int sideCount = InputInt(nameof(sideCount));
			double inradius = InputDouble(nameof(inradius));

			var figure = new RegularPolygon(point, sideCount, inradius);
			return (RegularPolygon)ConfirmCreate(figure);
		}

		#endregion

		private Point InputPoint()
		{
			int x = InputInt(nameof(x));
			int y = InputInt(nameof(y));

			var point = new Point(x, y);
			Terminal.WriteLine($"Point {point}");
			return point;
		}

		private double InputDouble(string paramName)
		{
			double input;

			Terminal.WriteLine($"Enter {paramName}");
			while (!double.TryParse(Terminal.ReadLine(), out input))
			{
				Terminal.WriteLine("Invalid input ");
			}
			return input;
		}

		private int InputInt(string paramName)
		{
			int input;

			Terminal.WriteLine($"Enter {paramName}");
			while (!int.TryParse(Terminal.ReadLine(), out input))
			{
				Terminal.WriteLine("Invalid input ");
			}
			return input;
		}

		private bool ConfirmEnter()
		{
			ConsoleKey input;
			while (true)
			{
				Terminal.WriteLine("Continue [Y/N]");

				input = Terminal.ReadKey().Key;
				switch (input)
				{
					case ConsoleKey.Y:
						return true;
					case ConsoleKey.N:
						return false;
				}
			}
		}

		private IFigure ConfirmCreate(IFigure figure)
		{
			var type = figure.GetFigureType().ToString().ToLower();

			Terminal.WriteLine($"Create {type} {Environment.NewLine} {figure}");
			if (ConfirmEnter())
			{
				return figure;
			}
			return null;
		}
	}
}
