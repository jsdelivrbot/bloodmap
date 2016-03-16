CREATE TABLE [dbo].[Address] (
    [AddressId] INT             IDENTITY (1, 1) NOT NULL,
    [Locality]  VARCHAR (300)   NULL,
    [City]      VARCHAR (50)    NULL,
    [State]     VARCHAR (50)    NULL,
    [Country]   VARCHAR (50)    NULL,
    [PinCode]   VARCHAR (50)    NULL,
    [Phone]     VARCHAR (50)    NULL,
    [Latitude]  DECIMAL (12, 9) NULL,
    [Longitude] DECIMAL (12, 9) NULL,
    CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([AddressId] ASC)
);



