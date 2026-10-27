IF OBJECT_ID('dbo.Proposals', 'U') IS NOT NULL DROP TABLE dbo.Proposals;
IF OBJECT_ID('dbo.Item', 'U') IS NOT NULL DROP TABLE dbo.Item;
IF OBJECT_ID('dbo.Warehouse', 'U') IS NOT NULL DROP TABLE dbo.Warehouse;
IF OBJECT_ID('dbo.Supplier', 'U') IS NOT NULL DROP TABLE dbo.Supplier;
IF OBJECT_ID('dbo.Family', 'U') IS NOT NULL DROP TABLE dbo.Family;

CREATE TABLE dbo.Family
(
	FamilyId varchar(50) NOT NULL,
	Description varchar(100) NULL,
	CONSTRAINT PK_Family PRIMARY KEY (FamilyId)
);

CREATE TABLE dbo.Supplier
(
	SupplierId varchar(50) NOT NULL,
	Description varchar(100) NULL,
	CONSTRAINT PK_Supplier PRIMARY KEY (SupplierId)
);

CREATE TABLE dbo.Item
(
	ItemId varchar(100) NOT NULL,
	Description varchar(100) NULL,
	FamilyId varchar(50) NULL,
	SupplierId varchar(50) NULL,
	UnitCost decimal(18,4) NULL,
	UnitVol decimal(18,4) NULL,
	ListPrice decimal(18,4) NULL,
	CONSTRAINT PK_Item PRIMARY KEY (ItemId)
);

CREATE TABLE dbo.Warehouse
(
	WarehouseId varchar(50) NOT NULL,
	Description varchar(100) NULL,
	CONSTRAINT PK_Warehouse PRIMARY KEY (WarehouseId)
);

CREATE TABLE dbo.Proposals
(
	ItemId varchar(100) NOT NULL,
	WarehouseId varchar(50) NOT NULL,
	ProposalIndex int NOT NULL,
	Quantity decimal(18,4) NULL,
	ReleaseDate date NULL,
	DueDate date NULL,
	CONSTRAINT PK_Proposals PRIMARY KEY (ItemId, WarehouseId, ProposalIndex)
);
