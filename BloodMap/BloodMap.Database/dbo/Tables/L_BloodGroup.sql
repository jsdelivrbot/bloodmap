CREATE TABLE [dbo].[L_BloodGroup] (
    [BloodGroupId] INT          IDENTITY (1, 1) NOT NULL,
    [GroupTitle]   VARCHAR (50) NOT NULL,
    [CreatedDate]  DATETIME     NULL,
    [ModifiedDate] DATETIME     NULL,
    CONSTRAINT [PK_L_BloodGroup] PRIMARY KEY CLUSTERED ([BloodGroupId] ASC)
);

