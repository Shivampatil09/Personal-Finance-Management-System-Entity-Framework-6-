create proc SP1_transactions
@transaction_id int,
@account_id int,
@type nvarchar(10),
@amount decimal(10,2),
@statement nvarchar(225),
@time datetime,
@flag nvarchar(1)

as
begin

if(@flag = 'I')
begin
insert into [dbo].[transactions](
account_id,
type,
amount,
statement,
time
)
values(
@account_id,
@type,
@amount,
@statement,
GETDATE()
)
end

if(@flag = 'U')
begin
update [dbo].[transactions] set 
account_id = @account_id,
type = @type,
amount = @amount,
statement = @statement,
time = @time
where transaction_id = @transaction_id
end

end