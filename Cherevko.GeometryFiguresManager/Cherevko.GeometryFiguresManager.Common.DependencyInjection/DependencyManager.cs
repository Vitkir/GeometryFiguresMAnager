using Cherevko.GeometryFiguresManager.BLL.Contract;
using Cherevko.GeometryFiguresManager.BLL.Kernel;
using Cherevko.GeometryFiguresManager.DAL.Contract;
using Cherevko.GeometryFiguresManager.DAL.MSSQL;
using Ninject.Modules;
using System.Configuration;

namespace Cherevko.GeometryFiguresManager.Common.DependencyInjection
{
	public class DependencyManager : NinjectModule
	{
		private readonly string connectionString = ConfigurationManager.ConnectionStrings["MSSQLDB"].ConnectionString;
		public override void Load()
		{
			Bind<IFigureDao>().To<FigureDao>().WithConstructorArgument("connectionString", connectionString);
			Bind<ICache>().To<Cache>();
			Bind<ILogic>().To<FigureLogic>();
		}
	}
}
