CREATE VIEW This_Year_Projects AS
SELECT Projects.ProjectName, Departments.DepartName, Hours_worked.PayDate
From Projects
INNER JOIN Hours_worked ON Projects.ProjectID = Hours_worked.ProjectID
INNER JOIN Departments ON Departments.DepartmentID = Projects.DepartmentID
WHERE PayDate BETWEEN '2020-01-01' AND '2020-02-28';