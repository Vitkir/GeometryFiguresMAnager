using Cherevko.GeometryFiguresManager.Common.Entities.Contracts;
using System;
using System.Drawing;

namespace Cherevko.GeometryFiguresManager.Common.Entities.Figures
{
	public class Rectangle : IAreal
	{
		private double height;
		private double width;

		public int Id { get; set; }

		public Point BasicPoint { get; set; }

		public double Height
		{
			get => height;
			set
			{
				height = value > 0 ? value : throw new ArgumentException();
			}
		}

		public double Width
		{
			get => width;
			set
			{
				width = value > 0 ? value : throw new ArgumentException();
			}
		}

		public double Perimeter
		{
			get => 2 * (Height + Width);

		}

		public double Area
		{
			get => Height * Width;
		}

		public Rectangle(Point point, double height, double width)
		{
			BasicPoint = point;
			Height = height;
			Width = width;
		}

		public override string ToString()
		{
			var newLine = Environment.NewLine;
			return $"BasicPoint:{BasicPoint}{newLine}" +
				$"Height:{Height}{newLine}" +
				$"Width:{Width}{newLine}" +
				$"Perimeter:{Perimeter}{newLine}" +
				$"Area:{Area}{newLine}";
		}
	}
}
