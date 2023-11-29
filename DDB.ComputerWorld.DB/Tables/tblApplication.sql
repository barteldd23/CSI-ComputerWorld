CREATE TABLE [dbo].[tblApplication]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] varchar(50) not null,
	[Size] float not null,
	[ParentId] int not null
)
