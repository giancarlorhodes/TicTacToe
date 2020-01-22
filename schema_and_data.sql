USE [master]
GO
/****** Object:  Database [TicTacToe]    Script Date: 1/20/2020 12:58:50 PM ******/
CREATE DATABASE [TicTacToe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TicTacToe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\TicTacToe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TicTacToe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\TicTacToe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TicTacToe] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TicTacToe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TicTacToe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TicTacToe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TicTacToe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TicTacToe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TicTacToe] SET ARITHABORT OFF 
GO
ALTER DATABASE [TicTacToe] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TicTacToe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TicTacToe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TicTacToe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TicTacToe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TicTacToe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TicTacToe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TicTacToe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TicTacToe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TicTacToe] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TicTacToe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TicTacToe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TicTacToe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TicTacToe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TicTacToe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TicTacToe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TicTacToe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TicTacToe] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TicTacToe] SET  MULTI_USER 
GO
ALTER DATABASE [TicTacToe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TicTacToe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TicTacToe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TicTacToe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TicTacToe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TicTacToe] SET QUERY_STORE = OFF
GO
USE [TicTacToe]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 1/20/2020 12:58:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[PlayerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[BirthDate] [datetime2](7) NULL,
	[Gender] [varchar](1) NULL,
 CONSTRAINT [PK__Player__4A4E74A83BF03788] PRIMARY KEY CLUSTERED 
(
	[PlayerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlayerStats]    Script Date: 1/20/2020 12:58:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayerStats](
	[PlayerStatsID] [int] IDENTITY(1,1) NOT NULL,
	[Wins] [int] NOT NULL,
	[Losses] [int] NOT NULL,
	[Draws] [int] NOT NULL,
	[PlayerID_FK] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PlayerStatsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_player_playerstats]    Script Date: 1/20/2020 12:58:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_player_playerstats] AS
	
	SELECT PlayerID, FirstName, LastName, ps.Wins, ps.Losses, ps.Draws 	
	FROM Player p
	LEFT JOIN PlayerStats ps ON ps.PlayerID_FK = p.PlayerID;
GO
/****** Object:  Table [dbo].[GameState]    Script Date: 1/20/2020 12:58:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameState](
	[GameStateID] [int] IDENTITY(1,1) NOT NULL,
	[GameName] [varchar](50) NULL,
	[PlayerID_FK_1] [int] NULL,
	[PlayerID_FK_2] [int] NULL,
	[BoardSpace1] [varchar](1) NULL,
	[BoardSpace2] [varchar](1) NULL,
	[BoardSpace3] [varchar](1) NULL,
	[BoardSpace4] [varchar](1) NULL,
	[BoardSpace5] [varchar](1) NULL,
	[BoardSpace6] [varchar](1) NULL,
	[BoardSpace7] [varchar](1) NULL,
	[BoardSpace8] [varchar](1) NULL,
	[BoardSpace9] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[GameStateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[GameState] ON 

INSERT [dbo].[GameState] ([GameStateID], [GameName], [PlayerID_FK_1], [PlayerID_FK_2], [BoardSpace1], [BoardSpace2], [BoardSpace3], [BoardSpace4], [BoardSpace5], [BoardSpace6], [BoardSpace7], [BoardSpace8], [BoardSpace9]) VALUES (1, N'GR VS. JS 01-14-2020', 2, 6, N'_', N'_', N'_', N'_', N'_', N'_', N'_', N'_', N'_')
INSERT [dbo].[GameState] ([GameStateID], [GameName], [PlayerID_FK_1], [PlayerID_FK_2], [BoardSpace1], [BoardSpace2], [BoardSpace3], [BoardSpace4], [BoardSpace5], [BoardSpace6], [BoardSpace7], [BoardSpace8], [BoardSpace9]) VALUES (2, N'Tim Smith VS. Tim Bixler 01-14-2020', 12, 13, N'X', N'O', N'X', N'_', N'O', N'X', N'O', N'_', N'X')
SET IDENTITY_INSERT [dbo].[GameState] OFF
SET IDENTITY_INSERT [dbo].[Player] ON 

INSERT [dbo].[Player] ([PlayerID], [FirstName], [LastName], [BirthDate], [Gender]) VALUES (2, N'Giancarlo', N'Rhodes', CAST(N'2000-01-01T00:00:00.0000000' AS DateTime2), N'M')
INSERT [dbo].[Player] ([PlayerID], [FirstName], [LastName], [BirthDate], [Gender]) VALUES (6, N'Joe', N'Smith', NULL, NULL)
INSERT [dbo].[Player] ([PlayerID], [FirstName], [LastName], [BirthDate], [Gender]) VALUES (7, N'Jill', N'Watson', CAST(N'1975-06-17T00:00:00.0000000' AS DateTime2), N'F')
INSERT [dbo].[Player] ([PlayerID], [FirstName], [LastName], [BirthDate], [Gender]) VALUES (8, N'Dillan', N'Adams', NULL, NULL)
INSERT [dbo].[Player] ([PlayerID], [FirstName], [LastName], [BirthDate], [Gender]) VALUES (9, N'Heather', N'Wells', NULL, NULL)
INSERT [dbo].[Player] ([PlayerID], [FirstName], [LastName], [BirthDate], [Gender]) VALUES (10, N'Colton', N'Smith', NULL, NULL)
INSERT [dbo].[Player] ([PlayerID], [FirstName], [LastName], [BirthDate], [Gender]) VALUES (11, N'Joe', N'Smith', NULL, NULL)
INSERT [dbo].[Player] ([PlayerID], [FirstName], [LastName], [BirthDate], [Gender]) VALUES (12, N'Tim', N'Smith', NULL, NULL)
INSERT [dbo].[Player] ([PlayerID], [FirstName], [LastName], [BirthDate], [Gender]) VALUES (13, N'Tim', N'Bixler', NULL, NULL)
INSERT [dbo].[Player] ([PlayerID], [FirstName], [LastName], [BirthDate], [Gender]) VALUES (14, N'Lonnie', N'Hansen', CAST(N'1932-02-17T00:00:00.0000000' AS DateTime2), N'M')
INSERT [dbo].[Player] ([PlayerID], [FirstName], [LastName], [BirthDate], [Gender]) VALUES (15, N'Jamie', N'Decoske', CAST(N'1965-11-02T00:00:00.0000000' AS DateTime2), N'M')
SET IDENTITY_INSERT [dbo].[Player] OFF
SET IDENTITY_INSERT [dbo].[PlayerStats] ON 

INSERT [dbo].[PlayerStats] ([PlayerStatsID], [Wins], [Losses], [Draws], [PlayerID_FK]) VALUES (3, 0, 0, 0, 2)
INSERT [dbo].[PlayerStats] ([PlayerStatsID], [Wins], [Losses], [Draws], [PlayerID_FK]) VALUES (7, 10, 12, 2, 6)
INSERT [dbo].[PlayerStats] ([PlayerStatsID], [Wins], [Losses], [Draws], [PlayerID_FK]) VALUES (8, 2, 3, 0, 7)
INSERT [dbo].[PlayerStats] ([PlayerStatsID], [Wins], [Losses], [Draws], [PlayerID_FK]) VALUES (9, 22, 31, 13, 8)
SET IDENTITY_INSERT [dbo].[PlayerStats] OFF
ALTER TABLE [dbo].[GameState] ADD  DEFAULT ('_') FOR [BoardSpace1]
GO
ALTER TABLE [dbo].[GameState] ADD  DEFAULT ('_') FOR [BoardSpace2]
GO
ALTER TABLE [dbo].[GameState] ADD  DEFAULT ('_') FOR [BoardSpace3]
GO
ALTER TABLE [dbo].[GameState] ADD  DEFAULT ('_') FOR [BoardSpace4]
GO
ALTER TABLE [dbo].[GameState] ADD  DEFAULT ('_') FOR [BoardSpace5]
GO
ALTER TABLE [dbo].[GameState] ADD  DEFAULT ('_') FOR [BoardSpace6]
GO
ALTER TABLE [dbo].[GameState] ADD  DEFAULT ('_') FOR [BoardSpace7]
GO
ALTER TABLE [dbo].[GameState] ADD  DEFAULT ('_') FOR [BoardSpace8]
GO
ALTER TABLE [dbo].[GameState] ADD  DEFAULT ('_') FOR [BoardSpace9]
GO
ALTER TABLE [dbo].[PlayerStats] ADD  DEFAULT ((0)) FOR [Wins]
GO
ALTER TABLE [dbo].[PlayerStats] ADD  DEFAULT ((0)) FOR [Losses]
GO
ALTER TABLE [dbo].[PlayerStats] ADD  DEFAULT ((0)) FOR [Draws]
GO
ALTER TABLE [dbo].[GameState]  WITH CHECK ADD  CONSTRAINT [FK_PlayerID1_To_Player] FOREIGN KEY([PlayerID_FK_1])
REFERENCES [dbo].[Player] ([PlayerID])
GO
ALTER TABLE [dbo].[GameState] CHECK CONSTRAINT [FK_PlayerID1_To_Player]
GO
ALTER TABLE [dbo].[GameState]  WITH CHECK ADD  CONSTRAINT [FK_PlayerID2_To_Player] FOREIGN KEY([PlayerID_FK_2])
REFERENCES [dbo].[Player] ([PlayerID])
GO
ALTER TABLE [dbo].[GameState] CHECK CONSTRAINT [FK_PlayerID2_To_Player]
GO
ALTER TABLE [dbo].[PlayerStats]  WITH CHECK ADD  CONSTRAINT [FK_PlayerStats_To_Player] FOREIGN KEY([PlayerID_FK])
REFERENCES [dbo].[Player] ([PlayerID])
GO
ALTER TABLE [dbo].[PlayerStats] CHECK CONSTRAINT [FK_PlayerStats_To_Player]
GO
/****** Object:  StoredProcedure [dbo].[sp_delete_player]    Script Date: 1/20/2020 12:58:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_delete_player]
	-- Add the parameters for the stored procedure here
		@parm_playerid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Player
	WHERE PlayerID = @parm_playerid;

END
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_player]    Script Date: 1/20/2020 12:58:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Giancarlo Rhodes
-- Create date: 1/15/2020
-- Description:	used to create a new player
-- =============================================
CREATE PROCEDURE [dbo].[sp_insert_player] 
	-- Add the parameters for the stored procedure here
	@parm_firstname varchar(50), 
	@parm_lastname varchar(50),
	@parm_birthdate datetime2,
	@parm_gender varchar(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>

	INSERT INTO Player (FirstName, LastName, BirthDate, Gender)
	VALUES (@parm_firstname, @parm_lastname, @parm_birthdate, @parm_gender);

END
GO
/****** Object:  StoredProcedure [dbo].[sp_select_all_players]    Script Date: 1/20/2020 12:58:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_select_all_players] 
	-- Add the parameters for the stored procedure here
	@parm_playerid int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	IF (@parm_playerid <> 0)
	BEGIN
		SELECT 
			[PlayerID]
			,[FirstName]
			,[LastName]
			,[BirthDate]
			,[Gender]
		FROM [TicTacToe].[dbo].[Player]
		WHERE PlayerID = @parm_playerid
	END
	ELSE
	BEGIN
		SELECT 
			 [PlayerID]
			,[FirstName]
			,[LastName]
			,[BirthDate]
			,[Gender]
		FROM [TicTacToe].[dbo].[Player]
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_update_player]    Script Date: 1/20/2020 12:58:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Giancarlo Rhodes
-- Create date: 1/15/2020
-- Description:	used to create a new player
-- =============================================
CREATE PROCEDURE [dbo].[sp_update_player] 
	-- Add the parameters for the stored procedure here
	@parm_playerid int,
	@parm_firstname varchar(50), 
	@parm_lastname varchar(50),
	@parm_birthdate datetime,
	@parm_gender varchar(1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>

	UPDATE  Player SET FirstName = @parm_firstname, LastName = @parm_lastname, 
	BirthDate = @parm_birthdate, Gender = @parm_gender
	WHERE PlayerID = @parm_playerid;

END
GO
USE [master]
GO
ALTER DATABASE [TicTacToe] SET  READ_WRITE 
GO
