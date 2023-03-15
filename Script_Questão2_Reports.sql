-- CREATE TABLE

CREATE TABLE Funcionarios(
  ID integer primary key,
  FirstName varchar(60),
  LastName varchar(60),
  ReportsTo varchar(60),
  Position varchar(60),
  Age integer
  );

-- INSERT TABLE

 INSERT INTO Funcionarios VALUES
(1, 'Daniel', 'Smith'   , 'Bob Boss'     ,'Engineer'  , 25),
(2, 'Mike'  , 'White'   , 'Bob Boss'     ,'Contractor', 22),
(3, 'Jenny' , 'Richards', null           ,'CEO'       , 45),
(4, 'Robert', 'Black'   ,'Daniel Smith'  ,'Sales'     , 22),
(5, 'Noah'  , 'Fritz'   ,'Jenny Richards','Assistant' , 30),
(6, 'David' , 'S'       ,'Jenny Richards','Director'  , 32),
(7, 'Ashley', 'Wells'   ,'David S'       ,'Assistant' , 25),
(8, 'Ashley', 'Johnson' , null           ,'Intern'    , 25);

--Consultas

--1 - Retornar os nome das pessoas que são reportadas (excluindo valores nulos)
--    número de membros e a idade média ordenada pelos nomes
SELECT
 ReportsTo as Reportados,
 COUNT(ID) as Membros,
 ROUND(AVG(Age), 0) as Idade_Media
FROM Funcionarios
 WHERE ReportsTo IS NOT NULL
 GROUP BY
   ReportsTo
 ORDER BY ReportsTo

 --Select da tabela
SELECT * FROM Funcionarios