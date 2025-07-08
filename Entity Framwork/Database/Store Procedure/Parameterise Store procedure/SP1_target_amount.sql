create proc SP1_target_amount
@target_id int,
@user_id int,
@amount decimal(10,2),
@flag nvarchar(1)

as
begin

if(@flag = 'I')
begin
insert into [dbo].[target_amount](
user_id,
amount
)
values(
@user_id,
@amount
)
end

if(@flag = 'U')
begin
update [dbo].[target_amount] set
user_id = @user_id,
amount = @amount
where target_id = @target_id
end

end
