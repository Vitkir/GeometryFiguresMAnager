using System;
using System.Drawing;

namespace Cherevko.GeometryFiguresManager.Common.Entities.Contracts
{
	public interface IFigure : IIndexed, ICloneable
	{
		Point BasicPoint { get; set; }

		double Perimeter { get; }

		string Print();
	}
}
