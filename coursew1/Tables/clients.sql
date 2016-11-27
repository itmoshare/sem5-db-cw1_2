CREATE TABLE [dbo].[clients]
(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	person_id INT NOT NULL,
	CONSTRAINT [clients_fk0] FOREIGN KEY (person_id) REFERENCES persons(id)
)
