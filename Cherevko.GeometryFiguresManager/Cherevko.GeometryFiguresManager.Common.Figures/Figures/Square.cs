﻿using Cherevko.GeometryFiguresManager.Common.Entities.Contracts;
using System;
using System.Drawing;

namespace Cherevko.GeometryFiguresManager.Common.Entities.Figures
{
	public class Square : IAreal
	{
		private double side;

		public int Id { get; set; }

		public Point BasicPoint { get; set; }

		public double Side
		{
			get => side;
			set
			{
				side = value > 0 ? value : throw new ArgumentException();
			}
		}

		public double Perimeter
		{
			get => Side * 4;
		}

		public double Area
		{
			get => Math.Pow(Side, 2);
		}

		public FigureTypes Type => FigureTypes.Square;

		public Square(Point basicPoint, double side)
		{
			BasicPoint = basicPoint;
			Side = side;
		}

		public override string ToString()
		{
			var newLine = Environment.NewLine;
			return $"BasicPoint:{BasicPoint}{newLine}" +
				$"Perimeter:{Perimeter}{newLine}" +
				$"Area:{Area}{newLine}";
		}

		public object Clone()
		{
			return new Square(BasicPoint, Side)
			{
				Id = Id
			};
		}
	}
}