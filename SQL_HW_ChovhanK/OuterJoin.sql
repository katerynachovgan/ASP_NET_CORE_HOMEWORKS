USE univer;

SELECT FirstName, LastName, Age, Students.ExamCount, ExamDay, SubjectId, Subjects.SubjectName
FROM  Exams 
LEFT JOIN Students ON Exams.StudentId = Students.Id
LEFT JOIN Subjects ON Exams.SubjectId = Subjects.Id


SELECT FirstName, LastName, Age, Students.ExamCount, ExamDay, SubjectId
FROM Students RIGHT JOIN Exams 
ON Exams.StudentId = Students.Id

SELECT *
FROM  Exams 
FULL JOIN Students ON Exams.StudentId = Students.Id
FULL JOIN Subjects ON Exams.SubjectId = Subjects.Id