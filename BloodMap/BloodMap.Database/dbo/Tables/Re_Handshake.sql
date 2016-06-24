CREATE TABLE [dbo].[Re_Handshake] (
    [Id]               UNIQUEIDENTIFIER CONSTRAINT [DF_Re_Handshake_Id] DEFAULT (newid()) NOT NULL,
    [SeriesIdentifier] VARCHAR (100)    NULL,
    [Token]            VARCHAR (500)    NULL,
    [CreatedDate]      DATETIME         NOT NULL,
    [LastLogin]        DATETIME         NULL,
    [UserId]           INT              NOT NULL,
    CONSTRAINT [PK_Re_Handshake] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Re_Handshake_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

