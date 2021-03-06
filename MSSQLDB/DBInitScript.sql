USE [master]
GO
/****** Object:  Database [GeometryFiguresDB]    Script Date: 02.04.2020 4:19:01 ******/
CREATE DATABASE [GeometryFiguresDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GeometryFiguresDB', FILENAME = N'C:\Users\Lenovo\GeometryFiguresDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GeometryFiguresDB_log', FILENAME = N'C:\Users\Lenovo\GeometryFiguresDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [GeometryFiguresDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GeometryFiguresDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GeometryFiguresDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GeometryFiguresDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GeometryFiguresDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GeometryFiguresDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GeometryFiguresDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [GeometryFiguresDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GeometryFiguresDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GeometryFiguresDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GeometryFiguresDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GeometryFiguresDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GeometryFiguresDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GeometryFiguresDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GeometryFiguresDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GeometryFiguresDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GeometryFiguresDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GeometryFiguresDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GeometryFiguresDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GeometryFiguresDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GeometryFiguresDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GeometryFiguresDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GeometryFiguresDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GeometryFiguresDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GeometryFiguresDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GeometryFiguresDB] SET  MULTI_USER 
GO
ALTER DATABASE [GeometryFiguresDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GeometryFiguresDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GeometryFiguresDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GeometryFiguresDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GeometryFiguresDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GeometryFiguresDB] SET QUERY_STORE = OFF
GO
USE [GeometryFiguresDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [GeometryFiguresDB]
GO
/****** Object:  UserDefinedTableType [dbo].[circleType]    Script Date: 02.04.2020 4:19:03 ******/
CREATE TYPE [dbo].[circleType] AS TABLE(
	[id] [int] NOT NULL,
	[radius] [float] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[figureType]    Script Date: 02.04.2020 4:19:03 ******/
CREATE TYPE [dbo].[figureType] AS TABLE(
	[id] [int] NULL,
	[basicPoint] [varchar](max) NULL,
	[type] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[intArray]    Script Date: 02.04.2020 4:19:03 ******/
CREATE TYPE [dbo].[intArray] AS TABLE(
	[value] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[rectangleType]    Script Date: 02.04.2020 4:19:03 ******/
CREATE TYPE [dbo].[rectangleType] AS TABLE(
	[id] [int] NOT NULL,
	[width] [float] NOT NULL,
	[height] [float] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[regularPolygonType]    Script Date: 02.04.2020 4:19:03 ******/
CREATE TYPE [dbo].[regularPolygonType] AS TABLE(
	[id] [int] NOT NULL,
	[sideCount] [int] NOT NULL,
	[inradius] [float] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[squareType]    Script Date: 02.04.2020 4:19:03 ******/
CREATE TYPE [dbo].[squareType] AS TABLE(
	[id] [int] NOT NULL,
	[side] [float] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  UserDefinedTableType [dbo].[triangleType]    Script Date: 02.04.2020 4:19:03 ******/
CREATE TYPE [dbo].[triangleType] AS TABLE(
	[id] [int] NOT NULL,
	[firstSide] [float] NOT NULL,
	[secondSide] [float] NOT NULL,
	[angle] [float] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Figures]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Figures](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[basicPoint] [geometry] NOT NULL,
	[type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Circles]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Circles](
	[id] [int] NOT NULL,
	[radius] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CircleView]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[CircleView] as
select 
[dbo].[Figures].[id],
[basicPoint],
[radius]
from [dbo].[Figures]
join [dbo].[Circles] on [dbo].[Figures].[id] = [dbo].[Circles].[id]
where [Figures].[type] = 2;
GO
/****** Object:  Table [dbo].[Squares]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Squares](
	[id] [int] NOT NULL,
	[side] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[SquareView]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[SquareView] as
select
[dbo].[Figures].[id],
[basicPoint],
[side]
from [dbo].[Figures]
join [dbo].[Squares] on [dbo].[Figures].[id] = [dbo].[Squares].[id]
where [Figures].[type] = 3;
GO
/****** Object:  Table [dbo].[Rectangles]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rectangles](
	[id] [int] NOT NULL,
	[width] [float] NOT NULL,
	[height] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[RectangleView]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[RectangleView] as
select
[dbo].[Figures].[id],
[basicPoint],
[width],
[height]
from [dbo].[Figures]
join [dbo].[Rectangles] on [dbo].[Figures].[id] = [dbo].[Rectangles].[id]
where [Figures].[type] = 4;
GO
/****** Object:  Table [dbo].[Triangles]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Triangles](
	[id] [int] NOT NULL,
	[firstSide] [float] NOT NULL,
	[secondSide] [float] NOT NULL,
	[angle] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[TriangleView]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[TriangleView] as
select
[dbo].[Figures].[id],
[basicPoint],
[firstSide],
[secondSide],
[angle]
from [dbo].[Figures]
join [dbo].[Triangles] on [dbo].[Figures].[id] = [dbo].[Triangles].[id]
where [Figures].[type] = 5;
GO
/****** Object:  Table [dbo].[RegularPolygons]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegularPolygons](
	[id] [int] NOT NULL,
	[sideCount] [int] NOT NULL,
	[inradius] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[RegularPolygonView]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[RegularPolygonView] as
select
[dbo].[Figures].[id],
[basicPoint],
[sideCount],
[inradius]
from [dbo].[Figures]
join [dbo].[RegularPolygons] on [dbo].[Figures].[id] = [dbo].[RegularPolygons].[id]
where [Figures].[type] = 6;
GO
/****** Object:  View [dbo].[RoundView]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create view [dbo].[RoundView] as
select 
[dbo].[Figures].[id],
[basicPoint],
[radius]
from [dbo].[Figures]
join [dbo].[Circles] on [dbo].[Figures].[id] = [dbo].[Circles].[id]
where [Figures].[type] = 1;
GO
/****** Object:  Table [dbo].[FigureTypes]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FigureTypes](
	[id] [int] NOT NULL,
	[type] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Circles]  WITH CHECK ADD  CONSTRAINT [FK__Circles__id__398D8EEE] FOREIGN KEY([id])
REFERENCES [dbo].[Figures] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Circles] CHECK CONSTRAINT [FK__Circles__id__398D8EEE]
GO
ALTER TABLE [dbo].[Figures]  WITH CHECK ADD FOREIGN KEY([type])
REFERENCES [dbo].[FigureTypes] ([id])
GO
ALTER TABLE [dbo].[Rectangles]  WITH CHECK ADD  CONSTRAINT [FK__Rectangles__id__412EB0B6] FOREIGN KEY([id])
REFERENCES [dbo].[Figures] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rectangles] CHECK CONSTRAINT [FK__Rectangles__id__412EB0B6]
GO
ALTER TABLE [dbo].[RegularPolygons]  WITH CHECK ADD  CONSTRAINT [FK__RegularPolygons__id__4BAC3F29] FOREIGN KEY([id])
REFERENCES [dbo].[Figures] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RegularPolygons] CHECK CONSTRAINT [FK__RegularPolygons__id__4BAC3F29]
GO
ALTER TABLE [dbo].[Squares]  WITH CHECK ADD  CONSTRAINT [FK__Squares__id__3D5E1FD2] FOREIGN KEY([id])
REFERENCES [dbo].[Figures] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Squares] CHECK CONSTRAINT [FK__Squares__id__3D5E1FD2]
GO
ALTER TABLE [dbo].[Triangles]  WITH CHECK ADD  CONSTRAINT [FK__Triangles__id__45F365D3] FOREIGN KEY([id])
REFERENCES [dbo].[Figures] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Triangles] CHECK CONSTRAINT [FK__Triangles__id__45F365D3]
GO
ALTER TABLE [dbo].[Circles]  WITH CHECK ADD  CONSTRAINT [CK_Circles_radius] CHECK  (([radius]>(0)))
GO
ALTER TABLE [dbo].[Circles] CHECK CONSTRAINT [CK_Circles_radius]
GO
ALTER TABLE [dbo].[Rectangles]  WITH CHECK ADD  CONSTRAINT [CK_Rectangles_height] CHECK  (([height]>(0)))
GO
ALTER TABLE [dbo].[Rectangles] CHECK CONSTRAINT [CK_Rectangles_height]
GO
ALTER TABLE [dbo].[Rectangles]  WITH CHECK ADD  CONSTRAINT [CK_Rectangles_width] CHECK  (([width]>(0)))
GO
ALTER TABLE [dbo].[Rectangles] CHECK CONSTRAINT [CK_Rectangles_width]
GO
ALTER TABLE [dbo].[RegularPolygons]  WITH CHECK ADD  CONSTRAINT [CK_RegularPolygons_inradius] CHECK  (([inradius]>(0)))
GO
ALTER TABLE [dbo].[RegularPolygons] CHECK CONSTRAINT [CK_RegularPolygons_inradius]
GO
ALTER TABLE [dbo].[RegularPolygons]  WITH CHECK ADD  CONSTRAINT [CK_RegularPolygons_sideCount] CHECK  (([sideCount]>(0)))
GO
ALTER TABLE [dbo].[RegularPolygons] CHECK CONSTRAINT [CK_RegularPolygons_sideCount]
GO
ALTER TABLE [dbo].[Squares]  WITH CHECK ADD  CONSTRAINT [CK_Squares_width] CHECK  (([side]>(0)))
GO
ALTER TABLE [dbo].[Squares] CHECK CONSTRAINT [CK_Squares_width]
GO
ALTER TABLE [dbo].[Triangles]  WITH CHECK ADD  CONSTRAINT [CK_Rectangles_angle] CHECK  (([angle]>(0) AND [angle]<(180)))
GO
ALTER TABLE [dbo].[Triangles] CHECK CONSTRAINT [CK_Rectangles_angle]
GO
ALTER TABLE [dbo].[Triangles]  WITH CHECK ADD  CONSTRAINT [CK_Rectangles_firstSide] CHECK  (([firstSide]>(0)))
GO
ALTER TABLE [dbo].[Triangles] CHECK CONSTRAINT [CK_Rectangles_firstSide]
GO
ALTER TABLE [dbo].[Triangles]  WITH CHECK ADD  CONSTRAINT [CK_Rectangles_secondSide] CHECK  (([secondSide]>(0)))
GO
ALTER TABLE [dbo].[Triangles] CHECK CONSTRAINT [CK_Rectangles_secondSide]
GO
/****** Object:  StoredProcedure [dbo].[CreateCircle]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CreateCircle] 
@basicPoint geometry,
@radius float,
@type int
as
declare 
@insertedId int;

insert into [dbo].[Figures]([basicPoint],[type])
values
	(@basicPoint, @type);
	set @insertedId = @@IDENTITY;

insert into [dbo].[Circles]([id],[radius])
values
	(@insertedId, @radius);

select * 
from [dbo].[CircleView]
where [id] = @insertedId;
GO
/****** Object:  StoredProcedure [dbo].[CreateRectangle]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[CreateRectangle] 
@basicPoint geometry,
@width float,
@height float
as
declare 
@insertedId int;

insert into [dbo].[Figures]([basicPoint],[type])
values
	(@basicPoint, 4);
	set @insertedId = @@IDENTITY;

insert into [dbo].[Rectangles]([id],[width],[height])
values
	(@insertedId, @width, @height);

select * 
from [dbo].[RectangleView]
where [id] = @insertedId;
GO
/****** Object:  StoredProcedure [dbo].[CreateRegularPolygon]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[CreateRegularPolygon]
@basicPoint geometry,
@sideCount int,
@inradius float
as
declare 
@insertedId int;

insert into [dbo].[Figures]([basicPoint],[type])
values
	(@basicPoint, 6);
	set @insertedId = @@IDENTITY;

insert into [dbo].[RegularPolygons]([id],[sideCount],[inradius])
values
	(@insertedId,@sidecount,@inradius);

select * 
from [dbo].[RegularPolygonView]
where [id] = @insertedId;
GO
/****** Object:  StoredProcedure [dbo].[CreateRound]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CreateRound] 
@basicPoint geometry,
@radius float,
@type int
as
declare 
@insertedId int;

insert into [dbo].[Figures]([basicPoint],[type])
values
	(@basicPoint, @type);
	set @insertedId = @@IDENTITY;

insert into [dbo].[Circles]([id],[radius])
values
	(@insertedId, @radius);

select * 
from [dbo].[RoundView]
where [id] = @insertedId;
GO
/****** Object:  StoredProcedure [dbo].[CreateSquare]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CreateSquare]
@basicPoint geometry,
@side float
as
declare 
@insertedId int;

insert into [dbo].[Figures]([basicPoint],[type])
values
	(@basicPoint, 3);
	set @insertedId = @@IDENTITY;

insert into [dbo].[Squares]([id], [side])
values
	(@insertedId, @side);

select * 
from [dbo].[SquareView]
where [id] = @insertedId;
GO
/****** Object:  StoredProcedure [dbo].[CreateTriangle]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[CreateTriangle] 
@basicPoint geometry,
@firstSide float,
@secondSide float,
@angle float
as
declare 
@insertedId int;

insert into [dbo].[Figures]([basicPoint],[type])
values
	(@basicPoint, 5);
	set @insertedId = @@IDENTITY;

insert into [dbo].[Triangles] ([id],[firstSide],[secondSide],[angle])
values
	(@insertedId, @firstSide,@secondSide,@angle);

select * 
from [dbo].[TriangleView]
where [id] = @insertedId;
GO
/****** Object:  StoredProcedure [dbo].[DeleteFigure]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DeleteFigure]
@deleteCache as [dbo].[intArray] readonly
as
delete [dbo].[Figures]
where [id] in (select [value] from @deleteCache);
GO
/****** Object:  StoredProcedure [dbo].[GetAll]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetAll] as
select * from [dbo].[CircleView];

select * from [dbo].[RoundView];

select * from [dbo].[SquareView];

select * from [dbo].[RectangleView];

select * from [dbo].[TriangleView];

select * from [dbo].[RegularPolygonView];
GO
/****** Object:  StoredProcedure [dbo].[UpdateFigures]    Script Date: 02.04.2020 4:19:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateFigures]
@common as [dbo].[figureType] readonly,
@circles as [dbo].[circleType] readonly,
@squares as [dbo].[squareType] readonly,
@rectangles as [dbo].[rectangleType] readonly,
@triangles as [dbo].[triangleType] readonly,
@regularPolygons as [dbo].[regularPolygonType] readonly
as
update [dbo].[Figures]
set 
	[basicPoint] =  geometry::STGeomFromText(c.[basicPoint],4326),
	[type] = c.[type]
from @common as c
where 
	[dbo].[Figures].[id] = c.[id];

update [dbo].[Circles]
set
	[radius] = c.[radius]
	from @circles as c
where 
	[dbo].[Circles].[id] = c.[id];

update [dbo].[Squares]
set
	[side] = c.[side]
from @squares as c
where 
	[dbo].[Squares].[id] = c.[id];

update [dbo].[Rectangles]
set
	[width] = c.[width],
	[height] = c.[height]
from @rectangles as c
where 
	[dbo].[Rectangles].[id] = c.[id];

update [dbo].[Triangles]
set
	[firstSide] = c.[firstSide],
	[secondSide] = c.[secondSide],
	[angle] = c.[angle]
from @triangles as c
where
	[dbo].[Triangles].[id] = c.[id];

update [dbo].[RegularPolygons]
set
	[sideCount] = c.[sideCount],
	[inradius] = c.[inradius]
from @regularPolygons as c
where
	[dbo].[RegularPolygons].[id] = c.[id];
GO
USE [master]
GO
ALTER DATABASE [GeometryFiguresDB] SET  READ_WRITE 
GO

USE [GeometryFiguresDB]
GO
insert into [FigureTypes]([id], [type])
values
	(1,N'Round'),
	(2,N'Circle'),
	(3,N'Square'),
	(4,N'Rectangle'),
	(5,N'Triangle'),
	(6,N'RegularPoligon');