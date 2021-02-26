USE [ReCapDatabase]
GO

/****** Object: Table [dbo].[Rentals] Script Date: 24.2.2021 23:22:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Rentals] (
    [RentId]     INT      NOT NULL,
    [CarId]      INT      NOT NULL,
    [CustomerId] INT      NOT NULL,
    [RentDate]   DATETIME NOT NULL,
    [ReturnDate] DATETIME NULL
);



GO
ALTER TABLE [dbo].[Rentals]
    ADD CONSTRAINT [PK_Rentals] PRIMARY KEY CLUSTERED ([RentId] ASC);


