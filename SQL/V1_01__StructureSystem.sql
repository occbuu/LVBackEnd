USE [master]
GO

IF EXISTS (SELECT * FROM SYSDATABASES WHERE NAME = 'LVBackEnd')
	DROP DATABASE [LVBackEnd]
CREATE DATABASE [LVBackEnd]
GO

USE [LVBackEnd]
GO

CREATE SCHEMA [System]
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'Setting')
	DROP TABLE [System].[Setting]
CREATE TABLE [System].[Setting]
(
	[Key]					VARCHAR(64) PRIMARY KEY,
	[Module]				VARCHAR(16),
	[DataType]				VARCHAR(32),
	[Description]			NTEXT,
	[Value]					NTEXT,
	[Status]				SMALLINT NULL DEFAULT 0,
	[CreatedBy]				INT,
	[CreatedOn]				DATETIME,
	[ModifiedBy]			INT,
	[ModifiedOn]			DATETIME
);

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'CodeType')
	DROP TABLE [System].[CodeType]
CREATE TABLE [System].[CodeType]
(
	[Code]					VARCHAR(64) PRIMARY KEY,
	[DisplayAs]				NTEXT,
	[Sequence]				INT,
	[Status]				SMALLINT NULL DEFAULT 0,
	[CreatedBy]				INT,
	[CreatedOn]				DATETIME,
	[ModifiedBy]			INT,
	[ModifiedOn]			DATETIME
);

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'Code')
	DROP TABLE [System].[Code]
CREATE TABLE [System].[Code]
(
	[Id]					INT IDENTITY(1, 1) PRIMARY KEY,
	[ParentId]				INT,
	[CodeType]				VARCHAR(64),
	[Value]					NVARCHAR(MAX),
	[DisplayAs]				NTEXT,
	[Sequence]				INT,
	[Status]				SMALLINT NULL DEFAULT 0,
	[CreatedBy]				INT,
	[CreatedOn]				DATETIME,
	[ModifiedBy]			INT,
	[ModifiedOn]			DATETIME
	CONSTRAINT FkCodeParent FOREIGN KEY ([ParentId]) REFERENCES [System].[Code]([Id]),
	CONSTRAINT FkCodeType FOREIGN KEY ([CodeType]) REFERENCES [System].[CodeType]([Code])
);

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'User')
	DROP TABLE [System].[User]
CREATE TABLE [System].[User]
(
	[Id]					INT IDENTITY(1, 1) PRIMARY KEY,
	[Pin]					VARCHAR(32),
	[Email]					VARCHAR(128),
	[UserName]				VARCHAR(64),
	[FirstName]				NVARCHAR(32),
	[LastName]				NVARCHAR(32),
	[Gender]				BIT,
	[Password]				VARCHAR(128),
	[Salt]					VARCHAR(64),
	[Pepper]				INT,
	[Joined]				SMALLDATETIME,
	[Birthday]				SMALLDATETIME,
	[Address]				NVARCHAR(MAX),
	[Pob]					NVARCHAR(128),
	[Note]					NVARCHAR(MAX),
	[Phone]					VARCHAR(32),
	[ReminderExpire]		DATETIME,
	[ReminderToken]			VARCHAR(128),
	[Status]				SMALLINT NULL DEFAULT 0,
	[CreatedBy]				INT,
	[CreatedOn]				DATETIME,
	[ModifiedBy]			INT,
	[ModifiedOn]			DATETIME
);

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'UserLog')
	DROP TABLE [System].[UserLog]
CREATE TABLE [System].[UserLog]
(
	[Id]					INT IDENTITY(1, 1) PRIMARY KEY,
	[UserId]				INT,
	[Action]				VARCHAR(MAX),
	[Objects]				VARCHAR(MAX),
	[ContentBefore]			NTEXT,
	[ContentAfter]			NTEXT,
	[Status]				SMALLINT NULL DEFAULT 0,
	[CreatedBy]				INT,
	[CreatedOn]				DATETIME,
	[ModifiedBy]			INT,
	[ModifiedOn]			DATETIME
	CONSTRAINT FkLogUser FOREIGN KEY ([UserId]) REFERENCES [System].[User]([Id])
);

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'Role')
	DROP TABLE [System].[Role]
CREATE TABLE [System].[Role]
(
	[Id]					INT IDENTITY(1,1) PRIMARY KEY,
	[Description]			NVARCHAR(512),
	[Status]				SMALLINT NULL DEFAULT 0,
	[CreatedBy]				INT,
	[CreatedOn]				DATETIME,
	[ModifiedBy]			INT,
	[ModifiedOn]			DATETIME
);

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'UserRole')
	DROP TABLE [System].[UserRole]
CREATE TABLE [System].[UserRole]
(
	[Id]					INT IDENTITY(1,1) PRIMARY KEY,
	[UserId]				INT,
	[RoleId]				INT,
	[Description]			NVARCHAR(512),
	[Status]				SMALLINT NULL DEFAULT 0,
	[CreatedBy]				INT,
	[CreatedOn]				DATETIME,
	[ModifiedBy]			INT,
	[ModifiedOn]			DATETIME
);

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'Function')
	DROP TABLE [System].[Function]
CREATE TABLE [System].[Function]
(
	[Id]					INT IDENTITY(1,1) PRIMARY KEY,
	[ParentId]				INT,
	[Code]					VARCHAR(64),
	[Description]			NVARCHAR(512),
	[Sequence]				INT,
	[Status]				SMALLINT NULL DEFAULT 0,
	[CreatedBy]				INT,
	[CreatedOn]				DATETIME,
	[ModifiedBy]			INT,
	[ModifiedOn]			DATETIME
);

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'FunctionRole')
	DROP TABLE [System].[FunctionRole]
CREATE TABLE [System].[FunctionRole]
(
	[Id]					INT IDENTITY(1,1) PRIMARY KEY,
	[FunctionId]			INT,
	[RoleId]				INT,
	[Description]			NVARCHAR(512),
	[Status]				SMALLINT NULL DEFAULT 0,
	[CreatedBy]				INT,
	[CreatedOn]				DATETIME,
	[ModifiedBy]			INT,
	[ModifiedOn]			DATETIME
);

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'Group')
	DROP TABLE [System].[Group]
CREATE TABLE [System].[Group]
(
	[Id]					INT IDENTITY(1,1) PRIMARY KEY,	
	[Level]					INT,
	[Pid]					INT,
	[InitialChar] 			NVARCHAR(32),
	[Description]			NVARCHAR(512),
	[Status]				SMALLINT NULL DEFAULT 0,
	[CreatedBy]				INT,
	[CreatedOn]				DATETIME,
	[ModifiedBy]			INT,
	[ModifiedOn]			DATETIME
);