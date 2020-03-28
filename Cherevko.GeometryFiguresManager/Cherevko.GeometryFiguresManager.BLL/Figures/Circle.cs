using Cherevko.GeometryFiguresManager.Common.Entities.Contracts;
using System;
using System.Drawing;

namespace Cherevko.GeometryFiguresManager.Common.Entities.Figures
{
	public class Circle : Round, IAreal
	{
		public double Area
		{
			get => Math.PI * Math.Pow(Radius, 2);
		}


		public Circle(Point point, double radius) : base(point, radius)
		{
		}

		public override string ToString()
		{
			return base.ToString() + Environment.NewLine +
				$"{Area}";
		}
	}
}
