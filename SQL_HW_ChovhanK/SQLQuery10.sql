USE [univer]
GO

INSERT INTO [dbo].[Exams]
           ([StudentId]
           ,[SubjectId]
		   ,[ExamDay]
		   ,[ExamCount]
           )
     VALUES (
           (SELECT Id FROM Students WHERE LastName='Shevchenko'),
           (SELECT Id FROM Subjects WHERE SubjectName='Math'),
		   '2021-09-30',
		   2
		   ),
		   (
		    (SELECT Id FROM Students WHERE LastName='Sashko'),
           (SELECT Id FROM Subjects WHERE SubjectName='Culture'),
		   '2021-10-04', 1
		   ),
		    (
		    (SELECT Id FROM Students WHERE LastName='Chovhan'),
           (SELECT Id FROM Subjects WHERE SubjectName='Natural'),
		   '2021-08-28',3
		   ),
		   (
		    (SELECT Id FROM Students WHERE LastName='Chovhan'),
           (SELECT Id FROM Subjects WHERE SubjectName='Germany'),
		   '2021-08-22', 6
		   ),
		     (
		    (SELECT Id FROM Students WHERE LastName='Litvinov'),
           (SELECT Id FROM Subjects WHERE SubjectName='Programming'),
		   '2021-09-01', 3
		   ),
		       (
		    (SELECT Id FROM Students WHERE LastName='Ivanova'),
           (SELECT Id FROM Subjects WHERE SubjectName='Literature'),
		   '2021-10-01', 5
		   ),
		       (
		    (SELECT Id FROM Students WHERE LastName='Petrova'),
           (SELECT Id FROM Subjects WHERE SubjectName='Programming'),
		   '2021-11-01', 3
		   ),
		       (
		    (SELECT Id FROM Students WHERE LastName='Zavalna'),
           (SELECT Id FROM Subjects WHERE SubjectName='Literature'),
		   '2021-08-27', 4
		   ),
		       (
		    (SELECT Id FROM Students WHERE LastName='Kobchyk'),
           (SELECT Id FROM Subjects WHERE SubjectName='Programming'),
		   '2021-09-05', 3
		   ),
		       (
		    (SELECT Id FROM Students WHERE LastName='Sashko'),
           (SELECT Id FROM Subjects WHERE SubjectName='English'),
		   '2021-10-02', 6
		   ),
		       (
		    (SELECT Id FROM Students WHERE LastName='Chovhan'),
           (SELECT Id FROM Subjects WHERE SubjectName='Ukrainian'),
		   '2021-09-10', 2
		   ),
		       (
		    (SELECT Id FROM Students WHERE LastName='Zavalna'),
           (SELECT Id FROM Subjects WHERE SubjectName='History'),
		   '2021-09-11', 3
		   ),
		       (
		    (SELECT Id FROM Students WHERE LastName='Petrova'),
           (SELECT Id FROM Subjects WHERE SubjectName='Phisics'),
		   '2021-09-15', 3
		   ),
		       (
		    (SELECT Id FROM Students WHERE LastName='Litvinov'),
           (SELECT Id FROM Subjects WHERE SubjectName='Chemistry'),
		   '2021-09-22', 5
		   ),
		       (
		    (SELECT Id FROM Students WHERE LastName='Kobchyk'),
           (SELECT Id FROM Subjects WHERE SubjectName='Geography'),
		   '2021-10-01', 2
		   )

GO


