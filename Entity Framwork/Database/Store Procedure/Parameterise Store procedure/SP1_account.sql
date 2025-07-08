create proc SP1_account
@account_id int,
@user_id int,
@account_type nvarchar(50),
@balance decimal(10,2),
@liabilities decimal(10,2),
@flag nvarchar(1)

as
begin

if(@flag = 'I')
begin
insert into [dbo].[account](
user_id,
account_type,
balance,
liabilities
)
values(
@user_id,
@account_type,
@balance,
@liabilities
)
end

if(@flag = 'U')
begin
update [dbo].[account] set
user_id = @user_id,
account_type = @account_type,
balance = @balance,
liabilities = @liabilities
where account_id = @account_id
end

end