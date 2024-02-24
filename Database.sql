Create database Players
Use Players    
CREATE TABLE [dbo].[Player](
	[PlayerId] [int] PRIMARY KEY NOT NULL,
	[PlayerCategory] [varchar](50) NULL,
	[Salary] [decimal](18, 0) NULL,
	[Tax] [decimal](18, 0) NULL);

	CREATE TABLE [dbo].[Team](
	[TeamPlayerId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[TeamMasterId] [int] NULL,
	[ItemId] [int] NULL,
	[Salary] [decimal](18, 0) NULL,
	[NumberOfPlayers] [decimal](18, 0) NULL,
	[Tax] [decimal](18, 0) NULL,
	[TotalAmount] [decimal](18, 0) NULL);

	CREATE TABLE [dbo].[TeamMaster](
	[TeamId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[TeamName] [varchar](50) NULL,
	[Phone] [varchar](20) NULL,
	[Address] [nchar](10) NULL);


INSERT [dbo].[Player] ([PlayerId], [PlayerCategory], [Salary], [Tax]) VALUES (1, N'A', CAST(80000 AS Decimal(18, 0)), CAST(25 AS Decimal(18, 0)))
INSERT [dbo].[Player] ([PlayerId], [PlayerCategory], [Salary], [Tax]) VALUES (2, N'B', CAST(60000 AS Decimal(18, 0)), CAST(25 AS Decimal(18, 0)))
INSERT [dbo].[Player] ([PlayerId], [PlayerCategory], [Salary], [Tax]) VALUES (3, N'C', CAST(40000 AS Decimal(18, 0)), CAST(25 AS Decimal(18, 0)))
INSERT [dbo].[Player] ([PlayerId], [PlayerCategory], [Salary], [Tax]) VALUES (4, N'D', CAST(21000 AS Decimal(18, 0)), CAST(25 AS Decimal(18, 0)))
INSERT [dbo].[Player] ([PlayerId], [PlayerCategory], [Salary], [Tax]) VALUES (5, N'E', CAST(16000 AS Decimal(18, 0)), CAST(25 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[Team] ON 
INSERT [dbo].[Team] ([TeamPlayerId], [TeamMasterId], [PlayerId], [Salary], [NumberOfPlayers], [Tax], [TotalAmount]) VALUES (3, 1, 2, CAST(10 AS Decimal(18, 0)), CAST(2 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)), CAST(21 AS Decimal(18, 0)))
INSERT [dbo].[Team] ([TeamPlayerId], [TeamMasterId], [PlayerId], [Salary], [NumberOfPlayers], [Tax], [TotalAmount]) VALUES (4, 1, 1, CAST(5 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)), CAST(53 AS Decimal(18, 0)))
INSERT [dbo].[Team] ([TeamPlayerId], [TeamMasterId], [PlayerId], [Salary], [NumberOfPlayers], [Tax], [TotalAmount]) VALUES (5, 1, 3, CAST(15 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)), CAST(16 AS Decimal(18, 0)))
INSERT [dbo].[Team] ([TeamPlayerId], [TeamMasterId], [PlayerId], [Salary], [NumberOfPlayers], [Tax], [TotalAmount]) VALUES (8, 2, 5, CAST(800 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)), CAST(8 AS Decimal(18, 0)), CAST(864 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Team] OFF

SET IDENTITY_INSERT [dbo].[TeamMaster] ON 
INSERT [dbo].[TeamMaster] ([TeamId], [TeamName], [Phone], [Address]) VALUES (1, N'Dhaka', N'0123456789', N'Dhaka     ')
INSERT [dbo].[TeamMaster] ([TeamId], [TeamName], [Phone], [Address]) VALUES (2, N'Narsindi', N'01523697452', N'Narsindi  ')
SET IDENTITY_INSERT [dbo].[TeamMaster] OFF
