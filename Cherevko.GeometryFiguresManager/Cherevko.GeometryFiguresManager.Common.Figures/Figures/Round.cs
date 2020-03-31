using Cherevko.GeometryFiguresManager.Common.Entities.Contracts;
using System;
using System.Drawing;

namespace Cherevko.GeometryFiguresManager.Common.Entities.Figures
{
	public class Round : Circle, IAreal
	{
		public double Area
		{
			get => Math.PI * Math.Pow(Radius, 2);
		}


		public Round(Point basicPoint, double radius) : 
			base(basicPoint, radius, FigureTypes.Round)
		{
		}

		public override string ToString()
		{
			return base.ToString() + Environment.NewLine +
				$"{Area}";
		}
	}
}
