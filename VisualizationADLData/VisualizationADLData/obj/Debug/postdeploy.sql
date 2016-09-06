﻿/*
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
MERGE INTO Course AS Target 
USING (VALUES 
        (1, 'Economics', 3), 
        (2, 'Literature', 3), 
        (3, 'Chemistry', 4)
) 
AS Source (CourseID, Title, Credits) 
ON Target.CourseID = Source.CourseID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (Title, Credits) 
VALUES (Title, Credits);


MERGE INTO Student AS Target
USING (VALUES 
        (1, 'Tibbetts', 'Donnie', '2013-09-01'), 
        (2, 'Guzman', 'Liza', '2012-01-13'), 
	(3, 'Catlett', 'Phil', '2011-09-03')
)
AS Source (StudentID, LastName, FirstName, EnrollmentDate)
ON Target.StudentID = Source.StudentID
WHEN NOT MATCHED BY TARGET THEN
INSERT (LastName, FirstName, EnrollmentDate)
VALUES (LastName, FirstName, EnrollmentDate);


MERGE INTO Enrollment AS Target
USING (VALUES 
	(1, 2.00, 1, 1),
	(2, 3.50, 1, 2),
	(3, 4.00, 2, 3),
	(4, 1.80, 2, 1),
	(5, 3.20, 3, 1),
	(6, 4.00, 3, 2)
)
AS Source (EnrollmentID, Grade, CourseID, StudentID)
ON Target.EnrollmentID = Source.EnrollmentID
WHEN NOT MATCHED BY TARGET THEN
INSERT (Grade, CourseID, StudentID)
VALUES (Grade, CourseID, StudentID);


MERGE INTO Alert AS Target
USING (VALUES
		(1, 'This is a test alert', '2016-08-09', '2016-09-09', 1, '2016-08-10')
)
AS Source (AlertId, AlertMessage, CreateDate, ExpirationDate, Accepted, AcceptedDate)
ON Target.AlertId = Source.AlertId
WHEN NOT MATCHED BY TARGET THEN
INSERT (AlertMessage, CreateDate, ExpirationDate, Accepted, AcceptedDate)
VALUES (AlertMessage, CreateDate, ExpirationDate, Accepted, AcceptedDate);




MERGE INTO Activity AS Target
USING (VALUES
		(1, 'Chatting', 1, 2, '2016-08-09', 'Chat with Friend'),
		(2, 'Eating', 1, 2,'2016-08-10', 'Eating with Family'),
		(3, 'Chatting', 1, 2,'2016-08-11', 'Chat with Friend'),
		(4, 'Eating',1, 2, '2016-08-11', 'Eating with Family'),
		(5, 'Sleeping',1, 2, '2016-08-11', 'Sleep in the bed'),
		(6, 'Eating', 1, 2,'2016-08-11', 'Eating with Family'),
		(7, 'Eating', 12, 12,'2016-08-11', 'Eating with Family'),
		(8, 'Chatting', 42.0308, -93.6319,'2016-08-14', 'Chat with Friend')

)
AS Source (ActivityID, ActivityName, Latitude, Longitude, ActivityTime, ActivityDescription)
ON Target.ActivityID = Source.ActivityID
WHEN NOT MATCHED BY TARGET THEN
INSERT (ActivityName, Latitude, Longitude, ActivityTime, ActivityDescription)
VALUES (ActivityName, Latitude, Longitude, ActivityTime, ActivityDescription);



GO
