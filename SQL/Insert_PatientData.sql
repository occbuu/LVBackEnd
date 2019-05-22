USE [LVBackEnd]
GO

INSERT INTO [Luan].[PatientData]
           ([Age]
           ,[Sex]
           ,[Symptons]
           ,[OriginalHealth]
           ,[BloodPressure]
           ,[BloodPressureP]
           ,[BloodPressureN]
           ,[Temperature]
           ,[BloodVessel]
           ,[nDays]
           ,[ResultDisease1]
           ,[ResultDisease2]
           ,[Status]
           ,[CreatedBy]
           ,[CreatedOn])
SELECT 
	(Year(Getdate()) - [NamSinh]) as 'Tuoi',
	GioiTinh,
	TrieuChung,
	[TienSu],
	HA,
	HAP,
	HAN,
	NhietDo,
	Mach,
	SoNgay,
	BenhChinh,
	BenhPhu,
	1,1,GETDATE()
from [Luan].[BenhAn]
GO


