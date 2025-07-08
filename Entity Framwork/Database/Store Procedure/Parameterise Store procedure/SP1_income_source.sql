create proc SP1_income_source
@source_id int,
@user_id int,
@source_name nvarchar(100),
@flag nvarchar(1)

as
begin

if(@flag = 'I')
begin
insert into [dbo].[income_source](
user_id,
source_name
)
values(
@user_id,
@source_name
)
end

if(@flag = 'U')
begin
update [dbo].[income_source] set
user_id = @user_id,
source_name = @source_name
where source_id = @source_id
end

end