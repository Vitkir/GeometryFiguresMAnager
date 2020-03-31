using Cherevko.GeometryFiguresManager.Common.Entities.Contracts;
using Cherevko.GeometryFiguresManager.Common.Entities.Figures;
using Cherevko.GeometryFiguresManager.DAL.Contract;
using Microsoft.SqlServer.Types;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using Rectangle = Cherevko.GeometryFiguresManager.Common.Entities.Figures.Rectangle;

namespace Cherevko.GeometryFiguresManager.DAL.MSSQL
{
	public class FigureDao : IFigureDao
	{
		private readonly string connectionString;

		public FigureDao(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public IFigure Create(IFigure figure)
		{
			switch (figure)
			{
				case Round round:
					return CreateCircle(round, FigureTypes.Round);
				case Circle circle:
					return CreateCircle(circle, FigureTypes.Circle);
				case Square square:
					return CreateSquare(square);
				case Rectangle rectangle:
					return CreateRectangle(rectangle);
				case Triangle triangle:
					return CreateTriangle(triangle);
				case RegularPolygon polygon:
					return CreateRegularPolygon(polygon);
			}

			return null;
		}

		public void Delete(IEnumerable<int> deleteCache)
		{
			var table = CreateFigureIdsTable(deleteCache);

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand("Delete");
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("deleteCache", table);

				connection.Open();
				command.ExecuteNonQuery();
			}
		}

		public Dictionary<int, IFigure> GetAll()
		{
			var result = new Dictionary<int, IFigure>();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand("GetAll");
				command.CommandType = CommandType.StoredProcedure;
				connection.Open();
				var reader = command.ExecuteReader();
				while (reader.Read())
				{
					var circle = ReadCircle(reader);
					result.Add(circle.Id, circle);
				}
				reader.NextResult();
				while (reader.Read())
				{
					var square = ReadSquare(reader);
					result.Add(square.Id, square);
				}
				reader.NextResult();
				while (reader.Read())
				{
					var rectangle = ReadRectangle(reader);
					result.Add(rectangle.Id, rectangle);
				}
				reader.NextResult();
				while (reader.Read())
				{
					var triangle = ReadTriangle(reader);
					result.Add(triangle.Id, triangle);
				}
				reader.NextResult();
				while (reader.Read())
				{
					var regularPolygon = ReadRegularPolygon(reader);
					result.Add(regularPolygon.Id, regularPolygon);
				}
			}

			return result;
		}

		public void Update(Dictionary<int, IFigure> figures)
		{
			var common = CreateCommonTable(figures);
			var circles = CreateCirclesTable(figures);
			var squqres = CreateSquaresTable(figures);
			var rectangles = CreateRectanglesTable(figures);
			var triangles = CreateTrianglesTable(figures);
			var regularPolygon = CreateRegularPolygonsTable(figures);

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand("Update");
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("common", common);
				command.Parameters.AddWithValue("circles", circles);
				command.Parameters.AddWithValue("squres", squqres);
				command.Parameters.AddWithValue("rectangles", rectangles);
				command.Parameters.AddWithValue("triangles", triangles);
				command.Parameters.AddWithValue("regularPolygons", regularPolygon);

				connection.Open();
				command.ExecuteNonQuery();
			}
		}

		private Circle CreateCircle(Circle circle, FigureTypes figures)
		{
			Circle result = default;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand("CreateCircle");
				command.CommandType = CommandType.StoredProcedure;
				var point = ToSqlGeometry(circle.BasicPoint);
				command.Parameters.AddWithValue("basicPoint", point);
				command.Parameters.AddWithValue("radius", circle.Radius);
				command.Parameters.AddWithValue("type", (int)figures);
				connection.Open();
				var reader = command.ExecuteReader();
				while (reader.Read())
				{
					result = ReadCircle(reader);
				}
			}

			return result;
		}

		private IFigure CreateSquare(Square square)
		{
			Square result = default;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand("CreateSquare");
				command.CommandType = CommandType.StoredProcedure;
				var point = ToSqlGeometry(square.BasicPoint);
				command.Parameters.AddWithValue("basicPoint", point);
				command.Parameters.AddWithValue("side", square.Side);
				connection.Open();
				var reader = command.ExecuteReader();
				while (reader.Read())
				{
					result = ReadSquare(reader);
				}
			}

			return result;
		}

		private IFigure CreateRectangle(Rectangle rectangle)
		{
			Rectangle result = default;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand("CreateRectangle");
				command.CommandType = CommandType.StoredProcedure;
				var point = ToSqlGeometry(rectangle.BasicPoint);
				command.Parameters.AddWithValue("basicPoint", point);
				command.Parameters.AddWithValue("width", rectangle.Width);
				command.Parameters.AddWithValue("height", rectangle.Height);
				connection.Open();
				var reader = command.ExecuteReader();
				while (reader.Read())
				{
					result = ReadRectangle(reader);
				}
			}

			return result;
		}

		private IFigure CreateTriangle(Triangle triangle)
		{
			Triangle result = default;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand("CreateTriangle");
				command.CommandType = CommandType.StoredProcedure;
				var point = ToSqlGeometry(triangle.BasicPoint);
				command.Parameters.AddWithValue("basicPoint", point);
				command.Parameters.AddWithValue("firstSide", triangle.FirstSide);
				command.Parameters.AddWithValue("secondSide", triangle.SecondSide);
				command.Parameters.AddWithValue("angle", triangle.Angle);
				connection.Open();
				var reader = command.ExecuteReader();
				while (reader.Read())
				{
					result = ReadTriangle(reader);
				}
			}

			return result;
		}

		private IFigure CreateRegularPolygon(RegularPolygon polygon)
		{
			RegularPolygon result = default;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand("CreateRegularPolygon");
				command.CommandType = CommandType.StoredProcedure;
				var point = ToSqlGeometry(polygon.BasicPoint);
				command.Parameters.AddWithValue("basicPoint", point);
				command.Parameters.AddWithValue("sideCount", polygon.SideCount);
				command.Parameters.AddWithValue("inradius", polygon.Inradius);
				connection.Open();
				var reader = command.ExecuteReader();
				while (reader.Read())
				{
					result = ReadRegularPolygon(reader);
				}
			}

			return result;
		}

		#region Get figures from reader

		private Circle ReadCircle(SqlDataReader reader)
		{
			Circle result;
			var basicPoint = ToPoint((SqlGeometry)reader["basicPoint"]);
			result = new Circle(basicPoint, (double)reader["radius"])
			{
				Id = (int)reader["id"]
			};
			return result;
		}

		private Square ReadSquare(SqlDataReader reader)
		{
			Square result;
			var basicPoint = ToPoint((SqlGeometry)reader["basicPoint"]);
			result = new Square(basicPoint, (double)reader["side"])
			{
				Id = (int)reader["id"]
			};
			return result;
		}

		private Rectangle ReadRectangle(SqlDataReader reader)
		{
			Rectangle result;
			var basicPoint = ToPoint((SqlGeometry)reader["basicPoint"]);
			result = new Rectangle(basicPoint,
				(double)reader["height"],
				(double)reader["width"])
			{
				Id = (int)reader["id"],
			};
			return result;
		}

		private Triangle ReadTriangle(SqlDataReader reader)
		{
			Triangle result;
			var basicPoint = ToPoint((SqlGeometry)reader["basicPoint"]);
			result = new Triangle(basicPoint,
				(double)reader["angle"],
				(double)reader["firstSide"],
				(double)reader["secondSide"])
			{
				Id = (int)reader["id"]
			};
			return result;
		}

		private RegularPolygon ReadRegularPolygon(SqlDataReader reader)
		{
			RegularPolygon result;
			var basicPoint = ToPoint((SqlGeometry)reader["basicPoint"]);
			result = new RegularPolygon(
				basicPoint,
				(int)reader["sideCount"],
				(double)reader["inradius"])
			{
				Id = (int)reader["id"]
			};
			return result;
		}

		#endregion

		#region Cast point

		private Point ToPoint(SqlGeometry point)
		{
			return new Point((int)point.STX, (int)point.STY);
		}

		private SqlGeometry ToSqlGeometry(Point point)
		{
			return SqlGeometry.Point(point.X, point.Y, 4326);
		}

		#endregion

		#region Tables creations

		private DataTable CreateCommonTable(Dictionary<int, IFigure> figures)
		{
			DataTable table = new DataTable("common");
			table.Columns.Add("id", typeof(int));
			table.Columns.Add("basicPoint", typeof(SqlGeometry));
			table.Columns.Add("type", typeof(int));

			foreach (var item in figures.Values)
			{
				table.Rows.Add(item.Id, item.BasicPoint, item.GetFigureType());
			}
			return table;
		}

		private DataTable CreateCirclesTable(Dictionary<int, IFigure> figures)
		{
			DataTable table = new DataTable();
			table.Columns.Add("id", typeof(int));
			table.Columns.Add("radius", typeof(double));

			foreach (var item in figures.Values.Where(e => e is Circle).Cast<Circle>())
			{
				table.Rows.Add(item.Id, item.Radius);
			}
			return table;
		}

		private DataTable CreateSquaresTable(Dictionary<int, IFigure> figures)
		{
			DataTable table = new DataTable();
			table.Columns.Add("id", typeof(int));
			table.Columns.Add("side", typeof(double));

			foreach (var item in figures.Values.Where(e => e is Square).Cast<Square>())
			{
				table.Rows.Add(item.Id, item.Side);
			}
			return table;
		}

		private DataTable CreateRectanglesTable(Dictionary<int, IFigure> figures)
		{
			DataTable table = new DataTable();
			table.Columns.Add("id", typeof(int));
			table.Columns.Add("width", typeof(double));
			table.Columns.Add("height", typeof(double));

			foreach (var item in figures.Values.Where(e => e is Rectangle).Cast<Rectangle>())
			{
				table.Rows.Add(item.Id, item.Width, item.Height);
			}
			return table;
		}

		private DataTable CreateTrianglesTable(Dictionary<int, IFigure> figures)
		{
			DataTable table = new DataTable();
			table.Columns.Add("id", typeof(int));
			table.Columns.Add("firstSide", typeof(double));
			table.Columns.Add("secondSide", typeof(double));
			table.Columns.Add("angle", typeof(double));

			foreach (var item in figures.Values.Where(e => e is Triangle).Cast<Triangle>())
			{
				table.Rows.Add(item.Id, item.FirstSide, item.SecondSide, item.Angle);
			}
			return table;
		}

		private DataTable CreateRegularPolygonsTable(Dictionary<int, IFigure> figures)
		{
			DataTable table = new DataTable();
			table.Columns.Add("id", typeof(int));
			table.Columns.Add("sideCount", typeof(int));
			table.Columns.Add("inradius", typeof(double));

			foreach (var item in figures.Values.Where(e => e is RegularPolygon).Cast<RegularPolygon>())
			{
				table.Rows.Add(item.Id, item.SideCount, item.Inradius);
			}
			return table;

		}

		private DataTable CreateFigureIdsTable(IEnumerable<int> figureIds)
		{
			DataTable table = new DataTable();
			table.Columns.Add("id", typeof(int));

			foreach (var item in figureIds)
			{
				table.Rows.Add(item);
			}

			return table;
		}

		#endregion
	}
}
