USE [COMS]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 01/13/2012 20:42:54 ******/
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
/****** Object:  Table [dbo].[AutoID]    Script Date: 01/13/2012 20:42:54 ******/
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
/****** Object:  Table [dbo].[Access_Right]    Script Date: 01/13/2012 20:42:54 ******/
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
/****** Object:  Table [dbo].[Department]    Script Date: 01/13/2012 20:42:54 ******/
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
/****** Object:  Table [dbo].[Error]    Script Date: 01/13/2012 20:42:55 ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 01/13/2012 20:42:55 ******/
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
/****** Object:  Table [dbo].[Workflow]    Script Date: 01/13/2012 20:42:55 ******/
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
/****** Object:  Table [dbo].[Role_Right_ref]    Script Date: 01/13/2012 20:42:55 ******/
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
/****** Object:  Table [dbo].[Printer]    Script Date: 01/13/2012 20:42:55 ******/
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
/****** Object:  Table [dbo].[Order]    Script Date: 01/13/2012 20:42:55 ******/
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
/****** Object:  StoredProcedure [dbo].[GenerateNewID]    Script Date: 01/13/2012 20:43:07 ******/
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
/****** Object:  Table [dbo].[Employee]    Script Date: 01/13/2012 20:42:55 ******/
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
/****** Object:  Table [dbo].[Emp_Role_ref]    Script Date: 01/13/2012 20:42:54 ******/
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
/****** Object:  Table [dbo].[Step]    Script Date: 01/13/2012 20:42:55 ******/
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
/****** Object:  Table [dbo].[Order_Log]    Script Date: 01/13/2012 20:42:55 ******/
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
/****** Object:  Table [dbo].[Order_Detail]    Script Date: 01/13/2012 20:42:55 ******/
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
/****** Object:  Table [dbo].[Cylinder]    Script Date: 01/13/2012 20:42:54 ******/
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
/****** Object:  Table [dbo].[Step_ref]    Script Date: 01/13/2012 20:42:55 ******/
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
/****** Object:  Table [dbo].[Formula]    Script Date: 01/13/2012 20:42:55 ******/
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
/****** Object:  Table [dbo].[Cylinder_Log]    Script Date: 01/13/2012 20:42:54 ******/
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
/****** Object:  Default [DF_Access_Right_rightsId]    Script Date: 01/13/2012 20:42:54 ******/
ALTER TABLE [dbo].[Access_Right] ADD  CONSTRAINT [DF_Access_Right_rightsId]  DEFAULT (newid()) FOR [rightsId]
GO
/****** Object:  Default [DF_Access_Right_created_by]    Script Date: 01/13/2012 20:42:54 ******/
ALTER TABLE [dbo].[Access_Right] ADD  CONSTRAINT [DF_Access_Right_created_by]  DEFAULT (N'system') FOR [created_by]
GO
/****** Object:  Default [DF_Access_Right_created_date]    Script Date: 01/13/2012 20:42:54 ******/
ALTER TABLE [dbo].[Access_Right] ADD  CONSTRAINT [DF_Access_Right_created_date]  DEFAULT (getdate()) FOR [created_date]
GO
/****** Object:  Default [DF_Access_Right_isactive]    Script Date: 01/13/2012 20:42:54 ******/
ALTER TABLE [dbo].[Access_Right] ADD  CONSTRAINT [DF_Access_Right_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Table_1_orderid]    Script Date: 01/13/2012 20:42:54 ******/
ALTER TABLE [dbo].[AutoID] ADD  CONSTRAINT [DF_Table_1_orderid]  DEFAULT ((0)) FOR [autoid]
GO
/****** Object:  Default [DF_AutoID_created_date]    Script Date: 01/13/2012 20:42:54 ******/
ALTER TABLE [dbo].[AutoID] ADD  CONSTRAINT [DF_AutoID_created_date]  DEFAULT (getdate()) FOR [created_date]
GO
/****** Object:  Default [DF_Table_1_CustomerID]    Script Date: 01/13/2012 20:42:54 ******/
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Table_1_CustomerID]  DEFAULT (newid()) FOR [customerid]
GO
/****** Object:  Default [DF_Cylinder_status]    Script Date: 01/13/2012 20:42:54 ******/
ALTER TABLE [dbo].[Cylinder] ADD  CONSTRAINT [DF_Cylinder_status]  DEFAULT (N'PENDING') FOR [status]
GO
/****** Object:  Default [DF_Cylinder_Log_formula]    Script Date: 01/13/2012 20:42:54 ******/
ALTER TABLE [dbo].[Cylinder_Log] ADD  CONSTRAINT [DF_Cylinder_Log_formula]  DEFAULT ('') FOR [formula]
GO
/****** Object:  Default [DF_Department_departmentId]    Script Date: 01/13/2012 20:42:54 ******/
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [DF_Department_departmentId]  DEFAULT (newid()) FOR [departmentId]
GO
/****** Object:  Default [DF_Department_isactive]    Script Date: 01/13/2012 20:42:54 ******/
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [DF_Department_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Emp_Role_ref_Id]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Emp_Role_ref] ADD  CONSTRAINT [DF_Emp_Role_ref_Id]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [DF_Emp_Role_ref_isapproved]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Emp_Role_ref] ADD  CONSTRAINT [DF_Emp_Role_ref_isapproved]  DEFAULT ((0)) FOR [isapproved]
GO
/****** Object:  Default [DF_Employee_employeeId]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_employeeId]  DEFAULT (newid()) FOR [employeeId]
GO
/****** Object:  Default [DF_Employee_isactive]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Formula_isactive]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Formula] ADD  CONSTRAINT [DF_Formula_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Order_isactive]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_isactive]  DEFAULT ((0)) FOR [status]
GO
/****** Object:  Default [DF_Role_isactive]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Role_Right_ref_Id]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Role_Right_ref] ADD  CONSTRAINT [DF_Role_Right_ref_Id]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [DF_Role_Right_ref_created_date]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Role_Right_ref] ADD  CONSTRAINT [DF_Role_Right_ref_created_date]  DEFAULT (getdate()) FOR [created_date]
GO
/****** Object:  Default [DF_Step_stepId]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Step] ADD  CONSTRAINT [DF_Step_stepId]  DEFAULT (newid()) FOR [stepId]
GO
/****** Object:  Default [DF_Step_isActive]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Step] ADD  CONSTRAINT [DF_Step_isActive]  DEFAULT ((1)) FOR [isActive]
GO
/****** Object:  Default [DF_Step_isStep_1]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Step] ADD  CONSTRAINT [DF_Step_isStep_1]  DEFAULT ((1)) FOR [isStep]
GO
/****** Object:  Default [DF_Step_isStep]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Step] ADD  CONSTRAINT [DF_Step_isStep]  DEFAULT ((0)) FOR [isBegin]
GO
/****** Object:  Default [DF_Workflow_workflowId]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Workflow] ADD  CONSTRAINT [DF_Workflow_workflowId]  DEFAULT (newid()) FOR [workflowId]
GO
/****** Object:  Default [DF_Workflow_isactive]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Workflow] ADD  CONSTRAINT [DF_Workflow_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  ForeignKey [FK_Cylinder_Order_Detail]    Script Date: 01/13/2012 20:42:54 ******/
ALTER TABLE [dbo].[Cylinder]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Order_Detail] FOREIGN KEY([order_detailId])
REFERENCES [dbo].[Order_Detail] ([order_detailId])
GO
ALTER TABLE [dbo].[Cylinder] CHECK CONSTRAINT [FK_Cylinder_Order_Detail]
GO
/****** Object:  ForeignKey [FK_Cylinder_Workflow]    Script Date: 01/13/2012 20:42:54 ******/
ALTER TABLE [dbo].[Cylinder]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Workflow] FOREIGN KEY([workflowId])
REFERENCES [dbo].[Workflow] ([workflowId])
GO
ALTER TABLE [dbo].[Cylinder] CHECK CONSTRAINT [FK_Cylinder_Workflow]
GO
/****** Object:  ForeignKey [FK_Cylinder_Log_Cylinder]    Script Date: 01/13/2012 20:42:54 ******/
ALTER TABLE [dbo].[Cylinder_Log]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Log_Cylinder] FOREIGN KEY([cylinderId])
REFERENCES [dbo].[Cylinder] ([cylinderId])
GO
ALTER TABLE [dbo].[Cylinder_Log] CHECK CONSTRAINT [FK_Cylinder_Log_Cylinder]
GO
/****** Object:  ForeignKey [FK_Cylinder_Log_Employee]    Script Date: 01/13/2012 20:42:54 ******/
ALTER TABLE [dbo].[Cylinder_Log]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Log_Employee] FOREIGN KEY([employeeId])
REFERENCES [dbo].[Employee] ([employeeId])
GO
ALTER TABLE [dbo].[Cylinder_Log] CHECK CONSTRAINT [FK_Cylinder_Log_Employee]
GO
/****** Object:  ForeignKey [FK_Cylinder_Log_Step]    Script Date: 01/13/2012 20:42:54 ******/
ALTER TABLE [dbo].[Cylinder_Log]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Log_Step] FOREIGN KEY([stepId])
REFERENCES [dbo].[Step] ([stepId])
GO
ALTER TABLE [dbo].[Cylinder_Log] CHECK CONSTRAINT [FK_Cylinder_Log_Step]
GO
/****** Object:  ForeignKey [FK_Emp_Role_ref_Employee]    Script Date: 01/13/2012 20:42:54 ******/
ALTER TABLE [dbo].[Emp_Role_ref]  WITH CHECK ADD  CONSTRAINT [FK_Emp_Role_ref_Employee] FOREIGN KEY([employeeId])
REFERENCES [dbo].[Employee] ([employeeId])
GO
ALTER TABLE [dbo].[Emp_Role_ref] CHECK CONSTRAINT [FK_Emp_Role_ref_Employee]
GO
/****** Object:  ForeignKey [FK_Emp_Role_ref_Role]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Emp_Role_ref]  WITH CHECK ADD  CONSTRAINT [FK_Emp_Role_ref_Role] FOREIGN KEY([roleId])
REFERENCES [dbo].[Role] ([roleId])
GO
ALTER TABLE [dbo].[Emp_Role_ref] CHECK CONSTRAINT [FK_Emp_Role_ref_Role]
GO
/****** Object:  ForeignKey [FK_Employee_Department]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([departmentId])
REFERENCES [dbo].[Department] ([departmentId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
/****** Object:  ForeignKey [FK_Formula_Step]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Formula]  WITH CHECK ADD  CONSTRAINT [FK_Formula_Step] FOREIGN KEY([stepId])
REFERENCES [dbo].[Step] ([stepId])
GO
ALTER TABLE [dbo].[Formula] CHECK CONSTRAINT [FK_Formula_Step]
GO
/****** Object:  ForeignKey [FK_Order_Customer]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customer] ([customerid])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
/****** Object:  ForeignKey [FK_Order_Detail_Order]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Order_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Order_Detail_Order] FOREIGN KEY([orderId])
REFERENCES [dbo].[Order] ([orderId])
GO
ALTER TABLE [dbo].[Order_Detail] CHECK CONSTRAINT [FK_Order_Detail_Order]
GO
/****** Object:  ForeignKey [FK_Order_Log_Order]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Order_Log]  WITH CHECK ADD  CONSTRAINT [FK_Order_Log_Order] FOREIGN KEY([orderId])
REFERENCES [dbo].[Order] ([orderId])
GO
ALTER TABLE [dbo].[Order_Log] CHECK CONSTRAINT [FK_Order_Log_Order]
GO
/****** Object:  ForeignKey [FK_Order_Log_Workflow]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Order_Log]  WITH CHECK ADD  CONSTRAINT [FK_Order_Log_Workflow] FOREIGN KEY([workflowId])
REFERENCES [dbo].[Workflow] ([workflowId])
GO
ALTER TABLE [dbo].[Order_Log] CHECK CONSTRAINT [FK_Order_Log_Workflow]
GO
/****** Object:  ForeignKey [FK_Printer_Customer]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Printer]  WITH CHECK ADD  CONSTRAINT [FK_Printer_Customer] FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customer] ([customerid])
GO
ALTER TABLE [dbo].[Printer] CHECK CONSTRAINT [FK_Printer_Customer]
GO
/****** Object:  ForeignKey [FK_Role_Right_ref_Access_Right]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Role_Right_ref]  WITH CHECK ADD  CONSTRAINT [FK_Role_Right_ref_Access_Right] FOREIGN KEY([rightId])
REFERENCES [dbo].[Access_Right] ([rightsId])
GO
ALTER TABLE [dbo].[Role_Right_ref] CHECK CONSTRAINT [FK_Role_Right_ref_Access_Right]
GO
/****** Object:  ForeignKey [FK_Role_Right_ref_Role]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Role_Right_ref]  WITH CHECK ADD  CONSTRAINT [FK_Role_Right_ref_Role] FOREIGN KEY([roleId])
REFERENCES [dbo].[Role] ([roleId])
GO
ALTER TABLE [dbo].[Role_Right_ref] CHECK CONSTRAINT [FK_Role_Right_ref_Role]
GO
/****** Object:  ForeignKey [FK_Step_Workflow]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Step]  WITH CHECK ADD  CONSTRAINT [FK_Step_Workflow] FOREIGN KEY([workflowId])
REFERENCES [dbo].[Workflow] ([workflowId])
GO
ALTER TABLE [dbo].[Step] CHECK CONSTRAINT [FK_Step_Workflow]
GO
/****** Object:  ForeignKey [FK_Step_ref_Step]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Step_ref]  WITH CHECK ADD  CONSTRAINT [FK_Step_ref_Step] FOREIGN KEY([from_stepId])
REFERENCES [dbo].[Step] ([stepId])
GO
ALTER TABLE [dbo].[Step_ref] CHECK CONSTRAINT [FK_Step_ref_Step]
GO
/****** Object:  ForeignKey [FK_Step_ref_Step1]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Step_ref]  WITH CHECK ADD  CONSTRAINT [FK_Step_ref_Step1] FOREIGN KEY([to_stepId])
REFERENCES [dbo].[Step] ([stepId])
GO
ALTER TABLE [dbo].[Step_ref] CHECK CONSTRAINT [FK_Step_ref_Step1]
GO
/****** Object:  ForeignKey [FK_Step_ref_Workflow]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Step_ref]  WITH CHECK ADD  CONSTRAINT [FK_Step_ref_Workflow] FOREIGN KEY([workflowId])
REFERENCES [dbo].[Workflow] ([workflowId])
GO
ALTER TABLE [dbo].[Step_ref] CHECK CONSTRAINT [FK_Step_ref_Workflow]
GO
/****** Object:  ForeignKey [FK_Workflow_Department]    Script Date: 01/13/2012 20:42:55 ******/
ALTER TABLE [dbo].[Workflow]  WITH CHECK ADD  CONSTRAINT [FK_Workflow_Department] FOREIGN KEY([departmentId])
REFERENCES [dbo].[Department] ([departmentId])
GO
ALTER TABLE [dbo].[Workflow] CHECK CONSTRAINT [FK_Workflow_Department]
GO
