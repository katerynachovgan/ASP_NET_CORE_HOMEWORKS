USE univer;

SELECT Subjects.SubjectName, Exams.ExamDay, Exams.ExamCount, Students.FirstName, Students.LastName 
FROM Exams
JOIN Subjects ON Subjects.Id = Exams.SubjectId
JOIN Students ON Students.Id = Exams.StudentId