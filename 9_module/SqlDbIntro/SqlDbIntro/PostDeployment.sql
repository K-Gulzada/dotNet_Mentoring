
Insert into People(FirstName, LastName) values ('Jack', 'Sparrow')
Insert into People(FirstName, LastName) values ('John', 'Smith')
Insert into People(FirstName, LastName) values ('Hannah', 'Montana')
Insert into People(FirstName, LastName) values ('Ariana', 'Grande')
Insert into People(FirstName, LastName) values ('Justin', 'Bieber')

insert into Addresses(Street, City, State, Zipcode) values('Boston Street', 'Boston', 'Massachusetts', '456')
insert into Addresses(Street, City, State, Zipcode) values('Portland Street', 'Portland', 'Oregon', '395')
insert into Addresses(Street, City, State, Zipcode) values('Las Vegas Street', 'Las Vegas', 'Nevada', '712')
insert into Addresses(Street, City, State, Zipcode) values('Jacksonville Street', 'Jacksonville', 'Florida', '618')
insert into Addresses(Street, City, State, Zipcode) values('San Diego Street', 'San Diego', 'California', '467')
insert into Addresses(Street, City, State, Zipcode) values('Dallas Street', 'Dallas', 'Texas', '993')
insert into Addresses(Street, City, State, Zipcode) values('Denver Street', 'Denver', 'Colorado', '194')
insert into Addresses(Street, City, State, Zipcode) values('Washington Street', 'Washington', 'District of Columbia', '733')

insert into Companies(Name, AddressId) values('Company 1', 1)
insert into Companies(Name, AddressId) values('Company 2', 2)
insert into Companies(Name, AddressId) values('Company 3', 3)
insert into Companies(Name, AddressId) values('Company 4', 4)
insert into Companies(Name, AddressId) values('Company 5', 5)
insert into Companies(Name, AddressId) values('Company 6', 6)

insert into Employees(AddressId, PersonId, CompanyName, Position, EmployeeName) values(1, 1, 'Company 1', 'developer', 'Jack-Jack')
insert into Employees(AddressId, PersonId, CompanyName, Position, EmployeeName) values(2, 2, 'Company 2', 'manager', 'John-John')
insert into Employees(AddressId, PersonId, CompanyName, Position, EmployeeName) values(3, 3, 'Company 3', 'QA engineer', 'Hann')
insert into Employees(AddressId, PersonId, CompanyName, Position, EmployeeName) values(4, 4, 'Company 4', 'scrum master', 'Ari')
insert into Employees(AddressId, PersonId, CompanyName, Position, EmployeeName) values(5, 5, 'Company 5', 'developer', 'Justiny')

 -- task 2

alter view EmployeeInfo as
select top 5 e.Id, 
isnull(e.EmployeeName,CONCAT(p.FirstName, ' ', p.LastName)) as 'EmployeeFullName',
CONCAT(a.ZipCode, '_', a.State, ', ', a.City, '-', a.Street) as 'EmployeeFullAddress',
CONCAT(e.CompanyName, ' ', e.Position) as 'EmployeeCompanyInfo'
from Employees e
join People p on p.Id=e.PersonId
join Addresses a on a.Id=e.AddressId
order by a.City

 select * from EmployeeInfo

-- task 3 Creating SP

CREATE PROCEDURE SP_InsertEmployeeInfo 
@EmployeeName nvarchar(100) = NULL, 
@FirstName nvarchar(50),
@LastName nvarchar(50),
@CompanyName nvarchar(20),
@Position nvarchar(50) = NULL,
@Street nvarchar(50),
@City nvarchar(20) = NULL,
@State nvarchar(50) = NULL,
@ZipCode nvarchar(50) = NULL
AS
 DECLARE @AddressId INT;
 DECLARE @PersonId INT;

 INSERT INTO Addresses values(@Street, @City, @State, @ZipCode) SET @AddressId = @@IDENTITY;
 INSERT INTO People(FirstName, LastName) values(@FirstName, @LastName) SET @PersonId = @@IDENTITY;

 INSERT INTO Employees(AddressId, PersonId, CompanyName, Position, EmployeeName) values(@AddressId, @PersonId, @CompanyName, @Position, @EmployeeName);

GO

-- task 4 create trigger

CREATE TRIGGER Trg_InsertCompanyAfterNewEmployee
ON Employees
AFTER INSERT
AS
BEGIN
    INSERT INTO Companies(
       Name,
	   AddressId
    )
	SELECT
       e.CompanyName,
	   e.AddressId
    FROM
        Employees e where e.Id=@@IDENTITY
   
END
