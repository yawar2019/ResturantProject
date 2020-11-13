USE [master]
GO
/****** Object:  Database [DB_Restaurent]    Script Date: 13/11/2020 07:22:02 ******/
CREATE DATABASE [DB_Restaurent]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_Restaurent', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DB_Restaurent.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DB_Restaurent_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DB_Restaurent_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DB_Restaurent] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Restaurent].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Restaurent] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_Restaurent] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_Restaurent] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_Restaurent] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_Restaurent] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_Restaurent] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DB_Restaurent] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_Restaurent] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_Restaurent] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_Restaurent] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_Restaurent] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_Restaurent] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_Restaurent] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_Restaurent] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_Restaurent] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_Restaurent] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_Restaurent] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_Restaurent] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_Restaurent] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_Restaurent] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_Restaurent] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_Restaurent] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_Restaurent] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_Restaurent] SET  MULTI_USER 
GO
ALTER DATABASE [DB_Restaurent] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_Restaurent] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_Restaurent] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_Restaurent] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DB_Restaurent] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DB_Restaurent]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 13/11/2020 07:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBL_CATEGORY]    Script Date: 13/11/2020 07:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_CATEGORY](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NULL,
	[DESCRIPTION] [varchar](max) NULL,
	[Enabled] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_TBL_CATEGORY_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_ITEMLIST]    Script Date: 13/11/2020 07:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_ITEMLIST](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CATEID] [int] NULL,
	[ITEMNAME] [varchar](50) NULL,
	[DESCRIPTION] [varchar](50) NULL,
	[PRICE] [float] NULL,
	[TYPE] [varchar](50) NULL,
	[ENABLED] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_TBL_ITEMLIST_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_LOGIN]    Script Date: 13/11/2020 07:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_LOGIN](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[RoleId] [int] NULL,
	[Password] [varchar](50) NULL,
	[EmailId] [varchar](50) NULL,
	[MobileNo] [varchar](50) NULL,
	[IsEnabled] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_TBL_LOGIN] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_ROLE]    Script Date: 13/11/2020 07:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_ROLE](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NULL,
	[RoleDescription] [varchar](50) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_TBL_ROLE] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 13/11/2020 07:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](75) NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [Name]) VALUES (1, N'customer')
SET IDENTITY_INSERT [dbo].[Roles] OFF
/****** Object:  StoredProcedure [dbo].[SP_DELETECATEGORY]    Script Date: 13/11/2020 07:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DELETECATEGORY]
@CID INT
AS
BEGIN
DELETE FROM TBL_CATEGORY WHERE ID=@CID
END


GO
/****** Object:  StoredProcedure [dbo].[SP_DELETEITEM]    Script Date: 13/11/2020 07:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
CREATE PROCEDURE [dbo].[SP_DELETEITEM]
@PID INT
AS
BEGIN
DELETE FROM TBL_ITEMLIST WHERE ID=@PID
END


GO
/****** Object:  StoredProcedure [dbo].[SP_DELETELOGIN]    Script Date: 13/11/2020 07:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
CREATE PROCEDURE [dbo].[SP_DELETELOGIN]
@USERID INT
AS
BEGIN
DELETE FROM TBL_LOGIN WHERE UserId=@USERID
END


GO
/****** Object:  StoredProcedure [dbo].[SP_DELETEROLE]    Script Date: 13/11/2020 07:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
CREATE PROCEDURE [dbo].[SP_DELETEROLE]
@ROLED INT
AS
BEGIN
DELETE FROM TBL_ROLE WHERE RoleId=@ROLED
END


GO
/****** Object:  StoredProcedure [dbo].[SP_GETCATEGORYDEATILS]    Script Date: 13/11/2020 07:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
CREATE PROCEDURE [dbo].[SP_GETCATEGORYDEATILS]
@CID INT,@CATEGORYNAME VARCHAR(50),@DESCRIPTION VARCHAR(50),@ENABLED BINARY(50)
AS
BEGIN
SELECT @CATEGORYNAME=CategoryName,@DESCRIPTION=DESCRIPTION,@ENABLED=Enabled FROM TBL_CATEGORY WHERE CID=@CID
END


GO
/****** Object:  StoredProcedure [dbo].[SP_GETITEMDEATILS]    Script Date: 13/11/2020 07:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
CREATE PROCEDURE [dbo].[SP_GETITEMDEATILS]
@CATEID INT,@ITEMNAME VARCHAR(50),@DESCRIPTION VARCHAR(50),@PRICE FLOAT,@TYPE VARCHAR(50),@ENABLED BINARY,@PID INT
AS
BEGIN
SELECT @CATEID=CATEID,@ITEMNAME=ITEMNAME,@DESCRIPTION=DESCRIPTION,@PRICE=PRICE,@TYPE=TYPE,@ENABLED=ENABLED FROM  TBL_ITEMLIST WHERE PID=@PID
END

GO
/****** Object:  StoredProcedure [dbo].[SP_INERTITEM]    Script Date: 13/11/2020 07:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
CREATE PROCEDURE [dbo].[SP_INERTITEM]
@CATEID INT,@ITEMNAME VARCHAR(50),@DESCRIPTION VARCHAR(50),@PRICE FLOAT,@TYPE VARCHAR(50),@ENABLED BIT,@CREATEDBY INT,@UPDATEDBY INT
AS
 BEGIN
 INSERT INTO TBL_ITEMLIST (CATEID,ITEMNAME,DESCRIPTION,PRICE,TYPE,ENABLED,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate) VALUES (@CATEID,@ITEMNAME,@DESCRIPTION,@PRICE,@TYPE,@ENABLED,@CREATEDBY,GETDATE(),@UPDATEDBY,GETDATE())
 END


GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTCATEGORY]    Script Date: 13/11/2020 07:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (ew Menu).SQL
CREATE PROCEDURE [dbo].[SP_INSERTCATEGORY]
@CATEGORYNAME VARCHAR(50),@DESCRIPTION VARCHAR(50),@ENABLED BIT,@CreatedBy int,@UpdatedBy int
AS
BEGIN
INSERT INTO TBL_CATEGORY (CategoryName,DESCRIPTION,Enabled,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate) VALUES (@CATEGORYNAME,@DESCRIPTION,@ENABLED,@CreatedBy,GETDATE(),@UpdatedBy,GETDATE())
END

GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTLOGIN]    Script Date: 13/11/2020 07:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
Create procedure [dbo].[SP_INSERTLOGIN]
@USERNAME VARCHAR(50),@ROLEID INT,@PASSWORD VARCHAR(50),@EMAILID VARCHAR(50),@MOLBILENO VARCHAR(50),@ISENABLED BIT,@CREATEDBY INT,@UPDTAEDBY INT
AS
BEGIN
INSERT INTO TBL_LOGIN (UserName,RoleId,Password,EmailId,MobileNo,IsEnabled,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate) VALUES (@USERNAME,@ROLEID,@PASSWORD,@EMAILID,@MOLBILENO,@ISENABLED,@CREATEDBY,GETDATE(),@UPDTAEDBY,GETDATE())
END


GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTROLE]    Script Date: 13/11/2020 07:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
CREATE PROCEDURE [dbo].[SP_INSERTROLE]
@ROLENAME VARCHAR(50),@ROLEDESCRIPTION VARCHAR(50),@CREATEDBY INT,@UPDATEDBY INT
AS
BEGIN
INSERT INTO TBL_ROLE (RoleName,RoleDescription,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate) VALUES (@ROLENAME,@ROLEDESCRIPTION,@CREATEDBY,GETDATE(),@UPDATEDBY,GETDATE())
END


GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATECATEGORY]    Script Date: 13/11/2020 07:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
CREATE PROCEDURE [dbo].[SP_UPDATECATEGORY]
@CID INT,@CATEGORYNAME VARCHAR(50),@DESCRIPTION VARCHAR(50),@ENABLED BIT,@CreatedBy INT,@UpdatedBy INT
AS
BEGIN
UPDATE TBL_CATEGORY SET CategoryName=@CATEGORYNAME,@DESCRIPTION=@DESCRIPTION,Enabled=@ENABLED,CreatedBy=@CreatedBy,CreatedDate=GETDATE(),UpdatedBy=@UpdatedBy,UpdatedDate=GETDATE() WHERE ID =@CID
END


GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATEITEM]    Script Date: 13/11/2020 07:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
CREATE PROCEDURE [dbo].[SP_UPDATEITEM]
@CATEID INT,@ITEMNAME VARCHAR(50),@DESCRIPTION VARCHAR(50),@PRICE FLOAT,@TYPE VARCHAR(50),@ENABLED BIT,@PID INT,@CREATEDBY INT,@UPDATEDBY INT
AS
 BEGIN
 UPDATE TBL_ITEMLIST SET CATEID=@CATEID,ITEMNAME=@ITEMNAME,DESCRIPTION=@DESCRIPTION,PRICE=@PRICE,TYPE=@TYPE,ENABLED=@ENABLED,CreatedBy=@CREATEDBY,CreatedDate=GETDATE(),UpdatedBy=@UPDATEDBY,UpdatedDate=GETDATE() WHERE ID=@PID
 END

GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATELOGIN]    Script Date: 13/11/2020 07:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
CREATE PROCEDURE [dbo].[SP_UPDATELOGIN]
@USERNAME VARCHAR(50),@ROLEID INT,@PASSWORD VARCHAR(50),@EMAILID VARCHAR(50),@MOLBILENO VARCHAR(50),@ISENABLED BIT,@CREATEDBY INT,@UPDTAEDBY INT,@USERID INT
AS
BEGIN
UPDATE TBL_LOGIN SET UserName=@USERNAME,RoleId=@ROLEID,Password=@PASSWORD,EmailId=@EMAILID,MobileNo=@MOLBILENO,IsEnabled=@ISENABLED,CreatedBy=@CREATEDBY,CreatedDate=GETDATE(),UpdatedBy=@UPDTAEDBY,UpdatedDate=GETDATE() where UserId=@USERID
END

GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATEROLE]    Script Date: 13/11/2020 07:22:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
CREATE PROCEDURE [dbo].[SP_UPDATEROLE]
@ROLEID INT,@ROLENAME VARCHAR(50),@ROLEDESCRIPTION VARCHAR(50),@CREATEDBY INT,@UPDATEDBY INT
AS
BEGIN



UPDATE TBL_ROLE SET RoleName=@ROLENAME,RoleDescription=@ROLEDESCRIPTION,CreatedBy=@CREATEDBY,CreatedDate=GETDATE(),UpdatedBy=@UPDATEDBY,UpdatedDate=GETDATE() WHERE RoleId=@ROLEID
END


GO
USE [master]
GO
ALTER DATABASE [DB_Restaurent] SET  READ_WRITE 
GO
