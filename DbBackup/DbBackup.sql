USE [NGT_DB_ECOMM]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 11/10/2019 4:41:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AddressTypeId] [int] NOT NULL,
	[Country] [int] NOT NULL,
	[City] [int] NOT NULL,
	[Town] [decimal](18, 2) NOT NULL,
	[ZipCode] [decimal](18, 2) NOT NULL,
	[AddressLine] [nvarchar](4000) NOT NULL,
	[AddressLine1] [nvarchar](4000) NOT NULL,
	[AddressLine2] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_AddressId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 11/10/2019 4:41:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[ProductName] [nvarchar](250) NULL,
 CONSTRAINT [PK_CartId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coupon]    Script Date: 11/10/2019 4:41:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coupon](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Discount] [int] NOT NULL,
 CONSTRAINT [PK_CouponId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/10/2019 4:41:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Surname] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[Password] [nvarchar](250) NULL,
	[Phone] [nvarchar](250) NULL,
 CONSTRAINT [PK_CustomerId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/10/2019 4:41:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[AddressId] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[InsertDatetime] [datetime] NOT NULL,
 CONSTRAINT [PK_OrderId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/10/2019 4:41:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductTypeId] [int] NOT NULL,
	[ProductName] [nvarchar](200) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Stock] [int] NOT NULL,
	[Description] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 11/10/2019 4:41:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[ID] [int] IDENTITY(30000,1) NOT NULL,
	[ProductType] [nvarchar](200) NOT NULL,
	[Description] [varchar](500) NOT NULL,
 CONSTRAINT [PK_ProductTypeId] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cart] ON 

INSERT [dbo].[Cart] ([Id], [Status], [ProductId], [CustomerId], [Quantity], [UnitPrice], [TotalPrice], [ProductName]) VALUES (9, 0, 1, 1, 2, CAST(25.50 AS Decimal(18, 2)), CAST(51.00 AS Decimal(18, 2)), N'Karisik Pizza')
INSERT [dbo].[Cart] ([Id], [Status], [ProductId], [CustomerId], [Quantity], [UnitPrice], [TotalPrice], [ProductName]) VALUES (10, 0, 2, 1, 1, CAST(22.50 AS Decimal(18, 2)), CAST(22.50 AS Decimal(18, 2)), N'Karisik Pizza')
SET IDENTITY_INSERT [dbo].[Cart] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Name], [Surname], [Email], [Password], [Phone]) VALUES (1, N'Nazire', N'Gündüz', N'naziregndz@gmail.com', N'1234567', N'05432546217')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [Status], [CustomerId], [ProductId], [AddressId], [UnitPrice], [TotalPrice], [InsertDatetime]) VALUES (4, 1, 1, 1, 1, CAST(25.50 AS Decimal(18, 2)), CAST(51.00 AS Decimal(18, 2)), CAST(N'2019-11-10T15:34:09.533' AS DateTime))
INSERT [dbo].[Order] ([Id], [Status], [CustomerId], [ProductId], [AddressId], [UnitPrice], [TotalPrice], [InsertDatetime]) VALUES (5, 1, 1, 2, 1, CAST(22.50 AS Decimal(18, 2)), CAST(22.50 AS Decimal(18, 2)), CAST(N'2019-11-10T15:34:18.877' AS DateTime))
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [ProductTypeId], [ProductName], [Price], [Stock], [Description]) VALUES (1, 1, N'Karisik Pizza', CAST(25.50 AS Decimal(18, 2)), 10, N'Sucuklu Peynirli Pizza')
INSERT [dbo].[Product] ([ID], [ProductTypeId], [ProductName], [Price], [Stock], [Description]) VALUES (2, 1, N'Vejeteryan Pizza', CAST(22.50 AS Decimal(18, 2)), 20, N'Peynirli Pizza')
INSERT [dbo].[Product] ([ID], [ProductTypeId], [ProductName], [Price], [Stock], [Description]) VALUES (3, 2, N'Karisik Dürüm', CAST(25.50 AS Decimal(18, 2)), 30, N'Sucuklu Peynirli Dürüm')
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[ProductType] ON 

INSERT [dbo].[ProductType] ([ID], [ProductType], [Description]) VALUES (30000, N'1', N'Pizza')
INSERT [dbo].[ProductType] ([ID], [ProductType], [Description]) VALUES (30001, N'2', N'Dürüm')
SET IDENTITY_INSERT [dbo].[ProductType] OFF
