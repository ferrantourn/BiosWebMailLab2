use master
GO

--CHEQUEAMOS SI LA BASE DE DATOS EXISTE
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'ObligatorioApp1')
ALTER DATABASE ObligatorioApp1 SET SINGLE_USER WITH ROLLBACK IMMEDIATE
-- LA LINEA ANTERIOR ELIMINA TODAS LAS CONEXIONES EXISTENTES A LA BASE DE DATOS PARA PODER DROPEARLA
GO

IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'ObligatorioApp1')
DROP DATABASE [ObligatorioApp1] /* ELIMINAMOS LA BASE DE DATOS */
GO

/* LA CREAMOS O VOLVEMOS A CREAR */
create database ObligatorioApp1
GO

use ObligatorioApp1
GO

create table Usuario (Ci int primary key not null,
					 NombreUsuario nvarchar (15) not null ,
				     Nombre nvarchar (20) not null,
					 Apellido nvarchar (20) not null,
					 Pass nvarchar (20) not null
					 )
GO

CREATE UNIQUE NONCLUSTERED INDEX IX_NombreUsuario ON dbo.Usuario (NombreUsuario) 
GO

create table Alumno(Ci int primary key not null, 
					Foto nvarchar(256),
					Activo bit not null,
				    foreign key (Ci) references Usuario(Ci))
GO

create table Docente(Ci int primary key not null,
					 Materias nvarchar (500),
					 foreign key (Ci) references Usuario(Ci))
GO

create table Carpeta(Ci int not null,
					 NumeroCarpeta int identity(1,1) not null,
					 NombreCarpeta nvarchar(20) not null,
					 foreign key (Ci) references Usuario(Ci),
					 primary key (Ci,NumeroCarpeta))

GO

create table Mail(NumeroMail int identity(1,1) primary key not null,

				  CiR int not null,
				  NumeroCarpetaR int,

				  CiD int not null,
				  NumeroCarpetaD int,

				  Asunto nvarchar(max),
				  Cuerpo nvarchar(max),
				  Leido bit not null, --0 es no leído, 1 si ya fue leido
				  Fecha datetime not null,

				  foreign key (CiR,NumeroCarpetaR) references Carpeta(Ci,NumeroCarpeta),
				  foreign key (CiD,NumeroCarpetaD) references Carpeta(Ci,NumeroCarpeta))

GO

--ALTA ALUMNO
create proc spAltaAlumno
@Ci int,
@NombreUsuario nvarchar(15),
@Nombre nvarchar(20),
@Apellido nvarchar(20),
@Pass nvarchar(20),
@Foto nvarchar(256),
@Activo bit
as
if exists(select * from Usuario where Usuario.Ci=@Ci or Usuario.NombreUsuario = @NombreUsuario)
	begin
		return -1   --Usuario ya Existe
	end

begin tran
	insert into Usuario (Ci, NombreUsuario, Nombre, Apellido, Pass)
			values(@Ci, @NombreUsuario, @Nombre, @Apellido, @Pass)

	if @@error<>0
	begin
    rollback tran
		return -2  --Si no se pudo insertar un Usuario--
	end

	insert into Alumno(Ci, Foto, Activo)
			values(@Ci, @Foto, @Activo)

	if @@error<>0
	begin
    rollback tran
		return -3  --Si no se pudo insertar un Alumno--
	end

	insert into Carpeta(Ci, NombreCarpeta)
			values (@Ci, 'Inbox')
	
	if @@error<>0
	begin
    rollback tran
		return -4  --Si no se pudo insertar Carpeta--
	end

	insert into Carpeta(Ci, NombreCarpeta)
			values(@Ci, 'Enviados')

	if @@error<>0
	begin
    rollback tran
		return -5  --Si no se pudo insertar Carpeta--
	end

	insert into Carpeta(Ci, NombreCarpeta)
			values(@Ci, 'Papelera')

	if @@error<>0
	begin
    rollback tran
		return -6  --Si no se pudo insertar Carpeta--
	end

commit tran
GO

--ALTA ALUMNO
create proc spModificarAlumno
@Ci int,
@NombreUsuario nvarchar(15),
@Nombre nvarchar(20),
@Apellido nvarchar(20),
@Pass nvarchar(20),
@Foto nvarchar(256),
@Activo bit
as
BEGIN
if not exists(select * from Usuario where Usuario.Ci=@Ci)
	begin
		return -1   --Usuario no Existe
	end

begin tran
	update Usuario set NombreUsuario = @NombreUsuario,
					   Nombre = @Nombre,
					   Apellido = @Apellido, 
					   Pass = @Pass where ci = @Ci

	if @@error<>0
	begin
    rollback tran
		return -2  --Si no se pudo modificar la tabla Usuario--
	end

	update Alumno set Foto = @Foto,
					  Activo = @Activo where ci = @Ci
	if @@error<>0
	begin
    rollback tran
		return -3  --Si no se pudo modificar la tabla Alumno--
	end

commit tran
END

GO


--ALTA DOCENTE	
create proc spAltaDocente
@Ci int,
@NombreUsuario nvarchar(15),
@Nombre nvarchar(20),
@Apellido nvarchar(20),
@Pass nvarchar(20),
@Materias nvarchar(500)
as

if exists(select * from Usuario where Usuario.Ci=@Ci or Usuario.NombreUsuario = @NombreUsuario)
	begin
		return -1   --Usuario ya Existe
	end

begin tran
	insert into Usuario (Ci, NombreUsuario, Nombre, Apellido, Pass)
			values(@Ci, @NombreUsuario, @Nombre, @Apellido, @Pass)

	if @@error<>0
	begin
    rollback tran
		return -2  --Si no se pudo insertar un Usuario--
	end

	insert into Docente(Ci, Materias)
			values(@Ci, @Materias)

	if @@error<>0
	begin
    rollback tran
		return -3  --Si no se pudo insertar un Docente--
	end

commit tran
GO

--MODIFICAR DOCENTE
create proc spModificarDocente
@Ci int,
@NombreUsuario nvarchar(15),
@Nombre nvarchar(20),
@Apellido nvarchar(20),
@Pass nvarchar(20),
@Materias nvarchar(500)
as
begin
if not exists(select * from Usuario where Usuario.Ci=@Ci)
	begin
		return -1   --Usuario no Existe
	end

begin tran
	update Usuario set NombreUsuario = @NombreUsuario,
					   Nombre = @Nombre,
					   Apellido = @Apellido, 
					   Pass = @Pass where ci = @Ci

	if @@error<>0
	begin
    rollback tran
		return -2  --Si no se pudo modificar la tabla Usuario--
	end

	update Docente set Materias = @Materias where ci = @Ci
	if @@error<>0
	begin
    rollback tran
		return -3  --Si no se pudo modificar la tabla Alumno--
	end

commit tran
end

GO

--BAJA DOCENTE
create proc spBajaDocente
@Ci int
as
BEGIN
if not exists(select * from Usuario where Usuario.Ci = @Ci)
	begin
		return -1   --Usuario no Existe
	end

begin tran
	
	delete from Docente where Docente.Ci = @Ci
	if @@error<>0
	begin
    rollback tran
		return -2  --Si no se pudo borrar al Docente--
	end

	delete from Usuario where Usuario.Ci = @Ci
	if @@error<>0
	begin
    rollback tran
		return -3  --Si no se pudo borrar al Usuario--
	end

commit tran
end

GO

--BAJA ALUMNO
create proc spBajaAlumno
@Ci int,
@NumeroCarpeta int
as
BEGIN
if not exists(select * from Usuario where Usuario.Ci=@Ci)
	begin
		return -1   --Usuario no Existe
	end
begin tran

	update Mail SET NumeroCarpetaR = null  where (NumeroCarpetaR = @NumeroCarpeta)
	if @@error<>0
	begin
    rollback tran
		return -2
	end 
	
	update Mail SET NumeroCarpetaD = null  where (NumeroCarpetaD = @NumeroCarpeta)
	
	if @@error<>0
	begin
    rollback tran
		return -3 
	end

	--borramos los mails que no esten en ninguna carpeta

	delete from Mail where (NumeroCarpetaD = null and NumeroCarpetaR = null)
	
	if @@error<>0
	begin
    rollback tran
		return -4
	end

	DELETE FROM Carpeta where ci=@Ci
	
	delete from Alumno where Alumno.Ci = @Ci
	if @@error<>0
	begin
    rollback tran
		return -5  --Si no se pudo borrar al Alumno--
	end

	delete from Usuario where Usuario.Ci = @Ci
	if @@error<>0
	begin
    rollback tran
		return -6  --Si no se pudo borrar al Usuario--
	end

commit tran
END

GO

create proc spAltaCarpeta
@Ci int,
@NombreCarpeta nvarchar(20)
as
BEGIN
if exists(select * from Carpeta where Carpeta.NombreCarpeta=@NombreCarpeta)
	begin
		return -1 --Carpeta ya Existe
	end

if not exists(select * from Usuario where Usuario.Ci=@Ci)
	begin
		return -2 --Usuario inexistente
	end

	insert into Carpeta(Ci, NombreCarpeta)
			values(@Ci, @NombreCarpeta)

	if @@error<>0
	begin
		return -3  --Si no se pudo insertar una carpeta --
	end
	END
GO

--Lista los mails con todos los datos, última novedad!
create proc spListarMailsRecibidos
@NumeroCarpeta int
as
SELECT     Mail.Asunto, Mail.Cuerpo,Mail.Fecha, Mail.Leido, Mail.NumeroMail, Remitente.Nombre AS NombreRemitente, 
                      Remitente.NombreUsuario AS NombreUsuarioRemitente, Remitente.Apellido AS ApellidoRemitente, Destinatario.Nombre AS NombreDestinatario, 
                      Destinatario.Apellido AS ApellidoDestinatario, Destinatario.NombreUsuario AS NombreUsuarioDestinatario, CarpetaRemitente.NumeroCarpeta as NumeroCarpetaRem, 
                      CarpetaRemitente.NombreCarpeta as NombreCarpetaRem, CarpetaDestinatario.NumeroCarpeta AS NumeroCarpetaDest, CarpetaDestinatario.NombreCarpeta AS NombreCarpetaDest
FROM         Mail INNER JOIN
                      Usuario AS Remitente ON Mail.CiR = Remitente.Ci INNER JOIN
                      Usuario AS Destinatario ON Mail.CiD = Destinatario.Ci INNER JOIN
                      Carpeta AS CarpetaRemitente ON Mail.NumeroCarpetaR = CarpetaRemitente.NumeroCarpeta INNER JOIN
                      Carpeta AS CarpetaDestinatario ON Mail.NumeroCarpetaD = CarpetaDestinatario.NumeroCarpeta
where CarpetaDestinatario.NumeroCarpeta = @NumeroCarpeta

GO

--Lista los mails con todos los datos, última novedad!
create proc spListarMailsEnviados
@NumeroCarpeta int
as
SELECT     Mail.Asunto, Mail.Cuerpo,Mail.Fecha, Mail.Leido, Mail.NumeroMail, Remitente.Nombre AS NombreRemitente, 
                      Remitente.NombreUsuario AS NombreUsuarioRemitente, Remitente.Apellido AS ApellidoRemitente, Destinatario.Nombre AS NombreDestinatario, 
                      Destinatario.Apellido AS ApellidoDestinatario, Destinatario.NombreUsuario AS NombreUsuarioDestinatario, CarpetaRemitente.NumeroCarpeta as NumeroCarpetaRem, 
                      CarpetaRemitente.NombreCarpeta as NombreCarpetaRem, CarpetaDestinatario.NumeroCarpeta AS NumeroCarpetaDest, CarpetaDestinatario.NombreCarpeta AS NombreCarpetaDest
FROM         Mail INNER JOIN
                      Usuario AS Remitente ON Mail.CiR = Remitente.Ci INNER JOIN
                      Usuario AS Destinatario ON Mail.CiD = Destinatario.Ci INNER JOIN
                      Carpeta AS CarpetaRemitente ON Mail.NumeroCarpetaR = CarpetaRemitente.NumeroCarpeta INNER JOIN
                      Carpeta AS CarpetaDestinatario ON Mail.NumeroCarpetaD = CarpetaDestinatario.NumeroCarpeta
where CarpetaRemitente.NumeroCarpeta = @NumeroCarpeta
go

--Lista los mails con todos los datos, última novedad!
create proc spListarMails
@NumeroCarpeta int
as
SELECT     Mail.Asunto, Mail.Cuerpo,Mail.Fecha, Mail.Leido, Mail.NumeroMail, Remitente.Nombre AS NombreRemitente, 
                      Remitente.NombreUsuario AS NombreUsuarioRemitente, Remitente.Apellido AS ApellidoRemitente, Destinatario.Nombre AS NombreDestinatario, 
                      Destinatario.Apellido AS ApellidoDestinatario, Destinatario.NombreUsuario AS NombreUsuarioDestinatario, CarpetaRemitente.NumeroCarpeta as NumeroCarpetaRem, 
                      CarpetaRemitente.NombreCarpeta as NombreCarpetaRem, CarpetaDestinatario.NumeroCarpeta AS NumeroCarpetaDest, CarpetaDestinatario.NombreCarpeta AS NombreCarpetaDest
FROM         Mail INNER JOIN
                      Usuario AS Remitente ON Mail.CiR = Remitente.Ci INNER JOIN
                      Usuario AS Destinatario ON Mail.CiD = Destinatario.Ci INNER JOIN
                      Carpeta AS CarpetaRemitente ON Mail.NumeroCarpetaR = CarpetaRemitente.NumeroCarpeta INNER JOIN
                      Carpeta AS CarpetaDestinatario ON Mail.NumeroCarpetaD = CarpetaDestinatario.NumeroCarpeta
where CarpetaRemitente.NumeroCarpeta = @NumeroCarpeta OR CarpetaDestinatario.NumeroCarpeta  = @NumeroCarpeta
go

CREATE PROC spNuevoEmail
@ciR as int,
@NumCarpetaR as int,
@CiD as int,
@NumCarpetaD as int,
@Asunto as nvarchar(max),
@Cuerpo as nvarchar(max),
@Leido as bit,
@Fecha as datetime
as
begin

INSERT INTO Mail (CiR,NumeroCarpetaR,CiD,NumeroCarpetaD,Asunto,Cuerpo,Leido,Fecha)
			values (@ciR, @NumCarpetaR,@CiD,@NumCarpetaD,@Asunto,@Cuerpo,@Leido,@Fecha)


end
GO

--BUSCA UN USUARIO
CREATE PROC spBuscarUsuario
@NombreUsuario as nvarchar(15)

as
begin
select * from Usuario where NombreUsuario = @NombreUsuario
end

GO

CREATE procedure spGetMail
@NumeroMail int
as
begin
 SELECT     Mail.Asunto, Mail.Cuerpo,Mail.Fecha, Mail.Leido, Mail.NumeroMail, Remitente.Nombre AS NombreRemitente, 
                      Remitente.NombreUsuario AS NombreUsuarioRemitente, Remitente.Apellido AS ApellidoRemitente, Destinatario.Nombre AS NombreDestinatario, 
                      Destinatario.Apellido AS ApellidoDestinatario, Destinatario.NombreUsuario AS NombreUsuarioDestinatario, CarpetaRemitente.NumeroCarpeta as NumeroCarpetaRem, 
                      CarpetaRemitente.NombreCarpeta as NombreCarpetaRem, CarpetaDestinatario.NumeroCarpeta AS NumeroCarpetaDest, CarpetaDestinatario.NombreCarpeta AS NombreCarpetaDest
FROM         Mail INNER JOIN
                      Usuario AS Remitente ON Mail.CiR = Remitente.Ci INNER JOIN
                      Usuario AS Destinatario ON Mail.CiD = Destinatario.Ci INNER JOIN
                      Carpeta AS CarpetaRemitente ON Mail.NumeroCarpetaR = CarpetaRemitente.NumeroCarpeta INNER JOIN
                      Carpeta AS CarpetaDestinatario ON Mail.NumeroCarpetaD = CarpetaDestinatario.NumeroCarpeta 
                      
where NumeroMail = @NumeroMail
end

GO

--BUSCA UN ALUMNO
CREATE PROC spBuscarAlumno
@NombreUsuario as nvarchar(15)

as
begin
select Usuario.*, Alumno.Activo,Alumno.Foto from Usuario INNER JOIN Alumno ON Usuario.Ci = Alumno.Ci
 where NombreUsuario = @NombreUsuario
end

GO

CREATE PROC spBuscarAlumnoPorCi
@Ci as int

as
begin
select Usuario.*, Alumno.Activo,Alumno.Foto from Usuario INNER JOIN Alumno ON Usuario.Ci = Alumno.Ci
 where Alumno.Ci = @Ci
end

go 

--BUSCA UN DOCENTE
CREATE PROCEDURE spBuscarDocente
@NombreUsuario as nvarchar(15)

as
begin
select Usuario.*, Docente.Materias from Usuario INNER JOIN Docente ON Usuario.Ci = Docente.Ci
 where NombreUsuario = @NombreUsuario
end

GO

CREATE PROCEDURE spLoginDocente
@NombreUsuario as nvarchar(15),
@Pass as nvarchar(20)
as

begin
	--if not exists (select * from Usuario where NombreUsuario = @NombreUsuario and Pass = @Pass)
	--begin 
	--	return -1
	--end
	
	select Usuario.*, Docente.Materias from Usuario inner join Docente on Usuario.Ci = Docente.Ci
	where NombreUsuario = @NombreUsuario and Pass = @Pass
		
end

GO

--ALCANZA CON UN SOLO SELECT PARA SABER SI EL USUARIO EXISTE O NO.
CREATE PROC spLoginAlumno
@NombreUsuario as nvarchar(15),
@Pass as nvarchar(20)
as
begin
	select Usuario.*, Alumno.Activo,Alumno.Foto from Usuario inner join Alumno on Usuario.Ci = Alumno.Ci
	where NombreUsuario = @NombreUsuario and Pass = @Pass
end

GO
 
-- BUSCA LA CARPETA DE sistema dada de UN USUARIO
CREATE PROC spBuscarCarpetaSistema
@Ci as int,
@nombreCarpetaSistema as varchar(20)

as
begin
select * from Carpeta where NombreCarpeta = @nombreCarpetaSistema AND Ci = @Ci
end

GO

-- BUSCA una carpeta de usuario
CREATE PROC spBuscarCarpeta
@Ci as int,
@numCarpeta as int
as
begin
select * from Carpeta where Ci = @Ci AND NumeroCarpeta = @numCarpeta
end

GO

-- LISTA TODAS LAS CARPETAS DE UN USUARIO
CREATE PROC spListarCarpetasUsuario
@Ci as int
as
begin
select * from Carpeta where Ci = @Ci order by NombreCarpeta asc
end

GO

CREATE PROC spContarMailsCarpeta
@numCarpeta int
as
begin
	select count(*) as Total from Mail where (Mail.NumeroCarpetaR = @numCarpeta or Mail.NumeroCarpetaD = @numCarpeta)
end

GO

CREATE PROC spContarMailsSinLeer
@numCarpeta int
as
begin
	select count(*) as Total from Mail where ((Mail.NumeroCarpetaR = @numCarpeta or Mail.NumeroCarpetaD = @numCarpeta) and Mail.Leido = 0)
end

GO


create procedure spListarAlumnosSinMovimientos
@NumeroDias as int
as
begin

--selecciona todos los usuarios no contendidos en el subselect
select Usuario.*, Alumno.Foto, Alumno.Activo from Usuario inner join Alumno on Usuario.Ci = Alumno.Ci
where Alumno.Ci NOT IN (
--Me trae todas las cedulas de los alumnos que enviaron mails en el lapso de dias requerido
select Alumno.Ci from Alumno inner join Mail on Mail.CiR = Alumno.Ci
where Mail.Fecha >= DATEADD(DAY,-@NumeroDias,GETDATE()))
end

GO

create procedure spActualiarStatusAlumno
@ci as int,
@SetStatus as bit
as
begin

if not exists(select * from Alumno where Alumno.Ci=@Ci)
	begin
		return -1   --Alumno no Existe
	end

	update Alumno set Activo = @SetStatus
	where Alumno.Ci = @ci
end



GO

Create Procedure spEliminarEmail
@NumeroMail as int,
@NumeroCarpeta as int
as
begin
	update Mail set NumeroCarpetaD = null where (NumeroMail = @NumeroMail and NumeroCarpetaD = @NumeroCarpeta)
	update Mail set NumeroCarpetaR = null where (NumeroMail = @NumeroMail and NumeroCarpetaR = @NumeroCarpeta)
	delete from Mail where (NumeroCarpetaD = null and NumeroCarpetaR = null)
end

GO

Create Procedure spMarcarMailComoLeido --SP marcar como leído.
@NumeroMail int,
@NumeroCarpeta int
as
begin
	if exists(select * from Carpeta where NumeroCarpeta=@NumeroCarpeta and NombreCarpeta='Inbox')
		update Mail set Leido = 1 where NumeroMail=@NumeroMail
end

GO



--Elimina una carpeta y todos sus emails
Create Procedure spEliminarCarpeta
@NumeroCarpeta as int
as
begin
begin tran

	update Mail SET NumeroCarpetaR = null  where (NumeroCarpetaR = @NumeroCarpeta)
	if @@error<>0
	begin
    rollback tran
		return -1  
	end 
	
	update Mail SET NumeroCarpetaD = null  where (NumeroCarpetaD = @NumeroCarpeta)
	
	if @@error<>0
	begin
    rollback tran
		return -2 
	end

	--borramos los mails que no esten en ninguna carpeta

	delete from Mail where (NumeroCarpetaD = null and NumeroCarpetaR = null)
	
	if @@error<>0
	begin
    rollback tran
		return -3
	end
	
	--hacemos el delete de la tabla Carpeta
	delete Carpeta where NumeroCarpeta = @NumeroCarpeta
		if @@error<>0
	begin
    rollback tran
		return -3 
	end
	
	commit tran
end

GO

create Procedure spMoverEmail
@NumeroEmail int,
@NumeroCarpetaActual int,
@NumeroCarpetaDestino int
as
	--Actualizo Mail, moviendo el mail de una carpeta a otra
	update Mail set NumeroCarpetaD = @NumeroCarpetaDestino where (NumeroMail = @NumeroEmail and NumeroCarpetaD = @NumeroCarpetaActual)
	update Mail set NumeroCarpetaR = @NumeroCarpetaDestino where (NumeroMail = @NumeroEmail and NumeroCarpetaR = @NumeroCarpetaActual)
GO

create procedure spListarAlumnos
as
begin
select Usuario.* ,Alumno.Activo, Alumno.Foto FROM Usuario INNER JOIN Alumno ON Usuario.Ci = Alumno.Ci
end

GO

create procedure spListarDocentes
as
begin
select Usuario.* ,Docente.Materias FROM Usuario INNER JOIN Docente ON Usuario.Ci = Docente.Ci
end

GO 

--CODIGO PARA CARGAR ALUMNOS, EJECUTANDO STORED PROCEDURE YA GENERADO.
EXEC	spAltaAlumno
		 1234567,
		'yanick',
		 'Yanick',
		 'Tourn',
		 '111111',
		 '',
		 1
		
GO
		--CODIGO PARA CARGAR ALUMNOS, EJECUTANDO STORED PROCEDURE YA GENERADO.
EXEC	spAltaAlumno
		98745563,
		'fito',
		'Amalfi',
		'Marini',
		'111111',
		'',
		1
		
		GO
		
		
		EXEC	spAltaDocente
		78541125,
		'ilena',
		'ilena',
		'Balciunas',
		'111111',
		'aplicaciones,basedatos'
		
		






