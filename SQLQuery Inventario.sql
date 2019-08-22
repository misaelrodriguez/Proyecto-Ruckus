create database Inventario
use Inventario


create table usuarios(Id_user int primary key, 
Nombre varchar(30) not null, 
Contraseña varchar(20) not null,
Tipo_user varchar(10) not null);
select * from usuarios;

 delete from usuarios where Id_user=12
insert into usuarios values(12718, 'Misael Rodriguez', 1234, 'admin')
insert into usuarios values(75, 'Juan Reyes', 'reyes', 'user')
drop table usuarios

create table Existencia(No_parte varchar(15) primary key,
Descripcion varchar(80) not null,
Modelo varchar(25) not null,
Categoria varchar(15) not null,
Localidad varchar(15) not null,
Cantidad int not null,
CostoUnitario money not null,
CantidadMin int not null,
CantidadMax int not null,
Usuario int not null,
Fecha DATETIME default getdate())

select * from Existencia

create table Movimientos(Id_mov int IDENTITY(1, 1) primary key,
No_parte varchar(15) not null,
Descripcion varchar(80) not null,
Modelo varchar(25) not null,
Categoria varchar(15) not null,
Localidad varchar(15) not null,
Cantidad int not null,
Usuario int not null,
Fecha datetime default getdate())

select * from Movimientos
select * from Existencia
select * from Movimientos
alter table Movimientos add foreign key (No_parte) references Existencia (No_parte)

Create table MaterialsinExist(No_parte varchar(15) not null,
Descripcion varchar(80) not null,
Modelo varchar(25) not null,
Prioridad varchar(15) not null,
Fecha DATETIME DEFAULT getdate());

alter table MaterialsinExist add primary key (No_parte)

select * from MaterialsinExist
drop table MaterialsinExist
insert into Existencia
 (No_parte, Descripcion, Modelo, Categoria, Localidad, Cantidad, CostoUnitario, CantidadMin, CantidadMax, Usuario)
 Values ('B002.01618.005', 'IC PER 3.3V SMD LQFP80 GP/HF ETHERNET MA', 'ICX6450-48P', 'Reparacion', 'B1A', 65, 2.00, 20, 100, 12718) 




select * from Movimientos
insert into Movimientos (No_parte, Descripcion, Modelo, Categoria, Localidad, Cantidad, Usuario) 
values ('B002.01618.005', 'IC PER 3.3V SMD LQFP80 GP/HF ETHERNET MA', 'ICX6450-48P', 'Reparacion', 'B1A', 10, 35703)


  CREATE TRIGGER Mov_AI
 on [Movimientos]
 AFTER INSERT
  AS
  UPDATE Existencia set Existencia.Cantidad = Existencia.Cantidad-i.Cantidad 
  from inserted as i inner join Existencia AS Existencia on 
  i.No_parte=Existencia.No_parte

  