CREATE TABLE [dbo].[Activity]
(
	[ActivityID] INT IDENTITY(1,1) NOT NULL,
	[ActivityName] NVARCHAR (50) NULL,
	[Latitude] Decimal(9,6) NULL,
	[Longitude] Decimal(9,6) NULL,
	[ActivityTime] DATETIME NULL,
	[ActivityDescription] NVARCHAR(200) NULL,
	PRIMARY KEY CLUSTERED ([ActivityID] ASC)
)
