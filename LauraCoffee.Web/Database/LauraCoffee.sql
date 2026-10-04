/* SQL Server / LocalDB schema for Laura Coffee.
   The web app creates this structure and seeds the complete menu automatically
   on its first run. Run this script only if you prefer to create the schema yourself. */
IF DB_ID(N'LauraCoffeeDb') IS NULL CREATE DATABASE LauraCoffeeDb;
GO
USE LauraCoffeeDb;
GO
CREATE TABLE Categories (
  CategoryId INT IDENTITY(1,1) PRIMARY KEY,
  Name NVARCHAR(100) NOT NULL UNIQUE,
  Icon NVARCHAR(20) NOT NULL DEFAULT N'☕',
  DisplayOrder INT NOT NULL,
  IsActive BIT NOT NULL DEFAULT 1
);
CREATE TABLE Products (
  ProductId INT IDENTITY(1,1) PRIMARY KEY,
  CategoryId INT NOT NULL,
  Name NVARCHAR(150) NOT NULL,
  Description NVARCHAR(300) NULL,
  Price DECIMAL(18,0) NOT NULL CHECK (Price >= 0),
  Unit NVARCHAR(50) NULL,
  ImageUrl NVARCHAR(500) NULL,
  IsAvailable BIT NOT NULL DEFAULT 1,
  IsFeatured BIT NOT NULL DEFAULT 0,
  CONSTRAINT UQ_Products_Category_Name UNIQUE(CategoryId, Name),
  CONSTRAINT FK_Products_Categories FOREIGN KEY(CategoryId) REFERENCES Categories(CategoryId)
);
CREATE TABLE AddOns (
  AddOnId INT IDENTITY(1,1) PRIMARY KEY,
  Name NVARCHAR(100) NOT NULL,
  Price DECIMAL(18,0) NOT NULL CHECK (Price >= 0),
  IsAvailable BIT NOT NULL DEFAULT 1
);
CREATE TABLE Orders (
  OrderId INT IDENTITY(1,1) PRIMARY KEY,
  CustomerName NVARCHAR(80) NOT NULL,
  Phone NVARCHAR(20) NOT NULL,
  Note NVARCHAR(300) NULL,
  CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  Status INT NOT NULL DEFAULT 0 CHECK (Status BETWEEN 0 AND 4),
  TotalAmount DECIMAL(18,0) NOT NULL CHECK (TotalAmount >= 0)
);
CREATE TABLE OrderItems (
  OrderItemId INT IDENTITY(1,1) PRIMARY KEY,
  OrderId INT NOT NULL,
  ProductId INT NOT NULL,
  ProductName NVARCHAR(150) NOT NULL,
  UnitPrice DECIMAL(18,0) NOT NULL,
  Quantity INT NOT NULL CHECK (Quantity > 0),
  AddOnNames NVARCHAR(300) NULL,
  AddOnPrice DECIMAL(18,0) NOT NULL DEFAULT 0,
  CONSTRAINT FK_OrderItems_Orders FOREIGN KEY(OrderId) REFERENCES Orders(OrderId) ON DELETE CASCADE,
  CONSTRAINT FK_OrderItems_Products FOREIGN KEY(ProductId) REFERENCES Products(ProductId)
);
GO
