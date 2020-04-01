using Cherevko.GeometryFiguresManager.Common.Entities.Contracts;
using Cherevko.GeometryFiguresManager.Common.Entities.Figures;
using System.Collections.Generic;

namespace Cherevko.GeometryFiguresManager.BLL.Contract
{
	public interface ICache
	{
		IFigure Add(IFigure figure);

		void Remove(int id);

		IFigure Update(IFigure figure);

		IEnumerable<IFigure> GetAll();

		bool ContainsFigure(int id, FigureTypes type);

		void RestoreCache();
	}
}
