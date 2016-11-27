CREATE TABLE [dbo].[persons]
(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	first_name NCHAR(30) NOT NULL,
	last_name NCHAR(40) NOT NULL,
	middle_name NCHAR(30) NOT NULL,
	photo VARBINARY(MAX) NULL,
	birth_date date NOT NULL
)
