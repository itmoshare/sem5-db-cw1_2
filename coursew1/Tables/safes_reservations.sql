CREATE TABLE [dbo].[safes_reservations]
(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	person_id INT NOT NULL,
	CONSTRAINT [safes_reservation_fk0] FOREIGN KEY (person_id) REFERENCES persons(id),
	safe_id INT NOT NULL,
	CONSTRAINT [safes_reservation_fk1] FOREIGN KEY (safe_id) REFERENCES safes(id),
	reservation_date_start datetime NOT NULL,
	reservation_date_end datetime NOT NULL
)
