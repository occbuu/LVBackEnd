USE [LVBackEnd]
GO

CREATE SCHEMA [Luan]
GO

IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'Symptom')
	DROP TABLE [Luan].[Sympton]
CREATE TABLE [Luan].[Symptom]
(
	[Id]					INT IDENTITY(1, 1) PRIMARY KEY,	
	[Group]					NVARCHAR(100),
	[Name]					NVARCHAR(256),
	[Description]			NVARCHAR(MAX),
	[Status]				SMALLINT NULL DEFAULT 0,
	[CreatedBy]				INT,
	[CreatedOn]				DATETIME,
	[ModifiedBy]			INT,
	[ModifiedOn]			DATETIME
);

GO
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'Disease')
	DROP TABLE [Luan].[Disease]
CREATE TABLE [Luan].[Disease]
(
	[Id]					INT IDENTITY(1, 1) PRIMARY KEY,	
	[Code]					NVARCHAR(50),
	[Name]					NVARCHAR(256),
	[Chapter]				INT,
	[Description]			NVARCHAR(MAX),
	[Status]				SMALLINT NULL DEFAULT 0,
	[CreatedBy]				INT,
	[CreatedOn]				DATETIME,
	[ModifiedBy]			INT,
	[ModifiedOn]			DATETIME
);

GO
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'PatientData')
	DROP TABLE [Luan].[PatientData]
CREATE TABLE [Luan].[PatientData]
(
	[Id]					INT IDENTITY(1, 1) PRIMARY KEY,		
	[Age]					INT,
	[Sex]					BIT,
	[Symptons]				VARCHAR(MAX),
	[OriginalHealth]		NVARCHAR(256),
	[BloodPressureP]		INT,
	[BloodPressureN]		INT,
	[Temperature]			INT,
	[BloodVessel]			INT,
	[ResultDisease]			INT,
	[Status]				SMALLINT NULL DEFAULT 0,
	[CreatedBy]				INT,
	[CreatedOn]				DATETIME,
	[ModifiedBy]			INT,
	[ModifiedOn]			DATETIME
);

