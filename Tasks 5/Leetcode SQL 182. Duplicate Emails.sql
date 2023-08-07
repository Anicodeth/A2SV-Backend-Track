SELECT Email FROM 
    (
      SELECT Email, COUNT(Email) AS num 
      FROM Person
      GROUP BY Email  
    ) AS Email
WHERE num > 1;
