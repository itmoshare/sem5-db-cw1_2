CREATE TABLE [dbo].[products]
(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	title NCHAR(20) NOT NULL,
	price decimal NOT NULL,
	[count] integer NOT NULL
)
