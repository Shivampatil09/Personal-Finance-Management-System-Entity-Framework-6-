create table expenses(
expense_id int PRIMARY KEY IDENTITY(1,1),
user_id int NULL,
account_id int NULL,
expense_date date NULL,
expence_category nvarchar(100) NULL,
remark nvarchar(100) NULL,
ammount decimal(10,2),
FOREIGN KEY (user_id) REFERENCES [user] (user_Id),
FOREIGN KEY (account_id) REFERENCES account(account_id)
);