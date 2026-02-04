create trigger delete_department on DEPARTMENT
after delete as
begin
declare @id int
select @id = id from deleted
delete from EMPLOYEE where DepartmentID = @id
delete from POSITION where DepartmentID = @id
end