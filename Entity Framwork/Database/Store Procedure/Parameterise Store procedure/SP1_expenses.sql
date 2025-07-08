create proc SP1_expenses
@expense_id int,
@user_id int,
@account_id int,
@expense_date date,
@expence_category nvarchar(100),
@remark nvarchar(100),
@ammount decimal(10,2),
@flag nvarchar(1)

as
begin

if(@flag = 'I')
begin
insert into [dbo].[expenses](
user_id,
account_id,
expense_date,
expence_category,
remark,
ammount
)
values(
@user_id,
@account_id,
GETDATE(),
@expence_category,
@remark,
@ammount
)
end

if(@flag = 'U')
begin
update [dbo].[expenses] set 
user_id = @user_id,
account_id = @account_id,
expense_date = GETDATE(),
expence_category = @expence_category,
remark = @remark,
ammount = @ammount
where expense_id = @expense_id
end

end