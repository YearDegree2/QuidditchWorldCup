CREATE TABLE [dbo].[Joueur]
(
	[Id]            INT          NOT NULL,
    [Nom]           VARCHAR (50) NOT NULL,
    [Prenom]        VARCHAR (50) NOT NULL,
    [DateNaissance] DATETIME     NOT NULL,
    [Numero]        VARCHAR (50) NOT NULL,
    [PosteJoueur]   TINYINT          NOT NULL,
    [Capitaine]     TINYINT      NOT NULL,
    [IdEquipe]      INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Joueur_Equipe] FOREIGN KEY ([IdEquipe]) REFERENCES [dbo].[Equipe] ([Id])
)
