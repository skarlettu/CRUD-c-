use master
go
IF NOT EXISTS(SELECT name FROM master.dbo.sysdatabases WHERE NAME = 'DBEJERCICIO')
CREATE DATABASE DBEJERCICIO

GO 

USE DBEJERCICIO

GO

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'PRODUCTO')
create table PRODUCTO(
SKUP int primary key identity(1,1),
Nombre nvarchar(60) not null ,
Descripcion nvarchar(250),
foto image ,
)

go

select * from dbo.PRODUCTO