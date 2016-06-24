CREATE TABLE [dbo].[User] (
    [UserId]       INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (50)   NULL,
    [LastName]     VARCHAR (50)   NULL,
    [DOB]          DATE           NOT NULL,
    [Phone]        VARCHAR (50)   NULL,
    [IsDonor]      BIT            NOT NULL,
    [L_RoleId]     INT            NOT NULL,
    [CreatedDate]  DATETIME       NULL,
    [ModifiedDate] DATETIME       NULL,
    [EmailId]      NVARCHAR (250) NULL,
    [Password]     NVARCHAR (50)  NULL,
    [DonorId]      INT            NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_User_Donor] FOREIGN KEY ([DonorId]) REFERENCES [dbo].[Donor] ([DonorId]),
    CONSTRAINT [FK_User_L_Role] FOREIGN KEY ([L_RoleId]) REFERENCES [dbo].[L_Role] ([L_RoleId])
);







