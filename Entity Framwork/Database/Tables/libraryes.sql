create table libraryes(
Roll_no int PRIMARY KEY IDENTITY(1,1),
name nvarchar(50) NULL,
student_id int NULL,
FOREIGN KEY (student_id) REFERENCES class(student_id)
);