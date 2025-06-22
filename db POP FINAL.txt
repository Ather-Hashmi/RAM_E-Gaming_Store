CREATE TABLE [Games] (
	GameID integer NOT NULL,
	GameName varchar(50),
	Developedby_ID integer,
	ESBR_Rating varchar(20),
	Data_for_Download varbinary(20),
	Category integer,
	DLC integer,
	Thumbnail_Image binary,
	Price integer,
	dicount integer,
	TotalDownload integer,
	AvgDailyPlayers integer,
	ActivePlayer integer,
  CONSTRAINT [PK_GAMES] PRIMARY KEY CLUSTERED
  (
  [GameID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Category] (
	CategoryID integer NOT NULL,
	Category_Name varchar(20),
	Category_Description varchar(20),
  CONSTRAINT [PK_CATEGORY] PRIMARY KEY CLUSTERED
  (
  [CategoryID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Game_Images/_Videos] (
	GameID integer NOT NULL,
	[images/video_snip] varchar(20),
	ImageID integer NOT NULL,
  CONSTRAINT [CK_Game_Images/_Videos] PRIMARY KEY (GameID,ImageID)
)
GO
CREATE TABLE [Published_By] (
	Developer_ID integer NOT NULL,
	Name varchar(20) NOT NULL,
	Email varchar(20) NOT NULL,
	Password varchar(20) NOT NULL,
  CONSTRAINT [PK_PUBLISHED_BY] PRIMARY KEY CLUSTERED
  (
  [Developer_ID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Edition/_Package] (
	Package_ID integer NOT NULL,
	Package_Name varchar(20) NOT NULL,
	Price integer NOT NULL,
  CONSTRAINT [PK_EDITION/_PACKAGE] PRIMARY KEY CLUSTERED
  (
  [Package_ID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Edition_Games] (
	PackageID integer NOT NULL,
	Game_ID integer NOT NULL,
  CONSTRAINT  [CK_edition_Games] PRIMARY KEY (PackageID, Game_ID)

)
GO
CREATE TABLE [Featured] (
	GameID integer NOT NULL,
	FeatureID integer NOT NULL,
	FeatureFrom_Date date,
	FeatureTill_Date date,
  CONSTRAINT [PK_FEATURED] PRIMARY KEY CLUSTERED
  (
  [FeatureID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Users] (
	Users_Tag integer NOT NULL,
	Email varchar(20) NOT NULL,
	Password varchar(20) NOT NULL,
	wallet_amount float,
	develop_id integer,
  CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED
  (
  [Users_Tag] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
Create TABLE [Purchase_History] (
	UserID integer NOT NULL,
	PurchaseID integer NOT NULL,
	Purchase_Date datetime NOT NULL,
  CONSTRAINT  [CK_Purchase_History] PRIMARY KEY (UserID,PurchaseID)

  )
GO
CREATE TABLE [Shopping_Cart] (
	PurchaseID integer NOT NULL,
	User_ID integer NOT NULL,
	Discount integer NOT NULL,
	Total_Price integer NOT NULL,
  CONSTRAINT [PK_SHOPPING_CART] PRIMARY KEY CLUSTERED
  (
  [PurchaseID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Purchase_Contents] (
	Purchase_ID integer NOT NULL,
	Game_ID integer NOT NULL,
	Package_ID integer NOT NULL,
    CONSTRAINT  [CK_Purchase_Contents] PRIMARY KEY (Purchase_ID,Game_ID)
)
GO
CREATE TABLE [Recently_Viewed] (
	ViewDate datetime NOT NULL,
	Viewed_by_UserID integer NOT NULL,
	GameId_Viewed integer NOT NULL,
    CONSTRAINT  [CK_Recently_Viewed] PRIMARY KEY (ViewDate,Viewed_by_UserID)
)
GO
CREATE TABLE [Reviews] (
	UserID integer NOT NULL,
	Review_ID integer NOT NULL,
	GameID integer NOT NULL,
	Rating integer NOT NULL,
  CONSTRAINT  [CK_Reviews] PRIMARY KEY (UserID,Review_ID)
)
GO

ALTER TABLE [Games] WITH CHECK ADD CONSTRAINT [Games_fk1] FOREIGN KEY ([Developedby_ID]) REFERENCES [Published_By]([Developer_ID])
ON UPDATE CASCADE
GO
ALTER TABLE [Games] CHECK CONSTRAINT [Games_fk1]
GO
ALTER TABLE [Games] WITH CHECK ADD CONSTRAINT [Games_fk2] FOREIGN KEY ([Category]) REFERENCES [Category]([CategoryID])
ON UPDATE CASCADE
GO
ALTER TABLE [Games] CHECK CONSTRAINT [Games_fk2]
GO
ALTER TABLE [Games] WITH CHECK ADD CONSTRAINT [Games_fk3] FOREIGN KEY ([DLC]) REFERENCES [Games]([GameID])
ON UPDATE No Action
GO
ALTER TABLE [Games] CHECK CONSTRAINT [Games_fk3]
GO


ALTER TABLE [Game_Images/_Videos] WITH CHECK ADD CONSTRAINT [Game_Images/_Videos_fk0] FOREIGN KEY ([GameID]) REFERENCES [Games]([GameID])
ON UPDATE CASCADE
GO
ALTER TABLE [Game_Images/_Videos] CHECK CONSTRAINT [Game_Images/_Videos_fk0]
GO



ALTER TABLE [Edition_Games] WITH CHECK ADD CONSTRAINT [Edition_Games_fk0] FOREIGN KEY ([PackageID]) REFERENCES [Edition/_Package]([Package_ID])
ON UPDATE CASCADE
GO
ALTER TABLE [Edition_Games] CHECK CONSTRAINT [Edition_Games_fk0]
GO
ALTER TABLE [Edition_Games] WITH CHECK ADD CONSTRAINT [Edition_Games_fk1] FOREIGN KEY ([Game_ID]) REFERENCES [Games]([GameID])
ON UPDATE CASCADE
GO
ALTER TABLE [Edition_Games] CHECK CONSTRAINT [Edition_Games_fk1]
GO

ALTER TABLE [Featured] WITH CHECK ADD CONSTRAINT [Featured_fk0] FOREIGN KEY ([GameID]) REFERENCES [Games]([GameID])
ON UPDATE CASCADE
GO
ALTER TABLE [Featured] CHECK CONSTRAINT [Featured_fk0]
GO

ALTER TABLE [Users] WITH CHECK ADD CONSTRAINT [Users_fk0] FOREIGN KEY ([develop_id]) REFERENCES [Published_By]([Developer_ID])
ON UPDATE CASCADE
GO
ALTER TABLE [Users] CHECK CONSTRAINT [Users_fk0]
GO

ALTER TABLE [Purchase_History] WITH CHECK ADD CONSTRAINT [Purchase_History_fk0] FOREIGN KEY ([UserID]) REFERENCES [Users]([Users_Tag])
ON UPDATE CASCADE
GO
ALTER TABLE [Purchase_History] CHECK CONSTRAINT [Purchase_History_fk0]
GO
ALTER TABLE [Purchase_History] WITH CHECK ADD CONSTRAINT [Purchase_History_fk1] FOREIGN KEY ([PurchaseID]) REFERENCES [Shopping_Cart]([PurchaseID])
ON UPDATE CASCADE
GO
ALTER TABLE [Purchase_History] CHECK CONSTRAINT [Purchase_History_fk1]
GO

ALTER TABLE [Shopping_Cart] WITH CHECK ADD CONSTRAINT [Shopping_Cart_fk0] FOREIGN KEY ([User_ID]) REFERENCES [Users]([Users_Tag])
ON UPDATE No Action
GO
ALTER TABLE [Shopping_Cart] CHECK CONSTRAINT [Shopping_Cart_fk0]
GO

ALTER TABLE [Purchase_Contents] WITH CHECK ADD CONSTRAINT [Purchase_Contents_fk0] FOREIGN KEY ([Purchase_ID]) REFERENCES [Shopping_Cart]([PurchaseID])
ON UPDATE CASCADE
GO
ALTER TABLE [Purchase_Contents] CHECK CONSTRAINT [Purchase_Contents_fk0]
GO
ALTER TABLE [Purchase_Contents] WITH CHECK ADD CONSTRAINT [Purchase_Contents_fk1] FOREIGN KEY ([Game_ID]) REFERENCES [Games]([GameID])
ON UPDATE CASCADE
GO
ALTER TABLE [Purchase_Contents] CHECK CONSTRAINT [Purchase_Contents_fk1]
GO
ALTER TABLE [Purchase_Contents] WITH CHECK ADD CONSTRAINT [Purchase_Contents_fk2] FOREIGN KEY ([Package_ID]) REFERENCES [Edition/_Package]([Package_ID])
ON UPDATE CASCADE
GO
ALTER TABLE [Purchase_Contents] CHECK CONSTRAINT [Purchase_Contents_fk2]
GO

ALTER TABLE [Recently_Viewed] WITH CHECK ADD CONSTRAINT [Recently_Viewed_fk0] FOREIGN KEY ([Viewed_by_UserID]) REFERENCES [Users]([Users_Tag])
ON UPDATE CASCADE
GO
ALTER TABLE [Recently_Viewed] CHECK CONSTRAINT [Recently_Viewed_fk0]
GO
ALTER TABLE [Recently_Viewed] WITH CHECK ADD CONSTRAINT [Recently_Viewed_fk1] FOREIGN KEY ([GameId_Viewed]) REFERENCES [Games]([GameID])
ON UPDATE NO ACTION
GO
ALTER TABLE [Recently_Viewed] CHECK CONSTRAINT [Recently_Viewed_fk1]
GO

ALTER TABLE [Reviews] WITH CHECK ADD CONSTRAINT [Reviews_fk0] FOREIGN KEY ([UserID]) REFERENCES [Users]([Users_Tag])
ON UPDATE CASCADE
GO
ALTER TABLE [Reviews] CHECK CONSTRAINT [Reviews_fk0]
GO
ALTER TABLE [Reviews] WITH CHECK ADD CONSTRAINT [Reviews_fk1] FOREIGN KEY ([GameID]) REFERENCES [Games]([GameID])
ON UPDATE No ACTION
GO
ALTER TABLE [Reviews] CHECK CONSTRAINT [Reviews_fk1]
GO

--select * from Category;

insert into Category
values (1, 'Adventure', 'Exploration')
insert into Category
values(2, 'Horror', 'scary boo')
insert into Category
values(3, 'Fighting', 'phadda')
insert into Category
values(4, 'FPS', 'gun fight');


--select * from Users

insert into Users
values(1,'ather@game.pk', '1234',20, null)
insert into Users
values(2,'muzz@game.pk', '2231',30, 1)
insert into Users
values(3,'razi@game.pk', '1531',20, null)
insert into Users
values(4,'anaconda@game.pk', '1312',0, null)
insert into Users
values(5,'Zimba@game.pk', '1531',null, null)



--select * from Published_By

insert into Published_By
values (1, 'Muzz' , 'muzz@game.pk', '2231')
insert into Published_By
values (2, 'Rocky', 'Rockstar@game.pk', '3321')


--select * from Games


insert into Games
values(1, 'Clash of Clan', 1, null,null,1,null, null, null, null, 10000, 214244, 500)
insert into Games
values(2, 'WWE 2k22', null, 'T',null,3,null, null, 50, null,2000, 42, 4)
insert into Games
values(3, 'CS GO', null, 'M' ,null,4,null, null, null, null,20333,1042, 40)
insert into Games
values(4, 'Fortnite', null, 'E10+',null,4,null, null, null, null,209900, 42, 4)
insert into Games
values(5, 'AC Creed IV', null, 'M',null,1,10, null, 40, 12,500, 42, 15)
insert into Games
values(6, 'Resident Evil 2', null, 'M',null,2,null, null, 40, 0,500, 42, 15)
insert into Games
values(7, 'Super Mario', null, 'E',null,1,null, null, 20, 5,100, 22, 15)
insert into Games
values(8, 'Among Us', null, 'E',null,1,null, null, 0, 0,10000, 2, 0)
insert into Games
values(9, 'Fall Guys', null, 'E',null,1,null, null, 10, 0,10022, 242, 155)
insert into Games
values(10, 'AC Creed IV: Freedom Cry', null, 'E',null,1,null, null, 10, 0,10022, 242, 155)

insert into Games
values(11, 'Alan Wake', null, 'E',null,2,null, null, 10, 0,10022, 242, 155)
insert into Games
values(12, 'Scary Doll', null, 'E',null,2,null, null, 10, 0,10022, 242, 155)

insert into Games
values(13, 'Hu pigeon Fight', null, 'E',null,3,null, null, 10, 0,10, 242, 155)
insert into Games
values(14, 'Tekken 7', null, 'E',null,2,null, null, 30, 0,10022, 242, 155)
insert into Games
values(15, 'Tekken 7', null, 'E',null,3,null, null, 30, 0,10022, 242, 155)

--select * from Featured

insert into Featured
values(1, 1, convert(date, GetDate()), '02-12-2022')
insert into Featured
values(3, 2, convert(date,GetDate()),  '02-12-2022')
insert into Featured 
values( 5, 3, '03-03-2022', convert(date, GetDate()))


select * from  [Edition/_Package]

insert into [Edition/_Package]
values ( 1,'Deluxe', 15)

insert into [Edition/_Package]
values ( 2,'Big Bang', 10)

insert into [Edition/_Package]
values ( 3,'Luxury', 25)


select * from Edition_Games
 
insert into Edition_Games
values( 2, 1)
insert into Edition_Games
values( 2, 6)
insert into Edition_Games
values( 3, 5)
insert into Edition_Games
values( 1, 3)
insert into Edition_Games
values( 1, 2)
insert into Edition_Games
values(1,7)

select * from Reviews
insert into Reviews
values(3,1,2,5)
insert into Reviews
values(3,2,4,2) 
insert into Reviews
values(1,1,5,4)
insert into Reviews
values(1,2,4,3) 
insert into Reviews
values(1,3,3,5)
insert into Reviews
values(1,4,7,2)
insert into Reviews
values(4,1,6,1)

select * from [Game_Images/_Videos]
insert into [Game_Images/_Videos]
values (1, null, 1), (2,null,1) , (3,null,1),(4,null,1), (5,null,1) ,(6,null,1) ,(7,null,1) ,(8,null,1) ,(9,null,1)