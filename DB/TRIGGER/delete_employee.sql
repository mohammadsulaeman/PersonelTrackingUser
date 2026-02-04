create trigger delete_employee on employee
after delete as 
Begin
declare @id int 
select @id = ID from deleted
delete from TASK where EmployeeID = @id
delete from SALARY where EmployeeID = @id
delete from PERMISSION where EmployeeID = @id
End