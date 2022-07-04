go
use DBEJERCICIO
go
--************************ VALIDAMOS SI EXISTE EL PROCEDIMIENTO ************************--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_registrar')
DROP PROCEDURE usp_registrar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_modificar')
DROP PROCEDURE usp_modificar

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_obtener')
DROP PROCEDURE usp_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_listar')
DROP PROCEDURE usp_obtener

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_eliminar')
DROP PROCEDURE usp_eliminar

go

--************************ PROCEDIMIENTOS PARA CREAR ************************--
create procedure usp_registrar(
@Nombre nvarchar(60),
@Descripcion nvarchar(250),
@foto image
)
as
begin

insert into PRODUCTO(Nombre,Descripcion,foto)
values(
@Nombre,
@Descripcion,
@foto
)

end


go

create procedure usp_modificar(
@SKUP int,
@Nombre nvarchar(60),
@Descripcion nvarchar(250),
@foto image
)
as
begin

update PRODUCTO set 
Nombre = @Nombre,
Descripcion = @Descripcion,
foto = @foto
where SKUP = @SKUP

end

go

create procedure usp_obtener(@SKUP int)
as
begin

select * from PRODUCTO where SKUP = @SKUP
end

go
create procedure usp_listar
as
begin

select * from PRODUCTO
end


go

go

create procedure usp_eliminar(
@SKUP int
)
as
begin

delete from PRODUCTO where SKUP = @SKUP

end

go