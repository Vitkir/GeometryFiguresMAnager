using Cherevko.GeometryFiguresManager.Common.Entities.Figures;
using System;

namespace Cherevko.GeometryFiguresManager.Common.Entities.Contracts
{
	public static class IFigureExtension
	{
		public static FigureTypes GetFigureType(this IFigure figure)
		{
			switch (figure)
			{
				case Round round:
					return FigureTypes.Round;
				case Circle circle:
					return FigureTypes.Circle;
				case Square square:
					return FigureTypes.Square;
				case Rectangle rectangle:
					return FigureTypes.Rectangle;
				case Triangle triangle:
					return FigureTypes.Triangle;
				case RegularPolygon polygon:
					return FigureTypes.RegularPoligon;
			}

			throw new InvalidCastException("IFigure doesn't contain such type");
		}
	}
}
