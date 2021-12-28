SELECT Dependents.DependentName, Employee.Name
FROM Dependents
INNER JOIN Employee ON Dependents.EmployeeID = Employee.EmployeeID
