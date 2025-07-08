create proc SP1_income
@income_id int,
@user_id int,
@account_id int,
@income_date date,
@income_source nvarchar(100),
@amount decimal,
@flag nvarchar(1)

as
begin

if(@flag = 'I')
begin
insert into [dbo].[income](
user_id,
account_id,
income_date,
income_source,
amount
)
values(
@user_id,
@account_id,
GETDATE(),
@income_source,
@amount
)
end

if(@flag = 'U')
begin
update [dbo].[income] set
user_id = @user_id,
account_id = @account_id,
income_date = GETDATE(),
income_source = @income_source,
 amount= @amount
 where income_id = @income_id
 end

 end