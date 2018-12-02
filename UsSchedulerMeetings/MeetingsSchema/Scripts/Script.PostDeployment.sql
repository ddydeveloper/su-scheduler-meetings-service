/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF NOT EXISTS (SELECT TOP 1 Id FROM Meetings) 
BEGIN

	INSERT INTO Meetings([Name], [CreatedBy], [CompanyId], [StartDate], [StartTimeMinutes], [DurationMinutes], [Days])
			  SELECT N'Samsung customer meeting', 0, 0, DATEFROMPARTS(2018, 12, 10), 660, 60, NULL
	UNION ALL SELECT N'Samsung customer meeting', 0, 0, DATEFROMPARTS(2018, 12, 14), 840, 45, NULL
	UNION ALL SELECT N'Samsung customer meeting', 0, 0, DATEFROMPARTS(2018, 12, 16), 720, 60, NULL
	UNION ALL SELECT N'Samsung customer meeting', 0, 0, DATEFROMPARTS(2018, 12, 20), 615, 45, NULL  
	UNION ALL SELECT N'Samsung team Daily SU', 0, 0, NULL, 585, 15, N'1,2,3,4,5'

	UNION ALL SELECT N'Xaomi customer meeting', 8, 1, DATEFROMPARTS(2018, 12, 10), 660, 60, NULL
	UNION ALL SELECT N'Xaomi tech talks', 8, 1, DATEFROMPARTS(2018, 12, 10), 810, 30, NULL
	UNION ALL SELECT N'Xaomi employee introduction', 8, 1, DATEFROMPARTS(2018, 12, 11), 960, 15, NULL
	UNION ALL SELECT N'Xaomi customer demo', 8, 1, DATEFROMPARTS(2018, 12, 12), 1020, 30, NULL  
	UNION ALL SELECT N'Xaomi team Daily SU', 8, 1, NULL, 585, 15, N'1,2,3,4,5'

	INSERT INTO Participants([MeetingId], [UserId])
			  SELECT 0, 0
	UNION ALL SELECT 0, 1
	UNION ALL SELECT 0, 2
	UNION ALL SELECT 0, 3
	UNION ALL SELECT 0, 7

	UNION ALL SELECT 1, 0
	UNION ALL SELECT 1, 1
	UNION ALL SELECT 1, 2
	UNION ALL SELECT 1, 3
	UNION ALL SELECT 1, 7

	UNION ALL SELECT 2, 0
	UNION ALL SELECT 2, 1
	UNION ALL SELECT 2, 2
	UNION ALL SELECT 2, 3
	UNION ALL SELECT 2, 4
	UNION ALL SELECT 2, 5
	UNION ALL SELECT 2, 6
	UNION ALL SELECT 2, 7

	UNION ALL SELECT 3, 0
	UNION ALL SELECT 3, 1
	UNION ALL SELECT 3, 2
	UNION ALL SELECT 3, 3
	UNION ALL SELECT 3, 4
	UNION ALL SELECT 3, 5
	UNION ALL SELECT 3, 6
	UNION ALL SELECT 3, 7

	UNION ALL SELECT 4, 0
	UNION ALL SELECT 4, 1
	UNION ALL SELECT 4, 2
	UNION ALL SELECT 4, 3
	UNION ALL SELECT 4, 4
	UNION ALL SELECT 4, 5
	UNION ALL SELECT 4, 6
	UNION ALL SELECT 4, 7

	UNION ALL SELECT 5, 8
	UNION ALL SELECT 5, 9
	UNION ALL SELECT 5, 10
	UNION ALL SELECT 5, 11
	UNION ALL SELECT 5, 12

	UNION ALL SELECT 6, 10
	UNION ALL SELECT 6, 11
	UNION ALL SELECT 6, 12

	UNION ALL SELECT 7, 8
	UNION ALL SELECT 7, 9
	UNION ALL SELECT 7, 12

	UNION ALL SELECT 8, 8
	UNION ALL SELECT 8, 9
	UNION ALL SELECT 8, 10
	UNION ALL SELECT 8, 11
	UNION ALL SELECT 8, 12

	UNION ALL SELECT 9, 8
	UNION ALL SELECT 9, 9
	UNION ALL SELECT 9, 10
	UNION ALL SELECT 9, 11
	UNION ALL SELECT 9, 12

END