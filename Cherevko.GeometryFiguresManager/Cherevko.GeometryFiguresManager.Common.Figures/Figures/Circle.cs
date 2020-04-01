using Cherevko.GeometryFiguresManager.Common.Entities.Contracts;
using System;
using System.Drawing;

namespace Cherevko.GeometryFiguresManager.Common.Entities.Figures
{
	public class Circle : IFigure
	{
		private double radius;

		public int Id { get; set; }

		public Point BasicPoint { get; set; }

		public double Radius
		{
			get => radius;
			set
			{
				radius = value > 0 ? value : throw new ArgumentException("radius cannot be negative");
			}
		}

		public double Perimeter
		{
			get => Math.PI * Radius * 2;
		}

		public FigureTypes Type { get; }

		public Circle(Point basicPoint, double radius) :
			this(basicPoint, radius, FigureTypes.Circle)
		{
		}

		protected Circle(Point basicPoint, double radius, FigureTypes type)
		{
			BasicPoint = basicPoint;
			Radius = radius;
			Type = type;
		}

		public override string ToString()
		{
			var newLine = Environment.NewLine;
			var id = Id > 0 ? $"Id: {Id}{newLine}" : "";
			return id +
				$"BasicPoint:{BasicPoint}{newLine}" +
				$"Radius:{Radius}{newLine}" +
				$"Perimeter:{Perimeter}{newLine}";
		}

		public object Clone()
		{
			return new Circle(BasicPoint, Radius)
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
