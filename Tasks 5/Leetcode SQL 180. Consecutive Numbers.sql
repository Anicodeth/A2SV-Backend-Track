SELECT DISTINCT t1.num as ConsecutiveNums
FROM Logs t1
JOIN Logs t2 ON t1.num = t2.num
JOIN Logs t3 ON t1.num = t3.num
WHERE t1.id = t2.id - 1
  AND t2.id = t3.id - 1;
