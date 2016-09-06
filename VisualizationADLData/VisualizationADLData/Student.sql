CREATE TABLE [dbo].[Student]
(
	[StudentID] INT IDENTITY (1,1) NOT NULL,
	[LastName] NVARCHAR (50) NULL,
	[FirstName] NVARCHAR (50) NULL,
	[MiddleName] NVARCHAR (50) NULL,
	[EnrollmentDate] DATE NULL,
	PRIMARY KEY CLUSTERED ([StudentID] ASC)
)
