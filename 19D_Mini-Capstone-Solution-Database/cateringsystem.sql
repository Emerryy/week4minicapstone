
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the inventoryInfo (IF EXISTS)
IF EXISTS(select * from sys.databases where name='CateringSystem')
DROP DATABASE CateringSystem;
GO

-- Create a new inventoryInfo Database
CREATE DATABASE CateringSystem;
GO

-- Switch to the World Database
USE CateringSystem
GO

-- Begin a TRANSACTION that must complete with no errors
BEGIN TRANSACTION;

CREATE TABLE inventory (
    code NCHAR(2) PRIMARY KEY,
    name NVARCHAR(30) NOT NULL,
    price MONEY NOT NULL,
	type NCHAR(1) NOT Null
   );

CREATE TABLE log (
    logtime DATETIME,
    description NVARCHAR(30),
    startamount MONEY,
    endamount MONEY
)

INSERT INTO inventory (code, name, price, type) VALUES ('B1','Soda',1.50,'B');
INSERT INTO inventory (code, name, price, type) VALUES ('B2','Wine',3.05,'B');
INSERT INTO inventory (code, name, price, type) VALUES ('B3','Beer',2.55,'B');
INSERT INTO inventory (code, name, price, type) VALUES ('B4','Sparkling Water',2.35,'B');
INSERT INTO inventory (code, name, price, type) VALUES ('B5','Punch',0.90,'B');
INSERT INTO inventory (code, name, price, type) VALUES ('A1','Tropical Fruit Bowl',3.50,'A');
INSERT INTO inventory (code, name, price, type) VALUES ('A2','Meatballs',2.95,'A');
INSERT INTO inventory (code, name, price, type) VALUES ('A3','Bacon Wrapped Shrimp',4.15,'A');
INSERT INTO inventory (code, name, price, type) VALUES ('A4','Bruschetta',2.65,'A');
INSERT INTO inventory (code, name, price, type) VALUES ('E1','Baked Chicken',8.85,'E');
INSERT INTO inventory (code, name, price, type) VALUES ('E2','Pork Loin',9.45,'E');
INSERT INTO inventory (code, name, price, type) VALUES ('E3','BBQ Ribs',11.65,'E');
INSERT INTO inventory (code, name, price, type) VALUES ('E4','Beef and Gravy',5.15,'E');
INSERT INTO inventory (code, name, price, type) VALUES ('D1','NY Style Cheesecake',2.55,'D');
INSERT INTO inventory (code, name, price, type) VALUES ('D2','Cake',1.80,'D');
INSERT INTO inventory (code, name, price, type) VALUES ('D3','Brownies',1.10,'D');
INSERT INTO inventory (code, name, price, type) VALUES ('D4','Jolly Ranger Tart',0.85,'D');
INSERT INTO inventory (code, name, price, type) VALUES ('D5','Apple Pie',2.50,'D');

COMMIT TRANSACTION;




