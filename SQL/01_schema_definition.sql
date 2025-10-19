IF DB_ID('wheelzyDb') IS NULL
BEGIN
    CREATE DATABASE wheelzyDb;
END;
GO

USE [wheelzyDb];
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'ZipCodes')
BEGIN
    CREATE TABLE dbo.ZipCodes (
        [ID] INT IDENTITY (1,1),
        [ZIP_CODE] INT UNIQUE NOT NULL,
        [AREA_NAME] NVARCHAR(255) NOT NULL,
        [IS_ACTIVE] BIT NOT NULL,
        CONSTRAINT PK_ZipCodes PRIMARY KEY CLUSTERED ([ID])
    );
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Cars')
BEGIN
    CREATE TABLE dbo.Cars (
        [ID] INT IDENTITY(1,1),
        [MAKE] NVARCHAR(255) NOT NULL,
        [MODEL] NVARCHAR(255) NOT NULL,
        [SUBMODEL] NVARCHAR(255) NOT NULL,
        [YEAR] DATE NOT NULL,
        [ID_ZIP_CODE] INT NOT NULL,
        [IS_ACTIVE] BIT NOT NULL,
        CONSTRAINT PK_Cars PRIMARY KEY CLUSTERED ([ID]),
        CONSTRAINT FK_Cars_ZipCodes FOREIGN KEY ([ID_ZIP_CODE]) REFERENCES dbo.ZipCodes([ZIP_CODE])
    );
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Buyers')
BEGIN
    CREATE TABLE dbo.Buyers (
        [ID] INT IDENTITY(1,1),
        [FULLNAME] NVARCHAR(255) NOT NULL,
        [IS_ACTIVE] BIT NOT NULL,
        CONSTRAINT PK_Buyers PRIMARY KEY CLUSTERED ([ID])
    );
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Quotes')
BEGIN
    CREATE TABLE dbo.Quotes (
        [ID] INT IDENTITY(1,1),
        [ID_BUYER] INT NOT NULL,
        [ID_ZIP_CODE] INT NOT NULL,
        [AMOUNT] FLOAT NOT NULL,
        [IS_CURRENT] BIT NOT NULL,
        [IS_ACTIVE] BIT NOT NULL,
        CONSTRAINT PK_Quotes PRIMARY KEY CLUSTERED ([ID]),
        CONSTRAINT FK_Quotes_ZipCodes FOREIGN KEY ([ID_ZIP_CODE]) REFERENCES dbo.ZipCodes([ZIP_CODE]),
        CONSTRAINT FK_Quotes_Buyers FOREIGN KEY ([ID_BUYER]) REFERENCES dbo.Buyers([ID])
    );
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'States')
BEGIN
    CREATE TABLE dbo.States (
        [ID] INT IDENTITY(1,1),
        [DESCRIPTION] NVARCHAR(255) NOT NULL,
        CONSTRAINT PK_States PRIMARY KEY CLUSTERED ([ID])
    );
END;
GO


IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Orders')
BEGIN
    CREATE TABLE dbo.Orders (
        [ID] INT IDENTITY(1,1),
        [ID_QUOTE] INT NOT NULL,
        [ID_STATUS] INT NOT NULL,
        [CREATED_DATE] DATE NOT NULL,
        [IS_ACTIVE] BIT NOT NULL,
        CONSTRAINT PK_Orders PRIMARY KEY CLUSTERED ([ID]),
        CONSTRAINT FK_Orders_Quotes FOREIGN KEY ([ID_QUOTE]) REFERENCES dbo.Quotes([ID]),
        CONSTRAINT FK_Orders_States FOREIGN KEY ([ID_STATUS]) REFERENCES dbo.States([ID])
    );
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'OrdersDetail')
BEGIN
    CREATE TABLE dbo.OrdersDetail (
        [ID] INT IDENTITY(1,1),
        [ID_ORDER] INT NOT NULL,
        [ID_CAR] INT NOT NULL,
        [PICKED_UP_DATE] DATE,
        CONSTRAINT PK_OrdersDetail PRIMARY KEY CLUSTERED ([ID]),
        CONSTRAINT FK_OrdersDetail_Orders FOREIGN KEY ([ID_ORDER]) REFERENCES dbo.Orders([ID]),
        CONSTRAINT FK_OrdersDetail_Cars FOREIGN KEY ([ID_CAR]) REFERENCES dbo.Cars([ID])
    );
END;

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'OrdersHistory')
BEGIN
    CREATE TABLE dbo.OrdersHistory (
        [ID] INT IDENTITY(1,1),
        [ID_ORDER_DETAIL] INT NOT NULL,
        [ID_STATUS] INT NOT NULL,
        [UPDATE_DATE] DATE,
        CONSTRAINT PK_OrdersHistory PRIMARY KEY CLUSTERED ([ID]),
        CONSTRAINT FK_OrdersHistory_Orders FOREIGN KEY ([ID_ORDER_DETAIL]) REFERENCES dbo.OrdersDetail([ID]),
        CONSTRAINT FK_OrdersHistory_States FOREIGN KEY ([ID_STATUS]) REFERENCES dbo.States([ID])
    );
END;
GO


