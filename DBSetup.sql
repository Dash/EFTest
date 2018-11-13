DROP TABLE Sellers;
DROP TABLE Buyers;
DROP TABLE Persons;
DROP TABLE Products;


CREATE TABLE Products (
	Id INT IDENTITY PRIMARY KEY,
	[Description] nvarchar(256),
)

create table Persons (
	Id int IDENTITY PRIMARY KEY,
	[Name] nvarchar(128),
	ProductId INT NOT NULL,
	FOREIGN KEY (ProductId) REFERENCES Products(Id)
)

CREATE TABLE Buyers (
	Id INT PRIMARY KEY,
	ShipTo nvarchar(256)
)

CREATE TABLE Sellers (
	Id INT PRIMARY KEY,
	Rating INT NOT NULL DEFAULT 0
)

DECLARE @ProductId int;
INSERT INTO Products ([Description]) VALUES ('Widget');
SET @ProductId = @@IDENTITY;

INSERT INTO Persons ([Name], ProductId) VALUES ('Bob the seller', @ProductId);
INSERT INTO Sellers (Id, Rating) VALUES (@@IDENTITY, 0);

INSERT INTO Persons ([Name], ProductId) VALUES ('Bert the buyer', @ProductId);
INSERT INTO Buyers (Id, ShipTo) VALUES (@@IDENTITY, 'Somewhere');


SELECT * FROM Products;
SELECT * FROM Persons p INNER JOIN Sellers s ON p.Id = s.Id;
SELECT * FROM Persons p INNER JOIN Buyers b ON p.Id = b.Id;
