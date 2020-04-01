using Cherevko.GeometryFiguresManager.BLL.Contract;
using Cherevko.GeometryFiguresManager.Common.Entities.Contracts;
using Cherevko.GeometryFiguresManager.Common.Entities.Figures;
using System.Collections.Generic;

namespace Cherevko.GeometryFiguresManager.BLL.Kernel
{
	public class FigureLogic : ILogic
	{
		private readonly ICache cache;

		public FigureLogic(ICache cache)
		{
			this.cache = cache;
		}

		public IFigure Create(IFigure figure)
		{
			return cache.Add(figure);
		}

		public void Delete(int id)
		{
			cache.Remove(id);
		}

		public IEnumerable<IFigure> GetAll()
		{
			return cache.GetAll();
		}

		public IFigure Update(IFigure figure)
		{
			return cache.Update(figure);
		}
		public bool ContainsFigure(int id, FigureTypes type)
		{
			return cache.ContainsFigure(id, type);
		}

		public void RestoreCache()
		{
			cache.RestoreCache();
		}
	}
}
