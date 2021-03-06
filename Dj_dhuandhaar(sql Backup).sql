USE [dj_dhuandhaar]
GO
/****** Object:  Table [dbo].[Tbl_Enquiry]    Script Date: 8/5/2019 7:42:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Enquiry](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Mobile] [varchar](50) NULL,
	[Message] [varchar](150) NOT NULL,
	[MDT] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_Enquiry] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Login]    Script Date: 8/5/2019 7:42:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Login](
	[Email] [varchar](50) NULL,
	[Pass] [varchar](50) NULL,
	[usertype] [varchar](50) NULL,
	[MDT] [varchar](50) NULL,
	[status] [bit] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Registration]    Script Date: 8/5/2019 7:42:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Registration](
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NOT NULL,
	[Mobilenumber] [varchar](50) NULL,
	[Pass] [varchar](50) NULL,
	[Picture] [varchar](max) NULL,
	[MDT] [varchar](50) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Tbl_Registration] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Tbl_Login] ([Email], [Pass], [usertype], [MDT], [status]) VALUES (N'acsp.fzd99@gmail.com', N'123', N'user', N'8/2/2019 8:29:41 PM', 1)
INSERT [dbo].[Tbl_Login] ([Email], [Pass], [usertype], [MDT], [status]) VALUES (N'acspfzd@gmail.com', N'1', N'user', N'8/4/2019 10:44:33 AM', 1)
INSERT [dbo].[Tbl_Login] ([Email], [Pass], [usertype], [MDT], [status]) VALUES (N'gud@gobar.com', N'1', N'user', N'8/4/2019 10:58:31 AM', 1)
INSERT [dbo].[Tbl_Login] ([Email], [Pass], [usertype], [MDT], [status]) VALUES (N'tanveer@chacha.com', N'1', N'user', N'8/4/2019 12:01:13 PM', 1)
INSERT [dbo].[Tbl_Login] ([Email], [Pass], [usertype], [MDT], [status]) VALUES (N'admin@djdhuandhaar.tk', N'Admin', N'Administrator', N'2019/08/01', 1)
INSERT [dbo].[Tbl_Login] ([Email], [Pass], [usertype], [MDT], [status]) VALUES (N'tanveer1@chacha.com', N'1', N'user', N'8/5/2019 10:12:44 AM', 1)
INSERT [dbo].[Tbl_Registration] ([Name], [Email], [Mobilenumber], [Pass], [Picture], [MDT], [Status]) VALUES (N'Avinash Yadav', N'acsp.fzd99@gmail.com', N'07309797975', N'1', N'Avinash (1).jpeg', N'8/2/2019 8:29:41 PM', 1)
INSERT [dbo].[Tbl_Registration] ([Name], [Email], [Mobilenumber], [Pass], [Picture], [MDT], [Status]) VALUES (N'Surya', N'acspfzd@gmail.com', N'6307776440', N'1', N'Viah.jpg', N'8/4/2019 10:44:33 AM', 1)
INSERT [dbo].[Tbl_Registration] ([Name], [Email], [Mobilenumber], [Pass], [Picture], [MDT], [Status]) VALUES (N'satyanash', N'gud@gobar.com', N'6307776440', N'1', N'Viah.jpg', N'8/4/2019 10:58:31 AM', 1)
INSERT [dbo].[Tbl_Registration] ([Name], [Email], [Mobilenumber], [Pass], [Picture], [MDT], [Status]) VALUES (N'Tanveer', N'tanveer@chacha.com', N'08090516186', N'1', N'Tanveer.jpeg', N'8/4/2019 12:01:13 PM', 1)
INSERT [dbo].[Tbl_Registration] ([Name], [Email], [Mobilenumber], [Pass], [Picture], [MDT], [Status]) VALUES (N'Tanveer Chaccha', N'tanveer1@chacha.com', N'8948183733', N'1', N'Tanveer.jpeg', N'8/5/2019 10:12:44 AM', 1)
