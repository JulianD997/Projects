USE [master]
GO

/****** Object:  Database [Northwind] ******/
IF  DB_ID('CompanyDatabase') IS NOT NULL
DROP DATABASE CompanyDatabase;
GO

CREATE DATABASE [CompanyDatabase]
GO

---CREATE TABLES
USE CompanyDatabase
Go

-- Create Customer Table



CREATE TABLE Locations(
	[LocationID] [int] NOT NULL PRIMARY KEY,
	[Location] [varchar] (30) NOT NULL
)
GO

CREATE TABLE Departments(
	[DepartmentID] [int] NOT NULL PRIMARY KEY,
	[DepartName] [varchar](20) NOT NULL,
	[ManagerID] [int] NOT NULL ,
	[ManagerStartDate] [int] NULL
)
GO

CREATE TABLE Projects(
	[ProjectID] [int] NOT NULL PRIMARY KEY,
	[ProjectName] [varchar](50) NULL,
	[DepartmentID] [int] NOT NULL 
)
GO


CREATE TABLE Project_Location(
	[ProjectID] [int] NOT NULL PRIMARY KEY ,
	[LocationID] [int] NOT NULL 
)
GO

CREATE TABLE Employee(
	[EmployeeID] [int] NOT NULL PRIMARY KEY,
	[Name] [varchar](25) NOT NULL,
	[SSN] [int] NULL,
	[Address] [varchar](50) NULL,
	[Salary] [int] NULL,
	[Sex] [varchar](10) NULL,
	[DOB] [int] NULL,
	[SupervisorID] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL ,
)
GO

CREATE TABLE Employee_Projects(
	[WorkID] [int] NOT NULL PRIMARY KEY,
	[ProjectID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL
)
GO

CREATE TABLE Supervisors(
	[SupervisorID] [int] NOT NULL PRIMARY KEY,
	[SupervisorName] [varchar](30) NOT NULL,
)
GO

CREATE TABLE Dependents(
	[EmployeeID] [int] NOT NULL PRIMARY KEY,
	[DependentFirstName] [varchar](50) NULL,
	[Sex] [varchar](10) NULL,
	[DOB] [int] NULL,
	[Relationship] [varchar](15) NULL,
)
GO

CREATE TABLE Hours_worked(
	[EntryID] [int] NOT NULL PRIMARY KEY,
	[ProjectID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL ,
	[PayDate] [int] NOT NULL,
	[Hours] [int] NOT NULL
)
GO


insert into Departments(DepartmentID, DepartName, ManagerID, ManagerStartDate)
Values(100, 'Accessories', 10, 2014-01-01),
(200, 'Mowers', 20, 2016-09-10),
(300,'Tractors',70, 2019-07-10),
(400,'Washers',90, 2020-02-01),
(500,'Dryers',100, 2019-06-04)

Insert into Employee(EmployeeID, Name, SSN, Address, Salary, Sex, DOB, SupervisorID, DepartmentID)
Values(10, 'John Neal', NULL, NULL, NULL, NULL, NULL, 10, 100),
(20,'Ryan Michael', NULL, NULL, NULL, NULL, NULL, 20, 100),
(30,'Bennie Evans ', NULL, NULL, NULL, NULL, NULL, 10, 200),
(40,'Brett Owens', NULL, NULL, NULL, NULL, NULL, 10, 300),
(50,'Alvin Bush', NULL, NULL, NULL, NULL, NULL, 20, 300),
(60,'Jimmie Delgado', NULL, NULL, NULL, NULL, NULL, 20, 400),
(70,'Roland Myers', NULL, NULL, NULL, NULL, NULL, 20,400),
(80,'Trevor Figueroa', NULL, NULL, NULL, NULL, NULL, 30, 200),
(90,'Merle Clayton', NULL, NULL, NULL, NULL, NULL, 30, 500),
(100,'Gail Stone', NULL, NULL, NULL, NULL, NULL, 30, 500),
(110,'Cesar Flores', NULL, NULL, NULL, NULL, NULL, 20, 300),
(120,'Zachary Allen', NULL, NULL, NULL, NULL, NULL, 20, 200),
(130,'Heidi Gonzalez', NULL, NULL, NULL, NULL, NULL, 20, 300),
(140,'Wanda Weber', NULL, NULL, NULL, NULL, NULL, 20, 400),
(150,'Natalie Rice', NULL, NULL, NULL, NULL, NULL, 10, 100)

Insert into Project_Location(ProjectID, LocationID)
Values(1, 30818),
(2, 30819),
(3, 30811),
(4, 30810),
(5, 30812),
(6, 30807),
(7, 30817),
(8, 30816),
(9, 30809),
(10, 30813),
(11, 30814),
(12, 30815),
(13, 30799),
(14, 30798),
(15, 30797)

Insert into Projects(ProjectID, ProjectName, DepartmentID)
Values(1, NULL, 100),
(2, NULL, 100),
(3, NULL, 100),
(4, NULL, 200),
(5, NULL, 200),
(6, NULL, 200),
(7, NULL, 300),
(8, NULL, 300),
(9, NULL, 300),
(10, NULL, 400),
(11, NULL, 400),
(12, NULL, 500),
(13, NULL, 500),
(14, NULL, 400),
(15, NULL, 400)

Insert into Locations(LocationID, Location)
Values(30797, 'Atlanta'),
(30798,'Boston'),
(30799,'Miami'),
(30807,'Los Angeles'),
(30809,'San Diego'),
(30810,'New York City'),
(30811,'Philadelphia'),
(30812,'Dallas'),
(30813,'Seattle'),
(30814,'Washington'),
(30815,'Denver'),
(30816,'Houston'),
(30817,'Chicago'),
(30818,'Oakland'),
(30819,'Baltimore')

Insert into Employee_Projects(WorkID, ProjectID, EmployeeID)
Values(1, 1, 10),
(2, 1, 20),
(3, 1,100),
(4, 2, 30),
(5, 2, 40),
(6, 3, 10),
(7, 3, 150),
(8, 4, 60),
(9, 4, 90),
(10, 5, 130),
(11, 6, 30),
(12, 6, 50),
(13, 6, 70),
(14, 6, 100),
(15, 7, 150),
(16, 8, 140),
(17, 9, 130),
(18, 9, 140),
(19, 9, 150),
(20, 10, 20),
(21, 10, 50),
(22, 10, 80),
(23, 10, 120),
(24, 10, 150),
(25, 11, 60),
(26, 11, 130),
(27, 12, 80),
(28, 13, 150),
(29, 14, 50),
(30, 14, 80),
(31, 14, 120),
(32, 15, 140),
(33, 15, 150)


Insert into Supervisors(SupervisorID, SupervisorName)
Values(10, 'James McArthur'),
(20, 'Mary Firm'),
(30, 'Mike Johnson')

Insert into Dependents(EmployeeID, DependentFirstName, Sex, DOB, Relationship)
Values(10, 'Nancy Neal', 'Female', NULL, 'Wife'),
(20, NULL, NULL, NULL, NULL),
(30, 'Jason Evans', 'Male', NULL, 'Father'),
(40, 'Casey Owens', 'Male', NULL, 'Son'),
(50, 'Nichole Rutledge', 'Female', NULL, 'Stepmother'),
(60, 'Stephan Delgado', 'Male', NULL, 'Father'),
(70, 'Garrett Myers', 'Male', NULL, 'Brother'),
(80, 'Connie Figueroa', 'Female', NULL, 'Daughter'),
(90, NULL, NULL, NULL, NULL),
(100, 'Jamie Stone', 'Female', NULL, 'Mother'),
(110, 'Vernon Flores', 'Male', NULL, 'Husband'),
(120, 'Dolly Miles', 'Female', NULL, 'Girlfriend'),
(130, NULL, NULL, NULL, NULL),
(140, 'Jayden-Lee Weber', 'Male', NULL, 'Husband'),
(150, 'Rachel Rice', 'Female', NULL, 'Daughter')

Insert into Hours_worked(EntryID, ProjectID, EmployeeID, PayDate, Hours)
Values(1, 1, 10, 2020-02-07, 25),
(2, 1, 10, 2020-02-14, 35),
(3, 1, 20, 2020-02-07, 10),
(4, 1, 20, 2020-02-14, 29),
(5, 2, 20, 2020-02-07, 15),
(6, 2, 20, 2020-02-14, 15),
(7, 2, 30, 2020-02-07, 10),
(8, 2, 30, 2020-02-14, 5),
(9, 2, 30, 2020-02-21, 5),
(10, 2, 30, 2020-02-28, 5),
(11, 3, 40, 2020-02-07, 10),
(12, 3, 40, 2020-02-14, 15),
(13, 3, 40, 2020-02-21, 20),
(14, 3, 20, 2020-02-28, 25),
(15, 3, 20, 2020-01-03, 25),
(16, 3, 50, 2020-02-07, 10),
(17, 4, 50, 2020-02-14, 10),
(18, 4, 50, 2020-02-21, 15),
(19, 4, 50, 2020-02-28, 15),
(20, 4, 60, 2019-12-06, 20),
(21, 4, 60, 2019-12-13, 29),
(22, 5, 10, 2019-12-06, 25),
(23, 5, 10, 2019-12-13, 35),
(24, 5, 10, 2019-11-01, 10),
(25, 5, 20, 2019-11-08, 29),
(26, 5, 20, 2019-11-15, 15),
(27, 5, 20, 2020-02-07, 15),
(28, 5, 30, 2020-02-14, 10),
(29, 6, 30, 2020-02-07, 5),
(30, 6, 40, 2020-02-14, 5),
(31, 7, 50, 2020-02-07, 5),
(32, 7, 70, 2020-02-14, 10),
(33, 8, 70, 2020-02-07, 15),
(34, 8, 70, 2020-02-14, 20),
(35, 9, 80, 2020-02-07, 25),
(36, 9, 80, 2020-02-14, 25),
(37, 10, 80, 2020-02-07, 10),
(38, 11, 100, 2020-02-14, 10),
(39, 12, 100, 2020-02-07, 15),
(40, 13, 110, 2020-02-14, 15),
(41, 14, 110, 2019-12-06, 20),
(42, 15, 110, 2019-12-13, 29),
(43, 16, 120, 2019-12-06, 10),
(44, 16, 130, 2019-12-13, 15),
(45, 16, 140, 2019-11-01, 15),
(46, 16, 140, 2019-11-08, 20),
(47, 16, 130, 2019-11-15, 29)



Go