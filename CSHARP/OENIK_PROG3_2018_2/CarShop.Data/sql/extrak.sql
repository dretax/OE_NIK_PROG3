CREATE TABLE [dbo].[extrak]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [kategorianev] VARCHAR(50) NULL, 
    [nev] VARCHAR(50) NULL, 
    [ar] INT NULL, 
    [szin] VARCHAR(50) NULL, 
    [tobbszor_hasznalhato] TINYINT NULL
)
