
USE [TaskManager]
GO

/****** Object:  Table [dbo].[ParentTaskTable]    Script Date: 9/27/2019 2:48:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ParentTaskTable](
	[Parent_ID] [int] NOT NULL,
	[Parent_Task] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Parent_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO








-------------------------------------------------------


USE [TaskManager]
GO

/****** Object:  Table [dbo].[ProjectTable]    Script Date: 9/27/2019 2:48:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProjectTable](
	[Project_ID] [int] NOT NULL,
	[Project] [nvarchar](20) NULL,
	[Start_Date] [datetime] NULL,
	[End_Date] [datetime] NULL,
	[Priority] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Project_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


----------------------------------------------------------------

USE [TaskManager]
GO

/****** Object:  Table [dbo].[TaskTable]    Script Date: 9/27/2019 3:02:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TaskTable](
	[Task_ID] [int] NOT NULL,
	[Parent_ID] [int] NOT NULL,
	[Project_ID][int] NOT NULL,
	[Task] [nvarchar](20) NULL,
	[Start_Date] [datetime] NULL,
	[End_Date] [datetime] NULL,
	[Priority] [int] NULL,
	[Status][nvarchar](100)NULL
PRIMARY KEY CLUSTERED 
(
	[Task_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TaskTable]  WITH CHECK ADD  CONSTRAINT [FK_TaskTable_ParentTaskTable_Parent_ID] FOREIGN KEY([Parent_ID])
REFERENCES [dbo].[ParentTaskTable] ([Parent_ID])
GO

ALTER TABLE [dbo].[TaskTable] CHECK CONSTRAINT [FK_TaskTable_ParentTaskTable_Parent_ID]
GO



ALTER TABLE [dbo].[TaskTable]  WITH CHECK ADD  CONSTRAINT [FK_TaskTable_ProjectTable_Project_ID] FOREIGN KEY([Project_ID])
REFERENCES [dbo].[ProjectTable] ([Project_ID])
GO

ALTER TABLE [dbo].[TaskTable] CHECK CONSTRAINT [FK_TaskTable_ProjectTable_Project_ID] 
GO
-----------------------------------------------------------------------------
USE [TaskManager]
GO

/****** Object:  Table [dbo].[UsersTable]    Script Date: 9/27/2019 2:50:32 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UsersTable](
	[User_ID] [int] NOT NULL,
	[First Name] [nvarchar](20) NULL,
	[Last Name] [nvarchar](20) NULL,
	[Employee_ID] [int] NOT NULL,
	[Project_ID] [int] NOT NULL,
	[Task_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UsersTable]  WITH CHECK ADD  CONSTRAINT [FK_UsersTable_ProjectTable_Project_ID] FOREIGN KEY([Project_ID])
REFERENCES [dbo].[ProjectTable] ([Project_ID])
GO

ALTER TABLE [dbo].[UsersTable] CHECK CONSTRAINT [FK_UsersTable_ProjectTable_Project_ID]
GO

ALTER TABLE [dbo].[UsersTable]  WITH CHECK ADD  CONSTRAINT [FK_UsersTable_TaskTable_Task_ID] FOREIGN KEY([Task_ID])
REFERENCES [dbo].[TaskTable] ([Task_ID])
GO

ALTER TABLE [dbo].[UsersTable] CHECK CONSTRAINT [FK_UsersTable_TaskTable_Task_ID]
GO


------------------------------------------------------------------



USE [TaskManager]
GO

/****** Object:  Table [dbo].[ProjectTable]    Script Date: 9/27/2019 2:51:10 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProjectTable](
	[Project_ID] [int] NOT NULL,
	[Project] [nvarchar](20) NULL,
	[Start_Date] [datetime] NULL,
	[End_Date] [datetime] NULL,
	[Priority] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Project_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


