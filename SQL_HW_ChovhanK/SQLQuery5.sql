CREATE DATABASE univer;
GO

USE univer;

CREATE TABLE Students
(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Age INT NOT NULL,
ExamCount INT DEFAULT 0
);

CREATE TABLE Subjects
(
Id INT PRIMARY KEY IDENTITY,
SubjectName NVARCHAR(50) NOT NULL
);

CREATE TABLE Exams
(
Id INT IDENTITY PRIMARY KEY,
StudentId INT NOT NULL REFERENCES Students(Id) ON DELETE CASCADE,
SubjectId INT NOT NULL REFERENCES Subjects(Id) ON DELETE CASCADE,
ExamDay DATE NOT NULL,
ExamCount INT DEFAULT 1
);