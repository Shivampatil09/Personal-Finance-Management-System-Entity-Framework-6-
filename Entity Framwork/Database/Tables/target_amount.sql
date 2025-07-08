create table target_amount(
target_id int PRIMARY KEY IDENTITY(1,1),
user_id int NULL,
amount decimal(10,2) NULL,
FOREIGN KEY (user_id) REFERENCES [user] (user_id)
);