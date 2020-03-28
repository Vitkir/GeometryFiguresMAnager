using Cherevko.GeometryFiguresManager.Common.Entities.Contracts;
using System;
using System.Drawing;

namespace Cherevko.GeometryFiguresManager.Common.Entities.Figures
{
	//todo names, angles
	public class Triangle : IAreal
	{
		private double angle;
		private double firstSide;
		private double secondSide;

		public int Id { get; set; }

		public Point BasicPoint { get; set; }

		public double Angle
		{
			get => angle;
			set
			{
				angle = value > 0 && value < 180 ? value : throw new ArgumentException();
			}
		}

		public double FirstSide
		{
			get => firstSide;
			set
			{
				firstSide = value > 0 ? value : throw new ArgumentException();
			}
		}

		public double SecondSide
		{
			get => secondSide;
			set
			{
				secondSide = value > 0 ? value : throw new ArgumentException();
			}
		}

		public double ThirdSide
		{
			get => Math.Sqrt(Math.Pow(FirstSide, 2) + Math.Pow(SecondSide, 2) - 2 * FirstSide * SecondSide * Math.Cos(Angle));
		}

		public double Perimeter
		{
			get => FirstSide + SecondSide + ThirdSide;
		}

		public double Area
		{
			get
			{
				var halfPer = Perimeter / 2;
				return Math.Sqrt(halfPer * (halfPer - FirstSide) * (halfPer - SecondSide) * (halfPer - ThirdSide));
			}
		}

		public Triangle(Point basicPoint,
			double angle,
			double firstSide,
			double secondSide)
		{
			BasicPoint = basicPoint;
			Angle = angle;
			FirstSide = firstSide;
			SecondSide = secondSide;
		}

		public override string ToString()
		{
			var newLine = Environment.NewLine;
			return $"BasicPoint:{BasicPoint}{newLine}" +
				$"Angle:{Angle}{newLine}" +
				$"FirstSide:{FirstSide}{newLine}" +
				$"SecondSide:{SecondSide}{newLine}" +
				$"ThirdSide:{ThirdSide}{newLine}" +
				$"Perimeter:{Perimeter}{newLine}" +
				$"Area:{Area}{newLine}";
		}
	}
}
