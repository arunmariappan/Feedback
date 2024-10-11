USE [master]
GO
/****** Object:  Database [CustomerFeedback]    Script Date: 11-10-2024 14:14:56 ******/
CREATE DATABASE [CustomerFeedback]
GO
ALTER DATABASE [CustomerFeedback] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CustomerFeedback].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CustomerFeedback] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CustomerFeedback] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CustomerFeedback] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CustomerFeedback] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CustomerFeedback] SET ARITHABORT OFF 
GO
ALTER DATABASE [CustomerFeedback] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CustomerFeedback] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CustomerFeedback] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CustomerFeedback] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CustomerFeedback] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CustomerFeedback] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CustomerFeedback] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CustomerFeedback] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CustomerFeedback] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CustomerFeedback] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CustomerFeedback] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CustomerFeedback] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CustomerFeedback] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CustomerFeedback] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CustomerFeedback] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CustomerFeedback] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CustomerFeedback] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CustomerFeedback] SET RECOVERY FULL 
GO
ALTER DATABASE [CustomerFeedback] SET  MULTI_USER 
GO
ALTER DATABASE [CustomerFeedback] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CustomerFeedback] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CustomerFeedback] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CustomerFeedback] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CustomerFeedback] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CustomerFeedback] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CustomerFeedback', N'ON'
GO
ALTER DATABASE [CustomerFeedback] SET QUERY_STORE = ON
GO
ALTER DATABASE [CustomerFeedback] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CustomerFeedback]
GO
/****** Object:  Table [dbo].[Feedbacks]    Script Date: 11-10-2024 14:14:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedbacks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](max) NOT NULL,
	[EmailAddress] [nvarchar](max) NOT NULL,
	[FeedbackType] [nvarchar](max) NOT NULL,
	[FeedbackMessage] [nvarchar](max) NOT NULL,
	[AppVersion] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Feedbacks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [CustomerFeedback] SET  READ_WRITE 
GO
