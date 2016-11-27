
CREATE TABLE [dbo].[positions]
(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	name VARCHAR(20) NOT NULL,
	salary money
)

CREATE TABLE [dbo].[staff]
(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	position_id INT NOT NULL,
	person_id INT NOT NULL,
	CONSTRAINT [person_fk0] FOREIGN KEY (person_id) REFERENCES persons(id),
	CONSTRAINT [staff_fk1] FOREIGN KEY (position_id) REFERENCES positions(id)
)


