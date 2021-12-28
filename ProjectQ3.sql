CREATE VIEW Projects_Working_on_Current AS
SELECT Projects.ProjectName, Hours_worked.PayDate, Departments.DepartName
From Projects
INNER JOIN Hours_worked ON Projects.ProjectID = Hours_worked.ProjectID
INNER JOIN Departments ON Departments.DepartmentID = Projects.DepartmentID
WHERE PayDate = '2020-02-28';