CREATE TABLE [dbo].[services]
(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	client_id INT NOT NULL,
	CONSTRAINT [subscriptions_fk0] FOREIGN KEY (client_id) REFERENCES persons([id]),
	[type] NCHAR(30) NOT NULL,
	price MONEY NOT NULL
)
