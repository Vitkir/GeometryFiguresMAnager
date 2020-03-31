﻿using Cherevko.GeometryFiguresManager.Common.Entities.Contracts;
using System.Collections.Generic;

namespace Cherevko.GeometryFiguresManager.BLL.Contract
{
	public interface ILogic
	{
		IFigure Create(IFigure figure);

		void Update(IFigure figure);

		void Delete(int id);

		IEnumerable<IFigure> GetAll();
	}
}