create table income(
income_id int PRIMARY KEY IDENTITY(1,1),
user_id int NULL,
account_id int NULL,
income_date date NULL,
income_source nvarchar(100) NULL,
amount decimal(10,2) NULL,
FOREIGN KEY (user_id) REFERENCES [user] (user_id),
FOREIGN KEY (account_id) REFERENCES account (account_id)
);