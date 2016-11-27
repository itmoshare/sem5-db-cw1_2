CREATE TABLE [dbo].[trainings]
(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	room_id INT NOT NULL,
	CONSTRAINT [trainings_fk0] FOREIGN KEY (room_id) REFERENCES rooms(id),
	staff_id INT NOT NULL,
	CONSTRAINT [trainings_fk1] FOREIGN KEY (staff_id) REFERENCES persons(id),
	program_id INT NOT NULL,
	CONSTRAINT [trainings_fk2] FOREIGN KEY (program_id) REFERENCES training_programs(id),
	time_begin TIME NOT NULL,
	time_end TIME NOT NULL,
	days NCHAR(50)
)
