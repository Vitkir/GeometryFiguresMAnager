using Cherevko.GeometryFiguresManager.BLL.Contract;
using Cherevko.GeometryFiguresManager.Common.Entities.Contracts;
using Cherevko.GeometryFiguresManager.DAL.Contract;
using System.Collections.Generic;
using System.Linq;

namespace Cherevko.GeometryFiguresManager.BLL.Kernel
{
	public class Cache : ICache
	{
		private readonly IFigureDao figureDao;
		private readonly Dictionary<int, IFigure> cache;
		private readonly List<int> deleteCache;

		public Cache(IFigureDao figureDao)
		{
			this.figureDao = figureDao;
			cache = new Dictionary<int, IFigure>();
			deleteCache = new List<int>();
		}

		public IFigure Add(IFigure figure)
		{
			var createdFigure = figureDao.Create(figure);
			cache.Add(createdFigure.Id, createdFigure);
			return (IFigure)createdFigure.Clone();
		}

		public IEnumerable<IFigure> GetAll()
		{
			return cache.Values.
				Select(e => (IFigure)e.Clone());
		}

		public void Remove(int id)
		{
			if (cache.ContainsKey(id))
			{
				deleteCache.Add(id);
				cache.Remove(id);
				return;
			}
			throw new KeyNotFoundException();
		}

		public void Update(IFigure figure)
		{
			cache[figure.Id] = figure;
		}

		public void RestoreCache()
		{
			figureDao.Update(cache);
			figureDao.Delete(deleteCache);

			deleteCache.Clear();
		}
	}
}
