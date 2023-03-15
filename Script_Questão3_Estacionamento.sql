-- CREATE TABLES
CREATE TABLE Cliente(
  cpf INTEGER PRIMARY KEY,
  nome VARCHAR(60),
  dtNasc date);

CREATE TABLE Modelo(
  codMod INTEGER PRIMARY KEY,
  descricao VARCHAR(40));

CREATE TABLE Veiculo(
  placa VARCHAR(8) PRIMARY KEY,
  cor VARCHAR(20),
  fk_Modelo_CodMod INTEGER references Modelo,
  fk_Cliente_Cpf INTEGER references Cliente);

CREATE TABLE Patio(
  num INTEGER PRIMARY KEY,
  ender VARCHAR(40),
  capacidade INTEGER);

CREATE TABLE Estaciona(
  cod INTEGER PRIMARY KEY,
  dtEntrada VARCHAR(10),
  dtSaida VARCHAR(10),
  hsEntrada VARCHAR(10),
  hsSaida VARCHAR(10),
  fk_Patio_Num INTEGER references Patio,
  fk_Veiculo_Placa VARCHAR(8) references Veiculo);


-- INSERT TABLES  
INSERT INTO Cliente 
(cpf, nome, dtNasc)
VALUES
(06704895, 'Paulo Mattos'      , '1980/05/23'),
(45729164, 'Gabriel Cunha'     , '1995/01/14'),
(33037126, 'Laina Soares Paula', '2002/08/22'),
(76505847, 'Péricles Oliveira' , '1999/03/26'),
(84186354, 'Maria de Jesus'    , '1970/06/11'),
(28053429, 'Fábio Correa'      , '1975/09/10');

INSERT INTO Modelo 
(codMod, descricao)
VALUES
(1, 'Punto'),
(2, 'Corola'),
(3, 'HB20'),
(4, 'Palio'),
(5, 'Gol'),
(6, 'Opala');
  
INSERT INTO Veiculo 
(placa, cor, fk_Modelo_CodMod, fk_Cliente_Cpf)
VALUES
('OPQ-1111', 'prata'   , 1, 06704895),
('LMN-2222', 'vermelho', 2, 45729164),
('FGH-3333', 'amarelo' , 3, 33037126),
('DEF-4444', 'preto'   , 4, 76505847),
('BTG-2022', 'marrom'  , 5, 84186354),
('ABC-1111', 'azul'    , 6, 28053429);
  
INSERT INTO Patio 
(num, ender, capacidade)
VALUES
(1, 'Avenida das Torres', 50),
(2, 'Rua das Travessas' , 60),
(3, 'Avenida do Acre'   , 100),
(4, 'Rua das Palmeiras' , 200);

INSERT INTO Estaciona
(cod, dtEntrada, dtSaida, hsEntrada, hsSaida, fk_Patio_Num, fk_Veiculo_Placa)
VALUES
(1, '2023/01/01', '2023/01/01', '08:00', '18:00', 1, 'OPQ-1111'),
(2, '2023/04/05', '2023/04/05', '13:00', '13:20', 1, 'LMN-2222'),
(3, '2023/06/10', '2023/06/11', '12:00', '23:00', 2, 'FGH-3333'),
(4, '2023/07/15', '2023/07/16', '07:40', '16:10', 3, 'DEF-4444'),
(5, '2023/08/20', '2023/08/21', '10:10', '20:00', 3, 'BTG-2022'),
(6, '2023/09/25', '2023/09/25', '09:20', '21:00', 4, 'ABC-1111'),
(7, '2023/02/10', '2023/02/10', '08:30', '16:00', 2, 'BTG-2022');


--Consultas

--1 - Exiba a placa e o nome dos donos de todos os veículos
SELECT v.placa AS Placa, c.nome AS "Nome"
FROM cliente c inner join veiculo v
ON (c.cpf = v.fk_Cliente_cpf);

--2 - Exiba o endereço, a data de entrada e saída dos estacionamentos do veículo de placa "BTG-2022"
SELECT p.ender, e.dtEntrada, e.dtSaida
FROM estaciona e inner join patio p 
ON (p.num = e.fk_Patio_num)
where e.fk_Veiculo_placa like 'BTG-2022';


--Select das tabelas
select * from Cliente
select * from Modelo
select * from Veiculo
select * from Patio
select * from Estaciona

-- Delete das tabelas
delete from Estaciona
delete from Patio
delete from Veiculo
delete from Modelo
delete from Cliente

--Drop das tabelas
drop table Estaciona
drop table Patio
drop table Veiculo
drop table Modelo
drop table Cliente
