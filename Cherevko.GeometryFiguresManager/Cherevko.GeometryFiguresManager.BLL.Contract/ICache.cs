using Cherevko.GeometryFiguresManager.Common.Entities.Contracts;
using System.Collections.Generic;

namespace Cherevko.GeometryFiguresManager.BLL.Contract
{
	public interface ICache
	{
		IFigure Add(IFigure figure);

		void Remove(int id);

		void Update(IFigure figure);

		IEnumerable<IFigure> GetAll();
	}
}
