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
				height = value > 0 ? value : throw new ArgumentException("height cannot be negative");
			}
		}

		public double Width
		{
			get => width;
			set
			{
				width = value > 0 ? value : throw new ArgumentException("width cannot be negative");
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

		public FigureTypes Type => FigureTypes.Rectangle;

		public Rectangle(Point basicPoint, double height, double width)
		{
			BasicPoint = basicPoint;
			Height = height;
			Width = width;
		}

		public override string ToString()
		{
			var newLine = Environment.NewLine;
			var id = Id > 0 ? $"Id: {Id}{newLine}" : "";
			return id +
				$"BasicPoint:{BasicPoint}{newLine}" +
				$"Height:{Height}{newLine}" +
				$"Width:{Width}{newLine}" +
				$"Perimeter:{Perimeter}{newLine}" +
				$"Area:{Area}{newLine}";
		}

		public object Clone()
		{
			return new Rectangle(BasicPoint, Height, Width)
			{
				Id = Id
			};
		}

		public string Print()
		{
			return ToString();
		}
	}
}
