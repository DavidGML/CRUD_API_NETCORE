create database italika_db

use italika_db
go

create table inventario_motos(
sku varchar(100) not null primary key,
fert varchar(50) not null,
modelo varchar(25) not null,
tipo varchar(25) not null,
numero_serie varchar(50) not null,
fecha date not null
);
go

create table usuario (
id_usuario int not null primary key identity (1,1),
nombre_usuario varchar(25) not null,
contraseña varchar(256) not null
);
go

insert into usuario values('admin','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918')
go

create proc get_all
as
begin
select * from inventario_motos
end 
go

create proc get_by_sku
@sku varchar(100)
as
begin
select * from inventario_motos
where sku = @sku;
end 
go

create proc get_by_modelo
@modelo varchar(25)
as
begin
select * from inventario_motos
where modelo = @modelo;
end 
go

create proc edit_moto
@sku varchar(100),
@fert varchar(50),
@modelo varchar(25),
@tipo varchar(25),
@numero_serie varchar(50)
as
begin
update inventario_motos set fert = @fert, modelo = @modelo, tipo = @tipo, numero_serie = @numero_serie
where sku = @sku;
end 
go

create proc delete_moto
@sku varchar(100)
as
begin
delete from inventario_motos
where sku = @sku;
end 
go