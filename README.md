# BogusDataGeneratorExample
This is a working example of how to use the Bogus library in a .net/EF project to generate bogus test data on the fly. Please refer to my blog post [here](https://medium.com/@KeithPrinceBlog/fake-it-till-you-make-it-with-bogus-data-2947fe8c4483) for more information. 

# SQL Database Setup
For this example I used the LocalDb. You will need to create a Database named 'BogusDataExample' and then run the below script to create the table. This project uses Entity Framework and all paths, models and context files including config file with connection string points to the LocalDB and this DB name.

~~~
USE [BogusDataExample]
GO

ALTER TABLE [dbo].[Customer] DROP CONSTRAINT [DF_Customer_CreatedOn]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 11/29/2022 5:48:18 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
DROP TABLE [dbo].[Customer]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 11/29/2022 5:48:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[ZipCode] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[JobTitle] [nvarchar](50) NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO



~~~

# Swagger
Build and Run the application and you should get a browser window that shows the Swagger UI. Use the POST Generate to create records and DELETE Clear to delete all records within the Customer table. 

![image](https://user-images.githubusercontent.com/12174036/205139694-3fd33363-c5da-428d-a678-38a19b5987bc.png)

