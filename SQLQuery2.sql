SELECT  TOP 1 SUM(Hours_worked.Hours) TotalHoursWorked, Projects.ProjectName
FROM Hours_worked
INNER JOIN Projects ON Projects.ProjectID = Hours_worked.ProjectID
GROUP BY Projects.ProjectName
ORDER BY TotalHoursWorked DESC
