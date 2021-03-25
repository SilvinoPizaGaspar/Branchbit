CREATE DATABASE Branchbit

CREATE TABLE ProductoItalika
(
	SKU VARCHAR(50) PRIMARY KEY,
	Fert VARCHAR(50),
	Modelo VARCHAR(50),
	Tipo VARCHAR(50) CHECK(Tipo IN ('TRABAJO','DEPORTIVA','INFANTIL')),
	NumeroSerie VARCHAR(50),
	Fecha DATETIME
)

INSERT INTO ProductoItalika
VALUES
	('abcdef','qwerty','poñolik1234','TRABAJO','asdfghjklñ98765',GETDATE()),
	('ghijkl','asdef','ERT45678GHJ7','DEPORTIVA','ZXCVBNM12345678',GETDATE()),
	('MÑNOPQ','NINOM','RTYUlik1234','INFANTIL','yuio6789bnmb',GETDATE())

CREATE PROCEDURE ProductosGetAll
AS
SELECT
	SKU,
	Fert,
	Modelo,
	Tipo,
	NumeroSerie,
	Fecha
FROM
	ProductoItalika

CREATE PROCEDURE ProductosGetProductogetBySKU
	@SKU VARCHAR(50)
AS
SELECT
	SKU,
	Fert,
	Modelo,
	Tipo,
	NumeroSerie,
	Fecha
FROM
	ProductoItalika
WHERE 
	SKU =  @SKU



CREATE PROCEDURE ProductoAdd
	@SKU VARCHAR(50),
	@Fert VARCHAR(50),
	@Modelo VARCHAR(50),
	@Tipo VARCHAR(50),
	@NumeroSerie VARCHAR(50)
AS
INSERT INTO ProductoItalika
(
	SKU,
	Fert,
	Modelo,
	Tipo,
	NumeroSerie,
	Fecha
)
VALUES
(
	@SKU,
	@Fert,
	@Modelo,
	@Tipo,
	@NumeroSerie,
	GETDATE()
)

CREATE PROCEDURE ProductoUpdate
	@SKU VARCHAR(50),
	@Fert VARCHAR(50),
	@Modelo VARCHAR(50),
	@Tipo VARCHAR(50),
	@NumeroSerie VARCHAR(50)
AS
UPDATE ProductoItalika
SET
	SKU = @SKU,
	Fert = @Fert,
	Modelo = @Modelo,
	Tipo = @Tipo,
	NumeroSerie = @NumeroSerie,
	Fecha = GETDATE()
WHERE
	SKU = @SKU

CREATE PROCEDURE ProductoDelete
	@SKU VARCHAR(50)
AS
DELETE FROM ProductoItalika
WHERE
	SKU = @SKU