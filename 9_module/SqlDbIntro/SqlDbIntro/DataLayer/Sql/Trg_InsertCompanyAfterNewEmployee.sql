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
