create proc SP1_expense_category
@category_id int,
@user_id int,
@category_name nvarchar(100),
@flag nvarchar(1)

as
begin

if(@flag = 'I')
begin
insert into [dbo].[expense_category](
user_id,
category_name
)
values(
@user_id,
@category_name
)
end

if(@flag = 'U')
begin
update [dbo].[expense_category] set
user_id = @user_id,
category_name = @category_name
where category_id = @category_id
end

end