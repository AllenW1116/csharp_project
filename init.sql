USE [community]
GO
/****** Object:  Table [dbo].[Administrator]    Script Date: 2020/11/15 20:40:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Administrator](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Pwd] [varchar](50) NOT NULL,
	[AdminType] [int] NULL,
 CONSTRAINT [PK__Administ__6B2329655A7F2371] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Blog]    Script Date: 2020/11/15 20:40:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Blog](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Remark] [varchar](500) NULL,
 CONSTRAINT [PK__Blog__6B2329653D25E502] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Financial]    Script Date: 2020/11/15 20:40:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Financial](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[Price] [decimal](10, 2) NULL,
	[Remark] [varchar](500) NULL,
	[FinType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RegionInfo]    Script Date: 2020/11/15 20:40:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RegionInfo](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Remark] [varchar](500) NULL,
 CONSTRAINT [PK__RegionIn__6B2329651B31DE47] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 2020/11/15 20:40:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserInfo](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[UserSex] [int] NULL,
	[IdentityNumber] [varchar](50) NULL,
	[ContactAddress] [varchar](50) NULL,
	[ContactPhone] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK__UserInfo__6B232965EF866BA4] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Administrator] ON 

INSERT [dbo].[Administrator] ([AutoID], [Name], [Pwd], [AdminType]) VALUES (1, N'admin', N'123456', 0)
INSERT [dbo].[Administrator] ([AutoID], [Name], [Pwd], [AdminType]) VALUES (2, N'admin2', N'123', 1)
SET IDENTITY_INSERT [dbo].[Administrator] OFF
SET IDENTITY_INSERT [dbo].[Blog] ON 

INSERT [dbo].[Blog] ([AutoID], [Title], [Remark]) VALUES (1, N'博客1', N'dddddddddddddddddddddddd')
INSERT [dbo].[Blog] ([AutoID], [Title], [Remark]) VALUES (2, N'博客1', N'dddddddddddddddddddddddd')
INSERT [dbo].[Blog] ([AutoID], [Title], [Remark]) VALUES (3, N'ddfafds', N'dddddddddddddddddddd')
INSERT [dbo].[Blog] ([AutoID], [Title], [Remark]) VALUES (4, N'645', N'456')
SET IDENTITY_INSERT [dbo].[Blog] OFF
SET IDENTITY_INSERT [dbo].[Financial] ON 

INSERT [dbo].[Financial] ([AutoID], [Price], [Remark], [FinType]) VALUES (1, CAST(30.00 AS Decimal(10, 2)), N'迎新', 0)
INSERT [dbo].[Financial] ([AutoID], [Price], [Remark], [FinType]) VALUES (2, CAST(0.00 AS Decimal(10, 2)), N'dfasdfdsfadsffds', 0)
INSERT [dbo].[Financial] ([AutoID], [Price], [Remark], [FinType]) VALUES (3, CAST(0.00 AS Decimal(10, 2)), N'fasdfsdafasdf', 0)
SET IDENTITY_INSERT [dbo].[Financial] OFF
SET IDENTITY_INSERT [dbo].[RegionInfo] ON 

INSERT [dbo].[RegionInfo] ([AutoID], [Name], [Remark]) VALUES (1, N'迎新公告', N'社团将在9.1号迎新活动')
INSERT [dbo].[RegionInfo] ([AutoID], [Name], [Remark]) VALUES (2, N'dddddd', N'222222222222222222222222222222222222222222222222222222222')
INSERT [dbo].[RegionInfo] ([AutoID], [Name], [Remark]) VALUES (3, N'123', N'321')
SET IDENTITY_INSERT [dbo].[RegionInfo] OFF
SET IDENTITY_INSERT [dbo].[UserInfo] ON 

INSERT [dbo].[UserInfo] ([AutoID], [UserName], [UserSex], [IdentityNumber], [ContactAddress], [ContactPhone], [Email]) VALUES (1, N'张三', 0, NULL, NULL, NULL, N'')
INSERT [dbo].[UserInfo] ([AutoID], [UserName], [UserSex], [IdentityNumber], [ContactAddress], [ContactPhone], [Email]) VALUES (2, N'张三1', 0, NULL, NULL, NULL, N'')
INSERT [dbo].[UserInfo] ([AutoID], [UserName], [UserSex], [IdentityNumber], [ContactAddress], [ContactPhone], [Email]) VALUES (16, N'4545', 0, N'555555555555555', N'ddddd', N'15136593899', N'666@163.com')
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
