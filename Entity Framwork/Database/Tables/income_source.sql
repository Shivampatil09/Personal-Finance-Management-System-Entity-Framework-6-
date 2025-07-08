create table income_source(
source_id int PRIMARY KEY IDENTITY(1,1),
user_id int NULL,
source_name nvarchar(100) NULL,
FOREIGN KEY (user_id) REFERENCES [user] (user_id)
);