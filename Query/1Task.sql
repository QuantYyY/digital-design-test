SELECT e.NAME AS Имя, e.SALARY AS Зарплата
FROM employee e
JOIN (
	SELECT MAX(SALARY) AS max_salary
	FROM employee
) max_sal ON e.SALARY = max_sal.max_salary;
