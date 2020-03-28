﻿using System.Drawing;

namespace Cherevko.GeometryFiguresManager.Common.Entities.Contracts
{
	public interface IFigure : IIndexed
	{
		Point BasicPoint { get; set; }

		double Perimeter { get; }
	}
}
