CREATE TABLE [dbo].[Donor] (
    [DonorId]          INT      IDENTITY (1, 1) NOT NULL,
    [PrimaryAddress]   INT      NULL,
    [SecondaryAddress] INT      NULL,
    [L_BloodGroupId]   INT      NULL,
    [LastDonationDate] DATETIME NULL,
    [NoOfDonation]     INT      NULL,
    [UserId]           INT      NULL,
    CONSTRAINT [PK_Donor] PRIMARY KEY CLUSTERED ([DonorId] ASC),
    CONSTRAINT [FK_Donor_Address] FOREIGN KEY ([PrimaryAddress]) REFERENCES [dbo].[Address] ([AddressId]),
    CONSTRAINT [FK_Donor_Address1] FOREIGN KEY ([SecondaryAddress]) REFERENCES [dbo].[Address] ([AddressId]),
    CONSTRAINT [FK_Donor_L_BloodGroup] FOREIGN KEY ([L_BloodGroupId]) REFERENCES [dbo].[L_BloodGroup] ([BloodGroupId]),
    CONSTRAINT [FK_Donor_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

