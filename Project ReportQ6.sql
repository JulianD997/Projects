SELECT  Sum(Hours_worked.Hours) AS HoursWorkedOnProject, MAX(Projects.ProjectName) AS ProjectName , Employee.Name
FROM Projects
INNER JOIN Hours_worked ON Projects.ProjectID = Hours_worked.ProjectID 
INNER JOIN Employee ON Employee.EmployeeID = Hours_worked.EmployeeID
Group By Employee.Name
