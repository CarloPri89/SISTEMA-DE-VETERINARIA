CREATE DATABASE VETERINARIA
GO

USE VETERINARIA

CREATE TABLE VENTAS
(
ID_VENTAS VARCHAR(20) PRIMARY KEY NOT NULL,
ID_EMP VARCHAR(50) NOT NULL,
ID_PRO VARCHAR(50) NOT NULL,
TIPO_PRODUCTO VARCHAR(50) NOT NULL,
CANTIDAD VARCHAR(100) NOT NULL,
PRECIO_SOLES MONEY NOT NULL,
HORA_VENTA DATETIME 
FOREIGN KEY(ID_EMP) REFERENCES EMPLEADO (ID_EMP),
FOREIGN KEY(ID_PRO) REFERENCES PRODUCTO (ID_PRO)
)

CREATE TABLE PRODUCTO
(
ID_PRO VARCHAR(50) PRIMARY KEY NOT NULL,
TIPO_PRODUCTO_REGISTRADO VARCHAR(70) NOT NULL,
CANTIDAD CHAR (1000) NOT NULL,
PRECIO MONEY,
FECHA_REGISTRO DATETIME
)

CREATE TABLE EMPLEADO
(
ID_EMP VARCHAR(50) PRIMARY KEY NOT NULL,
NOM_EMP VARCHAR(25) NOT NULL,
APELLIDOS VARCHAR(50) NOT NULL,
SEXO VARCHAR(30) NOT NULL,
DNI VARCHAR(30) NOT NULL,
DIRECCION VARCHAR(50) NOT NULL,
TELEFONO VARCHAR(30) NOT NULL,
EMAIL VARCHAR(50) NOT NULL,
TURNO VARCHAR(20) NOT NULL,
FECHA_CONTRATA DATETIME
) 

CREATE TABLE SERVICIO
( 
ID_SERV VARCHAR(40) PRIMARY KEY NOT NULL,
ID_EMP VARCHAR(50) NOT NULL,
ID_CLI VARCHAR(70) NOT NULL,
ID_MASC VARCHAR(20) NOT NULL,
TIPO_SERV VARCHAR(50) NOT NULL,
PRECIO_SERV MONEY,
FECHA_REGISTRO DATETIME
FOREIGN KEY (ID_EMP) REFERENCES EMPLEADO (ID_EMP),
FOREIGN KEY (ID_CLI) REFERENCES CLIENTE (ID_CLI),
FOREIGN KEY (ID_MASC) REFERENCES MASCOTA (ID_MASC)
)

CREATE TABLE CLIENTE
(
ID_CLI VARCHAR(70) PRIMARY KEY NOT NULL,
NOM_CLI VARCHAR(30) NOT NULL, 
APE_CLI VARCHAR(50) NOT NULL,
DNI VARCHAR(30) NOT NULL,
SEXO VARCHAR(50) NOT NULL,
DIRECCION VARCHAR(50) NOT NULL,
TELEFONO VARCHAR (50) NOT NULL
) 

CREATE TABLE MASCOTA
(
 ID_MASC VARCHAR(20) PRIMARY KEY NOT NULL,
 NOM_MASC VARCHAR(50) NOT NULL,
 ESPECIE VARCHAR(50) NOT NULL, 
 RAZA VARCHAR(40) NOT NULL,
 SEXO VARCHAR(1) NOT NULL
) 

--INGRESAR DATOS A LA TABLA PRODUCTOS
INSERT INTO PRODUCTO VALUES ('P001','Ricocan Adulto de todas las razas - 15kg','10','80',GETDATE());
INSERT INTO PRODUCTO VALUES ('P002','Shampoo de Aloe Vera','20','27',GETDATE());
INSERT INTO PRODUCTO VALUES ('P003','Collar para perro','20','10',GETDATE());
INSERT INTO PRODUCTO VALUES ('P004','Bozal','10','10',GETDATE());
INSERT INTO PRODUCTO VALUES ('P005','Pechera','15','20',GETDATE());
INSERT INTO PRODUCTO VALUES ('P006','Comedero con antideslizante','30','10',GETDATE());
INSERT INTO PRODUCTO VALUES ('P007','Arena para gatos low tanck 18.1kg','30','20',GETDATE());
INSERT INTO PRODUCTO VALUES ('P008','Disfraz dinosaurio','10','40',GETDATE());

--REGISTAR AL EMPLEADO
INSERT INTO EMPLEADO VALUES ('EMP001','Andy','Blanco Arzapalo','M','995412041','Vitarte','944686609','AndyBlanco@hotmail.com','Mana�a',GETDATE());

--REGISTRAR AL CLIENTE
INSERT INTO CLIENTE VALUES ('CLI001','Jesus','Leon','M','Vitarte','945015332',GETDATE());

--REGISTRAR VENTAS
INSERT INTO VENTAS VALUES ('V001','EMP001','P006','Comedero con antideslizante','1','10',GETDATE());
INSERT INTO VENTAS VALUES ('V002','EMP001','P008','Disfraz dinosaurio','1','40',GETDATE());

--PROCEDIMIENTO ALMACENADO DE EMPLEADO
go
CREATE PROCEDURE SP_EMPLEADO
@ID_EMP VARCHAR(50),
@NOM_EMP VARCHAR(25),
@APELLIDOS VARCHAR(50),
@SEXO VARCHAR(30),
@DNI VARCHAR(30),
@DIRECCION VARCHAR(50),
@TELEFONO VARCHAR(30),
@EMAIL VARCHAR(50),
@TURNO VARCHAR(20),
@FECHA_CONTRATA DATETIME
AS
BEGIN TRANSACTION G
INSERT INTO EMPLEADO (ID_EMP,NOM_EMP,APELLIDOS,SEXO,DNI,DIRECCION,TELEFONO,EMAIL,TURNO,FECHA_CONTRATA)
VALUES(@ID_EMP,@NOM_EMP,@APELLIDOS,@SEXO,@DNI,@DIRECCION,@TELEFONO,@EMAIL,@TURNO,@FECHA_CONTRATA);
COMMIT TRANSACTION G

--PROCEDIMIENTO ALMACENADO DE CLIENTE
go
CREATE PROCEDURE SP_CLIENTE
@ID_CLI VARCHAR(70),
@NOM_CLI VARCHAR(30), 
@APE_CLI VARCHAR(50),
@DNI VARCHAR(30),
@SEXO VARCHAR(50),
@DIRECCION VARCHAR(50),
@TELEFONO VARCHAR (50)
AS
BEGIN TRANSACTION E
INSERT INTO CLIENTE (ID_CLI,NOM_CLI,APE_CLI,DNI,SEXO,DIRECCION,TELEFONO)
VALUES(@ID_CLI,@NOM_CLI,@APE_CLI,@DNI,@SEXO,@DIRECCION,@TELEFONO);
COMMIT TRANSACTION E

--PROCEDIMIENTO ALMACENADO DE MASCOTA
go
CREATE PROCEDURE SP_MASCOTA
 @ID_MASC VARCHAR(20),
 @NOM_MASC VARCHAR(50),
 @ESPECIE VARCHAR(50), 
 @RAZA VARCHAR(40),
 @SEXO VARCHAR(1)
 AS
 BEGIN TRANSACTION F
INSERT INTO MASCOTA (ID_MASC,NOM_MASC,ESPECIE,RAZA,SEXO)
VALUES(@ID_MASC,@NOM_MASC,@ESPECIE,@RAZA,@SEXO);
COMMIT TRANSACTION F

--UNION DE 2 TABLAS CLIENTE Y MASCOTA
SELECT a.ID_CLI, a.NOM_CLI, a.DNI, a.TELEFONO, b.NOM_MASC, b.ID_MASC
FROM CLIENTE a inner join MASCOTA b ON a.ID_CLI = b.ID_MASC

-- PROCEDIMIENTO ALMACENADO DE SERVICIO
go
CREATE PROCEDURE SP_SERVICIO
@ID_SERV VARCHAR(40),
@ID_EMP VARCHAR(50),
@ID_CLI VARCHAR(70),
@ID_MASC VARCHAR(20),
@TIPO_SERV VARCHAR(50),
@PRECIO_SERV MONEY,
@FECHA_REGISTRO DATETIME
AS
 BEGIN TRANSACTION G
INSERT INTO SERVICIO (ID_SERV,ID_EMP,ID_CLI,ID_MASC,TIPO_SERV,PRECIO_SERV,FECHA_REGISTRO)
VALUES(@ID_SERV,@ID_EMP,@ID_CLI,@ID_MASC,@TIPO_SERV,@PRECIO_SERV,@FECHA_REGISTRO);
COMMIT TRANSACTION G

--PRODECIMIENTO ALMACENADO CON PRODUCTO
go
CREATE PROCEDURE SP_PRODUCTO
@ID_PRO VARCHAR(50),
@TIPO_PRODUCTO_REGISTRADO VARCHAR(70),
@CANTIDAD CHAR (1000),
@PRECIO MONEY,
@FECHA_REGISTRO DATETIME
AS
BEGIN TRANSACTION E
INSERT INTO PRODUCTO (ID_PRO,TIPO_PRODUCTO_REGISTRADO,CANTIDAD,PRECIO,FECHA_REGISTRO)
VALUES (@ID_PRO,@TIPO_PRODUCTO_REGISTRADO,@CANTIDAD,@PRECIO,@FECHA_REGISTRO)
COMMIT TRANSACTION E

-- PROCEDIMIENTO ALMACENADO CON VENTAS
go
CREATE PROCEDURE SP_VENTAS
@ID_VENTAS VARCHAR(20),
@ID_EMP VARCHAR(50),
@ID_PRO VARCHAR(50),
@TIPO_PRODUCTO VARCHAR(50),
@CANTIDAD VARCHAR(100),
@PRECIO_SOLES MONEY,
@HORA_VENTA DATETIME 
AS
BEGIN TRANSACTION F 
INSERT INTO VENTAS (ID_VENTAS,ID_EMP,ID_PRO,TIPO_PRODUCTO,CANTIDAD,PRECIO_SOLES,HORA_VENTA)
VALUES (@ID_VENTAS,@ID_EMP,@ID_PRO,@TIPO_PRODUCTO,@CANTIDAD,@PRECIO_SOLES,@HORA_VENTA)
COMMIT TRANSACTION F
--BUSQUEDAS
select * from EMPLEADO
select * from CLIENTE
Select * from MASCOTA
select * from SERVICIO
select * from PRODUCTO
select * from VENTAS 