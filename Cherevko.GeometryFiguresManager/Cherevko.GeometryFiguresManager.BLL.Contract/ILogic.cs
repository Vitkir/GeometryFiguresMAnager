using Cherevko.GeometryFiguresManager.Common.Entities.Contracts;
using Cherevko.GeometryFiguresManager.Common.Entities.Figures;
using System.Collections.Generic;

namespace Cherevko.GeometryFiguresManager.BLL.Contract
{
	public interface ILogic
	{
		IFigure Create(IFigure figure);

		IFigure Update(IFigure figure);

		void Delete(int id);

		IEnumerable<IFigure> GetAll();

		bool ContainsFigure(int id, FigureTypes type);

		void RestoreCache();
	}
}