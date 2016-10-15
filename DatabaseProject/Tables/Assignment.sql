﻿CREATE TABLE [dbo].[Assignment]
(
	[Id] INT NOT NULL PRIMARY KEY, 
	[CustomerId] INT NOT NULL, 
	[ManagerId] INT NOT NULL, 
    [Description] VARCHAR(50) NULL, 
    [StartDate] DATETIME NULL, 
    [EndDate] DATETIME NULL, 
    CONSTRAINT [FK_Assignment_Manager] FOREIGN KEY ([ManagerId]) REFERENCES [Employee]([Id]), 
    CONSTRAINT [FK_Assignment_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id]),
)
