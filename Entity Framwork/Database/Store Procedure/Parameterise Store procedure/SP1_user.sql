create proc SP1_user
@user_id int,
@name nvarchar(100),
@username nvarchar(50),
@password nvarchar(100),
@flag nvarchar(1)

as
begin

if(@flag = 'I')
begin 
insert into [dbo].[user](
name,
username,
password
)
values(
@name,
@username,
@password
)
end

if(@flag = 'U')
begin
update [dbo].[user] set
name = @name,
username = @username,
password = @password
where user_id = @user_id
end

end