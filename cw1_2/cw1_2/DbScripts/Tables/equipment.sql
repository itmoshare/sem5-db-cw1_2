CREATE TABLE [dbo].[equipment]
(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	room_id INT NOT NULL,
	CONSTRAINT [fk0_roomR] FOREIGN KEY ([room_id]) REFERENCES [rooms]([id]),
	name NCHAR(20) NOT NULL,
	income_date datetime NOT NULL
)
