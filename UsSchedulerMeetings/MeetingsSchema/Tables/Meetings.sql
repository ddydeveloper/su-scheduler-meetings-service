CREATE TABLE [dbo].[Meetings]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(500) NULL, 
    [Created] DATETIME NOT NULL DEFAULT (SYSDATETIMEOFFSET()), 
    [CreatedBy] INT NOT NULL, 
    [StartDate] DATETIME NOT NULL, 
    [StartTime] NVARCHAR(50) NOT NULL, 
    [DurationMinutes] INT NOT NULL, 
    [Days] NVARCHAR(15) NULL, 
    [Active] BIT NOT NULL DEFAULT(1)
)
