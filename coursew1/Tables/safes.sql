CREATE TABLE [dbo].[safes]
(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	person_id INT NOT NULL,
	CONSTRAINT [safes_fk0] FOREIGN KEY (person_id) REFERENCES persons(id),
	reservation_date_start datetime NOT NULL,
	reservation_date_end datetime NOT NULL
)
