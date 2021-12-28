SELECT Locations.Location, Departments.DepartName
FROM Departments
INNER JOIN Projects ON Projects.DepartmentID = Departments.DepartmentID
INNER JOIN Project_Location ON Project_Location.ProjectID = Projects.ProjectID
INNER JOIN Locations ON Locations.LocationID = Project_Location.LocationID
