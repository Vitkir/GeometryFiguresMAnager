	use [GeometryFiguresDB]
	go

	create table [Points](
	[id] uniqueidentifier primary key,
	[basicPoint] geometry not null
	);
	
	create table [Rounds](
	[id] uniqueidentifier primary key,
	[basicPoint] geometry not null,
	[radius] float not null,
	[isCircle] bit not null,
	CONSTRAINT CK_Round_radius CHECK([radius]>0)
	);

	create table [Squares](
	[id] uniqueidentifier primary key,
	[basicPoint] geometry not null,
	[side] float not null,
	CONSTRAINT CK_Squares_wight CHECK([side]>0)
	);

	create table [Rectangle](
	[id] uniqueidentifier primary key,
	[basicPoint] geometry not null,
	[wight] float not null,
	[height] float not null,
	CONSTRAINT CK_Rectangle_wight CHECK([wight]>0),
	CONSTRAINT CK_Rectangle_height CHECK([height]>0)
	);

	create table [Triangle](
	[id] uniqueidentifier primary key,
	[basicPoint] geometry not null,
	[wight] float not null,
	[height] float not null,
	[angle] float not null,
	CONSTRAINT CK_Rectangle_wight CHECK([wight]>0),
	CONSTRAINT CK_Rectangle_height CHECK([height]>0),
	CONSTRAINT CK_Rectangle_angle CHECK([angle]>0 and [angle]<180)
	);