SELECT a.name as Employee
FROM Employee a, Employee b
WHERE a.managerId = b.id
AND a.salary > b.salary;
