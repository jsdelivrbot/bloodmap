CREATE TABLE [dbo].[L_Role] (
    [L_RoleId]     INT          IDENTITY (1, 1) NOT NULL,
    [Title]        VARCHAR (50) NULL,
    [CreatedDate]  DATETIME     NULL,
    [ModifiedDate] DATETIME     NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([L_RoleId] ASC)
);

