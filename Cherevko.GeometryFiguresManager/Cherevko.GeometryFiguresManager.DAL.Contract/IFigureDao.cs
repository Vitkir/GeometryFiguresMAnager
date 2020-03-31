using Cherevko.GeometryFiguresManager.Common.Entities.Contracts;
using System.Collections.Generic;

namespace Cherevko.GeometryFiguresManager.DAL.Contract
{
	public interface IFigureDao
	{
		IFigure Create(IFigure figure);

		void Update(Dictionary<int, IFigure> figure);

		void Delete(IEnumerable<int> deleteCache);

		Dictionary<int, IFigure> GetAll();
	}
}
