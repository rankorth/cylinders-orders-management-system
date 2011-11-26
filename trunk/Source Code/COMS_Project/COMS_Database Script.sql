USE [master]
GO
/****** Object:  Database [COMS]    Script Date: 11/26/2011 14:36:56 ******/
CREATE DATABASE [COMS] ON  PRIMARY 
( NAME = N'COMS', FILENAME = N'C:\COMS_Database\COMS.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'COMS_log', FILENAME = N'C:\COMS_Database\COMS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
ALTER DATABASE [COMS] SET AUTO_CLOSE ON
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
/****** Object:  Table [dbo].[Department]    Script Date: 11/26/2011 14:36:59 ******/
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
/****** Object:  Table [dbo].[Access_Right]    Script Date: 11/26/2011 14:36:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Access_Right](
	[rightsId] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
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
/****** Object:  Table [dbo].[Order]    Script Date: 11/26/2011 14:36:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[orderId] [uniqueidentifier] NOT NULL,
	[order_code] [nvarchar](50) NOT NULL,
	[product_name] [nvarchar](50) NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
	[received_date] [datetime] NULL,
	[dead_line] [datetime] NULL,
	[order_type] [nvarchar](50) NULL,
	[barcode] [nvarchar](50) NULL,
	[remark] [nvarchar](255) NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
	[isactive] [bit] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[orderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Error]    Script Date: 11/26/2011 14:36:59 ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 11/26/2011 14:36:59 ******/
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
/****** Object:  Table [dbo].[Role_Right_ref]    Script Date: 11/26/2011 14:36:59 ******/
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
/****** Object:  Table [dbo].[Workflow]    Script Date: 11/26/2011 14:36:59 ******/
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
 CONSTRAINT [PK_Workflow] PRIMARY KEY CLUSTERED 
(
	[workflowId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Detail]    Script Date: 11/26/2011 14:36:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Detail](
	[order_detailId] [uniqueidentifier] NOT NULL,
	[orderId] [uniqueidentifier] NOT NULL,
	[cylinder_code] [nvarchar](50) NOT NULL,
	[cylinder_type] [nvarchar](50) NOT NULL,
	[quantity] [int] NOT NULL,
	[color_count] [int] NOT NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_Order_Detail] PRIMARY KEY CLUSTERED 
(
	[order_detailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11/26/2011 14:36:59 ******/
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
/****** Object:  Table [dbo].[Cylinder]    Script Date: 11/26/2011 14:36:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cylinder](
	[cylinderId] [uniqueidentifier] NOT NULL,
	[order_detailId] [uniqueidentifier] NOT NULL,
	[barcode] [nvarchar](50) NOT NULL,
	[priority] [int] NOT NULL,
	[status] [int] NOT NULL,
	[length] [decimal](18, 5) NOT NULL,
	[diameter] [decimal](18, 5) NOT NULL,
	[area] [decimal](18, 5) NOT NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_Cylinder] PRIMARY KEY CLUSTERED 
(
	[cylinderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Emp_Role_ref]    Script Date: 11/26/2011 14:36:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emp_Role_ref](
	[Id] [uniqueidentifier] NOT NULL,
	[employeeId] [uniqueidentifier] NOT NULL,
	[roleId] [uniqueidentifier] NOT NULL,
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
/****** Object:  Table [dbo].[Step]    Script Date: 11/26/2011 14:36:59 ******/
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
 CONSTRAINT [PK_Step] PRIMARY KEY CLUSTERED 
(
	[stepId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Step_ref]    Script Date: 11/26/2011 14:36:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Step_ref](
	[Id] [uniqueidentifier] NOT NULL,
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
/****** Object:  Table [dbo].[Formula]    Script Date: 11/26/2011 14:36:59 ******/
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
/****** Object:  Table [dbo].[Cylinder_Log]    Script Date: 11/26/2011 14:36:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cylinder_Log](
	[cylinderlogId] [uniqueidentifier] NOT NULL,
	[cylinderId] [uniqueidentifier] NOT NULL,
	[start_time] [datetime] NOT NULL,
	[end_time] [datetime] NULL,
	[mark] [int] NULL,
	[formulaId] [uniqueidentifier] NOT NULL,
	[employeeId] [uniqueidentifier] NOT NULL,
	[errorId] [uniqueidentifier] NULL,
	[stepId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Cylinder_Log] PRIMARY KEY CLUSTERED 
(
	[cylinderlogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Department_isactive]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [DF_Department_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Access_Right_isactive]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Access_Right] ADD  CONSTRAINT [DF_Access_Right_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Order_price]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_price]  DEFAULT ((0)) FOR [price]
GO
/****** Object:  Default [DF_Order_isactive]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Role_isactive]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Workflow_isactive]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Workflow] ADD  CONSTRAINT [DF_Workflow_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Employee_isactive]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Formula_isactive]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Formula] ADD  CONSTRAINT [DF_Formula_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  ForeignKey [FK_Role_Right_ref_Access_Right]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Role_Right_ref]  WITH CHECK ADD  CONSTRAINT [FK_Role_Right_ref_Access_Right] FOREIGN KEY([rightId])
REFERENCES [dbo].[Access_Right] ([rightsId])
GO
ALTER TABLE [dbo].[Role_Right_ref] CHECK CONSTRAINT [FK_Role_Right_ref_Access_Right]
GO
/****** Object:  ForeignKey [FK_Role_Right_ref_Role]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Role_Right_ref]  WITH CHECK ADD  CONSTRAINT [FK_Role_Right_ref_Role] FOREIGN KEY([roleId])
REFERENCES [dbo].[Role] ([roleId])
GO
ALTER TABLE [dbo].[Role_Right_ref] CHECK CONSTRAINT [FK_Role_Right_ref_Role]
GO
/****** Object:  ForeignKey [FK_Workflow_Department]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Workflow]  WITH CHECK ADD  CONSTRAINT [FK_Workflow_Department] FOREIGN KEY([departmentId])
REFERENCES [dbo].[Department] ([departmentId])
GO
ALTER TABLE [dbo].[Workflow] CHECK CONSTRAINT [FK_Workflow_Department]
GO
/****** Object:  ForeignKey [FK_Order_Detail_Order]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Order_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Order_Detail_Order] FOREIGN KEY([orderId])
REFERENCES [dbo].[Order] ([orderId])
GO
ALTER TABLE [dbo].[Order_Detail] CHECK CONSTRAINT [FK_Order_Detail_Order]
GO
/****** Object:  ForeignKey [FK_Employee_Department]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([departmentId])
REFERENCES [dbo].[Department] ([departmentId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
/****** Object:  ForeignKey [FK_Cylinder_Order_Detail]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Cylinder]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Order_Detail] FOREIGN KEY([order_detailId])
REFERENCES [dbo].[Order_Detail] ([order_detailId])
GO
ALTER TABLE [dbo].[Cylinder] CHECK CONSTRAINT [FK_Cylinder_Order_Detail]
GO
/****** Object:  ForeignKey [FK_Emp_Role_ref_Employee]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Emp_Role_ref]  WITH CHECK ADD  CONSTRAINT [FK_Emp_Role_ref_Employee] FOREIGN KEY([employeeId])
REFERENCES [dbo].[Employee] ([employeeId])
GO
ALTER TABLE [dbo].[Emp_Role_ref] CHECK CONSTRAINT [FK_Emp_Role_ref_Employee]
GO
/****** Object:  ForeignKey [FK_Emp_Role_ref_Role]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Emp_Role_ref]  WITH CHECK ADD  CONSTRAINT [FK_Emp_Role_ref_Role] FOREIGN KEY([roleId])
REFERENCES [dbo].[Role] ([roleId])
GO
ALTER TABLE [dbo].[Emp_Role_ref] CHECK CONSTRAINT [FK_Emp_Role_ref_Role]
GO
/****** Object:  ForeignKey [FK_Step_Workflow]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Step]  WITH CHECK ADD  CONSTRAINT [FK_Step_Workflow] FOREIGN KEY([workflowId])
REFERENCES [dbo].[Workflow] ([workflowId])
GO
ALTER TABLE [dbo].[Step] CHECK CONSTRAINT [FK_Step_Workflow]
GO
/****** Object:  ForeignKey [FK_Step_ref_Step]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Step_ref]  WITH CHECK ADD  CONSTRAINT [FK_Step_ref_Step] FOREIGN KEY([from_stepId])
REFERENCES [dbo].[Step] ([stepId])
GO
ALTER TABLE [dbo].[Step_ref] CHECK CONSTRAINT [FK_Step_ref_Step]
GO
/****** Object:  ForeignKey [FK_Step_ref_Step1]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Step_ref]  WITH CHECK ADD  CONSTRAINT [FK_Step_ref_Step1] FOREIGN KEY([to_stepId])
REFERENCES [dbo].[Step] ([stepId])
GO
ALTER TABLE [dbo].[Step_ref] CHECK CONSTRAINT [FK_Step_ref_Step1]
GO
/****** Object:  ForeignKey [FK_Formula_Step]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Formula]  WITH CHECK ADD  CONSTRAINT [FK_Formula_Step] FOREIGN KEY([stepId])
REFERENCES [dbo].[Step] ([stepId])
GO
ALTER TABLE [dbo].[Formula] CHECK CONSTRAINT [FK_Formula_Step]
GO
/****** Object:  ForeignKey [FK_Cylinder_Log_Cylinder]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Cylinder_Log]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Log_Cylinder] FOREIGN KEY([cylinderId])
REFERENCES [dbo].[Cylinder] ([cylinderId])
GO
ALTER TABLE [dbo].[Cylinder_Log] CHECK CONSTRAINT [FK_Cylinder_Log_Cylinder]
GO
/****** Object:  ForeignKey [FK_Cylinder_Log_Employee]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Cylinder_Log]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Log_Employee] FOREIGN KEY([employeeId])
REFERENCES [dbo].[Employee] ([employeeId])
GO
ALTER TABLE [dbo].[Cylinder_Log] CHECK CONSTRAINT [FK_Cylinder_Log_Employee]
GO
/****** Object:  ForeignKey [FK_Cylinder_Log_Error]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Cylinder_Log]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Log_Error] FOREIGN KEY([errorId])
REFERENCES [dbo].[Error] ([errorId])
GO
ALTER TABLE [dbo].[Cylinder_Log] CHECK CONSTRAINT [FK_Cylinder_Log_Error]
GO
/****** Object:  ForeignKey [FK_Cylinder_Log_Formula]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Cylinder_Log]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Log_Formula] FOREIGN KEY([formulaId])
REFERENCES [dbo].[Formula] ([formulaId])
GO
ALTER TABLE [dbo].[Cylinder_Log] CHECK CONSTRAINT [FK_Cylinder_Log_Formula]
GO
/****** Object:  ForeignKey [FK_Cylinder_Log_Step]    Script Date: 11/26/2011 14:36:59 ******/
ALTER TABLE [dbo].[Cylinder_Log]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Log_Step] FOREIGN KEY([stepId])
REFERENCES [dbo].[Step] ([stepId])
GO
ALTER TABLE [dbo].[Cylinder_Log] CHECK CONSTRAINT [FK_Cylinder_Log_Step]
GO
