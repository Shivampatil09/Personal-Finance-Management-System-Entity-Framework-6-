create proc SP1_budget
@budget_id int,
@user_id int,
@expense_category nvarchar(100),
@amount decimal(10,2),
@flag nvarchar(1)

as
begin

if(@flag = 'I')
begin
insert into [dbo].[budget](
user_id,
expense_category,
amount
)
values(
@user_id,
@expense_category,
@amount
)
end

if(@flag = 'U')
begin
update [dbo].[budget] set
user_id = @user_id,
expense_category = @expense_category,
amount = @amount
where budget_id = @budget_id
end

end