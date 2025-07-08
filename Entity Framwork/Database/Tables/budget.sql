create table budget(
budget_id int PRIMARY KEY IDENTITY(1,1),
user_id int NULL,
expense_category nvarchar(100) NULL,
amount decimal(10,2) NULL,
FOREIGN KEY (user_id) REFERENCES [user] (user_id)
);