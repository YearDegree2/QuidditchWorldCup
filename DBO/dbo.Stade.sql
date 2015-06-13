CREATE TABLE [dbo].[Stade]
(
    [Id]       INT          NOT NULL,
    [Nom]      VARCHAR (50) NOT NULL,
    [Adresse]  VARCHAR (50) NOT NULL,
    [Ville]    VARCHAR (50) NOT NULL,
    [NbPlaces] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
