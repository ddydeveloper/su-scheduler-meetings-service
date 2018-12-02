CREATE TABLE [dbo].[Meetings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(0,1), 
    [Name] NVARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(500) NULL, 
    [Created] DATETIME NOT NULL DEFAULT (GETDATE()), 
    [CreatedBy] INT NOT NULL, 
	[CompanyId] INT NOT NULL,
    [StartDate] DATETIME NULL, 
    [StartTimeMinutes] SMALLINT NOT NULL, 
    [DurationMinutes] INT NOT NULL, 
    [Days] NVARCHAR(15) NULL, 
    [Active] BIT NOT NULL DEFAULT(1)
)
