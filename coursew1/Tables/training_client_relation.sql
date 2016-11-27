CREATE TABLE [dbo].[training_client_relation]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [client_id] INT NULL, 
    [training_id] INT NULL, 
    CONSTRAINT [fk0_clientR] FOREIGN KEY ([client_id]) REFERENCES [clients]([id]),
	CONSTRAINT [fk1_trainingR] FOREIGN KEY ([training_id]) REFERENCES [trainings]([id])
)
