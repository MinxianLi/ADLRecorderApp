CREATE TABLE [dbo].[Alert]
(
	[AlertId] INT IDENTITY(1,1) NOT NULL,
	[AlertMessage] NVARCHAR(50) NULL,
	[CreateDate] DATETIME NULL,
	[ExpirationDate] DATETIME NULL,
	[Accepted] INT NULL,
	[AcceptedDate] DATETIME NULL,
	PRIMARY KEY CLUSTERED ([AlertId] ASC)
)
