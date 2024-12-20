CREATE DATABASE Generation;
USE Generation;

CREATE TABLE PaginaDiario(id INT PRIMARY KEY IDENTITY(1,1),
dataGiorno DATETIME,
coordinataX FLOAT,
coordinataY FLOAT,
luogo VARCHAR(200),
descrizione VARCHAR(MAX));