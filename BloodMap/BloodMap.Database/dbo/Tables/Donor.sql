CREATE TABLE [dbo].[Donor] (
    [DonorId]            INT      IDENTITY (1, 1) NOT NULL,
    [PrimaryAddressId]   INT      NULL,
    [SecondaryAddressId] INT      NULL,
    [L_BloodGroupId]     INT      NULL,
    [LastDonationDate]   DATETIME NULL,
    [NoOfDonation]       INT      NULL,
    CONSTRAINT [PK_Donor] PRIMARY KEY CLUSTERED ([DonorId] ASC),
    CONSTRAINT [FK_Donor_Address] FOREIGN KEY ([PrimaryAddressId]) REFERENCES [dbo].[Address] ([AddressId]),
    CONSTRAINT [FK_Donor_Address1] FOREIGN KEY ([SecondaryAddressId]) REFERENCES [dbo].[Address] ([AddressId]),
    CONSTRAINT [FK_Donor_L_BloodGroup] FOREIGN KEY ([L_BloodGroupId]) REFERENCES [dbo].[L_BloodGroup] ([BloodGroupId])
);



