﻿/*
Deployment script for BloodMap

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "BloodMap"
:setvar DefaultFilePrefix "BloodMap"
:setvar DefaultDataPath "C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Creating [dbo].[Address]...';


GO
CREATE TABLE [dbo].[Address] (
    [AddressId] INT             IDENTITY (1, 1) NOT NULL,
    [Address]   VARCHAR (300)   NULL,
    [City]      VARCHAR (50)    NULL,
    [State]     VARCHAR (50)    NULL,
    [Country]   VARCHAR (50)    NULL,
    [PinCode]   VARCHAR (50)    NULL,
    [Phone]     VARCHAR (50)    NULL,
    [Latitude]  DECIMAL (12, 9) NULL,
    [Longitude] DECIMAL (12, 9) NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([AddressId] ASC)
);


GO
PRINT N'Creating [dbo].[Donor]...';


GO
CREATE TABLE [dbo].[Donor] (
    [DonorId]          INT      IDENTITY (1, 1) NOT NULL,
    [PrimaryAddress]   INT      NULL,
    [SecondaryAddress] INT      NULL,
    [L_BloodGroupId]   INT      NULL,
    [LastDonationDate] DATETIME NULL,
    [NoOfDonation]     INT      NULL,
    [UserId]           INT      NULL,
    CONSTRAINT [PK_Donor] PRIMARY KEY CLUSTERED ([DonorId] ASC)
);


GO
PRINT N'Creating [dbo].[L_BloodGroup]...';


GO
CREATE TABLE [dbo].[L_BloodGroup] (
    [BloodGroupId] INT          IDENTITY (1, 1) NOT NULL,
    [GroupTitle]   VARCHAR (50) NOT NULL,
    [CreatedDate]  DATETIME     NULL,
    [ModifiedDate] DATETIME     NULL,
    CONSTRAINT [PK_L_BloodGroup] PRIMARY KEY CLUSTERED ([BloodGroupId] ASC)
);


GO
PRINT N'Creating [dbo].[L_Role]...';


GO
CREATE TABLE [dbo].[L_Role] (
    [L_RoleId]     INT          IDENTITY (1, 1) NOT NULL,
    [Title]        VARCHAR (50) NULL,
    [CreatedDate]  DATETIME     NULL,
    [ModifiedDate] DATETIME     NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([L_RoleId] ASC)
);


GO
PRINT N'Creating [dbo].[Login]...';


GO
CREATE TABLE [dbo].[Login] (
    [LoginId]      INT           IDENTITY (1, 1) NOT NULL,
    [EmailId]      VARCHAR (100) NOT NULL,
    [Password]     VARCHAR (50)  NOT NULL,
    [UserId]       INT           NOT NULL,
    [CreatedDate]  DATETIME      NULL,
    [ModifiedDate] DATETIME      NULL,
    CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED ([LoginId] ASC)
);


GO
PRINT N'Creating [dbo].[User]...';


GO
CREATE TABLE [dbo].[User] (
    [UserId]       INT          IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (50) NULL,
    [LastName]     VARCHAR (50) NULL,
    [DOB]          DATE         NOT NULL,
    [Phone]        VARCHAR (50) NULL,
    [IsDonor]      BIT          NOT NULL,
    [L_RoleId]     INT          NOT NULL,
    [CreatedDate]  DATETIME     NULL,
    [ModifiedDate] DATETIME     NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);


GO
PRINT N'Creating [dbo].[FK_Donor_Address]...';


GO
ALTER TABLE [dbo].[Donor] WITH NOCHECK
    ADD CONSTRAINT [FK_Donor_Address] FOREIGN KEY ([PrimaryAddress]) REFERENCES [dbo].[Address] ([AddressId]);


GO
PRINT N'Creating [dbo].[FK_Donor_Address1]...';


GO
ALTER TABLE [dbo].[Donor] WITH NOCHECK
    ADD CONSTRAINT [FK_Donor_Address1] FOREIGN KEY ([SecondaryAddress]) REFERENCES [dbo].[Address] ([AddressId]);


GO
PRINT N'Creating [dbo].[FK_Donor_L_BloodGroup]...';


GO
ALTER TABLE [dbo].[Donor] WITH NOCHECK
    ADD CONSTRAINT [FK_Donor_L_BloodGroup] FOREIGN KEY ([L_BloodGroupId]) REFERENCES [dbo].[L_BloodGroup] ([BloodGroupId]);


GO
PRINT N'Creating [dbo].[FK_Donor_User]...';


GO
ALTER TABLE [dbo].[Donor] WITH NOCHECK
    ADD CONSTRAINT [FK_Donor_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating [dbo].[FK_Login_User]...';


GO
ALTER TABLE [dbo].[Login] WITH NOCHECK
    ADD CONSTRAINT [FK_Login_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]);


GO
PRINT N'Creating [dbo].[FK_User_L_Role]...';


GO
ALTER TABLE [dbo].[User] WITH NOCHECK
    ADD CONSTRAINT [FK_User_L_Role] FOREIGN KEY ([L_RoleId]) REFERENCES [dbo].[L_Role] ([L_RoleId]);


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Donor] WITH CHECK CHECK CONSTRAINT [FK_Donor_Address];

ALTER TABLE [dbo].[Donor] WITH CHECK CHECK CONSTRAINT [FK_Donor_Address1];

ALTER TABLE [dbo].[Donor] WITH CHECK CHECK CONSTRAINT [FK_Donor_L_BloodGroup];

ALTER TABLE [dbo].[Donor] WITH CHECK CHECK CONSTRAINT [FK_Donor_User];

ALTER TABLE [dbo].[Login] WITH CHECK CHECK CONSTRAINT [FK_Login_User];

ALTER TABLE [dbo].[User] WITH CHECK CHECK CONSTRAINT [FK_User_L_Role];


GO
PRINT N'Update complete.';


GO