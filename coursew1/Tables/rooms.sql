CREATE TABLE [dbo].[rooms]
(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	name NCHAR(30) NOT NULL,
	work_time_begin TIME NOT NULL,
	work_time_end TIME NOT NULL
)
