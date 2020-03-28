using Cherevko.GeometryFiguresManager.Common.Entities.Contracts;
using System;
using System.Drawing;

namespace Cherevko.GeometryFiguresManager.Common.Entities.Figures
{
	public class Round : IFigure
	{
		private double radius;

		public int Id { get; set; }

		public Point BasicPoint { get; set; }

		public double Radius
		{
			get => radius;
			set
			{
				radius = value > 0 ? value : throw new ArgumentException();
			}
		}

		public double Perimeter
		{
			get => Math.PI * Radius * 2;
		}

		public Round(Point point, double radius)
		{
			BasicPoint = point;
			Radius = radius;
		}

		public override string ToString()
		{
			var newLine = Environment.NewLine;
			return $"BasicPoint:{BasicPoint}{newLine}" +
				$"Radius:{Radius}{newLine}" +
				$"Perimeter:{Perimeter}{newLine}";
		}
	}
}
