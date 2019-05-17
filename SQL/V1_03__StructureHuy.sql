USE [LVBackEnd]
GO

CREATE SCHEMA [Huy]
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'HuyLog')
	DROP TABLE [Huy].[HuyLog]
CREATE TABLE [Huy].[HuyLog]
(
	[Id]					INT IDENTITY(1, 1) PRIMARY KEY,
	[Duration]				FLOAT,
	[Source]				VARCHAR(100),
	[Destination]			VARCHAR(256),
	[Protocol]				VARCHAR(100),	
	[Length]				INT,
	[Info]					TEXT,	
	[StampTime]				DATETIME
);