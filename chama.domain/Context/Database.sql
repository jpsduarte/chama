USE chama;

DROP TABLE COURSE_STUDENT;
DROP TABLE COURSE;
DROP TABLE LECTURER;
DROP TABLE STUDENT;

CREATE TABLE LECTURER
(
	LecturerID int primary key identity (1,1),
	Name varchar(200) NOT NULL
)

create table COURSE
(
	CourseID int primary key identity (1,1),
	Name varchar(200) NOT NULL,
	Description varchar(200) NULL,
	MaxSeats int NOT NULL,
	LecturerID int NOT NULL,
	foreign key (LecturerID) references LECTURER(LecturerID)
)

CREATE TABLE STUDENT
(
	StudentID int primary key identity (1,1),
	Name varchar(200) NOT NULL,
	Age int NOT NULL
)

CREATE TABLE COURSE_STUDENT
(
	CourseID int NOT NULL, 
	StudentID int NOT NULL,
	primary key(CourseID, StudentID),
	foreign key (CourseID) references COURSE(CourseID),
	foreign key (StudentID) references STUDENT(StudentID)
)

INSERT INTO LECTURER values ('Rolanda Hooch');
INSERT INTO LECTURER values ('Rúbeo Hagrid');
INSERT INTO LECTURER values ('Sirius Black');
INSERT INTO LECTURER values ('Severo Snape');

INSERT INTO COURSE values ('Pyphon 3', NULL, 15, 1)
INSERT INTO COURSE values ('ASP.NET MVC', NULL, 10, 2)
INSERT INTO COURSE values ('Go', NULL, 5, 3)
INSERT INTO COURSE values ('Typescript', NULL, 2, 4)

INSERT INTO STUDENT values ('Harry Potter', 14);
INSERT INTO STUDENT values ('Draco Malfoy', 17);
INSERT INTO STUDENT values ('Hermione Granger', 16);

INSERT INTO COURSE_STUDENT values (1, 1);
INSERT INTO COURSE_STUDENT values (2, 2);
INSERT INTO COURSE_STUDENT values (3, 3);
INSERT INTO COURSE_STUDENT values (4, 1);
INSERT INTO COURSE_STUDENT values (3, 2);
INSERT INTO COURSE_STUDENT values (2, 3);
INSERT INTO COURSE_STUDENT values (1, 2);
