CREATE VIEW Old_Projects AS
SELECT Departments.DepartName
From Projects
INNER JOIN Hours_worked ON Projects.ProjectID = Hours_worked.ProjectID
INNER JOIN Departments ON Departments.DepartmentID = Projects.DepartmentID
WHERE PayDate != '2020-02-28' AND DepartName NOT IN ('Accessories','Mowers');