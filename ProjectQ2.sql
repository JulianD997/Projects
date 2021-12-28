CREATE VIEW Employees_Without_Dependents AS
SELECT Employee.Name, Employee.EmployeeID, Dependents.DependentName
FROM Dependents
INNER JOIN Employee ON Employee.EmployeeID = Dependents.EmployeeID
WHERE DependentName IS NULL;