CREATE TABLE [dbo].[Spectateur]
(
	[Id]            INT          NOT NULL,
    [Nom]           VARCHAR (50) NOT NULL,
    [Prenom]        VARCHAR (50) NOT NULL,
    [DateNaissance] DATETIME     NOT NULL,
    [Adresse]       VARCHAR (50) NOT NULL,
    [Ville]         VARCHAR (50) NOT NULL,
    [Email]         VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
