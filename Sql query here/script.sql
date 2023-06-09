USE [master]
GO
/****** Object:  Database [Highschool]    Script Date: 2023-02-05 20:05:16 ******/
CREATE DATABASE [Highschool]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Highschool', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\Highschool.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Highschool_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\Highschool_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Highschool] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Highschool].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Highschool] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Highschool] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Highschool] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Highschool] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Highschool] SET ARITHABORT OFF 
GO
ALTER DATABASE [Highschool] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Highschool] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Highschool] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Highschool] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Highschool] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Highschool] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Highschool] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Highschool] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Highschool] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Highschool] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Highschool] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Highschool] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Highschool] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Highschool] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Highschool] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Highschool] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Highschool] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Highschool] SET RECOVERY FULL 
GO
ALTER DATABASE [Highschool] SET  MULTI_USER 
GO
ALTER DATABASE [Highschool] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Highschool] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Highschool] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Highschool] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Highschool] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Highschool] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Highschool', N'ON'
GO
ALTER DATABASE [Highschool] SET QUERY_STORE = ON
GO
ALTER DATABASE [Highschool] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Highschool]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 2023-02-05 20:05:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[ID] [int] NOT NULL,
	[Name] [varchar](255) NULL,
	[TeacherCourseSalary] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grades]    Script Date: 2023-02-05 20:05:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grades](
	[ID] [int] NOT NULL,
	[StudentID] [int] NULL,
	[CourseID] [int] NULL,
	[TeacherID] [int] NULL,
	[Grade] [int] NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK__Grades__3214EC2759666EF3] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personnel]    Script Date: 2023-02-05 20:05:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personnel](
	[ID] [int] NOT NULL,
	[Name] [varchar](255) NULL,
	[Position] [varchar](255) NULL,
	[RegisterDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 2023-02-05 20:05:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[ID] [int] NOT NULL,
	[Name] [varchar](255) NULL,
	[Class] [varchar](255) NULL,
	[PersonalNumber] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK__Grades__CourseID__4222D4EF] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([ID])
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK__Grades__CourseID__4222D4EF]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK__Grades__StudentI__412EB0B6] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([ID])
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK__Grades__StudentI__412EB0B6]
GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK__Grades__TeacherI__4316F928] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Personnel] ([ID])
GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK__Grades__TeacherI__4316F928]
GO
/****** Object:  StoredProcedure [dbo].[AddGrade]    Script Date: 2023-02-05 20:05:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddGrade]
(
    @studentId INT,
    @gradeDate DATETIME,
    @enteredBy INT,
    @courseId INT,
    @grade INT
)
AS
BEGIN
    DECLARE @newId INT

    SELECT @newId = COALESCE(MAX(ID), 0) + 1
    FROM Grades

    INSERT INTO Grades (ID, StudentId, CourseId, Grade, Date, TeacherId)
    VALUES (@newId, @studentId, @courseId, @grade, @gradeDate, @enteredBy)
END
GO
USE [master]
GO
ALTER DATABASE [Highschool] SET  READ_WRITE 
GO
