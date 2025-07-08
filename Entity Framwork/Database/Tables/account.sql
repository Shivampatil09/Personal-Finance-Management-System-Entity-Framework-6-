CREATE TABLE account(
account_id int PRIMARY KEY IDENTITY(1,1),
user_id int NULL,
account_type nvarchar(50) NULL,
balance decimal(10,2) NULL,
liabilities decimal(10,2),
FOREIGN KEY (user_id) REFERENCES[user] (user_id) 
);
