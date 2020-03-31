using Cherevko.GeometryFiguresManager.BLL.Contract;
using Cherevko.GeometryFiguresManager.BLL.Kernel;
using Cherevko.GeometryFiguresManager.DAL.Contract;
using Cherevko.GeometryFiguresManager.DAL.MSSQL;
using Ninject.Modules;

namespace Cherevko.GeometryFiguresManager.Common.DependencyInjection
{
	public class DependencyManager : NinjectModule
	{
		public override void Load()
		{
			Bind<IFigureDao>().To<FigureDao>();
			Bind<ICache>().To<Cache>();
			Bind<ILogic>().To<FigureLogic>();
		}
	}
}
