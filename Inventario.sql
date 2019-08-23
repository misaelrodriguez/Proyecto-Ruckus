DROP DATABASE Inventario

CREATE DATABASE Inventario

USE Inventario

CREATE TABLE Usuarios(Id_user INT PRIMARY KEY,
Nombre VARCHAR(30) NOT NULL,
Contrasena VARCHAR(20) NOT NULL,
Tipo_user VARCHAR(10) NOT NULL);

CREATE TABLE Existencias(No_parte VARCHAR(15) PRIMARY KEY,
Descripcion VARCHAR(80) NOT NULL,
Modelo VARCHAR(25) NOT NULL,
Categoria VARCHAR(15) NOT NULL,
Localidad VARCHAR(15) NOT NULL,
Cantidad INT NOT NULL,
CostoUnitario MONEY NOT NULL,
CantidadMin INT NOT NULL,
CantidadMax INT NOT NULL,
Usuario INT NOT NULL,
Fecha DATETIME DEFAULT getdate())

CREATE TABLE Movimientos(Id_mov INT IDENTITY(1, 1) PRIMARY KEY,
No_parte VARCHAR(15) NOT NULL,
Descripcion VARCHAR(80) NOT NULL,
Modelo VARCHAR(25) NOT NULL,
Categoria VARCHAR(15) NOT NULL,
Localidad VARCHAR(15) NOT NULL,
Cantidad INT NOT NULL,
Usuario INT NOT NULL,
Fecha DATETIME DEFAULT getdate())

CREATE TABLE MaterialsinExist(No_parte VARCHAR(15) NOT NULL,
Descripcion VARCHAR(80) NOT NULL,
Modelo VARCHAR(25) NOT NULL,
Prioridad VARCHAR(15) NOT NULL,
Fecha DATETIME DEFAULT getdate());


ALTER TABLE Movimientos ADD FOREIGN KEY (No_parte) REFERENCES Existencias (No_parte)

ALTER TABLE MaterialsinExist ADD PRIMARY KEY (No_parte)


INSERT INTO Usuarios VALUES(12718, 'Misael Rodriguez', 1234, 'admin')
INSERT INTO Usuarios VALUES(75, 'Juan Reyes', 'reyes', 'user')

INSERT INTO Existencias
(No_parte, Descripcion, Modelo, Categoria, Localidad, Cantidad, CostoUnitario, CantidadMin, CantidadMax, Usuario)
VALUES ('B002.01618.005', 'IC PER 3.3V SMD LQFP80 GP/HF ETHERNET MA', 'ICX6450-48P', 'Reparacion', 'B1A', 65, 2.00, 20, 100, 12718)

INSERT INTO Movimientos (No_parte, Descripcion, Modelo, Categoria, Localidad, Cantidad, Usuario)
VALUES ('B002.01618.005', 'IC PER 3.3V SMD LQFP80 GP/HF ETHERNET MA', 'ICX6450-48P', 'Reparacion', 'B1A', 10, 35703)
INSERT INTO Movimientos (No_parte, Descripcion, Modelo, Categoria, Localidad, Cantidad, Usuario)
VALUES ('B002.01618.005', 'IC PER 3.3V SMD LQFP80 GP/HF ETHERNET MA', 'ICX6450-48P', 'Reparacion', 'C1A', 10, 35703)
INSERT INTO Movimientos (No_parte, Descripcion, Modelo, Categoria, Localidad, Cantidad, Usuario)
VALUES ('B002.01618.005', 'IC PER 3.3V SMD LQFP80 GP/HF ETHERNET MA', 'ICX6450-48P', 'Reparacion', 'D1A', 10, 35703)


CREATE TRIGGER Mov_AI
ON [Movimientos]
AFTER INSERT
AS
UPDATE Existencias SET Existencias.Cantidad = Existencias.Cantidad-i.Cantidad
FROM inserted AS i INNER JOIN Existencias AS Existencias ON
i.No_parte=Existencias.No_parte


SELECT * FROM Usuarios

SELECT * FROM Existencias

SELECT * FROM Movimientos

SELECT * FROM MaterialsinExist
