USE [master]
GO
/****** Object:  Database [EmployeeInfo]    Script Date: 12/24/2024 7:19:14 PM ******/
CREATE DATABASE [EmployeeInfo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmployeeInfo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\EmployeeInfo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmployeeInfo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\EmployeeInfo_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [EmployeeInfo] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeeInfo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmployeeInfo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeeInfo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeeInfo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeeInfo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeeInfo] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeeInfo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmployeeInfo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeeInfo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeInfo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeeInfo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeeInfo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeeInfo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeeInfo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeeInfo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeeInfo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmployeeInfo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeeInfo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeeInfo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmployeeInfo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmployeeInfo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeeInfo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmployeeInfo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmployeeInfo] SET RECOVERY FULL 
GO
ALTER DATABASE [EmployeeInfo] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeeInfo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmployeeInfo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmployeeInfo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmployeeInfo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmployeeInfo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmployeeInfo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EmployeeInfo', N'ON'
GO
ALTER DATABASE [EmployeeInfo] SET QUERY_STORE = ON
GO
ALTER DATABASE [EmployeeInfo] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [EmployeeInfo]
GO
/****** Object:  Schema [Hr]    Script Date: 12/24/2024 7:19:14 PM ******/
CREATE SCHEMA [Hr]
GO
/****** Object:  Table [Hr].[Department]    Script Date: 12/24/2024 7:19:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hr].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](100) NOT NULL,
	[ManagerId] [int] NULL,
	[Budget] [decimal](18, 0) NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hr].[Employee]    Script Date: 12/24/2024 7:19:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hr].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Phone] [varchar](15) NOT NULL,
	[Position] [nvarchar](255) NOT NULL,
	[JoinDate] [datetime2](7) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Employee_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Hr].[PerformanceReview]    Script Date: 12/24/2024 7:19:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Hr].[PerformanceReview](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[ReviewDate] [datetime2](7) NOT NULL,
	[ReviewScore] [int] NOT NULL,
	[ReviewNotes] [nvarchar](max) NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_PerformanceReview] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [Hr].[Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_Employee] FOREIGN KEY([ManagerId])
REFERENCES [Hr].[Employee] ([Id])
GO
ALTER TABLE [Hr].[Department] CHECK CONSTRAINT [FK_Department_Employee]
GO
ALTER TABLE [Hr].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentId])
REFERENCES [Hr].[Department] ([Id])
GO
ALTER TABLE [Hr].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
/****** Object:  StoredProcedure [Hr].[USP_CreateDepartment]    Script Date: 12/24/2024 7:19:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-12-22>
-- Description:	<Description,[Hr].[USP_CreateDepartment]>
-- =============================================
CREATE PROCEDURE [Hr].[USP_CreateDepartment]
(
 @DepartmentName NVARCHAR(255),
 @ManagerId NVARCHAR(50) NULL,
 @Budget DECIMAL(18,0)
)
AS
BEGIN
	IF EXISTS (SELECT DepartmentName FROM [Hr].[Department] WHERE LOWER(DepartmentName) = LOWER(@DepartmentName)) 
	BEGIN
	   SELECT 1 
	END
	ELSE
	BEGIN
		INSERT INTO [Hr].[Department]  
			(DepartmentName, ManagerId, Budget,Deleted)    
		VALUES    
			(@DepartmentName, @ManagerId, @Budget,0)
	END
END
GO
/****** Object:  StoredProcedure [Hr].[USP_CreateEmployee]    Script Date: 12/24/2024 7:19:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-12-22>
-- Description:	<Description,[Hr].[USP_CreateEmployee]>
-- =============================================
CREATE PROCEDURE [Hr].[USP_CreateEmployee]
(
 @Name NVARCHAR(255),
 @Email VARCHAR(100),
 @Phone VARCHAR(15),
 @Position NVARCHAR(255),
 @JoinDate DATETIME,
 @DepartmentId INT,
 @Status Bit
)
AS
BEGIN
	IF EXISTS (SELECT Phone FROM [Hr].[Employee] WHERE Phone = @Phone) 
	BEGIN
	   SELECT 1 
	END
	ELSE
	BEGIN
		INSERT INTO [Hr].[Employee]    
			(Name,Email,Phone,Position,JoinDate,DepartmentId, Status,Deleted)    
		VALUES    
			(@Name,@Email,@Phone,@Position,@JoinDate,@DepartmentId,@Status,0)
	END
END
GO
/****** Object:  StoredProcedure [Hr].[USP_CreateReview]    Script Date: 12/24/2024 7:19:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-12-23>
-- Description:	<Description,[Hr].[USP_CreateReview]>
-- =============================================
CREATE PROCEDURE [Hr].[USP_CreateReview]
(
 @EmployeeId INT,
 @ReviewDate DATETIME2,
 @ReviewScore INT,
 @ReviewNote NVARCHAR(MAX) NULL
)
AS
BEGIN
	IF EXISTS (
		SELECT EmployeeId 
		FROM [Hr].[PerformanceReview] 
		WHERE EmployeeId = @EmployeeId AND CAST(ReviewDate AS DATE) = CAST(@ReviewDate AS DATE)) 
	BEGIN
	   SELECT 1 
	END
	ELSE
	BEGIN
		INSERT INTO [Hr].[PerformanceReview]
			(EmployeeId, ReviewDate, ReviewScore, ReviewNotes, Deleted)    
		VALUES    
			(@EmployeeId, @ReviewDate, @ReviewScore, @ReviewNote, 0)
	END
END
GO
/****** Object:  StoredProcedure [Hr].[USP_DynamicQuery]    Script Date: 12/24/2024 7:19:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-12-22>
-- Description:	<Description,[Hr].[USP_GetAllEmployee]>
-- =============================================
CREATE PROCEDURE [Hr].[USP_DynamicQuery]
(
	@SkipRows int = 0,
	@TakeRows int = 5,
	@Name NVARCHAR(255) = '',
	@DepartmentId VARCHAR(2) = '',
	@Position VARCHAR(50) = '',
	@Score VARCHAR(5) = ''
)
AS        
BEGIN
DECLARE @SQL NVARCHAR(MAX)
SET @SQL='
	SELECT
		Emp.Id, Emp.Name, Emp.Email, Emp.Phone, Emp.Position, CONVERT(VARCHAR(25), CAST(Emp.JoinDate AS Date), 120)  AS FormatedDate, 
		Emp.DepartmentId,Emp.Status,Emp.Deleted,Dept.DepartmentName AS DepartmentName, PR.ReviewScore
	FROM
		[Hr].[Employee] AS Emp
		INNER JOIN [Hr].[Department] AS Dept ON Dept.Id = Emp.DepartmentId
		INNER JOIN [Hr].[PerformanceReview] AS PR ON PR.EmployeeId = Emp.Id'
SET @SQL +=' WHERE 1=1'  
IF (@Name <> '')                           
	BEGIN                          
		SET @SQL +=' AND Emp.Name LIKE'+'%'+ @Name+ '%'                          
	END
IF (@DepartmentId <> '')                           
	BEGIN                          
		SET @SQL +=' AND Emp.DepartmentId = '+ CAST(@DepartmentId AS INT)
	END
IF (@Position <> '')                           
	BEGIN                          
		SET @SQL +=' AND Emp.Position LIKE'+'%'+ @Position+ '%'                          
	END
--IF (@Score <> '')                           
--	BEGIN                          
--		SET @SQL +=' AND PR.PR.ReviewScore BETWEEN'+ '(SELECT Value FROM '+ String_split(@Score, '-'+')' + ' AND '+ @Score                
--	END

SET @SQL +='
	ORDER BY
			Emp.Id
	OFFSET @SkipRows ROWS
	FETCH NEXT @TakeRows ROWS ONLY'
	--PRINT(@SQL)                          
	EXEC (@SQL)   
END
GO
/****** Object:  StoredProcedure [Hr].[USP_GetAllDepartment]    Script Date: 12/24/2024 7:19:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-12-22>
-- Description:	<Description,[Hr].[USP_GetAllDepartment]>
-- =============================================
CREATE PROCEDURE [Hr].[USP_GetAllDepartment]
AS        
BEGIN
	SELECT
		Dept.Id, Dept.DepartmentName, Dept.Budget,ISNULL(Emp.Name,'') AS Manager,Dept.Deleted
	FROM
		[Hr].[Department] AS Dept
		LEFT JOIN [Hr].[Employee] AS Emp ON Emp.Id = Dept.ManagerId
END
GO
/****** Object:  StoredProcedure [Hr].[USP_GetAllEmployee]    Script Date: 12/24/2024 7:19:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-12-22>
-- Description:	<Description,[Hr].[USP_GetAllEmployee]>
-- =============================================
CREATE PROCEDURE [Hr].[USP_GetAllEmployee]
(
	@SkipRows int = 0,
	@TakeRows int = 5
)
AS        
BEGIN
	SELECT
		Emp.Id, emp.Name, Emp.Email, Emp.Phone, Emp.Position, CONVERT(VARCHAR(25), CAST(Emp.JoinDate AS Date), 120)  AS FormatedDate, 
		Emp.DepartmentId,Emp.Status,Emp.Deleted,Dept.DepartmentName AS DepartmentName, ISNULL(PR.ReviewScore, 0) AS ReviewScore
	FROM
		[Hr].[Employee] AS Emp
		INNER JOIN [Hr].[Department] AS Dept ON Dept.Id = Emp.DepartmentId
		LEFT JOIN [Hr].[PerformanceReview] AS PR ON PR.EmployeeId = Emp.Id
	ORDER BY
			Emp.Id
	OFFSET @SkipRows ROWS
	FETCH NEXT @TakeRows ROWS ONLY;
END
GO
/****** Object:  StoredProcedure [Hr].[USP_GetAllReview]    Script Date: 12/24/2024 7:19:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-12-23>
-- Description:	<Description,[Hr].[USP_GetAllReview]>
-- =============================================
CREATE PROCEDURE [Hr].[USP_GetAllReview]
AS        
BEGIN
	SELECT
		PR.Id, PR.EmployeeId, Emp.Name AS EmployeeName,CONVERT(VARCHAR(25), CAST(PR.ReviewDate AS Date), 120)  AS FormatedDate, 
		PR.ReviewScore, ISNULL(PR.ReviewNotes, '') AS ReviewNote, PR.Deleted
	FROM
		 [Hr].[PerformanceReview] AS PR
		LEFT JOIN [Hr].[Employee] AS Emp ON Emp.Id = PR.EmployeeId
END
GO
/****** Object:  StoredProcedure [Hr].[USP_GetAverageScore]    Script Date: 12/24/2024 7:19:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-12-23>
-- Description:	<Description,[Hr].[USP_GetAverageScore]>
-- =============================================
CREATE PROCEDURE [Hr].[USP_GetAverageScore]
AS        
BEGIN
	SELECT 
	Dept.DepartmentName, AVG(PR.ReviewScore) AS AverageScore
	FROM 
		[HR].[Department] AS Dept
		INNER JOIN HR.Employee AS Emp ON Dept.Id = Emp.DepartmentId
		INNER JOIN HR.PerformanceReview AS PR ON Emp.Id = PR.EmployeeId
	WHERE
		PR.Deleted = 0
	GROUP BY 
		Dept.DepartmentName
END
GO
/****** Object:  StoredProcedure [Hr].[USP_GetDepartmentById]    Script Date: 12/24/2024 7:19:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-12-22>
-- Description:	<Description,[Hr].[USP_GetDepartmentById]>
-- =============================================
CREATE PROCEDURE [Hr].[USP_GetDepartmentById]
(    
 @Id INT=0 
)
AS
BEGIN
	SELECT
		*
	FROM
		[Hr].[Department]
	WHERE
		Id = @Id
END
GO
/****** Object:  StoredProcedure [Hr].[USP_GetDrpEmployees]    Script Date: 12/24/2024 7:19:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-12-23>
-- Description:	<Description,[Hr].[USP_GetDrpEmployees]>
-- =============================================
CREATE PROCEDURE [Hr].[USP_GetDrpEmployees]
AS        
BEGIN
	SELECT
		Emp.Id, emp.Name
	FROM
		[Hr].[Employee] AS Emp
	WHERE
		Deleted = 0
	ORDER BY
			Emp.Id
END
GO
/****** Object:  StoredProcedure [Hr].[USP_GetEmployeeById]    Script Date: 12/24/2024 7:19:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-12-22>
-- Description:	<Description,[Hr].[USP_GetEmployeeById]>
-- =============================================
CREATE PROCEDURE [Hr].[USP_GetEmployeeById]
(    
 @Id INT=0 
)
AS
BEGIN
	SELECT
		Id, Name, Email, Phone, Position, CONVERT(VARCHAR(25), CAST(JoinDate AS Date), 120)  AS FormatedDate, 
		DepartmentId,Status
	FROM
		[Hr].[Employee]
	WHERE
		Id = @Id
END
GO
/****** Object:  StoredProcedure [Hr].[USP_GetReviewById]    Script Date: 12/24/2024 7:19:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-12-23>
-- Description:	<Description,[Hr].[USP_GetReviewById]>
-- =============================================
CREATE PROCEDURE [Hr].[USP_GetReviewById]
(    
 @Id INT = 0 
)
AS
BEGIN
	SELECT
		Id, EmployeeId, ISNULL(ReviewNotes, '') AS ReviewNote, ReviewScore,
		CONVERT(VARCHAR(25), CAST(ReviewDate AS Date), 120)  AS FormatedDate
	FROM
		[Hr].[PerformanceReview]
	WHERE
		Id = @Id
END
GO
/****** Object:  StoredProcedure [Hr].[USP_RemoveDepartment]    Script Date: 12/24/2024 7:19:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-12-22>
-- Description:	<Description,[Hr].[USP_RemoveDepartment]>
-- =============================================
CREATE PROCEDURE [Hr].[USP_RemoveDepartment]
(    
 @Id INT = 0 
)
AS
BEGIN
	UPDATE
		[Hr].[Department]
	SET
		Deleted = 1
	WHERE
		Id = @Id
END
GO
/****** Object:  StoredProcedure [Hr].[USP_RemoveEmployee]    Script Date: 12/24/2024 7:19:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-12-22>
-- Description:	<Description,[Hr].[USP_RemoveEmployee]>
-- =============================================
CREATE PROCEDURE [Hr].[USP_RemoveEmployee]
(    
 @Id INT = 0 
)
AS
BEGIN
	UPDATE [Hr].[Employee]
    SET 
		Deleted = 1
    WHERE 
		Id = @Id
END
GO
/****** Object:  StoredProcedure [Hr].[USP_RemoveReview]    Script Date: 12/24/2024 7:19:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-12-23>
-- Description:	<Description,[Hr].[USP_RemoveReview]>
-- =============================================
CREATE PROCEDURE [Hr].[USP_RemoveReview]
(    
 @Id INT = 0 
)
AS
BEGIN
	UPDATE
		[Hr].[PerformanceReview]
	SET
		Deleted = 1
	WHERE
		Id = @Id
END
GO
/****** Object:  StoredProcedure [Hr].[USP_UpdateDepartment]    Script Date: 12/24/2024 7:19:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-12-22>
-- Description:	<Description,[Hr].[USP_UpdateDepartment]>
-- =============================================
CREATE PROCEDURE [Hr].[USP_UpdateDepartment]
(
 @Id INT,
 @DepartmentName NVARCHAR(255),
 @ManagerId INT NULL,
 @Budget DECIMAL(18,0)
)
AS
BEGIN
	UPDATE [Hr].[Department]
    SET 
		DepartmentName = @DepartmentName,
		ManagerId = @ManagerId,
		Budget = @Budget
    WHERE 
		Id = @Id
END
GO
/****** Object:  StoredProcedure [Hr].[USP_UpdateEmployee]    Script Date: 12/24/2024 7:19:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-12-22>
-- Description:	<Description,[Hr].[USP_UpdateEmployee]>
-- =============================================
CREATE PROCEDURE [Hr].[USP_UpdateEmployee]
(
 @Id INT,
 @Name NVARCHAR(255),
 @Email VARCHAR(100),
 @Phone VARCHAR(15),
 @Position NVARCHAR(255),
 @JoinDate DATETIME,
 @DepartmentId INT,
 @Status Bit
)
AS
BEGIN
	UPDATE [Hr].[Employee]
    SET 
		Name = @Name,
		Email = @Email,
		Phone = @Phone,
		Position = @Position,
		JoinDate = @JoinDate,
		DepartmentId = @DepartmentId,
		Status = @Status
    WHERE 
		Id = @Id
END

GO
/****** Object:  StoredProcedure [Hr].[USP_UpdateReview]    Script Date: 12/24/2024 7:19:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,Biplob Hossain>
-- Create date: <Create Date,2024-12-23>
-- Description:	<Description,[Hr].[USP_UpdateReview]>
-- =============================================
CREATE PROCEDURE [Hr].[USP_UpdateReview]
(
 @Id INT,
 @EmployeeId INT,
 @ReviewDate DATETIME2,
 @ReviewScore INT,
 @ReviewNote NVARCHAR(MAX) NULL
)
AS
BEGIN
	UPDATE [Hr].[PerformanceReview]
    SET 
		EmployeeId = @EmployeeId,
		ReviewDate = @ReviewDate,
		ReviewScore = @ReviewScore,
		ReviewNotes = @ReviewNote
    WHERE 
		Id = @Id
END
GO
USE [master]
GO
ALTER DATABASE [EmployeeInfo] SET  READ_WRITE 
GO
