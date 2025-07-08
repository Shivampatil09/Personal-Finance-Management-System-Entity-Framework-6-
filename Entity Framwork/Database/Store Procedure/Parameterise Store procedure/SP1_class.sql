create proc SP1_class
@student_id int,
@name nvarchar(50),
@roll_no int,
@flag nvarchar(1)

as
begin

if(@flag = 'I')
begin
insert into [dbo].[class](
name,
roll_no
)
values(
@name,
@roll_no
)
end

if(@flag = 'U')
begin
update [dbo].[class] set
name = @name,
roll_no = @roll_no
where student_id = @student_id
end

end