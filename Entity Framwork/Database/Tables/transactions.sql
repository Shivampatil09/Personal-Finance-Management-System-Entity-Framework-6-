create table transactions(
transaction_id int PRIMARY KEY IDENTITY(1,1),
account_id int NULL,
type nvarchar(10) NULL,
amount decimal(10,2) NULL,
statement nvarchar(255) NULL,
time datetime NULL,
FOREIGN KEY (account_id) REFERENCES account (account_id)
);