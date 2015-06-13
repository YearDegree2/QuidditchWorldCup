CREATE TABLE [dbo].[Reservation]
(
	[Id]           INT NOT NULL,
    [IdMatch]      INT NOT NULL,
    [Place]        INT NOT NULL,
    [IdSpectateur] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Reservation_Match] FOREIGN KEY ([IdMatch]) REFERENCES [dbo].[Match] ([Id]),
    CONSTRAINT [FK_Reservation_Spectateur] FOREIGN KEY ([IdSpectateur]) REFERENCES [dbo].[Spectateur] ([Id])
)
