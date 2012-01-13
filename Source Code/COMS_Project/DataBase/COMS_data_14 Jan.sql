USE [master]
GO
/****** Object:  Database [COMS]    Script Date: 01/14/2012 03:38:17 ******/
CREATE DATABASE [COMS] ON  PRIMARY 
( NAME = N'COMS', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\COMS.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'COMS_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\COMS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [COMS] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [COMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [COMS] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [COMS] SET ANSI_NULLS OFF
GO
ALTER DATABASE [COMS] SET ANSI_PADDING OFF
GO
ALTER DATABASE [COMS] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [COMS] SET ARITHABORT OFF
GO
ALTER DATABASE [COMS] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [COMS] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [COMS] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [COMS] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [COMS] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [COMS] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [COMS] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [COMS] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [COMS] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [COMS] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [COMS] SET  DISABLE_BROKER
GO
ALTER DATABASE [COMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [COMS] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [COMS] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [COMS] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [COMS] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [COMS] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [COMS] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [COMS] SET  READ_WRITE
GO
ALTER DATABASE [COMS] SET RECOVERY SIMPLE
GO
ALTER DATABASE [COMS] SET  MULTI_USER
GO
ALTER DATABASE [COMS] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [COMS] SET DB_CHAINING OFF
GO
USE [COMS]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 01/14/2012 03:38:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[customerid] [uniqueidentifier] NOT NULL,
	[code] [nchar](10) NULL,
	[code_tax] [nvarchar](50) NULL,
	[address] [nvarchar](255) NULL,
	[created_date] [datetime] NULL,
	[created_by] [nvarchar](50) NULL,
	[fax] [nvarchar](50) NULL,
	[fullname] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[status] [nvarchar](10) NULL,
	[telephone] [nvarchar](50) NULL,
	[printer_id] [uniqueidentifier] NOT NULL,
	[updated_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[customerid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customer] ([customerid], [code], [code_tax], [address], [created_date], [created_by], [fax], [fullname], [name], [status], [telephone], [printer_id], [updated_date], [updated_by]) VALUES (N'393665a8-513e-461c-8fb8-322ab311d7aa', N'12        ', N'0301640003', N'635 HỒNG BÀNG Q6 P6', CAST(0x00009FD701605409 AS DateTime), N'Ba Tien', N'9692281', N'CTY TNHH SXTM NHẤT LỢI', N'NHẤT LỢI', N'ACTIVE', N'39605972-205(HẰNG)', N'00000000-0000-0000-0000-000000000000', CAST(0x00009FD701605409 AS DateTime), N'Ba Tien')
INSERT [dbo].[Customer] ([customerid], [code], [code_tax], [address], [created_date], [created_by], [fax], [fullname], [name], [status], [telephone], [printer_id], [updated_date], [updated_by]) VALUES (N'8153ac88-37a8-495d-84bc-53ab8010486f', N'1K        ', N'302751789', N'27/4b Trần Xuân Soạn - P. Tân kiểng Q.7 TP.HCM', CAST(0x00009FD70160540B AS DateTime), N'Ba Tien', N'8.39321009', N'Cty TNHH XNK Việt Gia', N'Pb Việt Gia', N'ACTIVE', N'8.39320227', N'00000000-0000-0000-0000-000000000000', CAST(0x00009FD70160540B AS DateTime), N'Ba Tien')
INSERT [dbo].[Customer] ([customerid], [code], [code_tax], [address], [created_date], [created_by], [fax], [fullname], [name], [status], [telephone], [printer_id], [updated_date], [updated_by]) VALUES (N'abe1b22e-3b50-450a-aebe-5ec326a1b000', N'14        ', N'302329400', N'SỐ E50 Đường Nhật Tảo .p 7 Q.11 HCM', CAST(0x00009FD70160540B AS DateTime), N'Ba Tien', N'9555479', N'NHỰA TÂN HƯNG', N'NHỰA TÂN HƯNG', N'ACTIVE', N'8562003-9556827- 0908622282', N'00000000-0000-0000-0000-000000000000', CAST(0x00009FD70160540B AS DateTime), N'Ba Tien')
INSERT [dbo].[Customer] ([customerid], [code], [code_tax], [address], [created_date], [created_by], [fax], [fullname], [name], [status], [telephone], [printer_id], [updated_date], [updated_by]) VALUES (N'392fedca-80ce-45ac-b054-deab9dea3d4f', N'1Q        ', N'310261516', N'Lô 8 Đường Tân Tạo - KCN Tân Tạo - Q. Bình Tân - TP. HCM', CAST(0x00009FD70160540B AS DateTime), N'Ba Tien', N'08. 37562692', N'Công ty TNHH MTV SX TM DV và XNK Viky', N'Viky', N'ACTIVE', N'08. 37562691', N'00000000-0000-0000-0000-000000000000', CAST(0x00009FD70160540B AS DateTime), N'Ba Tien')
/****** Object:  Table [dbo].[AutoID]    Script Date: 01/14/2012 03:38:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AutoID](
	[autoid] [bigint] NOT NULL,
	[created_date] [datetime] NOT NULL,
 CONSTRAINT [PK_AutoID] PRIMARY KEY CLUSTERED 
(
	[autoid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AutoID] ([autoid], [created_date]) VALUES (2, CAST(0x00009FD80021F569 AS DateTime))
/****** Object:  Table [dbo].[Access_Right]    Script Date: 01/14/2012 03:38:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Access_Right](
	[rightsId] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[module_name] [nvarchar](50) NULL,
	[action] [nvarchar](50) NOT NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	[isactive] [bit] NOT NULL,
 CONSTRAINT [PK_Access_Right] PRIMARY KEY CLUSTERED 
(
	[rightsId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'7a1bbf1a-009f-49c5-82d7-068dd3b4c080', N'Employee Management', N'Employee', N'Edit', N'system', CAST(0x00009FCB00000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'fe0c5af8-03fe-4391-95a1-0d793598997a', N'Role Management', N'Role', N'Edit', N'system', CAST(0x00009FCB00000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'12e6925d-348f-41c8-8d63-0f43af13aa84', N'Workflow Error', N'Workflow Error', N'Edit', N'system', CAST(0x00009FD700000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'edd9f355-43b7-43e7-909c-0f5e63f00e2b', N'Workflow Management', N'Workflow', N'Edit', N'system', CAST(0x00009FCB00000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'd15b5e23-c275-46b1-93a4-15c11b8c6454', N'Send to workflow/step', N'Send To Workflow', N'Edit', N'system', CAST(0x00009FD700000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'14f366a1-5ee2-445d-b049-15e5320bb57f', N'Cylinder Info', N'Cylinder Info', N'View', N'system', CAST(0x00009FD700000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'aad14991-61d2-4277-92a4-2f083a4ec749', N'Workflow Management', N'Workflow', N'View', N'system', CAST(0x00009FCB00000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'1a1b14d3-caf4-4361-898c-30b2af754de5', N'Step List', N'StepList.aspx', N'Report', N'system', CAST(0x00009FD300000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'3e81e34a-d984-43f7-bff3-49454db7b9da', N'Role Assignment Approval', N'Role Assignment', N'View', N'system', CAST(0x00009FD700000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'e3f30442-8b9c-45de-adb7-4e12be0c25bc', N'Order Management', N'Order', N'Edit', N'system', CAST(0x00009FD700000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'f351bcf5-05b6-42ad-a20e-549445165899', N'Approve Assign Roles', N'RoleApproval', N'Edit', N'system', CAST(0x00009FD700000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'e75b36b6-0a78-4aab-8cf6-5bcdc3d1a5e3', N'Customer', N'Customer', N'Edit', N'system', CAST(0x00009FD700000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'b1b78a5a-d14a-48b3-9c3f-70c806abf138', N'Send to workflow/step', N'Send To Workflow', N'View', N'system', CAST(0x00009FD700000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'330badc6-3cb6-48ee-8d1f-8057690b312d', N'Role Management', N'Role', N'View', N'system', CAST(0x00009FD700000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'fa04e969-b2e9-4a40-bacd-8ded979e74c2', N'Role Assignment Approval', N'Role Assignment', N'Edit', N'system', CAST(0x00009FCB00000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'd06bc8e5-f29d-4c44-b78c-af2d97097c8f', N'Employee Performance', N'EmployeePerformance.aspx', N'Report', N'system', CAST(0x00009FD300000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'c912e498-bb9e-4e84-b2cb-bb56a21e1c4a', N'Report', N'Report', N'View', N'system', CAST(0x00009FD700000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'ef908f13-7bbf-4940-9af2-d892b64c890d', N'View Current Queue', N'ViewQue', N'View', N'system', CAST(0x00009FD700000000 AS DateTime), N'', NULL, 1)
/****** Object:  Table [dbo].[Department]    Script Date: 01/14/2012 03:38:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[departmentId] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	[isactive] [bit] NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[departmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Department] ([departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'3ecff3ca-6379-4d9b-b4b3-354f7147fe0c', N'Engraving-Lasering Dept', N'Ba Tien', CAST(0x00009FD100000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Department] ([departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'83a044b8-f5fc-49a4-bb75-3a313053adda', N'Production Dept', N'Ba Tien', CAST(0x00009FD100000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Department] ([departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'cb609ff0-00b7-4994-94f8-420054eebd7b', N'Sales Dept', N'Ba Tien', CAST(0x00009FD100000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Department] ([departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'e01848b4-a671-4128-85e2-476460f1c562', N'Production Mgmt Dept', N'Ba Tien', CAST(0x00009FD100000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Department] ([departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'8e5c974f-e7a9-4d84-a610-50dc178edc54', N'Printing Dept', N'Ba Tien', CAST(0x00009FD100000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Department] ([departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'dba63bf4-9af0-44b5-8004-5d419a13683f', N'Mechanical Dept', N'Ba Tien', CAST(0x00009FD100000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Department] ([departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'72d09345-4128-4cde-a83e-c127867d20e0', N'test department', N'tin', CAST(0x00009FC400000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Department] ([departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'5b741cbc-93b0-4b20-b8ab-d0ce0ebf61a7', N'Quality Control 2 Dept', N'Ba Tien', CAST(0x00009FD100000000 AS DateTime), N'', NULL, 1)
INSERT [dbo].[Department] ([departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'951b242a-3ccb-40d0-91fb-f593e154c012', N'Graphic-Repro Dept', N'Ba Tien', CAST(0x00009FD100000000 AS DateTime), N'', NULL, 1)
/****** Object:  Table [dbo].[Error]    Script Date: 01/14/2012 03:38:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Error](
	[errorId] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Error] PRIMARY KEY CLUSTERED 
(
	[errorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 01/14/2012 03:38:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[roleId] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	[isactive] [bit] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[roleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Role] ([roleId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'085e81d5-871f-43d5-83d8-022c673497d2', N'Director', N'tranbatien', CAST(0x00009FD70161F105 AS DateTime), NULL, NULL, 1)
/****** Object:  Table [dbo].[Workflow]    Script Date: 01/14/2012 03:38:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workflow](
	[workflowId] [uniqueidentifier] NOT NULL,
	[departmentId] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	[isactive] [bit] NOT NULL,
	[prevWorkflowID] [uniqueidentifier] NULL,
	[nextWorkflowID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Workflow] PRIMARY KEY CLUSTERED 
(
	[workflowId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Workflow] ([workflowId], [departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive], [prevWorkflowID], [nextWorkflowID]) VALUES (N'b48d8cb1-3ac0-4a9a-a52f-034ef0e43ed9', N'951b242a-3ccb-40d0-91fb-f593e154c012', N'Graphic to Engraving', N'Ba Tien', CAST(0x00009FD7015BF760 AS DateTime), N'Ba Tien', CAST(0x00009FD7015BF760 AS DateTime), 1, N'8b37574b-0d0c-4743-a29b-8642e604377d', N'01644bc1-f35f-4ea2-9a3f-0654070a3612')
INSERT [dbo].[Workflow] ([workflowId], [departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive], [prevWorkflowID], [nextWorkflowID]) VALUES (N'841a89f5-40d6-42f7-9079-03d6597cda59', N'5b741cbc-93b0-4b20-b8ab-d0ce0ebf61a7', N'QC2 To Prod Mgmt', N'Ba Tien', CAST(0x00009FD7015BF761 AS DateTime), N'Ba Tien', CAST(0x00009FD7015BF761 AS DateTime), 1, N'6a3ef1dc-35b3-471d-905d-aba9f4badc43', NULL)
INSERT [dbo].[Workflow] ([workflowId], [departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive], [prevWorkflowID], [nextWorkflowID]) VALUES (N'01644bc1-f35f-4ea2-9a3f-0654070a3612', N'3ecff3ca-6379-4d9b-b4b3-354f7147fe0c', N'Engraving To Production', N'Ba Tien', CAST(0x00009FD7015BF760 AS DateTime), N'Ba Tien', CAST(0x00009FD7015BF760 AS DateTime), 1, N'4380144f-ed89-4a9a-851f-fceee75dee4e', N'ebc3ab04-073a-4814-95f3-67a094761f61')
INSERT [dbo].[Workflow] ([workflowId], [departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive], [prevWorkflowID], [nextWorkflowID]) VALUES (N'30024845-804b-473b-a0b7-431704b2dfd9', N'dba63bf4-9af0-44b5-8004-5d419a13683f', N'Mechanical To Production', N'Ba Tien', CAST(0x00009FD7015BF760 AS DateTime), N'Ba Tien', CAST(0x00009FD7015BF760 AS DateTime), 1, N'0111c5ae-b81d-4a16-a7be-a8f9308ad1a1', N'4380144f-ed89-4a9a-851f-fceee75dee4e')
INSERT [dbo].[Workflow] ([workflowId], [departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive], [prevWorkflowID], [nextWorkflowID]) VALUES (N'ebc3ab04-073a-4814-95f3-67a094761f61', N'83a044b8-f5fc-49a4-bb75-3a313053adda', N'Production to Printing', N'Ba Tien', CAST(0x00009FD7015BF761 AS DateTime), N'Ba Tien', CAST(0x00009FD7015BF761 AS DateTime), 1, N'01644bc1-f35f-4ea2-9a3f-0654070a3612', N'6a3ef1dc-35b3-471d-905d-aba9f4badc43')
INSERT [dbo].[Workflow] ([workflowId], [departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive], [prevWorkflowID], [nextWorkflowID]) VALUES (N'8b37574b-0d0c-4743-a29b-8642e604377d', N'cb609ff0-00b7-4994-94f8-420054eebd7b', N'Sales to Graphic', N'Ba Tien', CAST(0x00009FD7015BF75F AS DateTime), N'Ba Tien', CAST(0x00009FD7015BF75F AS DateTime), 1, NULL, N'b48d8cb1-3ac0-4a9a-a52f-034ef0e43ed9')
INSERT [dbo].[Workflow] ([workflowId], [departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive], [prevWorkflowID], [nextWorkflowID]) VALUES (N'0111c5ae-b81d-4a16-a7be-a8f9308ad1a1', N'cb609ff0-00b7-4994-94f8-420054eebd7b', N'Sales to Mechanical', N'Ba Tien', CAST(0x00009FD7015BF760 AS DateTime), N'Ba Tien', CAST(0x00009FD7015BF760 AS DateTime), 1, NULL, N'30024845-804b-473b-a0b7-431704b2dfd9')
INSERT [dbo].[Workflow] ([workflowId], [departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive], [prevWorkflowID], [nextWorkflowID]) VALUES (N'6a3ef1dc-35b3-471d-905d-aba9f4badc43', N'8e5c974f-e7a9-4d84-a610-50dc178edc54', N'Printing to QC2', N'Ba Tien', CAST(0x00009FD7015BF761 AS DateTime), N'Ba Tien', CAST(0x00009FD7015BF761 AS DateTime), 1, N'ebc3ab04-073a-4814-95f3-67a094761f61', N'841a89f5-40d6-42f7-9079-03d6597cda59')
INSERT [dbo].[Workflow] ([workflowId], [departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive], [prevWorkflowID], [nextWorkflowID]) VALUES (N'4380144f-ed89-4a9a-851f-fceee75dee4e', N'83a044b8-f5fc-49a4-bb75-3a313053adda', N'Production to Engraving', N'Ba Tien', CAST(0x00009FD7015BF760 AS DateTime), N'Ba Tien', CAST(0x00009FD7015BF760 AS DateTime), 1, N'30024845-804b-473b-a0b7-431704b2dfd9', N'01644bc1-f35f-4ea2-9a3f-0654070a3612')
/****** Object:  Table [dbo].[Role_Right_ref]    Script Date: 01/14/2012 03:38:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role_Right_ref](
	[Id] [uniqueidentifier] NOT NULL,
	[roleId] [uniqueidentifier] NOT NULL,
	[rightId] [uniqueidentifier] NOT NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_Role_Right_ref] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'51412cbd-2bab-4ac1-8309-0f6121576082', N'085e81d5-871f-43d5-83d8-022c673497d2', N'fe0c5af8-03fe-4391-95a1-0d793598997a', N'tranbatien', CAST(0x00009FD70161F147 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'47f12d77-ad30-43c2-8c54-115f58fd8438', N'085e81d5-871f-43d5-83d8-022c673497d2', N'330badc6-3cb6-48ee-8d1f-8057690b312d', N'tranbatien', CAST(0x00009FD70161F145 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'21ea6d71-f5b4-41b0-81ac-3253c526eb4b', N'085e81d5-871f-43d5-83d8-022c673497d2', N'd15b5e23-c275-46b1-93a4-15c11b8c6454', N'tranbatien', CAST(0x00009FD70161F149 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'1e68abee-15b8-4cef-bff5-3aa15b5c8908', N'085e81d5-871f-43d5-83d8-022c673497d2', N'3e81e34a-d984-43f7-bff3-49454db7b9da', N'tranbatien', CAST(0x00009FD70161F143 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'7ef01371-b36d-4718-867e-3fc417671cae', N'085e81d5-871f-43d5-83d8-022c673497d2', N'edd9f355-43b7-43e7-909c-0f5e63f00e2b', N'tranbatien', CAST(0x00009FD70161F154 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'3e89e1b1-87af-4144-b79a-4cfcef8f9302', N'085e81d5-871f-43d5-83d8-022c673497d2', N'aad14991-61d2-4277-92a4-2f083a4ec749', N'tranbatien', CAST(0x00009FD70161F157 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'65562695-d5ed-4539-b540-5771a5541d83', N'085e81d5-871f-43d5-83d8-022c673497d2', N'b1b78a5a-d14a-48b3-9c3f-70c806abf138', N'tranbatien', CAST(0x00009FD70161F14B AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'c7818709-f80f-4cc0-b3de-5881ea0eb4ba', N'085e81d5-871f-43d5-83d8-022c673497d2', N'e75b36b6-0a78-4aab-8cf6-5bcdc3d1a5e3', N'tranbatien', CAST(0x00009FD70161F134 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'd90f4ac3-4339-4332-bc34-657768b02a79', N'085e81d5-871f-43d5-83d8-022c673497d2', N'f351bcf5-05b6-42ad-a20e-549445165899', N'tranbatien', CAST(0x00009FD70161F12C AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'66e6a5c1-f2ff-4b37-b26b-65cee4cf853f', N'085e81d5-871f-43d5-83d8-022c673497d2', N'fa04e969-b2e9-4a40-bacd-8ded979e74c2', N'tranbatien', CAST(0x00009FD70161F141 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'61532409-79d7-4061-8760-7a8dafb6f62c', N'085e81d5-871f-43d5-83d8-022c673497d2', N'ef908f13-7bbf-4940-9af2-d892b64c890d', N'tranbatien', CAST(0x00009FD70161F150 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'30560e39-3f52-412a-b9b4-807a07a6762c', N'085e81d5-871f-43d5-83d8-022c673497d2', N'd06bc8e5-f29d-4c44-b78c-af2d97097c8f', N'tranbatien', CAST(0x00009FD70161F13B AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'5b2681d6-cf02-4496-bb29-909d87abbfa7', N'085e81d5-871f-43d5-83d8-022c673497d2', N'12e6925d-348f-41c8-8d63-0f43af13aa84', N'tranbatien', CAST(0x00009FD70161F152 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'c2461773-5e1e-4aea-9ca1-b0ea90ea2709', N'085e81d5-871f-43d5-83d8-022c673497d2', N'7a1bbf1a-009f-49c5-82d7-068dd3b4c080', N'tranbatien', CAST(0x00009FD70161F138 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'34e67ddd-1c7b-4a63-af47-b404236dc461', N'085e81d5-871f-43d5-83d8-022c673497d2', N'14f366a1-5ee2-445d-b049-15e5320bb57f', N'tranbatien', CAST(0x00009FD70161F136 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'20ec8031-d0ee-45c2-82a6-b6ecb581e693', N'085e81d5-871f-43d5-83d8-022c673497d2', N'1a1b14d3-caf4-4361-898c-30b2af754de5', N'tranbatien', CAST(0x00009FD70161F14E AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'0bc00e6f-ea84-4f2e-864f-b88fe7dc2c54', N'085e81d5-871f-43d5-83d8-022c673497d2', N'c912e498-bb9e-4e84-b2cb-bb56a21e1c4a', N'tranbatien', CAST(0x00009FD70161F13F AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'b49e1d93-40a4-4819-8957-ef20af56a05f', N'085e81d5-871f-43d5-83d8-022c673497d2', N'e3f30442-8b9c-45de-adb7-4e12be0c25bc', N'tranbatien', CAST(0x00009FD70161F13D AS DateTime), NULL, NULL)
/****** Object:  Table [dbo].[Printer]    Script Date: 01/14/2012 03:38:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Printer](
	[printer_id] [uniqueidentifier] NOT NULL,
	[customer_id] [uniqueidentifier] NULL,
	[address] [nvarchar](255) NULL,
	[code] [nvarchar](10) NULL,
	[hole_stick] [nvarchar](50) NULL,
	[name] [nvarchar](255) NULL,
	[slot_latch] [nvarchar](50) NULL,
	[status] [nvarchar](10) NULL,
	[created_date] [datetime] NULL,
	[created_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
 CONSTRAINT [PK_Printer] PRIMARY KEY CLUSTERED 
(
	[printer_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Printer] ([printer_id], [customer_id], [address], [code], [hole_stick], [name], [slot_latch], [status], [created_date], [created_by], [updated_date], [updated_by]) VALUES (N'6079d134-23ca-4537-a85b-078ceb99e3f3', N'392fedca-80ce-45ac-b054-deab9dea3d4f', N'', N'1Q', N'70 x 15', N'Viky', N'12 x 5', N'', CAST(0x00009FD70160540B AS DateTime), N'Ba Tien', NULL, N'Ba Tien')
INSERT [dbo].[Printer] ([printer_id], [customer_id], [address], [code], [hole_stick], [name], [slot_latch], [status], [created_date], [created_by], [updated_date], [updated_by]) VALUES (N'9e576728-987c-4569-8505-79a2bc50f876', N'abe1b22e-3b50-450a-aebe-5ec326a1b000', N'', N'14', N'60 x 15', N'Nhựa Tân Hưng', N'7 x 4', N'', CAST(0x00009FD70160540B AS DateTime), N'Ba Tien', NULL, N'Ba Tien')
INSERT [dbo].[Printer] ([printer_id], [customer_id], [address], [code], [hole_stick], [name], [slot_latch], [status], [created_date], [created_by], [updated_date], [updated_by]) VALUES (N'0d54c8e7-7b9b-4da3-ac48-e8d050e6e278', N'393665a8-513e-461c-8fb8-322ab311d7aa', N'', N'12', N'70 x 15', N'Anh Hà (BN) Máy 3', N'10 x 9 (1 Đầu)', N'', CAST(0x00009FD701605409 AS DateTime), N'Ba Tien', NULL, N'Ba Tien')
/****** Object:  Table [dbo].[Order]    Script Date: 01/14/2012 03:38:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[orderId] [uniqueidentifier] NOT NULL,
	[order_code] [nvarchar](50) NOT NULL,
	[customer_id] [uniqueidentifier] NOT NULL,
	[customer_rep] [nvarchar](50) NULL,
	[product_name] [nvarchar](255) NULL,
	[price_type] [nvarchar](10) NULL,
	[redo_pct] [int] NULL,
	[old_core] [bit] NULL,
	[delivery_date] [datetime] NULL,
	[order_type] [nvarchar](5) NULL,
	[status] [nvarchar](5) NULL,
	[set_code] [nvarchar](10) NULL,
	[cylinder_type] [nvarchar](5) NULL,
	[old_order_code] [nvarchar](10) NULL,
	[priority] [nvarchar](5) NULL,
	[created_date] [datetime] NOT NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[updated_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[belong_to_set] [nvarchar](10) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[orderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Order] ([orderId], [order_code], [customer_id], [customer_rep], [product_name], [price_type], [redo_pct], [old_core], [delivery_date], [order_type], [status], [set_code], [cylinder_type], [old_order_code], [priority], [created_date], [created_by], [updated_date], [updated_by], [belong_to_set]) VALUES (N'a2d48c69-6b2e-4792-a499-b9e7afdf04a5', N'0002-112', N'393665a8-513e-461c-8fb8-322ab311d7aa', N'Mr A', N'Túi Portball 1622', N'STD', 0, NULL, CAST(0x00009FEA00000000 AS DateTime), N'NEW', N'PROD', N'J1Q041201', N'A', NULL, N'MED', CAST(0x00009FD800000000 AS DateTime), N'Ba Tien', CAST(0x00009FD80021F58C AS DateTime), N'tranbatien', N'')
/****** Object:  StoredProcedure [dbo].[GenerateNewID]    Script Date: 01/14/2012 03:38:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Tin
-- Create date: 8-Jan-2012
-- =============================================
CREATE PROCEDURE [dbo].[GenerateNewID]
	
AS
BEGIN

	declare @NextId as bigint;
	
	UPDATE  AutoId  SET @NextId= autoid	= Case
										When MONTH(created_date)=MONTH(GETDATE()) then autoid+1
										When MONTH(created_date) <> MONTH(GETDATE()) then 0
								  End,
						created_date = GETDATE()
 
	select @NextId as SequenceCode ;
END
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 01/14/2012 03:38:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[employeeId] [uniqueidentifier] NOT NULL,
	[departmentId] [uniqueidentifier] NOT NULL,
	[surname] [nvarchar](50) NULL,
	[given_name] [nvarchar](255) NULL,
	[staff_code] [nvarchar](50) NOT NULL,
	[barcode] [nvarchar](50) NULL,
	[position] [nvarchar](50) NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[isactive] [bit] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[employeeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Employee] ([employeeId], [departmentId], [surname], [given_name], [staff_code], [barcode], [position], [username], [password], [created_by], [created_date], [updated_date], [updated_by], [isactive]) VALUES (N'4b2224aa-94fa-4046-9fff-92f507d218e7', N'3ecff3ca-6379-4d9b-b4b3-354f7147fe0c', N'Tran', N'Ba Tien', N'staff-code-111', N'', N'Manager', N'tranbatien', N'password', N'Ba Tien', CAST(0x00009FD7015AF7CB AS DateTime), NULL, NULL, 1)
/****** Object:  Table [dbo].[Emp_Role_ref]    Script Date: 01/14/2012 03:38:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emp_Role_ref](
	[Id] [uniqueidentifier] NOT NULL,
	[employeeId] [uniqueidentifier] NOT NULL,
	[roleId] [uniqueidentifier] NOT NULL,
	[isapproved] [bit] NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_Emp_Role_ref] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Emp_Role_ref] ([Id], [employeeId], [roleId], [isapproved], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'c1d50d29-7bff-445a-a6c6-7b7dce3d31ea', N'4b2224aa-94fa-4046-9fff-92f507d218e7', N'085e81d5-871f-43d5-83d8-022c673497d2', 1, N'tranbatien', CAST(0x00009FD800000000 AS DateTime), NULL, NULL)
/****** Object:  Table [dbo].[Step]    Script Date: 01/14/2012 03:38:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Step](
	[stepId] [uniqueidentifier] NOT NULL,
	[workflowId] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[description] [nvarchar](500) NULL,
	[instruction] [nvarchar](2000) NULL,
	[note] [nvarchar](500) NULL,
	[x] [int] NOT NULL,
	[y] [int] NOT NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	[isActive] [bit] NOT NULL,
	[isStep] [bit] NOT NULL,
	[isBegin] [bit] NOT NULL,
 CONSTRAINT [PK_Step] PRIMARY KEY CLUSTERED 
(
	[stepId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Log]    Script Date: 01/14/2012 03:38:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Log](
	[id] [uniqueidentifier] NOT NULL,
	[workflowId] [uniqueidentifier] NOT NULL,
	[orderId] [uniqueidentifier] NOT NULL,
	[order_status] [nvarchar](10) NULL,
	[dept_name] [nvarchar](25) NOT NULL,
	[updated_date] [datetime] NOT NULL,
	[remarks] [nvarchar](255) NULL,
	[updated_by] [nvarchar](max) NULL,
	[related_cyl] [nvarchar](max) NULL,
 CONSTRAINT [PK_Order_Log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Order_Log] ([id], [workflowId], [orderId], [order_status], [dept_name], [updated_date], [remarks], [updated_by], [related_cyl]) VALUES (N'b8b44df2-0c25-4493-ad8c-c76309ece8e7', N'8b37574b-0d0c-4743-a29b-8642e604377d', N'a2d48c69-6b2e-4792-a499-b9e7afdf04a5', N'STG', N'Sales Dept', CAST(0x00009FD80021F592 AS DateTime), NULL, N'tranbatien', NULL)
INSERT [dbo].[Order_Log] ([id], [workflowId], [orderId], [order_status], [dept_name], [updated_date], [remarks], [updated_by], [related_cyl]) VALUES (N'63ad16c5-7414-4e8a-b8d7-efaabe20f982', N'0111c5ae-b81d-4a16-a7be-a8f9308ad1a1', N'a2d48c69-6b2e-4792-a499-b9e7afdf04a5', N'PROD', N'Sales Dept', CAST(0x00009FD800220B00 AS DateTime), NULL, N'tranbatien', NULL)
/****** Object:  Table [dbo].[Order_Detail]    Script Date: 01/14/2012 03:38:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Detail](
	[order_detailId] [uniqueidentifier] NOT NULL,
	[orderId] [uniqueidentifier] NOT NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	[core_type] [nvarchar](10) NULL,
	[prod_print_width] [decimal](18, 2) NULL,
	[prod_width_stretch] [decimal](18, 2) NULL,
	[prod_print_height] [decimal](18, 2) NULL,
	[prod_height_stretch] [decimal](18, 2) NULL,
	[length_dir_repeat] [int] NULL,
	[circum_dir_repeat] [int] NULL,
	[web_print_width] [int] NULL,
	[web_total_width] [int] NULL,
	[cyl_length] [decimal](18, 2) NULL,
	[cyl_diameter] [decimal](18, 2) NULL,
	[eyemark_height] [int] NULL,
	[eyemark_width] [int] NULL,
	[eyemark_color] [nvarchar](10) NULL,
	[eyemark_sign] [nvarchar](10) NULL,
	[eyemark_location] [nvarchar](10) NULL,
	[keyhole_type] [nvarchar](10) NULL,
	[keyhole_inner_dia] [int] NULL,
	[keyhole_outer_dia] [int] NULL,
	[keyhole_angle] [int] NULL,
	[keyhole_keyway] [nvarchar](10) NULL,
	[color_count] [int] NULL,
	[color_list] [nvarchar](12) NULL,
	[new_cyl_count] [int] NULL,
	[used_cyl_count] [int] NULL,
	[print_method] [nvarchar](5) NULL,
	[reg_mark_type] [nvarchar](10) NULL,
	[splitline_size] [int] NULL,
	[splitline_type] [nvarchar](10) NULL,
	[splitline_color] [nvarchar](10) NULL,
	[print_material] [nvarchar](10) NULL,
	[result_based_on] [nvarchar](10) NULL,
	[img_orientation] [nvarchar](10) NULL,
	[graphic_done_date] [datetime] NULL,
	[sent_to_mech_date] [datetime] NULL,
	[cut_core_result] [nvarchar](20) NULL,
	[changes] [nvarchar](20) NULL,
 CONSTRAINT [PK_Order_Detail] PRIMARY KEY CLUSTERED 
(
	[order_detailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Order_Detail] ([order_detailId], [orderId], [created_by], [created_date], [updated_by], [updated_date], [core_type], [prod_print_width], [prod_width_stretch], [prod_print_height], [prod_height_stretch], [length_dir_repeat], [circum_dir_repeat], [web_print_width], [web_total_width], [cyl_length], [cyl_diameter], [eyemark_height], [eyemark_width], [eyemark_color], [eyemark_sign], [eyemark_location], [keyhole_type], [keyhole_inner_dia], [keyhole_outer_dia], [keyhole_angle], [keyhole_keyway], [color_count], [color_list], [new_cyl_count], [used_cyl_count], [print_method], [reg_mark_type], [splitline_size], [splitline_type], [splitline_color], [print_material], [result_based_on], [img_orientation], [graphic_done_date], [sent_to_mech_date], [cut_core_result], [changes]) VALUES (N'31fe6706-fd40-4746-badb-a3e99fa77be3', N'a2d48c69-6b2e-4792-a499-b9e7afdf04a5', N'Ba Tien', CAST(0x00009FD800000000 AS DateTime), N'tranbatien', CAST(0x00009FD80021F58C AS DateTime), N'1', CAST(1120.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(980.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 1, 1120, 1145, CAST(1220.00 AS Decimal(18, 2)), CAST(311.94 AS Decimal(18, 2)), 5, 10, N'K', N'', N'1SIDE', N'STD', NULL, NULL, NULL, NULL, 4, N'KCMY', 4, 0, N'SRF', N'STD', NULL, NULL, NULL, N'PET', N'GRAPHIC', N'Up', NULL, NULL, NULL, N'NEW FILE')
/****** Object:  Table [dbo].[Cylinder]    Script Date: 01/14/2012 03:38:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cylinder](
	[cylinderId] [uniqueidentifier] NOT NULL,
	[workflowId] [uniqueidentifier] NOT NULL,
	[order_detailId] [uniqueidentifier] NOT NULL,
	[barcode] [nvarchar](50) NOT NULL,
	[stepId] [uniqueidentifier] NULL,
	[color_no] [int] NULL,
	[core_type] [nvarchar](10) NULL,
	[cyl_no] [int] NULL,
	[diameter] [decimal](18, 2) NULL,
	[length] [decimal](18, 5) NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	[status] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Cylinder] PRIMARY KEY CLUSTERED 
(
	[cylinderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Cylinder] ([cylinderId], [workflowId], [order_detailId], [barcode], [stepId], [color_no], [core_type], [cyl_no], [diameter], [length], [created_by], [created_date], [updated_by], [updated_date], [status]) VALUES (N'c9bcb1f9-3c68-4066-bbcf-70e758a115a2', N'0111c5ae-b81d-4a16-a7be-a8f9308ad1a1', N'31fe6706-fd40-4746-badb-a3e99fa77be3', N'0002-11202-021', NULL, 2, N'1', 2, CAST(311.94 AS Decimal(18, 2)), CAST(1220.00000 AS Decimal(18, 5)), N'Ba Tien', CAST(0x00009FD800000000 AS DateTime), N'tranbatien', CAST(0x00009FD80021F58C AS DateTime), N'INPROD')
INSERT [dbo].[Cylinder] ([cylinderId], [workflowId], [order_detailId], [barcode], [stepId], [color_no], [core_type], [cyl_no], [diameter], [length], [created_by], [created_date], [updated_by], [updated_date], [status]) VALUES (N'4fc2b7c2-d37a-48f9-b95b-9a34be8cb625', N'0111c5ae-b81d-4a16-a7be-a8f9308ad1a1', N'31fe6706-fd40-4746-badb-a3e99fa77be3', N'0002-11204-041', NULL, 4, N'1', 4, CAST(311.94 AS Decimal(18, 2)), CAST(1220.00000 AS Decimal(18, 5)), N'Ba Tien', CAST(0x00009FD800000000 AS DateTime), N'tranbatien', CAST(0x00009FD80021F58C AS DateTime), N'INPROD')
INSERT [dbo].[Cylinder] ([cylinderId], [workflowId], [order_detailId], [barcode], [stepId], [color_no], [core_type], [cyl_no], [diameter], [length], [created_by], [created_date], [updated_by], [updated_date], [status]) VALUES (N'9eae718c-2a62-4ac8-b4cd-ab21688b85fb', N'0111c5ae-b81d-4a16-a7be-a8f9308ad1a1', N'31fe6706-fd40-4746-badb-a3e99fa77be3', N'0002-11203-031', NULL, 3, N'1', 3, CAST(311.94 AS Decimal(18, 2)), CAST(1220.00000 AS Decimal(18, 5)), N'Ba Tien', CAST(0x00009FD800000000 AS DateTime), N'tranbatien', CAST(0x00009FD80021F58C AS DateTime), N'INPROD')
INSERT [dbo].[Cylinder] ([cylinderId], [workflowId], [order_detailId], [barcode], [stepId], [color_no], [core_type], [cyl_no], [diameter], [length], [created_by], [created_date], [updated_by], [updated_date], [status]) VALUES (N'4eab5b1b-f128-4f2a-a2b6-f678cc118983', N'0111c5ae-b81d-4a16-a7be-a8f9308ad1a1', N'31fe6706-fd40-4746-badb-a3e99fa77be3', N'0002-11201-011', NULL, 1, N'1', 1, CAST(311.94 AS Decimal(18, 2)), CAST(1220.00000 AS Decimal(18, 5)), N'Ba Tien', CAST(0x00009FD800000000 AS DateTime), N'tranbatien', CAST(0x00009FD80021F58C AS DateTime), N'INPROD')
/****** Object:  Table [dbo].[Step_ref]    Script Date: 01/14/2012 03:38:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Step_ref](
	[Id] [uniqueidentifier] NOT NULL,
	[workflowId] [uniqueidentifier] NOT NULL,
	[from_stepId] [uniqueidentifier] NOT NULL,
	[to_stepId] [uniqueidentifier] NOT NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_Step_ref] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Formula]    Script Date: 01/14/2012 03:38:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Formula](
	[formulaId] [uniqueidentifier] NOT NULL,
	[stepId] [uniqueidentifier] NOT NULL,
	[formula] [nvarchar](50) NOT NULL,
	[coef1] [int] NOT NULL,
	[coef2] [int] NOT NULL,
	[coef3] [int] NOT NULL,
	[coef4] [int] NOT NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[isactive] [bit] NOT NULL,
 CONSTRAINT [PK_Formula] PRIMARY KEY CLUSTERED 
(
	[formulaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cylinder_Log]    Script Date: 01/14/2012 03:38:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cylinder_Log](
	[cylinderlogId] [uniqueidentifier] NOT NULL,
	[cylinderId] [uniqueidentifier] NOT NULL,
	[dept_name] [nvarchar](50) NOT NULL,
	[start_time] [datetime] NOT NULL,
	[end_time] [datetime] NULL,
	[mark] [int] NULL,
	[formula] [nvarchar](255) NOT NULL,
	[employeeId] [uniqueidentifier] NULL,
	[error_desc] [nvarchar](255) NULL,
	[stepId] [uniqueidentifier] NOT NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[remark] [nvarchar](255) NULL,
	[status] [nvarchar](255) NULL,
 CONSTRAINT [PK_Cylinder_Log] PRIMARY KEY CLUSTERED 
(
	[cylinderlogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Table_1_CustomerID]    Script Date: 01/14/2012 03:38:17 ******/
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Table_1_CustomerID]  DEFAULT (newid()) FOR [customerid]
GO
/****** Object:  Default [DF_Table_1_orderid]    Script Date: 01/14/2012 03:38:17 ******/
ALTER TABLE [dbo].[AutoID] ADD  CONSTRAINT [DF_Table_1_orderid]  DEFAULT ((0)) FOR [autoid]
GO
/****** Object:  Default [DF_AutoID_created_date]    Script Date: 01/14/2012 03:38:17 ******/
ALTER TABLE [dbo].[AutoID] ADD  CONSTRAINT [DF_AutoID_created_date]  DEFAULT (getdate()) FOR [created_date]
GO
/****** Object:  Default [DF_Access_Right_rightsId]    Script Date: 01/14/2012 03:38:17 ******/
ALTER TABLE [dbo].[Access_Right] ADD  CONSTRAINT [DF_Access_Right_rightsId]  DEFAULT (newid()) FOR [rightsId]
GO
/****** Object:  Default [DF_Access_Right_created_by]    Script Date: 01/14/2012 03:38:17 ******/
ALTER TABLE [dbo].[Access_Right] ADD  CONSTRAINT [DF_Access_Right_created_by]  DEFAULT (N'system') FOR [created_by]
GO
/****** Object:  Default [DF_Access_Right_created_date]    Script Date: 01/14/2012 03:38:17 ******/
ALTER TABLE [dbo].[Access_Right] ADD  CONSTRAINT [DF_Access_Right_created_date]  DEFAULT (getdate()) FOR [created_date]
GO
/****** Object:  Default [DF_Access_Right_isactive]    Script Date: 01/14/2012 03:38:17 ******/
ALTER TABLE [dbo].[Access_Right] ADD  CONSTRAINT [DF_Access_Right_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Department_departmentId]    Script Date: 01/14/2012 03:38:17 ******/
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [DF_Department_departmentId]  DEFAULT (newid()) FOR [departmentId]
GO
/****** Object:  Default [DF_Department_isactive]    Script Date: 01/14/2012 03:38:17 ******/
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [DF_Department_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Role_isactive]    Script Date: 01/14/2012 03:38:17 ******/
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Workflow_workflowId]    Script Date: 01/14/2012 03:38:17 ******/
ALTER TABLE [dbo].[Workflow] ADD  CONSTRAINT [DF_Workflow_workflowId]  DEFAULT (newid()) FOR [workflowId]
GO
/****** Object:  Default [DF_Workflow_isactive]    Script Date: 01/14/2012 03:38:17 ******/
ALTER TABLE [dbo].[Workflow] ADD  CONSTRAINT [DF_Workflow_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Role_Right_ref_Id]    Script Date: 01/14/2012 03:38:17 ******/
ALTER TABLE [dbo].[Role_Right_ref] ADD  CONSTRAINT [DF_Role_Right_ref_Id]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [DF_Role_Right_ref_created_date]    Script Date: 01/14/2012 03:38:17 ******/
ALTER TABLE [dbo].[Role_Right_ref] ADD  CONSTRAINT [DF_Role_Right_ref_created_date]  DEFAULT (getdate()) FOR [created_date]
GO
/****** Object:  Default [DF_Order_isactive]    Script Date: 01/14/2012 03:38:17 ******/
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_isactive]  DEFAULT ((0)) FOR [status]
GO
/****** Object:  Default [DF_Employee_employeeId]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_employeeId]  DEFAULT (newid()) FOR [employeeId]
GO
/****** Object:  Default [DF_Employee_isactive]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Emp_Role_ref_Id]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Emp_Role_ref] ADD  CONSTRAINT [DF_Emp_Role_ref_Id]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [DF_Emp_Role_ref_isapproved]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Emp_Role_ref] ADD  CONSTRAINT [DF_Emp_Role_ref_isapproved]  DEFAULT ((0)) FOR [isapproved]
GO
/****** Object:  Default [DF_Step_stepId]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Step] ADD  CONSTRAINT [DF_Step_stepId]  DEFAULT (newid()) FOR [stepId]
GO
/****** Object:  Default [DF_Step_isActive]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Step] ADD  CONSTRAINT [DF_Step_isActive]  DEFAULT ((1)) FOR [isActive]
GO
/****** Object:  Default [DF_Step_isStep_1]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Step] ADD  CONSTRAINT [DF_Step_isStep_1]  DEFAULT ((1)) FOR [isStep]
GO
/****** Object:  Default [DF_Step_isStep]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Step] ADD  CONSTRAINT [DF_Step_isStep]  DEFAULT ((0)) FOR [isBegin]
GO
/****** Object:  Default [DF_Cylinder_status]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Cylinder] ADD  CONSTRAINT [DF_Cylinder_status]  DEFAULT (N'PENDING') FOR [status]
GO
/****** Object:  Default [DF_Formula_isactive]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Formula] ADD  CONSTRAINT [DF_Formula_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Cylinder_Log_formula]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Cylinder_Log] ADD  CONSTRAINT [DF_Cylinder_Log_formula]  DEFAULT ('') FOR [formula]
GO
/****** Object:  ForeignKey [FK_Workflow_Department]    Script Date: 01/14/2012 03:38:17 ******/
ALTER TABLE [dbo].[Workflow]  WITH CHECK ADD  CONSTRAINT [FK_Workflow_Department] FOREIGN KEY([departmentId])
REFERENCES [dbo].[Department] ([departmentId])
GO
ALTER TABLE [dbo].[Workflow] CHECK CONSTRAINT [FK_Workflow_Department]
GO
/****** Object:  ForeignKey [FK_Role_Right_ref_Access_Right]    Script Date: 01/14/2012 03:38:17 ******/
ALTER TABLE [dbo].[Role_Right_ref]  WITH CHECK ADD  CONSTRAINT [FK_Role_Right_ref_Access_Right] FOREIGN KEY([rightId])
REFERENCES [dbo].[Access_Right] ([rightsId])
GO
ALTER TABLE [dbo].[Role_Right_ref] CHECK CONSTRAINT [FK_Role_Right_ref_Access_Right]
GO
/****** Object:  ForeignKey [FK_Role_Right_ref_Role]    Script Date: 01/14/2012 03:38:17 ******/
ALTER TABLE [dbo].[Role_Right_ref]  WITH CHECK ADD  CONSTRAINT [FK_Role_Right_ref_Role] FOREIGN KEY([roleId])
REFERENCES [dbo].[Role] ([roleId])
GO
ALTER TABLE [dbo].[Role_Right_ref] CHECK CONSTRAINT [FK_Role_Right_ref_Role]
GO
/****** Object:  ForeignKey [FK_Printer_Customer]    Script Date: 01/14/2012 03:38:17 ******/
ALTER TABLE [dbo].[Printer]  WITH CHECK ADD  CONSTRAINT [FK_Printer_Customer] FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customer] ([customerid])
GO
ALTER TABLE [dbo].[Printer] CHECK CONSTRAINT [FK_Printer_Customer]
GO
/****** Object:  ForeignKey [FK_Order_Customer]    Script Date: 01/14/2012 03:38:17 ******/
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customer] ([customerid])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
/****** Object:  ForeignKey [FK_Employee_Department]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([departmentId])
REFERENCES [dbo].[Department] ([departmentId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
/****** Object:  ForeignKey [FK_Emp_Role_ref_Employee]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Emp_Role_ref]  WITH CHECK ADD  CONSTRAINT [FK_Emp_Role_ref_Employee] FOREIGN KEY([employeeId])
REFERENCES [dbo].[Employee] ([employeeId])
GO
ALTER TABLE [dbo].[Emp_Role_ref] CHECK CONSTRAINT [FK_Emp_Role_ref_Employee]
GO
/****** Object:  ForeignKey [FK_Emp_Role_ref_Role]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Emp_Role_ref]  WITH CHECK ADD  CONSTRAINT [FK_Emp_Role_ref_Role] FOREIGN KEY([roleId])
REFERENCES [dbo].[Role] ([roleId])
GO
ALTER TABLE [dbo].[Emp_Role_ref] CHECK CONSTRAINT [FK_Emp_Role_ref_Role]
GO
/****** Object:  ForeignKey [FK_Step_Workflow]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Step]  WITH CHECK ADD  CONSTRAINT [FK_Step_Workflow] FOREIGN KEY([workflowId])
REFERENCES [dbo].[Workflow] ([workflowId])
GO
ALTER TABLE [dbo].[Step] CHECK CONSTRAINT [FK_Step_Workflow]
GO
/****** Object:  ForeignKey [FK_Order_Log_Order]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Order_Log]  WITH CHECK ADD  CONSTRAINT [FK_Order_Log_Order] FOREIGN KEY([orderId])
REFERENCES [dbo].[Order] ([orderId])
GO
ALTER TABLE [dbo].[Order_Log] CHECK CONSTRAINT [FK_Order_Log_Order]
GO
/****** Object:  ForeignKey [FK_Order_Log_Workflow]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Order_Log]  WITH CHECK ADD  CONSTRAINT [FK_Order_Log_Workflow] FOREIGN KEY([workflowId])
REFERENCES [dbo].[Workflow] ([workflowId])
GO
ALTER TABLE [dbo].[Order_Log] CHECK CONSTRAINT [FK_Order_Log_Workflow]
GO
/****** Object:  ForeignKey [FK_Order_Detail_Order]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Order_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Order_Detail_Order] FOREIGN KEY([orderId])
REFERENCES [dbo].[Order] ([orderId])
GO
ALTER TABLE [dbo].[Order_Detail] CHECK CONSTRAINT [FK_Order_Detail_Order]
GO
/****** Object:  ForeignKey [FK_Cylinder_Order_Detail]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Cylinder]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Order_Detail] FOREIGN KEY([order_detailId])
REFERENCES [dbo].[Order_Detail] ([order_detailId])
GO
ALTER TABLE [dbo].[Cylinder] CHECK CONSTRAINT [FK_Cylinder_Order_Detail]
GO
/****** Object:  ForeignKey [FK_Cylinder_Workflow]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Cylinder]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Workflow] FOREIGN KEY([workflowId])
REFERENCES [dbo].[Workflow] ([workflowId])
GO
ALTER TABLE [dbo].[Cylinder] CHECK CONSTRAINT [FK_Cylinder_Workflow]
GO
/****** Object:  ForeignKey [FK_Step_ref_Step]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Step_ref]  WITH CHECK ADD  CONSTRAINT [FK_Step_ref_Step] FOREIGN KEY([from_stepId])
REFERENCES [dbo].[Step] ([stepId])
GO
ALTER TABLE [dbo].[Step_ref] CHECK CONSTRAINT [FK_Step_ref_Step]
GO
/****** Object:  ForeignKey [FK_Step_ref_Step1]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Step_ref]  WITH CHECK ADD  CONSTRAINT [FK_Step_ref_Step1] FOREIGN KEY([to_stepId])
REFERENCES [dbo].[Step] ([stepId])
GO
ALTER TABLE [dbo].[Step_ref] CHECK CONSTRAINT [FK_Step_ref_Step1]
GO
/****** Object:  ForeignKey [FK_Step_ref_Workflow]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Step_ref]  WITH CHECK ADD  CONSTRAINT [FK_Step_ref_Workflow] FOREIGN KEY([workflowId])
REFERENCES [dbo].[Workflow] ([workflowId])
GO
ALTER TABLE [dbo].[Step_ref] CHECK CONSTRAINT [FK_Step_ref_Workflow]
GO
/****** Object:  ForeignKey [FK_Formula_Step]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Formula]  WITH CHECK ADD  CONSTRAINT [FK_Formula_Step] FOREIGN KEY([stepId])
REFERENCES [dbo].[Step] ([stepId])
GO
ALTER TABLE [dbo].[Formula] CHECK CONSTRAINT [FK_Formula_Step]
GO
/****** Object:  ForeignKey [FK_Cylinder_Log_Cylinder]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Cylinder_Log]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Log_Cylinder] FOREIGN KEY([cylinderId])
REFERENCES [dbo].[Cylinder] ([cylinderId])
GO
ALTER TABLE [dbo].[Cylinder_Log] CHECK CONSTRAINT [FK_Cylinder_Log_Cylinder]
GO
/****** Object:  ForeignKey [FK_Cylinder_Log_Employee]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Cylinder_Log]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Log_Employee] FOREIGN KEY([employeeId])
REFERENCES [dbo].[Employee] ([employeeId])
GO
ALTER TABLE [dbo].[Cylinder_Log] CHECK CONSTRAINT [FK_Cylinder_Log_Employee]
GO
/****** Object:  ForeignKey [FK_Cylinder_Log_Step]    Script Date: 01/14/2012 03:38:18 ******/
ALTER TABLE [dbo].[Cylinder_Log]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Log_Step] FOREIGN KEY([stepId])
REFERENCES [dbo].[Step] ([stepId])
GO
ALTER TABLE [dbo].[Cylinder_Log] CHECK CONSTRAINT [FK_Cylinder_Log_Step]
GO
