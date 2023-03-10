CREATE TABLE IF NOT EXISTS "User"(
    LastName  varchar(200),
	FirstName varchar(80) NOT NULL,
	ID integer GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY
);

CREATE TABLE IF NOT EXISTS "Goods"(
    Description  varchar(200),
	Name varchar(80) NOT NULL,
	Price decimal,
	ID integer GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY
);


CREATE TABLE IF NOT EXISTS "Basket" (
	UserId integer,
	GoodsId integer,
    FOREIGN KEY (UserId) REFERENCES "user" (ID),
	FOREIGN KEY (GoodsId) REFERENCES Goods (ID),
	ID integer GENERATED BY DEFAULT AS IDENTITY PRIMARY KEY
);

INSERT INTO "User" VALUES ('LastName1', 'FirstName1');
INSERT INTO "User" VALUES ('LastName2', 'FirstName2');
INSERT INTO "User" VALUES ('LastName3', 'FirstName3');
INSERT INTO "User" VALUES ('LastName4', 'FirstName4');
INSERT INTO "User" VALUES ('LastName5', 'FirstName5');

INSERT INTO "Goods" VALUES ('Description1', 'Name1', 10);
INSERT INTO "Goods" VALUES ('Description2', 'Name2', 20);
INSERT INTO "Goods" VALUES ('Description3', 'Name3', 30);
INSERT INTO "Goods" VALUES ('Description4', 'Name4', 40);
INSERT INTO "Goods" VALUES ('Description5', 'Name5', 50);

INSERT INTO "Basket" VALUES (1, 1);
INSERT INTO "Basket" VALUES (1, 2);
INSERT INTO "Basket" VALUES (3, 2);
INSERT INTO "Basket" VALUES (3, 1);
INSERT INTO "Basket" VALUES (4, 5);

SELECT table_name FROM information_schema.tables WHERE table_schema NOT IN('information_schema','pg_catalog');