USE [Cemetery]
GO

CREATE TABLE Cemetery (
	Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(200) NOT NULL,
	[Address] NVARCHAR(200) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	[Year] INT NOT NULL,
	CountOfBurial INT NOT NULL
);
GO