using Cherevko.GeometryFiguresManager.Common.Entities.Contracts;
using System;
using System.Drawing;

namespace Cherevko.GeometryFiguresManager.Common.Entities.Figures
{
	public class RegularPolygon : IAreal
	{
		private int sideCount;
		private double inradius;

		public int Id { get; set; }

		public Point BasicPoint { get; set; }

		public int SideCount
		{
			get => sideCount;
			set
			{
				sideCount = value > 0 ? value : throw new ArgumentException();
			}
		}

		public double Inradius
		{
			get => inradius;
			set
			{
				inradius = value > 0 ? value : throw new ArgumentException();
			}
		}

		public double InnerAngle
		{
			get => (SideCount - 2) / SideCount * 180;
		}

		public double SideLength
		{
			get => Inradius * (2 * Math.Tan(Math.PI / SideCount));
		}

		public double LongRadius
		{
			get => InnerAngle / (2 * Math.Sin(Math.PI / SideCount));
		}

		public double Perimeter
		{
			get => SideCount * SideLength;
		}

		public double Area
		{
			get => Perimeter / 2 * Inradius;
		}

		public FigureTypes Type => FigureTypes.RegularPoligon;

		public RegularPolygon(Point basicPoint, int sideCount, double inradius)
		{
			BasicPoint = basicPoint;
			SideCount = sideCount;
			Inradius = inradius;
		}

		public override string ToString()
		{
			var newLine = Environment.NewLine;
			return $"BasicPoint:{BasicPoint}{newLine}" +
				$"Inradius:{Inradius}{newLine}" +
				$"SideCount:{SideCount}{newLine}" +
				$"SideLength:{SideLength}{newLine}" +
				$"LongRadius:{LongRadius}{newLine}" +
				$"Perimeter:{Perimeter}{newLine}" +
				$"Area:{Area}{newLine}";
		}

		public object Clone()
		{
			return new RegularPolygon(BasicPoint, SideCount, Inradius)
			{
				Id = Id
			};
		}
	}
}
