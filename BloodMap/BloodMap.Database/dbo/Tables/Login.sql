CREATE TABLE [dbo].[Login] (
    [LoginId]      INT           IDENTITY (1, 1) NOT NULL,
    [EmailId]      VARCHAR (100) NOT NULL,
    [Password]     VARCHAR (50)  NOT NULL,
    [UserId]       INT           NOT NULL,
    [CreatedDate]  DATETIME      NULL,
    [ModifiedDate] DATETIME      NULL,
    CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED ([LoginId] ASC),
    CONSTRAINT [FK_Login_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

