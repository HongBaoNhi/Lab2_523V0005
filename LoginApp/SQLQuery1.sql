CREATE DATABASE Lab2DB;
GO
USE Lab2DB;

CREATE TABLE tblUsers (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50),
    Password NVARCHAR(50)
);

INSERT INTO tblUsers VALUES ('user1', 'password1');
INSERT INTO tblUsers VALUES ('user2', 'password2');

CREATE TABLE tblStudents (
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    StudentName NVARCHAR(100),
    Age INT
);

INSERT INTO tblStudents (StudentName, Age)
VALUES ('A',20), ('B',21);

CREATE TABLE tblCourses (
    CourseID INT PRIMARY KEY IDENTITY(1,1),
    CourseName NVARCHAR(100),
    Credits INT
);

INSERT INTO tblCourses (CourseName, Credits)
VALUES ('Math', 3), ('Physics', 4);

CREATE TABLE tblInstructors (
    InstructorID INT PRIMARY KEY IDENTITY(1,1),
    InstructorName NVARCHAR(100)
);

CREATE TABLE tblDepartments (
    DepartmentID INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName NVARCHAR(100)
);

CREATE TABLE tblStudentCourses (
    StudentID INT,
    CourseID INT
);
GO
CREATE PROCEDURE GetCourses
AS
BEGIN
    SELECT CourseID, CourseName FROM tblCourses;
END;
GO