USE [LVBackEnd]
GO

INSERT INTO [System].[CodeType]([Code], [DisplayAs], [Sequence]) VALUES
	('LeaveType', N'Leave type', 1),
	('LevelType', N'Level type', 2);

INSERT INTO [System].[Code]([ParentId], [CodeType], [Value], [DisplayAs], [Sequence]) VALUES
	(NULL, 'LeaveType', N'LT01', N'Annual leave', 1),
	(NULL, 'LeaveType', N'LT02', N'Annual sick leave', 2),
	(NULL, 'LeaveType', N'LT03', N'Annual family leave', 3);