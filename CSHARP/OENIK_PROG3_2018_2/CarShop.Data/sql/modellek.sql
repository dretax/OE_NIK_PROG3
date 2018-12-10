CREATE TABLE [dbo].[modellek]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [marka_id] INT NULL, 
    [nev] VARCHAR(50) NULL, 
    [megjelenesnapja] DATE NULL, 
    [motorterfogat] INT NULL, 
    [loero] INT NULL, 
    [alapar] INT NULL
)
