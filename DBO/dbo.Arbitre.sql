CREATE TABLE [dbo].[Arbitre]
(
	[Id]                       INT          NOT NULL,
    [Nom]                      VARCHAR (50) NOT NULL,
    [Prenom]                   VARCHAR (50) NOT NULL,
    [DateNaissance]            DATETIME     NOT NULL,
    [NumeroPoliceAssuranceVie] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
