Create Database BankDB
go

use BankDB
go


CREATE TABLE [dbo].[UserInfo] (
    [CustomerID] INT    IDENTITY (1000000000, 1)       NOT NULL,
    [SSNID]      INT          NOT NULL,
    [Name]       VARCHAR (50) NOT NULL,
    [Address]    VARCHAR (50) NOT NULL,
    [Age]        INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);


CREATE TABLE [dbo].[CustomerStatus] (
    [ID]           INT          IDENTITY (1000000000, 1) NOT NULL,
    [CustomerID]   INT          NOT NULL,
    [SSNID]        INT          NOT NULL,
    [Status]       VARCHAR (20) NOT NULL,
    [Message]      VARCHAR (50) NOT NULL,
    [Last Updated] DATETIME     NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[UserInfo] ([CustomerID]) 
	ON DELETE CASCADE ON UPDATE CASCADE
);
go



CREATE TABLE [dbo].[AccountStatus] (
	[AccountID]		INT	IDENTITY(1000000000,1) NOT NULL,
	[AccountType]	varchar(15) NOT NULL,
	[Status]		varchar(20)	NOT NULL,
	[Message]		varchar(50) NOT NULL,
	[Last Updated]  datetime	NOT NULL,
	[Balance] 	INT		NOT NULL,
	[CustomerID]	INT			NOT NULL,
	PRIMARY KEY CLUSTERED([AccountID] ASC),
	FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[UserInfo] ([CustomerID])
	ON DELETE CASCADE ON UPDATE CASCADE
);

go
