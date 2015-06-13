CREATE TABLE [dbo].[Match]
(
	[Id]                  INT        NOT NULL,
    [Date]                DATETIME   NOT NULL,
    [IdCoupe]             INT        NULL,
    [IdEquipeDomicile]    INT        NOT NULL,
    [IdEquipeVisiteur]    INT        NOT NULL,
    [Prix]                FLOAT (53) NOT NULL,
    [IdStade]             INT        NULL,
    [IdArbitre]           INT        NULL,
    [ScoreEquipeDomicile] INT        NOT NULL,
    [ScoreEquipeVisiteur] INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Match_EquipeDomicile] FOREIGN KEY ([IdEquipeDomicile]) REFERENCES [dbo].[Equipe] ([Id]),
    CONSTRAINT [FK_Match_EquipeVisiteur] FOREIGN KEY ([IdEquipeVisiteur]) REFERENCES [dbo].[Equipe] ([Id]),
    CONSTRAINT [FK_Match_Stade] FOREIGN KEY ([IdStade]) REFERENCES [dbo].[Stade] ([Id]),
    CONSTRAINT [FK_Match_Arbitre] FOREIGN KEY ([IdArbitre]) REFERENCES [dbo].[Arbitre] ([Id])
)
