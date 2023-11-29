CREATE TABLE [dbo].[tblComputer]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Model] VARCHAR(50) NOT NULL, 
    [Manufacturer] VARCHAR(50) NOT NULL, 
    [Cost] FLOAT NOT NULL, 
    [EquipmentType] INT NOT NULL, 
    [Memory] FLOAT NOT NULL, 
    [HardDriveSize] INT NOT NULL, 
    [Processor] VARCHAR(50) NOT NULL
)
