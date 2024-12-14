create database RegistroColegios
go

use RegistroColegios
go

create table School
(
SchoolId int primary key identity,
SchoolName varchar(50) not null,
Description varchar(1000),
Address varchar(50),
Phone varchar(50),
PostCode varchar(50),
PostAddress varchar(50)
)

create table Class
(
ClassId int primary key identity,
SchoolId int foreign key references School(SchoolId) not null,
ClassName varchar(50) not null,
Description varchar(1000)
)

create procedure ConsultSchool
@id int
as
	begin
		select SchoolId, SchoolName, Description, Address, Phone, PostCode, PostAddress from School where SchoolId = @id
	end

create procedure AddSchool
@name varchar(50),
@description varchar(1000),
@address varchar(50),
@phone varchar(50),
@postCode varchar(50),
@postAddress varchar(50)
as
	begin
		insert into School (SchoolName, Description, Address, Phone, PostCode, PostAddress) values (@name, @description, @address, @phone, @postCode, @postAddress)
	end

create procedure DeleteSchool
@id int
as
	begin
		delete School where SchoolId = @id
	end

create procedure EditSchool
@id int,
@name varchar(50),
@description varchar(1000),
@address varchar(50),
@phone varchar(50),
@postCode varchar(50),
@postAddress varchar(50)
as
	begin
		update School set SchoolName = @name, Description = @description, Address = @address, Phone = @phone, PostCode = @postCode, PostAddress = @postAddress where SchoolId = @id
	end

create procedure ConsultClass
@id int
as
	begin
		select ClassId, SchoolId, ClassName, Description from Class where ClassId = @id
	end

create procedure AddClass
@schoolId int,
@name varchar(50),
@description varchar(1000)
as
	begin
		insert into Class (SchoolId, ClassName, Description) values (@schoolId, @name, @description)
	end

create procedure DeleteClass
@id int
as
	begin
		delete Class where ClassId = @id
	end

create procedure EditClass
@id int,
@schoolId int,
@name varchar(50),
@description varchar(1000)
as
	begin
		update Class set SchoolId = @schoolId, ClassName = @name, Description = @description where ClassId = @id
	end