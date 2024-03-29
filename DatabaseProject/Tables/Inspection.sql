﻿CREATE TABLE [dbo].[Inspection]
(
	[Id] INT IDENTITY(1,1) NOT NULL, 
	[AssignmentId] INT NOT NULL, 
    [RegionId] INT NOT NULL, 
    [Location] VARCHAR(50) NOT NULL, 
    [StartDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NOT NULL, 
    [StatusId] INT NOT NULL, 
    [InspectorId] INT NULL, 
    [DateCreated] DATETIME NOT NULL DEFAULT GETDATE(), 
    [DateUpdated] DATETIME NOT NULL DEFAULT GETDATE(),
	CONSTRAINT [PK_Inspection] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Inspection_Assignment] FOREIGN KEY ([AssignmentId]) REFERENCES [Assignment]([Id]), 
    CONSTRAINT [FK_Inspection_InspectionStatus] FOREIGN KEY ([StatusId]) REFERENCES [InspectionStatus]([Id]), 
    CONSTRAINT [FK_Inspection_Region] FOREIGN KEY ([RegionId]) REFERENCES [Region]([Id]), 
    CONSTRAINT [FK_Inspection_Employee] FOREIGN KEY ([InspectorId]) REFERENCES [Employee]([Id]) 
)
