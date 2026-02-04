create trigger delete_position on position 
after delete as
begin
declare @id int
select @id = ID from deleted
delete from EMPLOYEE where PositionID = @id
end