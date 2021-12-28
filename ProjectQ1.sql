CREATE VIEW Current_Projects AS
SELECT Projects.ProjectName, Hours_worked.PayDate
From Projects
INNER JOIN Hours_worked ON Projects.ProjectID = Hours_worked.ProjectID
WHERE PayDate = '2020-02-28';