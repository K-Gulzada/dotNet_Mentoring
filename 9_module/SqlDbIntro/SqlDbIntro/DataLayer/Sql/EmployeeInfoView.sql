-- task 2 Creating View
alter view EmployeeInfo as
select top 5 e.Id, 
isnull(e.EmployeeName,CONCAT(p.FirstName, ' ', p.LastName)) as 'EmployeeFullName',
CONCAT(a.ZipCode, '_', a.State, ', ', a.City, '-', a.Street) as 'EmployeeFullAddress',
CONCAT(e.CompanyName, ' ', e.Position) as 'EmployeeCompanyInfo'
from Employees e
join People p on p.Id=e.PersonId
join Addresses a on a.Id=e.AddressId
order by a.City
