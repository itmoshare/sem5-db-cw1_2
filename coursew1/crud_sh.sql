--------equipment-------
IF OBJECT_ID('Create_equipment') IS NOT NULL
BEGIN 
DROP PROC Create_equipment 
END
GO
CREATE PROCEDURE Create_equipment
	   @name varchar(20),
	   @income_date datetime
	 
AS
BEGIN
INSERT INTO equipment (
	   name,
	   income_date)
    VALUES (
	   @name,
	   @income_date)

SELECT SCOPE_IDENTITY()
FROM equipment
WHERE id = SCOPE_IDENTITY()
END


IF OBJECT_ID('Update_equipment') IS NOT NULL
BEGIN 
DROP PROC Update_equipment
END 
GO
CREATE PROC Update_equipment
    @id int,
	@name varchar(20),
	@income_date datetime
  
AS 
BEGIN 
 
UPDATE equipment
SET  name = @name,
     income_date = @income_date
WHERE  id = @id
END
GO

IF OBJECT_ID('Delete_equipment') IS NOT NULL
BEGIN 
DROP PROC Delete_equipment
END 
GO
CREATE PROC Delete_equipment 
    @id int
AS 
BEGIN 
DELETE
FROM   equipment
WHERE  id = @id

END
GO


-----trainings-----
IF OBJECT_ID('Create_training') IS NOT NULL
BEGIN 
DROP PROC Create_training
END
GO
CREATE PROCEDURE Create_training
	   @room_id int,
	   @staff_id int,
	   @time_begin time,
	   @time_end time,
	   @program_id int,
	   @days NCHAR(50)
AS
BEGIN

DECLARE @room_begin time
DECLARE @room_end time

SELECT @room_begin = work_time_begin, @room_end = work_time_end
FROM rooms
WHERE id = @room_id
IF @time_begin >= @room_begin AND @time_end <= @room_end
BEGIN
	INSERT INTO trainings (
		   room_id,
		   staff_id,
		   time_begin,
		   time_end,
		   program_id,
		   days)
	    VALUES (
		   @room_id,
		   @staff_id,
		   @time_begin,
		   @time_end,
		   @program_id,
		   @days)

	SELECT SCOPE_IDENTITY()
	FROM trainings
	WHERE id = SCOPE_IDENTITY()
END
ELSE
	SELECT NULL
END


IF OBJECT_ID('Update_training') IS NOT NULL
BEGIN 
DROP PROC Update_training
END 
GO
CREATE PROC Update_training
    @id int,
	@room_id int,
    @staff_id int,
    @time_begin time,
    @time_end time,
    @program_id int,
    @days NCAHR(50)
  
AS 
BEGIN 
 
UPDATE trainings
SET  room_id = @room_id,
     staff_id = @staff_id,
     time_begin = @time_begin,
     time_end = @time_end,
     program_id = @program_id,
     days = @days
WHERE  id = @id
END
GO

IF OBJECT_ID('Delete_training') IS NOT NULL
BEGIN 
DROP PROC Delete_training
END 
GO
CREATE PROC Delete_training 
    @id int
AS 
BEGIN 
DELETE
FROM   trainings
WHERE  id = @id

END
GO

----persons----
IF OBJECT_ID('Create_person') IS NOT NULL
BEGIN 
DROP PROC Create_person
END
GO
CREATE PROCEDURE Create_person
	   @first_name nchar(20),
	   @last_name nchar(20),
	   @middle_name nchar(20),
	   @photo VARBINARY(MAX),
	   @birth_date date

AS
BEGIN
INSERT INTO persons (
	   first_name,
	   last_name,
	   middle_name,
	   photo,
	   birth_date)
    VALUES (
	   @first_name,
	   @last_name,
	   @middle_name,
	   @photo,
	   @birth_date)

SELECT SCOPE_IDENTITY()
FROM persons
WHERE id = SCOPE_IDENTITY()
END

IF OBJECT_ID('Update_person') IS NOT NULL
BEGIN 
DROP PROC Update_person
END 
GO
CREATE PROC Update_person
    @id int,
	@first_name nchar(20),
	@last_name nchar(20),
	@middle_name nchar(20),
	@photo VARBINARY(MAX),
	@birth_date date
  
AS 
BEGIN 
 
UPDATE persons
SET  first_name = @first_name,
     last_name = @last_name,
     middle_name = @middle_name,
     photo = @photo,
     birth_date = @birth_date
WHERE  id = @id
END
GO

IF OBJECT_ID('Delete_person') IS NOT NULL
BEGIN 
DROP PROC Delete_person
END 
GO
CREATE PROC Delete_person 
    @person_id int
AS 
BEGIN 


DECLARE @staff_id int
DECLARE @client_id int

SELECT @staff_id = id 
FROM staff
WHERE person_id = @person_id

SELECT @client_id = id
FROM clients
WHERE person_id = @person_id

EXEC Delete_staff @id = @staff_id
EXEC Delete_client @id = @client_id

DELETE
FROM   persons
WHERE  id = @person_id

END
GO


EXEC dbo.Create_equipment @name='gantelya', @income_date = '01.01.1982';