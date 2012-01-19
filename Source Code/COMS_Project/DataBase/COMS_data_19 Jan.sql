USE [COMS]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 01/19/2012 15:19:35 ******/
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
INSERT [dbo].[Customer] ([customerid], [code], [code_tax], [address], [created_date], [created_by], [fax], [fullname], [name], [status], [telephone], [printer_id], [updated_date], [updated_by]) VALUES (N'4a9cde7a-2ca7-42fc-8cd4-2aa004262a2e', N'12        ', N'0301640003', N'Jurong East , Street 41', CAST(0x00009FD80060A499 AS DateTime), N'Ba Tien', N'9692281', N'John Brian', N'NHẤT LỢI', N'ACTIVE', N'39605972-205(HẰNG)', N'00000000-0000-0000-0000-000000000000', CAST(0x00009FD80060A499 AS DateTime), N'Ba Tien')
INSERT [dbo].[Customer] ([customerid], [code], [code_tax], [address], [created_date], [created_by], [fax], [fullname], [name], [status], [telephone], [printer_id], [updated_date], [updated_by]) VALUES (N'f6e14c03-03cb-4123-a178-44b2e24bf631', N'12        ', N'0301640004', N'Bukit Gombak, 650341', CAST(0x00009FD10042CCFF AS DateTime), N'Ba Tien', N'9692281', N'Brian Tan', N'Brian', N'ACTIVE', N'98806576', N'00000000-0000-0000-0000-000000000000', CAST(0x00009FD10042CCFF AS DateTime), N'Ba Tien')
INSERT [dbo].[Customer] ([customerid], [code], [code_tax], [address], [created_date], [created_by], [fax], [fullname], [name], [status], [telephone], [printer_id], [updated_date], [updated_by]) VALUES (N'c8de51b8-c8d7-4d42-90b0-8fe6f477ca8c', N'14        ', N'302329400', N'Marchent Street, China Town', CAST(0x00009FD80060A499 AS DateTime), N'Ba Tien', N'9555479', N'Mark Twain', N'NHỰA TÂN HƯNG', N'ACTIVE', N'8562003-9556827- 0908622282', N'00000000-0000-0000-0000-000000000000', CAST(0x00009FD80060A499 AS DateTime), N'Ba Tien')
INSERT [dbo].[Customer] ([customerid], [code], [code_tax], [address], [created_date], [created_by], [fax], [fullname], [name], [status], [telephone], [printer_id], [updated_date], [updated_by]) VALUES (N'7feb104a-1226-42b4-aefc-c45246d2190d', N'1Q        ', N'310261516', N'Bishan Park', CAST(0x00009FD80060A499 AS DateTime), N'Ba Tien', N'08. 37562692', N'Roger', N'Viky', N'ACTIVE', N'08. 37562691', N'00000000-0000-0000-0000-000000000000', CAST(0x00009FD80060A499 AS DateTime), N'Ba Tien')
INSERT [dbo].[Customer] ([customerid], [code], [code_tax], [address], [created_date], [created_by], [fax], [fullname], [name], [status], [telephone], [printer_id], [updated_date], [updated_by]) VALUES (N'13bacf93-3fcb-4760-b951-f7e7f0f1d1d8', N'1K        ', N'302751789', N'Climenti Wood', CAST(0x00009FD80060A499 AS DateTime), N'Ba Tien', N'8.39321009', N'Alvin', N'Pb Việt Gia', N'ACTIVE', N'8.39320227', N'00000000-0000-0000-0000-000000000000', CAST(0x00009FD80060A499 AS DateTime), N'Ba Tien')
/****** Object:  Table [dbo].[AutoID]    Script Date: 01/19/2012 15:19:35 ******/
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
INSERT [dbo].[AutoID] ([autoid], [created_date]) VALUES (15, CAST(0x00009FD800DB3C2B AS DateTime))
/****** Object:  Table [dbo].[Access_Right]    Script Date: 01/19/2012 15:19:35 ******/
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
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'7a1bbf1a-009f-49c5-82d7-068dd3b4c080', N'Employee Management', N'Employee', N'Edit', N'system', CAST(0x00009FCB00E4D194 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'fe0c5af8-03fe-4391-95a1-0d793598997a', N'Role Management', N'Role', N'Edit', N'system', CAST(0x00009FCB00E45265 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'12e6925d-348f-41c8-8d63-0f43af13aa84', N'Workflow Error', N'Workflow Error', N'Edit', N'system', CAST(0x00009FD7003B3566 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'edd9f355-43b7-43e7-909c-0f5e63f00e2b', N'Workflow Management', N'Workflow', N'Edit', N'system', CAST(0x00009FCB00E3E0A8 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'd15b5e23-c275-46b1-93a4-15c11b8c6454', N'Send to workflow/step', N'Send To Workflow', N'Edit', N'system', CAST(0x00009FD7004B88E6 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'14f366a1-5ee2-445d-b049-15e5320bb57f', N'Cylinder Info', N'Cylinder Info', N'View', N'system', CAST(0x00009FD70030BE89 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'aad14991-61d2-4277-92a4-2f083a4ec749', N'Workflow Management', N'Workflow', N'View', N'system', CAST(0x00009FCB00E3EB51 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'1a1b14d3-caf4-4361-898c-30b2af754de5', N'Step List', N'StepList.aspx', N'Report', N'system', CAST(0x00009FD3015B2A91 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'3e81e34a-d984-43f7-bff3-49454db7b9da', N'Role Assignment Approval', N'Role Assignment', N'View', N'system', CAST(0x00009FD7004A7026 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'e3f30442-8b9c-45de-adb7-4e12be0c25bc', N'Order Management', N'Order', N'Edit', N'system', CAST(0x00009FD7002F829F AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'f351bcf5-05b6-42ad-a20e-549445165899', N'Approve Assign Roles', N'RoleApproval', N'Edit', N'system', CAST(0x00009FD70030F8C6 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'e75b36b6-0a78-4aab-8cf6-5bcdc3d1a5e3', N'Customer', N'Customer', N'Edit', N'system', CAST(0x00009FD7003B0121 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'b1b78a5a-d14a-48b3-9c3f-70c806abf138', N'Send to workflow/step', N'Send To Workflow', N'View', N'system', CAST(0x00009FD7004B9282 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'330badc6-3cb6-48ee-8d1f-8057690b312d', N'Role Management', N'Role', N'View', N'system', CAST(0x00009FD70044EB8D AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'fa04e969-b2e9-4a40-bacd-8ded979e74c2', N'Role Assignment Approval', N'Role Assignment', N'Edit', N'system', CAST(0x00009FCB00E51FC3 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'd06bc8e5-f29d-4c44-b78c-af2d97097c8f', N'Employee Performance', N'EmployeePerformance.aspx', N'Report', N'system', CAST(0x00009FD301858294 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'c912e498-bb9e-4e84-b2cb-bb56a21e1c4a', N'Report', N'Report', N'View', N'system', CAST(0x00009FD7003BD3CD AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Access_Right] ([rightsId], [name], [module_name], [action], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'ef908f13-7bbf-4940-9af2-d892b64c890d', N'View Current Queue', N'ViewQue', N'View', N'system', CAST(0x00009FD700312D11 AS DateTime), NULL, NULL, 1)
/****** Object:  Table [dbo].[Department]    Script Date: 01/19/2012 15:19:35 ******/
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
INSERT [dbo].[Department] ([departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'3ecff3ca-6379-4d9b-b4b3-354f7147fe0c', N'Engraving-Lasering Dept', N'Ba Tien', CAST(0x00009FD100429F50 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Department] ([departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'83a044b8-f5fc-49a4-bb75-3a313053adda', N'Production Dept', N'Ba Tien', CAST(0x00009FD100429F50 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Department] ([departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'cb609ff0-00b7-4994-94f8-420054eebd7b', N'Sales Dept', N'Ba Tien', CAST(0x00009FD100429F50 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Department] ([departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'e01848b4-a671-4128-85e2-476460f1c562', N'Production Mgmt Dept', N'Ba Tien', CAST(0x00009FD100429F50 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Department] ([departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'8e5c974f-e7a9-4d84-a610-50dc178edc54', N'Printing Dept', N'Ba Tien', CAST(0x00009FD100429F50 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Department] ([departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'dba63bf4-9af0-44b5-8004-5d419a13683f', N'Mechanical Dept', N'Ba Tien', CAST(0x00009FD100429F50 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Department] ([departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'72d09345-4128-4cde-a83e-c127867d20e0', N'test department', N'tin', CAST(0x00009FC400000000 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Department] ([departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'5b741cbc-93b0-4b20-b8ab-d0ce0ebf61a7', N'Quality Control 2 Dept', N'Ba Tien', CAST(0x00009FD100429F50 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Department] ([departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'951b242a-3ccb-40d0-91fb-f593e154c012', N'Graphic-Repro Dept', N'Ba Tien', CAST(0x00009FD100429F50 AS DateTime), NULL, NULL, 1)
/****** Object:  Table [dbo].[Error]    Script Date: 01/19/2012 15:19:35 ******/
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
INSERT [dbo].[Error] ([errorId], [name]) VALUES (N'4de09fa0-6d56-4863-8988-5e13876d7103', N'Damage')
INSERT [dbo].[Error] ([errorId], [name]) VALUES (N'882119c3-1281-4562-bb27-74f6932f8c14', N'Wrong specification')
INSERT [dbo].[Error] ([errorId], [name]) VALUES (N'73a84f18-47ba-41a5-b8f0-8b2be42d35b5', N'Previous Step Incomplete')
INSERT [dbo].[Error] ([errorId], [name]) VALUES (N'7826871e-fe82-4483-bda1-9d1fbb542194', N'Wrong Material')
/****** Object:  Table [dbo].[Role]    Script Date: 01/19/2012 15:19:35 ******/
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
INSERT [dbo].[Role] ([roleId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'9ee597ce-a7a3-441e-91ba-1e2f88aef706', N'Production', N'admin', CAST(0x00009FD800635F12 AS DateTime), NULL, NULL, 0)
INSERT [dbo].[Role] ([roleId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'f75d665c-0bd0-4504-b881-49f8eeae5d86', N'Accountant', N'admin', CAST(0x00009FD8006318DA AS DateTime), N'admin', CAST(0x00009FD80072F495 AS DateTime), 1)
INSERT [dbo].[Role] ([roleId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'0c6ab011-fbac-4eda-912c-6e148a101add', N'Report', N'admin', CAST(0x00009FD800619F26 AS DateTime), N'admin', CAST(0x00009FD800795B32 AS DateTime), 1)
INSERT [dbo].[Role] ([roleId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'6419fd9b-af4d-476a-9c83-7a9732b8304a', N'Director', N'admin', CAST(0x00009FD80062E068 AS DateTime), NULL, NULL, 1)
INSERT [dbo].[Role] ([roleId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive]) VALUES (N'4450f261-cb23-44ac-a2e3-f484915630f7', N'Admin', N'asdf', CAST(0x00009FD7003C672B AS DateTime), N'super', CAST(0x00009FD8006877F8 AS DateTime), 1)
/****** Object:  Table [dbo].[Workflow]    Script Date: 01/19/2012 15:19:35 ******/
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
INSERT [dbo].[Workflow] ([workflowId], [departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive], [prevWorkflowID], [nextWorkflowID]) VALUES (N'8d803ad5-e625-42cc-9800-073897653d26', N'3ecff3ca-6379-4d9b-b4b3-354f7147fe0c', N'Engraving To Production', N'Ba Tien', CAST(0x00009FD8003658DF AS DateTime), N'system', CAST(0x00009FD800493F8F AS DateTime), 1, N'ccda355c-8301-42e9-8856-6220cc22d020', N'47d51268-f6f7-4bb8-a841-70a403729af5')
INSERT [dbo].[Workflow] ([workflowId], [departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive], [prevWorkflowID], [nextWorkflowID]) VALUES (N'd6b0ac57-c413-460d-b78c-1717171409d1', N'951b242a-3ccb-40d0-91fb-f593e154c012', N'Graphic to Engraving', N'Ba Tien', CAST(0x00009FD8003658DF AS DateTime), N'system', CAST(0x00009FD80047BEA8 AS DateTime), 1, N'59068baf-7496-4e01-aefe-20972a297aff', N'8d803ad5-e625-42cc-9800-073897653d26')
INSERT [dbo].[Workflow] ([workflowId], [departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive], [prevWorkflowID], [nextWorkflowID]) VALUES (N'59068baf-7496-4e01-aefe-20972a297aff', N'cb609ff0-00b7-4994-94f8-420054eebd7b', N'Sales to Graphic', N'Ba Tien', CAST(0x00009FD8003658DE AS DateTime), N'system', CAST(0x00009FD80047C826 AS DateTime), 1, NULL, N'd6b0ac57-c413-460d-b78c-1717171409d1')
INSERT [dbo].[Workflow] ([workflowId], [departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive], [prevWorkflowID], [nextWorkflowID]) VALUES (N'ccda355c-8301-42e9-8856-6220cc22d020', N'83a044b8-f5fc-49a4-bb75-3a313053adda', N'Production to Engraving', N'Ba Tien', CAST(0x00009FD8003658DF AS DateTime), N'system', CAST(0x00009FD800487B05 AS DateTime), 1, N'68f9beaa-d587-452f-bc84-6558279dd00a', N'8d803ad5-e625-42cc-9800-073897653d26')
INSERT [dbo].[Workflow] ([workflowId], [departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive], [prevWorkflowID], [nextWorkflowID]) VALUES (N'68f9beaa-d587-452f-bc84-6558279dd00a', N'dba63bf4-9af0-44b5-8004-5d419a13683f', N'Mechanical To Production', N'Ba Tien', CAST(0x00009FD8003658DF AS DateTime), N'system', CAST(0x00009FD8004878BF AS DateTime), 1, N'eb189601-15cc-405f-af5c-8a687d5fd793', N'ccda355c-8301-42e9-8856-6220cc22d020')
INSERT [dbo].[Workflow] ([workflowId], [departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive], [prevWorkflowID], [nextWorkflowID]) VALUES (N'a778000a-743f-4536-b05d-69851c756718', N'8e5c974f-e7a9-4d84-a610-50dc178edc54', N'Printing to QC2', N'Ba Tien', CAST(0x00009FD8003658DF AS DateTime), N'system', CAST(0x00009FD8004875FD AS DateTime), 1, N'47d51268-f6f7-4bb8-a841-70a403729af5', N'c1fb4c8b-b6dc-4c7a-a81e-74f5dd11510c')
INSERT [dbo].[Workflow] ([workflowId], [departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive], [prevWorkflowID], [nextWorkflowID]) VALUES (N'47d51268-f6f7-4bb8-a841-70a403729af5', N'83a044b8-f5fc-49a4-bb75-3a313053adda', N'Production to Printing', N'Ba Tien', CAST(0x00009FD8003658DF AS DateTime), N'system', CAST(0x00009FD8004872B3 AS DateTime), 1, N'8d803ad5-e625-42cc-9800-073897653d26', N'a778000a-743f-4536-b05d-69851c756718')
INSERT [dbo].[Workflow] ([workflowId], [departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive], [prevWorkflowID], [nextWorkflowID]) VALUES (N'c1fb4c8b-b6dc-4c7a-a81e-74f5dd11510c', N'5b741cbc-93b0-4b20-b8ab-d0ce0ebf61a7', N'QC2 To Prod Mgmt', N'Ba Tien', CAST(0x00009FD8003658DF AS DateTime), N'system', CAST(0x00009FD800486E5A AS DateTime), 1, N'a778000a-743f-4536-b05d-69851c756718', N'00000000-0000-0000-0000-000000000000')
INSERT [dbo].[Workflow] ([workflowId], [departmentId], [name], [created_by], [created_date], [updated_by], [updated_date], [isactive], [prevWorkflowID], [nextWorkflowID]) VALUES (N'eb189601-15cc-405f-af5c-8a687d5fd793', N'cb609ff0-00b7-4994-94f8-420054eebd7b', N'Sales to Mechanical', N'Ba Tien', CAST(0x00009FD8003658DF AS DateTime), N'system', CAST(0x00009FD80047F2EA AS DateTime), 1, NULL, N'68f9beaa-d587-452f-bc84-6558279dd00a')
/****** Object:  Table [dbo].[Role_Right_ref]    Script Date: 01/19/2012 15:19:35 ******/
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
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'e187e318-8238-48a6-814e-0d6eb4a2a46d', N'f75d665c-0bd0-4504-b881-49f8eeae5d86', N'14f366a1-5ee2-445d-b049-15e5320bb57f', N'admin', CAST(0x00009FD80072F49A AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'2e37a7d7-6213-4dec-8ee0-1be6e3a6fafd', N'4450f261-cb23-44ac-a2e3-f484915630f7', N'c912e498-bb9e-4e84-b2cb-bb56a21e1c4a', N'super', CAST(0x00009FD800687819 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'b5dd3386-1a1e-4986-bebc-1cdf24fbf996', N'4450f261-cb23-44ac-a2e3-f484915630f7', N'd15b5e23-c275-46b1-93a4-15c11b8c6454', N'super', CAST(0x00009FD800687819 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'0bd1212d-25f3-4e30-b16c-228525a90dfa', N'9ee597ce-a7a3-441e-91ba-1e2f88aef706', N'b1b78a5a-d14a-48b3-9c3f-70c806abf138', N'admin', CAST(0x00009FD800635F17 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'8e147b88-997b-4b98-827f-2a1707bbcbcd', N'9ee597ce-a7a3-441e-91ba-1e2f88aef706', N'e3f30442-8b9c-45de-adb7-4e12be0c25bc', N'admin', CAST(0x00009FD800635F17 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'80e6ae38-e3d1-47aa-8ee7-307b0948f7a0', N'f75d665c-0bd0-4504-b881-49f8eeae5d86', N'd06bc8e5-f29d-4c44-b78c-af2d97097c8f', N'admin', CAST(0x00009FD80072F49A AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'bf12108e-c0fd-4b5c-88f0-312d303e9721', N'4450f261-cb23-44ac-a2e3-f484915630f7', N'3e81e34a-d984-43f7-bff3-49454db7b9da', N'super', CAST(0x00009FD800687819 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'bb2c2bde-67c2-4584-8439-33213ac69de8', N'4450f261-cb23-44ac-a2e3-f484915630f7', N'b1b78a5a-d14a-48b3-9c3f-70c806abf138', N'super', CAST(0x00009FD800687819 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'a972ebea-c49d-42e0-8098-47db03ab572e', N'0c6ab011-fbac-4eda-912c-6e148a101add', N'1a1b14d3-caf4-4361-898c-30b2af754de5', N'admin', CAST(0x00009FD800795B34 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'e231999e-4326-4e55-8aa4-4c492fc47340', N'4450f261-cb23-44ac-a2e3-f484915630f7', N'7a1bbf1a-009f-49c5-82d7-068dd3b4c080', N'super', CAST(0x00009FD800687819 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'4d06eef7-a7db-4339-8b79-4dfed1e71e72', N'6419fd9b-af4d-476a-9c83-7a9732b8304a', N'c912e498-bb9e-4e84-b2cb-bb56a21e1c4a', N'admin', CAST(0x00009FD80062E068 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'e398fdd5-f19d-459c-852f-4e14cdaacdbc', N'9ee597ce-a7a3-441e-91ba-1e2f88aef706', N'f351bcf5-05b6-42ad-a20e-549445165899', N'admin', CAST(0x00009FD800635F17 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'4e464495-a752-48ff-b157-67722c42abf9', N'9ee597ce-a7a3-441e-91ba-1e2f88aef706', N'330badc6-3cb6-48ee-8d1f-8057690b312d', N'admin', CAST(0x00009FD800635F17 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'51529bed-d86a-4149-ab34-7d3976f6f0e4', N'4450f261-cb23-44ac-a2e3-f484915630f7', N'330badc6-3cb6-48ee-8d1f-8057690b312d', N'super', CAST(0x00009FD800687819 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'6ef8d6ec-f9de-4e2d-b866-7f343e548c45', N'4450f261-cb23-44ac-a2e3-f484915630f7', N'f351bcf5-05b6-42ad-a20e-549445165899', N'super', CAST(0x00009FD800687819 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'a32fd203-1af8-4ac2-b352-8df4874d2fa5', N'4450f261-cb23-44ac-a2e3-f484915630f7', N'aad14991-61d2-4277-92a4-2f083a4ec749', N'super', CAST(0x00009FD80068781E AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'2b7fd657-8e1a-4442-b85a-901b55a392d3', N'0c6ab011-fbac-4eda-912c-6e148a101add', N'c912e498-bb9e-4e84-b2cb-bb56a21e1c4a', N'admin', CAST(0x00009FD800795B34 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'be66c1d8-f77f-46ca-ade5-9025f51148d6', N'9ee597ce-a7a3-441e-91ba-1e2f88aef706', N'ef908f13-7bbf-4940-9af2-d892b64c890d', N'admin', CAST(0x00009FD800635F17 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'2b75830f-9324-4505-afb8-958ee951e9f2', N'6419fd9b-af4d-476a-9c83-7a9732b8304a', N'd06bc8e5-f29d-4c44-b78c-af2d97097c8f', N'admin', CAST(0x00009FD80062E068 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'a9ac6883-7451-4f2e-8315-95bafa305bc1', N'0c6ab011-fbac-4eda-912c-6e148a101add', N'd06bc8e5-f29d-4c44-b78c-af2d97097c8f', N'admin', CAST(0x00009FD800795B33 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'8947ac2e-5089-4605-8bfc-981a706e2d09', N'6419fd9b-af4d-476a-9c83-7a9732b8304a', N'1a1b14d3-caf4-4361-898c-30b2af754de5', N'admin', CAST(0x00009FD80062E068 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'040be479-2ad5-4e85-8a25-9f8939801216', N'4450f261-cb23-44ac-a2e3-f484915630f7', N'ef908f13-7bbf-4940-9af2-d892b64c890d', N'super', CAST(0x00009FD800687819 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'58c4fd40-ef7f-4c90-82f6-b9ebb4583273', N'f75d665c-0bd0-4504-b881-49f8eeae5d86', N'ef908f13-7bbf-4940-9af2-d892b64c890d', N'admin', CAST(0x00009FD80072F49B AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'd76bd428-44cb-4bc8-8dc1-bd57ff63b9e8', N'9ee597ce-a7a3-441e-91ba-1e2f88aef706', N'fe0c5af8-03fe-4391-95a1-0d793598997a', N'admin', CAST(0x00009FD800635F17 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'08a57ead-0381-42cc-9b06-c18f2a67d5c2', N'4450f261-cb23-44ac-a2e3-f484915630f7', N'd06bc8e5-f29d-4c44-b78c-af2d97097c8f', N'super', CAST(0x00009FD800687819 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'db1ce28a-4fdf-40b6-a148-c2ae9c20ff65', N'4450f261-cb23-44ac-a2e3-f484915630f7', N'14f366a1-5ee2-445d-b049-15e5320bb57f', N'super', CAST(0x00009FD800687819 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'bd94db4a-7df8-49f1-a613-c498adb25413', N'4450f261-cb23-44ac-a2e3-f484915630f7', N'fa04e969-b2e9-4a40-bacd-8ded979e74c2', N'super', CAST(0x00009FD800687819 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'aa52c539-4978-435f-8f06-d19ddb6f43df', N'4450f261-cb23-44ac-a2e3-f484915630f7', N'edd9f355-43b7-43e7-909c-0f5e63f00e2b', N'super', CAST(0x00009FD80068781E AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'e2853694-e66c-489d-a9b0-d2f0dd48d1b4', N'4450f261-cb23-44ac-a2e3-f484915630f7', N'e75b36b6-0a78-4aab-8cf6-5bcdc3d1a5e3', N'super', CAST(0x00009FD800687819 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'4cd2aad1-90b2-482f-967b-d49bb1237fda', N'4450f261-cb23-44ac-a2e3-f484915630f7', N'12e6925d-348f-41c8-8d63-0f43af13aa84', N'super', CAST(0x00009FD80068781E AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'2d6efeaf-b2a1-447c-8733-d4cd5eb36dae', N'9ee597ce-a7a3-441e-91ba-1e2f88aef706', N'd15b5e23-c275-46b1-93a4-15c11b8c6454', N'admin', CAST(0x00009FD800635F17 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'1dda13ef-b274-4063-b8da-de2649712aa9', N'f75d665c-0bd0-4504-b881-49f8eeae5d86', N'e3f30442-8b9c-45de-adb7-4e12be0c25bc', N'admin', CAST(0x00009FD80072F49A AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'cacc5268-89f5-44da-88bc-e6f277ce1f39', N'4450f261-cb23-44ac-a2e3-f484915630f7', N'fe0c5af8-03fe-4391-95a1-0d793598997a', N'super', CAST(0x00009FD800687819 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'e442fb61-f947-40b1-8c88-eaca04e2c583', N'9ee597ce-a7a3-441e-91ba-1e2f88aef706', N'7a1bbf1a-009f-49c5-82d7-068dd3b4c080', N'admin', CAST(0x00009FD800635F17 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'da0ecdca-68f0-4d56-bc34-f280a6687411', N'4450f261-cb23-44ac-a2e3-f484915630f7', N'1a1b14d3-caf4-4361-898c-30b2af754de5', N'super', CAST(0x00009FD800687819 AS DateTime), NULL, NULL)
INSERT [dbo].[Role_Right_ref] ([Id], [roleId], [rightId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'81293930-aa32-4467-a5fd-f38f9a8fd7a0', N'4450f261-cb23-44ac-a2e3-f484915630f7', N'e3f30442-8b9c-45de-adb7-4e12be0c25bc', N'super', CAST(0x00009FD800687819 AS DateTime), NULL, NULL)
/****** Object:  Table [dbo].[Printer]    Script Date: 01/19/2012 15:19:35 ******/
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
INSERT [dbo].[Printer] ([printer_id], [customer_id], [address], [code], [hole_stick], [name], [slot_latch], [status], [created_date], [created_by], [updated_date], [updated_by]) VALUES (N'963d5e62-d01f-4eaa-8c57-32c987c5158d', N'c8de51b8-c8d7-4d42-90b0-8fe6f477ca8c', N'', N'14', N'60 x 15', N'Nhựa Tân Hưng', N'7 x 4', N'', CAST(0x00009FD80060A499 AS DateTime), N'Ba Tien', NULL, N'Ba Tien')
INSERT [dbo].[Printer] ([printer_id], [customer_id], [address], [code], [hole_stick], [name], [slot_latch], [status], [created_date], [created_by], [updated_date], [updated_by]) VALUES (N'b98ff0dc-bd5a-43ff-936a-60288ad09776', N'7feb104a-1226-42b4-aefc-c45246d2190d', N'', N'1Q', N'70 x 15', N'Viky', N'12 x 5', N'', CAST(0x00009FD80060A499 AS DateTime), N'Ba Tien', NULL, N'Ba Tien')
INSERT [dbo].[Printer] ([printer_id], [customer_id], [address], [code], [hole_stick], [name], [slot_latch], [status], [created_date], [created_by], [updated_date], [updated_by]) VALUES (N'3efac799-8f70-4b31-95c1-8b6faed11771', N'4a9cde7a-2ca7-42fc-8cd4-2aa004262a2e', N'', N'12', N'70 x 15', N'Anh Hà (BN) Máy 3', N'10 x 9 (1 Đầu)', N'', CAST(0x00009FD80060A499 AS DateTime), N'Ba Tien', NULL, N'Ba Tien')
INSERT [dbo].[Printer] ([printer_id], [customer_id], [address], [code], [hole_stick], [name], [slot_latch], [status], [created_date], [created_by], [updated_date], [updated_by]) VALUES (N'c6ce3b1d-379e-4bc5-bc87-f71043f696f5', N'f6e14c03-03cb-4123-a178-44b2e24bf631', N'', N'', N'70 x 15', N'Anh Hà (BN) Máy 3', N'10 x 9 (1 Đầu)', N'', CAST(0x00009FD10042CCFF AS DateTime), N'Ba Tien', NULL, N'Ba Tien')
/****** Object:  Table [dbo].[Order]    Script Date: 01/19/2012 15:19:35 ******/
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
	[price_type] [nvarchar](50) NULL,
	[redo_pct] [decimal](18, 2) NULL,
	[old_core] [bit] NULL,
	[delivery_date] [datetime] NULL,
	[order_type] [nvarchar](50) NULL,
	[status] [nvarchar](50) NULL,
	[set_code] [nvarchar](50) NULL,
	[cylinder_type] [nvarchar](50) NULL,
	[old_order_code] [nvarchar](50) NULL,
	[priority] [nvarchar](50) NULL,
	[created_date] [datetime] NOT NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[updated_date] [datetime] NULL,
	[updated_by] [nvarchar](50) NULL,
	[belong_to_set] [nvarchar](50) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[orderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Order] ([orderId], [order_code], [customer_id], [customer_rep], [product_name], [price_type], [redo_pct], [old_core], [delivery_date], [order_type], [status], [set_code], [cylinder_type], [old_order_code], [priority], [created_date], [created_by], [updated_date], [updated_by], [belong_to_set]) VALUES (N'4e9966d5-85b4-42f2-8e24-3ae019ca5989', N'0013-112', N'f6e14c03-03cb-4123-a178-44b2e24bf631', N'Tin', N'PISTON', N'', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0x00009FE900000000 AS DateTime), N'NEW', N'PROD', N'XDPISTON', N'1', NULL, N'MED', CAST(0x00009FD800000000 AS DateTime), N'finance', CAST(0x00009FD80075797C AS DateTime), N'admin', N'')
INSERT [dbo].[Order] ([orderId], [order_code], [customer_id], [customer_rep], [product_name], [price_type], [redo_pct], [old_core], [delivery_date], [order_type], [status], [set_code], [cylinder_type], [old_order_code], [priority], [created_date], [created_by], [updated_date], [updated_by], [belong_to_set]) VALUES (N'4e2fc36d-a8dd-4c05-8111-8ce322c7a5cc', N'0009-112', N'f6e14c03-03cb-4123-a178-44b2e24bf631', N'Tim', N'Piston', N'', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0x00009FD500004650 AS DateTime), N'NEW', N'PROD', N'xjyyi', N'1', NULL, N'MED', CAST(0x00009FD500004650 AS DateTime), N'tin', CAST(0x00009FD800528299 AS DateTime), N'admin', N'')
INSERT [dbo].[Order] ([orderId], [order_code], [customer_id], [customer_rep], [product_name], [price_type], [redo_pct], [old_core], [delivery_date], [order_type], [status], [set_code], [cylinder_type], [old_order_code], [priority], [created_date], [created_by], [updated_date], [updated_by], [belong_to_set]) VALUES (N'4f9331fa-8220-4ba7-adaf-b11016e542e9', N'0015-112', N'4a9cde7a-2ca7-42fc-8cd4-2aa004262a2e', N'', N'asdf', N'', CAST(0.00 AS Decimal(18, 2)), NULL, CAST(0x00009FE300000000 AS DateTime), N'NEW', N'STG', N'asdf', N'', NULL, N'MED', CAST(0x00009FD000000000 AS DateTime), N'', CAST(0x00009FD800DB3C2B AS DateTime), N'admin', N'')
/****** Object:  StoredProcedure [dbo].[GenerateNewID]    Script Date: 01/19/2012 15:19:33 ******/
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
/****** Object:  Table [dbo].[Employee]    Script Date: 01/19/2012 15:19:35 ******/
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
	[language] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[employeeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Employee] ([employeeId], [departmentId], [surname], [given_name], [staff_code], [barcode], [position], [username], [password], [created_by], [created_date], [updated_date], [updated_by], [isactive], [language]) VALUES (N'00000000-0000-0000-0000-000000000000', N'3ecff3ca-6379-4d9b-b4b3-354f7147fe0c', N'Super', N'Super', N'Super', N'Super', N'Super', N'super', N'super', N'system', CAST(0x00009FCB00000000 AS DateTime), NULL, NULL, 1, N'EN')
INSERT [dbo].[Employee] ([employeeId], [departmentId], [surname], [given_name], [staff_code], [barcode], [position], [username], [password], [created_by], [created_date], [updated_date], [updated_by], [isactive], [language]) VALUES (N'df179cb4-ce5e-4aa8-bce9-05d26cdada92', N'3ecff3ca-6379-4d9b-b4b3-354f7147fe0c', N'new user', N'New User', N'new001', N'new001', N'NA', N'newuser', N'newuser', N'admin', CAST(0x00009FD800000000 AS DateTime), NULL, NULL, 1, N'EN')
INSERT [dbo].[Employee] ([employeeId], [departmentId], [surname], [given_name], [staff_code], [barcode], [position], [username], [password], [created_by], [created_date], [updated_date], [updated_by], [isactive], [language]) VALUES (N'2c2f6803-8491-45f6-a866-80a4d3a691ec', N'3ecff3ca-6379-4d9b-b4b3-354f7147fe0c', N'', N'admin', N'ADM001', N'b001', N'Department Admin', N'admin', N'admin', N'user1', CAST(0x00009FD400000000 AS DateTime), NULL, NULL, 1, N'EN')
INSERT [dbo].[Employee] ([employeeId], [departmentId], [surname], [given_name], [staff_code], [barcode], [position], [username], [password], [created_by], [created_date], [updated_date], [updated_by], [isactive], [language]) VALUES (N'a29e5a7e-b836-40d2-807d-9bd5298ea7b1', N'3ecff3ca-6379-4d9b-b4b3-354f7147fe0c', N'', N'Finance User 1', N'002', N'b002', N'', N'financeuser1', N'financeuser1', N'user1', CAST(0x00009FD400000000 AS DateTime), NULL, NULL, 1, N'EN')
INSERT [dbo].[Employee] ([employeeId], [departmentId], [surname], [given_name], [staff_code], [barcode], [position], [username], [password], [created_by], [created_date], [updated_date], [updated_by], [isactive], [language]) VALUES (N'e28eb050-0b33-47b9-8886-9ed77931a09c', N'3ecff3ca-6379-4d9b-b4b3-354f7147fe0c', N'tin', N'kyawoo3', N'001', N'b003', N'IT', N'tinkyawoo', N'password', N'system', CAST(0x00009FCB00000000 AS DateTime), NULL, NULL, 1, N'EN')
INSERT [dbo].[Employee] ([employeeId], [departmentId], [surname], [given_name], [staff_code], [barcode], [position], [username], [password], [created_by], [created_date], [updated_date], [updated_by], [isactive], [language]) VALUES (N'd57a0a4a-7951-44e2-8975-db71e779121b', N'3ecff3ca-6379-4d9b-b4b3-354f7147fe0c', N'tonny', N'inspector', N'TN001', N'TN001', N'QC', N'inspector', N'inspector', N'admin', CAST(0x00009FD800000000 AS DateTime), NULL, NULL, 1, N'EN')
/****** Object:  Table [dbo].[Emp_Role_ref]    Script Date: 01/19/2012 15:19:35 ******/
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
INSERT [dbo].[Emp_Role_ref] ([Id], [employeeId], [roleId], [isapproved], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'0949a87b-9e41-4ce1-89e2-0d4175b4064e', N'd57a0a4a-7951-44e2-8975-db71e779121b', N'0c6ab011-fbac-4eda-912c-6e148a101add', 1, N'admin', CAST(0x00009FD800000000 AS DateTime), NULL, NULL)
INSERT [dbo].[Emp_Role_ref] ([Id], [employeeId], [roleId], [isapproved], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'968eb8af-8be0-4a56-b365-a7f2ae3a8998', N'df179cb4-ce5e-4aa8-bce9-05d26cdada92', N'f75d665c-0bd0-4504-b881-49f8eeae5d86', 1, N'admin', CAST(0x00009FD800000000 AS DateTime), NULL, NULL)
INSERT [dbo].[Emp_Role_ref] ([Id], [employeeId], [roleId], [isapproved], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'488e057a-1f4a-4610-bd89-b624d34a2693', N'2c2f6803-8491-45f6-a866-80a4d3a691ec', N'4450f261-cb23-44ac-a2e3-f484915630f7', 1, N'super', CAST(0x00009FD800000000 AS DateTime), NULL, NULL)
INSERT [dbo].[Emp_Role_ref] ([Id], [employeeId], [roleId], [isapproved], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'e9688fea-86c9-4fe1-b25b-c7b0108f72f1', N'a29e5a7e-b836-40d2-807d-9bd5298ea7b1', N'f75d665c-0bd0-4504-b881-49f8eeae5d86', 1, N'admin', CAST(0x00009FD800000000 AS DateTime), NULL, NULL)
/****** Object:  Table [dbo].[Step]    Script Date: 01/19/2012 15:19:35 ******/
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
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'bd68863f-3b15-49dd-8664-079d0941f3f8', N'59068baf-7496-4e01-aefe-20972a297aff', N'Graphic to Engraving(END)', N'', N'', N'', 72, 334, N'workflow_app', CAST(0x00009FD800431297 AS DateTime), N'workflow_app', CAST(0x00009FD80047C829 AS DateTime), 1, 0, 0)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'd844681e-c67c-4c27-8c92-0894aa913e42', N'a778000a-743f-4536-b05d-69851c756718', N'QC2 To Prod Mgmt(END)', N'', N'', N'', 58, 291, N'workflow_app', CAST(0x00009FD80044F1EC AS DateTime), N'workflow_app', CAST(0x00009FD800487601 AS DateTime), 1, 0, 0)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'dfc0121a-7bfd-4c18-a5e3-14693e265a24', N'd6b0ac57-c413-460d-b78c-1717171409d1', N'Sales to Graphic (BEGIN)', N'', N'', N'', 10, 10, N'workflow_app', CAST(0x00009FD800430086 AS DateTime), N'workflow_app', CAST(0x00009FD80047BEAC AS DateTime), 1, 0, 1)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'4f1abfe1-ed2e-4d25-a746-2233d5dfc385', N'8d803ad5-e625-42cc-9800-073897653d26', N'Engrave', N'', N'', N'', 67, 198, N'workflow_app', CAST(0x00009FD80042E2FD AS DateTime), N'workflow_app', CAST(0x00009FD800493F92 AS DateTime), 1, 1, 0)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'64bec2c7-0f7d-4c22-b339-258a1404d844', N'47d51268-f6f7-4bb8-a841-70a403729af5', N'Printing to QC2(END)', N'', N'', N'', 146, 305, N'workflow_app', CAST(0x00009FD80045840C AS DateTime), N'workflow_app', CAST(0x00009FD8004872B6 AS DateTime), 1, 0, 0)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'82c3d831-26fa-4978-9993-28880011852a', N'47d51268-f6f7-4bb8-a841-70a403729af5', N'Engraving To Production (BEGIN)', N'', N'', N'', 10, 10, N'workflow_app', CAST(0x00009FD80045840C AS DateTime), N'workflow_app', CAST(0x00009FD8004872BC AS DateTime), 1, 0, 1)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'e0ee2253-0fbb-4cc5-96a8-45480514654b', N'8d803ad5-e625-42cc-9800-073897653d26', N'Measure Depth', N'', N'', N'', 99, 88, N'workflow_app', CAST(0x00009FD80042E2FD AS DateTime), N'workflow_app', CAST(0x00009FD800493F98 AS DateTime), 1, 1, 0)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'0ec6b3a6-e467-4bfe-a345-467ed0a0c74f', N'a778000a-743f-4536-b05d-69851c756718', N'Print Sample', N'', N'', N'', 87, 108, N'workflow_app', CAST(0x00009FD80044F1EC AS DateTime), N'workflow_app', CAST(0x00009FD800487606 AS DateTime), 1, 1, 0)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'f41f84f0-7b7a-4a67-963a-5165ae12b0a2', N'59068baf-7496-4e01-aefe-20972a297aff', N'Nil (BEGIN)', N'', N'', N'', 67, 12, N'workflow_app', CAST(0x00009FD800431297 AS DateTime), N'workflow_app', CAST(0x00009FD80047C82E AS DateTime), 1, 0, 1)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'b873ec15-f296-461c-84be-59247d9a540e', N'c1fb4c8b-b6dc-4c7a-a81e-74f5dd11510c', N'Nil(END)', N'', N'', N'', 106, 339, N'workflow_app', CAST(0x00009FD80045CA6F AS DateTime), N'workflow_app', CAST(0x00009FD800486E5D AS DateTime), 1, 0, 0)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'8cd15db6-4370-4d64-8b08-593d064cc374', N'47d51268-f6f7-4bb8-a841-70a403729af5', N'Coat Chrome', N'', N'', N'', 110, 128, N'workflow_app', CAST(0x00009FD80045840C AS DateTime), N'workflow_app', CAST(0x00009FD8004872C3 AS DateTime), 1, 1, 0)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'80a1b7e6-a4a7-4e96-91b4-5f13156066ff', N'ccda355c-8301-42e9-8856-6220cc22d020', N'Mechanical To Production (BEGIN)', N'', N'', N'', 85, 6, N'workflow_app', CAST(0x00009FD800445761 AS DateTime), N'workflow_app', CAST(0x00009FD800487B09 AS DateTime), 1, 0, 1)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'7d27b70c-2783-4ba3-b593-5fdad66c798f', N'68f9beaa-d587-452f-bc84-6558279dd00a', N'Create Core', N'', N'', N'', 171, 125, N'workflow_app', CAST(0x00009FD80044A7CA AS DateTime), N'workflow_app', CAST(0x00009FD8004878C4 AS DateTime), 1, 1, 0)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'76236d69-9db0-4bfb-bb58-64d4f7552a2f', N'8d803ad5-e625-42cc-9800-073897653d26', N'Production to Engraving (BEGIN)', N'', N'', N'', 31, 16, N'workflow_app', CAST(0x00009FD80042E2FB AS DateTime), N'workflow_app', CAST(0x00009FD800493FA0 AS DateTime), 1, 0, 1)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'930d496e-b665-4209-9c62-7b37e8f22e6e', N'68f9beaa-d587-452f-bc84-6558279dd00a', N'Sales to Mechanical (BEGIN)', N'', N'', N'', 36, 10, N'workflow_app', CAST(0x00009FD80044A7CA AS DateTime), N'workflow_app', CAST(0x00009FD8004878CA AS DateTime), 1, 0, 1)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'd4b154ee-eca8-462e-b929-90f2465ecc03', N'8d803ad5-e625-42cc-9800-073897653d26', N'Lasering', N'', N'', N'', 285, 133, N'workflow_app', CAST(0x00009FD80042E2FD AS DateTime), N'workflow_app', CAST(0x00009FD800493FA6 AS DateTime), 1, 1, 0)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'6856c8f2-e602-49e1-839b-a2715ebe8004', N'ccda355c-8301-42e9-8856-6220cc22d020', N'Engraving To Production(END)', N'', N'', N'', 74, 369, N'workflow_app', CAST(0x00009FD800445761 AS DateTime), N'workflow_app', CAST(0x00009FD800487B0F AS DateTime), 1, 0, 0)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'67d0babf-f787-43fe-a267-a58d8a0596be', N'c1fb4c8b-b6dc-4c7a-a81e-74f5dd11510c', N'Printing to QC2 (BEGIN)', N'', N'', N'', 10, 10, N'workflow_app', CAST(0x00009FD80045CA6E AS DateTime), N'workflow_app', CAST(0x00009FD800486E64 AS DateTime), 1, 0, 1)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'dfd89e30-a332-4a5b-84b5-a8f3492c3ef3', N'a778000a-743f-4536-b05d-69851c756718', N'Production to Printing (BEGIN)', N'', N'', N'', 14, 1, N'workflow_app', CAST(0x00009FD80044F1EC AS DateTime), N'workflow_app', CAST(0x00009FD80048760C AS DateTime), 1, 0, 1)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'60b339b1-0ea3-4ae3-83ca-b4c6f075ea5e', N'eb189601-15cc-405f-af5c-8a687d5fd793', N'Mechanical To Production(END)', N'', N'', N'', 36, 304, N'workflow_app', CAST(0x00009FD80045DDA8 AS DateTime), N'workflow_app', CAST(0x00009FD80047F2EE AS DateTime), 1, 0, 0)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'3fc49b85-08fa-4335-84be-c76f117a1279', N'd6b0ac57-c413-460d-b78c-1717171409d1', N'Engraving To Production(END)', N'', N'', N'', 21, 89, N'workflow_app', CAST(0x00009FD800430086 AS DateTime), N'workflow_app', CAST(0x00009FD80047BEB1 AS DateTime), 1, 0, 0)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'04091e18-ff1f-485f-8048-dcc609ca2c2c', N'8d803ad5-e625-42cc-9800-073897653d26', N'Production to Printing(END)', N'', N'', N'', 124, 285, N'workflow_app', CAST(0x00009FD80042E2FD AS DateTime), N'workflow_app', CAST(0x00009FD800493FAB AS DateTime), 1, 0, 0)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'c56d0659-210c-4761-b71c-e6b73b7207f4', N'ccda355c-8301-42e9-8856-6220cc22d020', N'Coat Copper', N'', N'', N'', 184, 147, N'workflow_app', CAST(0x00009FD800445761 AS DateTime), N'workflow_app', CAST(0x00009FD800487B15 AS DateTime), 1, 1, 0)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'975eb664-df15-4f73-8906-e7746e5f1d18', N'68f9beaa-d587-452f-bc84-6558279dd00a', N'Production to Engraving(END)', N'', N'', N'', 75, 308, N'workflow_app', CAST(0x00009FD80044A7CA AS DateTime), N'workflow_app', CAST(0x00009FD8004878D1 AS DateTime), 1, 0, 0)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'35318b60-33ba-48c1-a9d7-ed84c745ab5f', N'eb189601-15cc-405f-af5c-8a687d5fd793', N'Nil (BEGIN)', N'', N'', N'', 10, 10, N'workflow_app', CAST(0x00009FD80045DDA8 AS DateTime), N'workflow_app', CAST(0x00009FD80047F2F3 AS DateTime), 1, 0, 1)
INSERT [dbo].[Step] ([stepId], [workflowId], [name], [description], [instruction], [note], [x], [y], [created_by], [created_date], [updated_by], [updated_date], [isActive], [isStep], [isBegin]) VALUES (N'1ceb8cb2-1a95-4db5-aebc-fe13ba77da74', N'c1fb4c8b-b6dc-4c7a-a81e-74f5dd11510c', N'Check Print Sample', N'', N'', N'', 85, 169, N'workflow_app', CAST(0x00009FD80045CA6F AS DateTime), N'workflow_app', CAST(0x00009FD800486E6A AS DateTime), 1, 1, 0)
/****** Object:  Table [dbo].[Order_Log]    Script Date: 01/19/2012 15:19:35 ******/
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
INSERT [dbo].[Order_Log] ([id], [workflowId], [orderId], [order_status], [dept_name], [updated_date], [remarks], [updated_by], [related_cyl]) VALUES (N'0552d3ca-4785-4e51-a406-14f53d10af58', N'59068baf-7496-4e01-aefe-20972a297aff', N'4e9966d5-85b4-42f2-8e24-3ae019ca5989', N'STG', N'Sales Dept', CAST(0x00009FD80075797E AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[Order_Log] ([id], [workflowId], [orderId], [order_status], [dept_name], [updated_date], [remarks], [updated_by], [related_cyl]) VALUES (N'f3707f3a-4deb-4077-a477-5452259ca6dc', N'eb189601-15cc-405f-af5c-8a687d5fd793', N'4e9966d5-85b4-42f2-8e24-3ae019ca5989', N'PROD', N'Sales Dept', CAST(0x00009FD80075C394 AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[Order_Log] ([id], [workflowId], [orderId], [order_status], [dept_name], [updated_date], [remarks], [updated_by], [related_cyl]) VALUES (N'8a5a4577-c26a-4b52-b0d3-5e0274341765', N'eb189601-15cc-405f-af5c-8a687d5fd793', N'4e2fc36d-a8dd-4c05-8111-8ce322c7a5cc', N'PROD', N'Sales Dept', CAST(0x00009FD80057B2C2 AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[Order_Log] ([id], [workflowId], [orderId], [order_status], [dept_name], [updated_date], [remarks], [updated_by], [related_cyl]) VALUES (N'0ea210c1-1736-4dcf-a66d-73d1ff48b577', N'59068baf-7496-4e01-aefe-20972a297aff', N'4e2fc36d-a8dd-4c05-8111-8ce322c7a5cc', N'STG', N'Sales Dept', CAST(0x00009FD80052829E AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[Order_Log] ([id], [workflowId], [orderId], [order_status], [dept_name], [updated_date], [remarks], [updated_by], [related_cyl]) VALUES (N'a393fe68-6be3-48fb-b5be-adb5fc0bc879', N'eb189601-15cc-405f-af5c-8a687d5fd793', N'4e2fc36d-a8dd-4c05-8111-8ce322c7a5cc', N'PROD', N'Sales Dept', CAST(0x00009FD80052A498 AS DateTime), NULL, N'admin', NULL)
INSERT [dbo].[Order_Log] ([id], [workflowId], [orderId], [order_status], [dept_name], [updated_date], [remarks], [updated_by], [related_cyl]) VALUES (N'5cfb4311-98dc-4cb5-bc04-f4f156ebc2bd', N'59068baf-7496-4e01-aefe-20972a297aff', N'4f9331fa-8220-4ba7-adaf-b11016e542e9', N'STG', N'Sales Dept', CAST(0x00009FD800DB3C30 AS DateTime), NULL, N'admin', NULL)
/****** Object:  Table [dbo].[Order_Detail]    Script Date: 01/19/2012 15:19:35 ******/
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
	[length_dir_repeat] [decimal](18, 2) NULL,
	[circum_dir_repeat] [decimal](18, 2) NULL,
	[web_print_width] [decimal](18, 2) NULL,
	[web_total_width] [decimal](18, 2) NULL,
	[cyl_length] [decimal](18, 2) NULL,
	[cyl_diameter] [decimal](18, 2) NULL,
	[eyemark_height] [decimal](18, 2) NULL,
	[eyemark_width] [decimal](18, 2) NULL,
	[eyemark_color] [nvarchar](10) NULL,
	[eyemark_sign] [nvarchar](10) NULL,
	[eyemark_location] [nvarchar](10) NULL,
	[keyhole_type] [nvarchar](10) NULL,
	[keyhole_inner_dia] [decimal](18, 2) NULL,
	[keyhole_outer_dia] [decimal](18, 2) NULL,
	[keyhole_angle] [decimal](18, 2) NULL,
	[keyhole_keyway] [nvarchar](10) NULL,
	[color_count] [decimal](18, 2) NULL,
	[color_list] [nvarchar](12) NULL,
	[new_cyl_count] [decimal](18, 2) NULL,
	[used_cyl_count] [decimal](18, 2) NULL,
	[print_method] [nvarchar](5) NULL,
	[reg_mark_type] [nvarchar](10) NULL,
	[splitline_size] [decimal](18, 2) NULL,
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
INSERT [dbo].[Order_Detail] ([order_detailId], [orderId], [created_by], [created_date], [updated_by], [updated_date], [core_type], [prod_print_width], [prod_width_stretch], [prod_print_height], [prod_height_stretch], [length_dir_repeat], [circum_dir_repeat], [web_print_width], [web_total_width], [cyl_length], [cyl_diameter], [eyemark_height], [eyemark_width], [eyemark_color], [eyemark_sign], [eyemark_location], [keyhole_type], [keyhole_inner_dia], [keyhole_outer_dia], [keyhole_angle], [keyhole_keyway], [color_count], [color_list], [new_cyl_count], [used_cyl_count], [print_method], [reg_mark_type], [splitline_size], [splitline_type], [splitline_color], [print_material], [result_based_on], [img_orientation], [graphic_done_date], [sent_to_mech_date], [cut_core_result], [changes]) VALUES (N'6e2707f8-fa5d-40a4-84f5-0b19ad961249', N'4f9331fa-8220-4ba7-adaf-b11016e542e9', N'', CAST(0x00009FD000000000 AS DateTime), N'admin', CAST(0x00009FD800DB3C2B AS DateTime), N'1', CAST(12.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(123.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)), CAST(123.00 AS Decimal(18, 2)), CAST(221.00 AS Decimal(18, 2)), CAST(39.15 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, N'1SIDE', N'STD', NULL, NULL, NULL, NULL, CAST(2.00 AS Decimal(18, 2)), N'KCMYW', CAST(2.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'SRF', N'STD', NULL, NULL, NULL, N'OPP', N'GRAPHIC', N'Up', NULL, NULL, NULL, N'NEW FILE')
INSERT [dbo].[Order_Detail] ([order_detailId], [orderId], [created_by], [created_date], [updated_by], [updated_date], [core_type], [prod_print_width], [prod_width_stretch], [prod_print_height], [prod_height_stretch], [length_dir_repeat], [circum_dir_repeat], [web_print_width], [web_total_width], [cyl_length], [cyl_diameter], [eyemark_height], [eyemark_width], [eyemark_color], [eyemark_sign], [eyemark_location], [keyhole_type], [keyhole_inner_dia], [keyhole_outer_dia], [keyhole_angle], [keyhole_keyway], [color_count], [color_list], [new_cyl_count], [used_cyl_count], [print_method], [reg_mark_type], [splitline_size], [splitline_type], [splitline_color], [print_material], [result_based_on], [img_orientation], [graphic_done_date], [sent_to_mech_date], [cut_core_result], [changes]) VALUES (N'3bcde5ab-bc30-4762-8d2e-1921de65fd8d', N'4e2fc36d-a8dd-4c05-8111-8ce322c7a5cc', N'tin', CAST(0x00009FD500004650 AS DateTime), N'admin', CAST(0x00009FD800528299 AS DateTime), N'1', CAST(10.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(1.59 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)), N'2', N'', N'1SIDE', N'STD', NULL, NULL, NULL, NULL, CAST(2.00 AS Decimal(18, 2)), N'KCMYW', CAST(2.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'SRF', N'aa', NULL, NULL, NULL, N'OPP', N'GRAPHIC', N'Up', NULL, NULL, NULL, N'NEW FILE')
INSERT [dbo].[Order_Detail] ([order_detailId], [orderId], [created_by], [created_date], [updated_by], [updated_date], [core_type], [prod_print_width], [prod_width_stretch], [prod_print_height], [prod_height_stretch], [length_dir_repeat], [circum_dir_repeat], [web_print_width], [web_total_width], [cyl_length], [cyl_diameter], [eyemark_height], [eyemark_width], [eyemark_color], [eyemark_sign], [eyemark_location], [keyhole_type], [keyhole_inner_dia], [keyhole_outer_dia], [keyhole_angle], [keyhole_keyway], [color_count], [color_list], [new_cyl_count], [used_cyl_count], [print_method], [reg_mark_type], [splitline_size], [splitline_type], [splitline_color], [print_material], [result_based_on], [img_orientation], [graphic_done_date], [sent_to_mech_date], [cut_core_result], [changes]) VALUES (N'0832b93e-0de3-435a-9513-f2cbcc4bd279', N'4e9966d5-85b4-42f2-8e24-3ae019ca5989', N'finance', CAST(0x00009FD800000000 AS DateTime), N'admin', CAST(0x00009FD80075797C AS DateTime), N'1', CAST(2.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(1.50 AS Decimal(18, 2)), CAST(0.63 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, N'1SIDE', N'STD', NULL, NULL, NULL, NULL, CAST(2.00 AS Decimal(18, 2)), N'KCMYW', CAST(2.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'SRF', N'STD', NULL, NULL, NULL, N'OPP', N'GRAPHIC', N'Up', NULL, NULL, NULL, N'NEW FILE')
/****** Object:  Table [dbo].[Cylinder]    Script Date: 01/19/2012 15:19:35 ******/
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
INSERT [dbo].[Cylinder] ([cylinderId], [workflowId], [order_detailId], [barcode], [stepId], [color_no], [core_type], [cyl_no], [diameter], [length], [created_by], [created_date], [updated_by], [updated_date], [status]) VALUES (N'7df0bb71-514c-41c7-9ea1-686e01c5a868', N'8d803ad5-e625-42cc-9800-073897653d26', N'3bcde5ab-bc30-4762-8d2e-1921de65fd8d', N'0009-11201-011', N'76236d69-9db0-4bfb-bb58-64d4f7552a2f', 1, N'1', 1, CAST(1.59 AS Decimal(18, 2)), CAST(10.00000 AS Decimal(18, 5)), N'tin', CAST(0x00009FD500004650 AS DateTime), N'admin', CAST(0x00009FD800528299 AS DateTime), N'INPROD')
INSERT [dbo].[Cylinder] ([cylinderId], [workflowId], [order_detailId], [barcode], [stepId], [color_no], [core_type], [cyl_no], [diameter], [length], [created_by], [created_date], [updated_by], [updated_date], [status]) VALUES (N'98781f9c-2b93-4d97-bfc6-cbc159ada351', N'68f9beaa-d587-452f-bc84-6558279dd00a', N'0832b93e-0de3-435a-9513-f2cbcc4bd279', N'0013-11202-021', N'930d496e-b665-4209-9c62-7b37e8f22e6e', 2, N'1', 2, CAST(0.63 AS Decimal(18, 2)), CAST(1.50000 AS Decimal(18, 5)), N'finance', CAST(0x00009FD800000000 AS DateTime), N'admin', CAST(0x00009FD80075797C AS DateTime), N'INPROD')
INSERT [dbo].[Cylinder] ([cylinderId], [workflowId], [order_detailId], [barcode], [stepId], [color_no], [core_type], [cyl_no], [diameter], [length], [created_by], [created_date], [updated_by], [updated_date], [status]) VALUES (N'ff5a9459-5c61-4bd2-a485-d6ffc0c4231f', N'68f9beaa-d587-452f-bc84-6558279dd00a', N'3bcde5ab-bc30-4762-8d2e-1921de65fd8d', N'0009-11202-021', N'930d496e-b665-4209-9c62-7b37e8f22e6e', 2, N'1', 2, CAST(1.59 AS Decimal(18, 2)), CAST(10.00000 AS Decimal(18, 5)), N'tin', CAST(0x00009FD500004650 AS DateTime), N'admin', CAST(0x00009FD800528299 AS DateTime), N'INPROD')
INSERT [dbo].[Cylinder] ([cylinderId], [workflowId], [order_detailId], [barcode], [stepId], [color_no], [core_type], [cyl_no], [diameter], [length], [created_by], [created_date], [updated_by], [updated_date], [status]) VALUES (N'8363df47-3afc-4d42-a19f-e3a0c07f4175', N'ccda355c-8301-42e9-8856-6220cc22d020', N'0832b93e-0de3-435a-9513-f2cbcc4bd279', N'0013-11201-011', N'80a1b7e6-a4a7-4e96-91b4-5f13156066ff', 1, N'1', 1, CAST(0.63 AS Decimal(18, 2)), CAST(1.50000 AS Decimal(18, 5)), N'finance', CAST(0x00009FD800000000 AS DateTime), N'admin', CAST(0x00009FD80075797C AS DateTime), N'INPROD')
/****** Object:  Table [dbo].[Step_ref]    Script Date: 01/19/2012 15:19:35 ******/
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
INSERT [dbo].[Step_ref] ([Id], [workflowId], [from_stepId], [to_stepId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'e314d0db-9362-43d7-8f99-0b28542fd9d4', N'd6b0ac57-c413-460d-b78c-1717171409d1', N'dfc0121a-7bfd-4c18-a5e3-14693e265a24', N'3fc49b85-08fa-4335-84be-c76f117a1279', N'workflow_app', CAST(0x00009FD80047BEBC AS DateTime), NULL, NULL)
INSERT [dbo].[Step_ref] ([Id], [workflowId], [from_stepId], [to_stepId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'1695f67f-d60c-4b51-a2ff-1879ba41856d', N'47d51268-f6f7-4bb8-a841-70a403729af5', N'8cd15db6-4370-4d64-8b08-593d064cc374', N'64bec2c7-0f7d-4c22-b339-258a1404d844', N'workflow_app', CAST(0x00009FD80045841B AS DateTime), NULL, NULL)
INSERT [dbo].[Step_ref] ([Id], [workflowId], [from_stepId], [to_stepId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'9e99cd75-4045-4f19-a483-2042c59f06ff', N'68f9beaa-d587-452f-bc84-6558279dd00a', N'930d496e-b665-4209-9c62-7b37e8f22e6e', N'7d27b70c-2783-4ba3-b593-5fdad66c798f', N'workflow_app', CAST(0x00009FD80044A7DB AS DateTime), NULL, NULL)
INSERT [dbo].[Step_ref] ([Id], [workflowId], [from_stepId], [to_stepId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'e6c14082-333d-4950-9ba7-39d21cf0fb2c', N'8d803ad5-e625-42cc-9800-073897653d26', N'e0ee2253-0fbb-4cc5-96a8-45480514654b', N'd4b154ee-eca8-462e-b929-90f2465ecc03', N'workflow_app', CAST(0x00009FD800454D87 AS DateTime), NULL, NULL)
INSERT [dbo].[Step_ref] ([Id], [workflowId], [from_stepId], [to_stepId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'dc6963dc-e626-4273-b5e9-50c96c88a90a', N'47d51268-f6f7-4bb8-a841-70a403729af5', N'82c3d831-26fa-4978-9993-28880011852a', N'8cd15db6-4370-4d64-8b08-593d064cc374', N'workflow_app', CAST(0x00009FD80045841B AS DateTime), NULL, NULL)
INSERT [dbo].[Step_ref] ([Id], [workflowId], [from_stepId], [to_stepId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'471ae4f0-d274-4e47-a6da-53d86e96be1b', N'ccda355c-8301-42e9-8856-6220cc22d020', N'80a1b7e6-a4a7-4e96-91b4-5f13156066ff', N'c56d0659-210c-4761-b71c-e6b73b7207f4', N'workflow_app', CAST(0x00009FD80044576F AS DateTime), NULL, NULL)
INSERT [dbo].[Step_ref] ([Id], [workflowId], [from_stepId], [to_stepId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'ed00669b-0ee9-4729-b78b-63e430005864', N'a778000a-743f-4536-b05d-69851c756718', N'dfd89e30-a332-4a5b-84b5-a8f3492c3ef3', N'0ec6b3a6-e467-4bfe-a345-467ed0a0c74f', N'workflow_app', CAST(0x00009FD80044F1FD AS DateTime), NULL, NULL)
INSERT [dbo].[Step_ref] ([Id], [workflowId], [from_stepId], [to_stepId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'11075824-7d0a-432c-9012-6a9e41bf08a0', N'eb189601-15cc-405f-af5c-8a687d5fd793', N'35318b60-33ba-48c1-a9d7-ed84c745ab5f', N'60b339b1-0ea3-4ae3-83ca-b4c6f075ea5e', N'workflow_app', CAST(0x00009FD80047F2FF AS DateTime), NULL, NULL)
INSERT [dbo].[Step_ref] ([Id], [workflowId], [from_stepId], [to_stepId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'b19ce399-e506-4e1d-85e5-872a3e3ebc03', N'ccda355c-8301-42e9-8856-6220cc22d020', N'c56d0659-210c-4761-b71c-e6b73b7207f4', N'6856c8f2-e602-49e1-839b-a2715ebe8004', N'workflow_app', CAST(0x00009FD800445770 AS DateTime), NULL, NULL)
INSERT [dbo].[Step_ref] ([Id], [workflowId], [from_stepId], [to_stepId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'eeae7c03-8947-4903-8c83-8aaffe0be986', N'8d803ad5-e625-42cc-9800-073897653d26', N'76236d69-9db0-4bfb-bb58-64d4f7552a2f', N'e0ee2253-0fbb-4cc5-96a8-45480514654b', N'workflow_app', CAST(0x00009FD800454D87 AS DateTime), NULL, NULL)
INSERT [dbo].[Step_ref] ([Id], [workflowId], [from_stepId], [to_stepId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'a1d7c497-e9d2-4597-9dc7-8d7833322ec8', N'c1fb4c8b-b6dc-4c7a-a81e-74f5dd11510c', N'67d0babf-f787-43fe-a267-a58d8a0596be', N'1ceb8cb2-1a95-4db5-aebc-fe13ba77da74', N'workflow_app', CAST(0x00009FD80045CA7B AS DateTime), NULL, NULL)
INSERT [dbo].[Step_ref] ([Id], [workflowId], [from_stepId], [to_stepId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'fd175ac7-10fa-4ee9-9cd0-cc60d9e32c70', N'8d803ad5-e625-42cc-9800-073897653d26', N'd4b154ee-eca8-462e-b929-90f2465ecc03', N'04091e18-ff1f-485f-8048-dcc609ca2c2c', N'workflow_app', CAST(0x00009FD800454D87 AS DateTime), NULL, NULL)
INSERT [dbo].[Step_ref] ([Id], [workflowId], [from_stepId], [to_stepId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'c2ddfc61-4782-4f0d-861b-d672fb8841c0', N'a778000a-743f-4536-b05d-69851c756718', N'0ec6b3a6-e467-4bfe-a345-467ed0a0c74f', N'd844681e-c67c-4c27-8c92-0894aa913e42', N'workflow_app', CAST(0x00009FD80044F1FD AS DateTime), NULL, NULL)
INSERT [dbo].[Step_ref] ([Id], [workflowId], [from_stepId], [to_stepId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'4a797b32-7725-4dc3-9d99-da5944300407', N'8d803ad5-e625-42cc-9800-073897653d26', N'4f1abfe1-ed2e-4d25-a746-2233d5dfc385', N'04091e18-ff1f-485f-8048-dcc609ca2c2c', N'workflow_app', CAST(0x00009FD800454D87 AS DateTime), NULL, NULL)
INSERT [dbo].[Step_ref] ([Id], [workflowId], [from_stepId], [to_stepId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'31a21240-40e0-4020-8eca-dcfa209ac270', N'59068baf-7496-4e01-aefe-20972a297aff', N'f41f84f0-7b7a-4a67-963a-5165ae12b0a2', N'bd68863f-3b15-49dd-8664-079d0941f3f8', N'workflow_app', CAST(0x00009FD80047C839 AS DateTime), NULL, NULL)
INSERT [dbo].[Step_ref] ([Id], [workflowId], [from_stepId], [to_stepId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'a7ddac25-a3bb-44ed-bbbd-e66e3a232b73', N'68f9beaa-d587-452f-bc84-6558279dd00a', N'7d27b70c-2783-4ba3-b593-5fdad66c798f', N'975eb664-df15-4f73-8906-e7746e5f1d18', N'workflow_app', CAST(0x00009FD80044A7DB AS DateTime), NULL, NULL)
INSERT [dbo].[Step_ref] ([Id], [workflowId], [from_stepId], [to_stepId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'24d5d4cb-3c23-4f16-819b-e761cece0969', N'8d803ad5-e625-42cc-9800-073897653d26', N'e0ee2253-0fbb-4cc5-96a8-45480514654b', N'4f1abfe1-ed2e-4d25-a746-2233d5dfc385', N'workflow_app', CAST(0x00009FD800454D87 AS DateTime), NULL, NULL)
INSERT [dbo].[Step_ref] ([Id], [workflowId], [from_stepId], [to_stepId], [created_by], [created_date], [updated_by], [updated_date]) VALUES (N'e8d4c387-ad1c-4e23-929e-f5647c9af393', N'c1fb4c8b-b6dc-4c7a-a81e-74f5dd11510c', N'1ceb8cb2-1a95-4db5-aebc-fe13ba77da74', N'b873ec15-f296-461c-84be-59247d9a540e', N'workflow_app', CAST(0x00009FD80045CA7B AS DateTime), NULL, NULL)
/****** Object:  Table [dbo].[Formula]    Script Date: 01/19/2012 15:19:35 ******/
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
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'd00cb41b-896d-482c-ac17-00707214477e', N'930d496e-b665-4209-9c62-7b37e8f22e6e', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD8004878CC AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'f2266ce7-0cf0-4e9a-b1fb-1d35fbc40494', N'60b339b1-0ea3-4ae3-83ca-b4c6f075ea5e', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD80047F2F0 AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'accffb10-cf17-48ca-94d9-2304b0b3550c', N'04091e18-ff1f-485f-8048-dcc609ca2c2c', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD800493FB0 AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'2daf04a6-304f-4686-b2dc-23d5d0f1cd19', N'd4b154ee-eca8-462e-b929-90f2465ecc03', N'S*D*a+b', 4, 2, 1, 8, N'system', CAST(0x00009FD800493FA7 AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'7a1d7809-0bc2-474f-988a-343212d43ce8', N'c56d0659-210c-4761-b71c-e6b73b7207f4', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD800487B18 AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'e5958e6b-f4e6-4e7c-ad8e-34ab6556b6ba', N'0ec6b3a6-e467-4bfe-a345-467ed0a0c74f', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD800487609 AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'91042892-6421-4352-aee3-4fc9e2aa9f92', N'67d0babf-f787-43fe-a267-a58d8a0596be', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD800486E67 AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'23d421bb-e1d4-467d-932a-69f5c53adaa8', N'b873ec15-f296-461c-84be-59247d9a540e', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD800486E60 AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'a912c37a-7c06-4f98-bee8-7e1d0312b671', N'f41f84f0-7b7a-4a67-963a-5165ae12b0a2', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD80047C830 AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'a208207c-fbdc-4d77-bb52-83d982b4d7f0', N'4f1abfe1-ed2e-4d25-a746-2233d5dfc385', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD800493F95 AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'7f3506b0-456a-4784-a30d-93f96fe79dd9', N'6856c8f2-e602-49e1-839b-a2715ebe8004', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD800487B12 AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'73c1f093-db08-4d73-99bc-9e82a210e83a', N'3fc49b85-08fa-4335-84be-c76f117a1279', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD80047BEB3 AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'31e0f2ec-7944-4f7e-ae84-a7e75e967b1c', N'76236d69-9db0-4bfb-bb58-64d4f7552a2f', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD800493FA2 AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'e03129c1-922e-4295-adc7-af817821f2c6', N'bd68863f-3b15-49dd-8664-079d0941f3f8', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD80047C82B AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'1f3b55a7-ea71-4527-be2f-afc128281716', N'80a1b7e6-a4a7-4e96-91b4-5f13156066ff', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD800487B0B AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'6daa0996-3177-4dd8-b795-bdfc8678fbb4', N'64bec2c7-0f7d-4c22-b339-258a1404d844', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD8004872B9 AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'7025346d-04d3-48f7-b1c8-c327de82e905', N'8cd15db6-4370-4d64-8b08-593d064cc374', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD8004872C5 AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'ef14231b-0fc5-4f89-a87a-c9e46e8e2822', N'dfd89e30-a332-4a5b-84b5-a8f3492c3ef3', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD80048760E AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'dadcb20d-0d99-4b7a-95eb-ca3ce4da7705', N'7d27b70c-2783-4ba3-b593-5fdad66c798f', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD8004878C6 AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'410443a0-6ba1-4f7d-a985-cc86ab2bed5c', N'82c3d831-26fa-4978-9993-28880011852a', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD8004872BF AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'55a58293-25e6-499d-997c-d2e595f42853', N'e0ee2253-0fbb-4cc5-96a8-45480514654b', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD800493F9B AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'cc4f9d6c-beab-4abb-b16a-d634eb5e807d', N'1ceb8cb2-1a95-4db5-aebc-fe13ba77da74', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD800486E6D AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'298f0301-aa60-4243-8617-dcb33d212d02', N'dfc0121a-7bfd-4c18-a5e3-14693e265a24', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD80047BEAE AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'0fae252d-5248-4a75-80d6-e0d72294d331', N'd844681e-c67c-4c27-8c92-0894aa913e42', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD800487603 AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'3264b761-7bb7-4815-92f7-e301e83a9144', N'975eb664-df15-4f73-8906-e7746e5f1d18', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD8004878D3 AS DateTime), 1)
INSERT [dbo].[Formula] ([formulaId], [stepId], [formula], [coef1], [coef2], [coef3], [coef4], [created_by], [created_date], [isactive]) VALUES (N'6ea78c99-bfc4-4d9a-9667-fc757e652c1b', N'35318b60-33ba-48c1-a9d7-ed84c745ab5f', N'', 0, 0, 0, 0, N'system', CAST(0x00009FD80047F2F6 AS DateTime), 1)
/****** Object:  Table [dbo].[Cylinder_Log]    Script Date: 01/19/2012 15:19:35 ******/
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
INSERT [dbo].[Cylinder_Log] ([cylinderlogId], [cylinderId], [dept_name], [start_time], [end_time], [mark], [formula], [employeeId], [error_desc], [stepId], [created_by], [remark], [status]) VALUES (N'33c61a65-c380-4a26-88d6-0d8fd383a47e', N'8363df47-3afc-4d42-a19f-e3a0c07f4175', N'Engraving-Lasering Dept', CAST(0x00009FD80076C6D0 AS DateTime), CAST(0x00009FD80076C6D0 AS DateTime), 0, N',coef1=0,coef2=0,coef3=0,coef4=0', N'2c2f6803-8491-45f6-a866-80a4d3a691ec', N'', N'80a1b7e6-a4a7-4e96-91b4-5f13156066ff', N' admin', N'Sent from previous workflow', N'COMP')
INSERT [dbo].[Cylinder_Log] ([cylinderlogId], [cylinderId], [dept_name], [start_time], [end_time], [mark], [formula], [employeeId], [error_desc], [stepId], [created_by], [remark], [status]) VALUES (N'5687bbb4-6c8a-4041-b1ae-13ed77dfde53', N'7df0bb71-514c-41c7-9ea1-686e01c5a868', N'Engraving-Lasering Dept', CAST(0x00009FD8007119EF AS DateTime), CAST(0x00009FD8007119EF AS DateTime), 0, N',coef1=0,coef2=0,coef3=0,coef4=0', N'2c2f6803-8491-45f6-a866-80a4d3a691ec', N'', N'76236d69-9db0-4bfb-bb58-64d4f7552a2f', N' admin', N'Sent from previous workflow', N'COMP')
INSERT [dbo].[Cylinder_Log] ([cylinderlogId], [cylinderId], [dept_name], [start_time], [end_time], [mark], [formula], [employeeId], [error_desc], [stepId], [created_by], [remark], [status]) VALUES (N'f0f2db1a-44b1-41e5-8384-1cb44a5ed828', N'7df0bb71-514c-41c7-9ea1-686e01c5a868', N'Engraving-Lasering Dept', CAST(0x00009FD80058D605 AS DateTime), CAST(0x00009FD80058D605 AS DateTime), 0, N',coef1=0,coef2=0,coef3=0,coef4=0', N'2c2f6803-8491-45f6-a866-80a4d3a691ec', N'', N'80a1b7e6-a4a7-4e96-91b4-5f13156066ff', N' Tin', N'Sent from previous workflow', N'COMP')
INSERT [dbo].[Cylinder_Log] ([cylinderlogId], [cylinderId], [dept_name], [start_time], [end_time], [mark], [formula], [employeeId], [error_desc], [stepId], [created_by], [remark], [status]) VALUES (N'd4bf4d3b-460d-4187-8797-309fbfdaf41d', N'7df0bb71-514c-41c7-9ea1-686e01c5a868', N'Production Dept', CAST(0x00009FD80070CED2 AS DateTime), CAST(0x00009FD8007119CD AS DateTime), 0, N',coef1=0,coef2=0,coef3=0,coef4=0', N'2c2f6803-8491-45f6-a866-80a4d3a691ec', N'', N'c56d0659-210c-4761-b71c-e6b73b7207f4', N'system', N'', N'COMP')
INSERT [dbo].[Cylinder_Log] ([cylinderlogId], [cylinderId], [dept_name], [start_time], [end_time], [mark], [formula], [employeeId], [error_desc], [stepId], [created_by], [remark], [status]) VALUES (N'a7ab909c-35cb-468f-a683-38460f5f4cad', N'8363df47-3afc-4d42-a19f-e3a0c07f4175', N'Engraving-Lasering Dept', CAST(0x00009FD80076A205 AS DateTime), CAST(0x00009FD80076A205 AS DateTime), 0, N',coef1=0,coef2=0,coef3=0,coef4=0', N'2c2f6803-8491-45f6-a866-80a4d3a691ec', N'Wrong Material', N'930d496e-b665-4209-9c62-7b37e8f22e6e', N' admin', N'Wrong Material', N'ERR_PRV')
INSERT [dbo].[Cylinder_Log] ([cylinderlogId], [cylinderId], [dept_name], [start_time], [end_time], [mark], [formula], [employeeId], [error_desc], [stepId], [created_by], [remark], [status]) VALUES (N'd1324e9c-11cd-45cb-8653-3cc0e7a6c62b', N'8363df47-3afc-4d42-a19f-e3a0c07f4175', N'Engraving-Lasering Dept', CAST(0x00009FD80077A2B2 AS DateTime), CAST(0x00009FD80077A2B2 AS DateTime), 0, N',coef1=0,coef2=0,coef3=0,coef4=0', N'2c2f6803-8491-45f6-a866-80a4d3a691ec', N'', N'80a1b7e6-a4a7-4e96-91b4-5f13156066ff', N' admin', N'material corrected', N'Rejected (or) Damaged, sent to [Step:Coat Copper] [Workflow:Production to Engraving]')
INSERT [dbo].[Cylinder_Log] ([cylinderlogId], [cylinderId], [dept_name], [start_time], [end_time], [mark], [formula], [employeeId], [error_desc], [stepId], [created_by], [remark], [status]) VALUES (N'4c6eb963-7724-4b8d-bb88-59d3ff12c815', N'8363df47-3afc-4d42-a19f-e3a0c07f4175', N'Mechanical Dept', CAST(0x00009FD80076B035 AS DateTime), CAST(0x00009FD80076C6BB AS DateTime), 0, N',coef1=0,coef2=0,coef3=0,coef4=0', N'2c2f6803-8491-45f6-a866-80a4d3a691ec', N'', N'7d27b70c-2783-4ba3-b593-5fdad66c798f', N'system', N'', N'COMP')
INSERT [dbo].[Cylinder_Log] ([cylinderlogId], [cylinderId], [dept_name], [start_time], [end_time], [mark], [formula], [employeeId], [error_desc], [stepId], [created_by], [remark], [status]) VALUES (N'c4d10be0-f281-4a00-9d4b-7bbd426cafbe', N'7df0bb71-514c-41c7-9ea1-686e01c5a868', N'Engraving-Lasering Dept', CAST(0x00009FD80070A958 AS DateTime), CAST(0x00009FD80070A958 AS DateTime), 0, N',coef1=0,coef2=0,coef3=0,coef4=0', N'2c2f6803-8491-45f6-a866-80a4d3a691ec', N'2'' tes t', N'80a1b7e6-a4a7-4e96-91b4-5f13156066ff', N' admin', N'2'' tes t', N'ERR_PRV')
INSERT [dbo].[Cylinder_Log] ([cylinderlogId], [cylinderId], [dept_name], [start_time], [end_time], [mark], [formula], [employeeId], [error_desc], [stepId], [created_by], [remark], [status]) VALUES (N'69e3388a-cfe1-4bee-8097-9a747224915c', N'7df0bb71-514c-41c7-9ea1-686e01c5a868', N'Engraving-Lasering Dept', CAST(0x00009FD80057E667 AS DateTime), CAST(0x00009FD8005814DD AS DateTime), 0, N',coef1=0,coef2=0,coef3=0,coef4=0', N'2c2f6803-8491-45f6-a866-80a4d3a691ec', N'2'' tes t', N'7d27b70c-2783-4ba3-b593-5fdad66c798f', N'admin', N'', N'ERR_DAMG')
INSERT [dbo].[Cylinder_Log] ([cylinderlogId], [cylinderId], [dept_name], [start_time], [end_time], [mark], [formula], [employeeId], [error_desc], [stepId], [created_by], [remark], [status]) VALUES (N'fa2bbbdc-235d-48c8-a4a9-ea95b55cade0', N'7df0bb71-514c-41c7-9ea1-686e01c5a868', N'Mechanical Dept', CAST(0x00009FD800585C3F AS DateTime), CAST(0x00009FD80058D5C8 AS DateTime), 0, N',coef1=0,coef2=0,coef3=0,coef4=0', N'2c2f6803-8491-45f6-a866-80a4d3a691ec', N'', N'975eb664-df15-4f73-8906-e7746e5f1d18', N'system', N'Sent from previous workflow', N'COMP')
/****** Object:  Default [DF_Access_Right_rightsId]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Access_Right] ADD  CONSTRAINT [DF_Access_Right_rightsId]  DEFAULT (newid()) FOR [rightsId]
GO
/****** Object:  Default [DF_Access_Right_created_by]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Access_Right] ADD  CONSTRAINT [DF_Access_Right_created_by]  DEFAULT (N'system') FOR [created_by]
GO
/****** Object:  Default [DF_Access_Right_created_date]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Access_Right] ADD  CONSTRAINT [DF_Access_Right_created_date]  DEFAULT (getdate()) FOR [created_date]
GO
/****** Object:  Default [DF_Access_Right_isactive]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Access_Right] ADD  CONSTRAINT [DF_Access_Right_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Table_1_orderid]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[AutoID] ADD  CONSTRAINT [DF_Table_1_orderid]  DEFAULT ((0)) FOR [autoid]
GO
/****** Object:  Default [DF_AutoID_created_date]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[AutoID] ADD  CONSTRAINT [DF_AutoID_created_date]  DEFAULT (getdate()) FOR [created_date]
GO
/****** Object:  Default [DF_Table_1_CustomerID]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Table_1_CustomerID]  DEFAULT (newid()) FOR [customerid]
GO
/****** Object:  Default [DF_Cylinder_status]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Cylinder] ADD  CONSTRAINT [DF_Cylinder_status]  DEFAULT (N'PENDING') FOR [status]
GO
/****** Object:  Default [DF_Cylinder_Log_formula]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Cylinder_Log] ADD  CONSTRAINT [DF_Cylinder_Log_formula]  DEFAULT ('') FOR [formula]
GO
/****** Object:  Default [DF_Department_departmentId]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [DF_Department_departmentId]  DEFAULT (newid()) FOR [departmentId]
GO
/****** Object:  Default [DF_Department_isactive]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [DF_Department_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Emp_Role_ref_Id]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Emp_Role_ref] ADD  CONSTRAINT [DF_Emp_Role_ref_Id]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [DF_Emp_Role_ref_isapproved]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Emp_Role_ref] ADD  CONSTRAINT [DF_Emp_Role_ref_isapproved]  DEFAULT ((0)) FOR [isapproved]
GO
/****** Object:  Default [DF_Employee_employeeId]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_employeeId]  DEFAULT (newid()) FOR [employeeId]
GO
/****** Object:  Default [DF_Employee_isactive]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Employee_language]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_language]  DEFAULT (N'EN') FOR [language]
GO
/****** Object:  Default [DF_Formula_isactive]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Formula] ADD  CONSTRAINT [DF_Formula_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Order_isactive]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_isactive]  DEFAULT ((0)) FOR [status]
GO
/****** Object:  Default [DF_Role_isactive]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  Default [DF_Role_Right_ref_Id]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Role_Right_ref] ADD  CONSTRAINT [DF_Role_Right_ref_Id]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [DF_Role_Right_ref_created_date]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Role_Right_ref] ADD  CONSTRAINT [DF_Role_Right_ref_created_date]  DEFAULT (getdate()) FOR [created_date]
GO
/****** Object:  Default [DF_Step_stepId]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Step] ADD  CONSTRAINT [DF_Step_stepId]  DEFAULT (newid()) FOR [stepId]
GO
/****** Object:  Default [DF_Step_isActive]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Step] ADD  CONSTRAINT [DF_Step_isActive]  DEFAULT ((1)) FOR [isActive]
GO
/****** Object:  Default [DF_Step_isStep_1]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Step] ADD  CONSTRAINT [DF_Step_isStep_1]  DEFAULT ((1)) FOR [isStep]
GO
/****** Object:  Default [DF_Step_isStep]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Step] ADD  CONSTRAINT [DF_Step_isStep]  DEFAULT ((0)) FOR [isBegin]
GO
/****** Object:  Default [DF_Workflow_workflowId]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Workflow] ADD  CONSTRAINT [DF_Workflow_workflowId]  DEFAULT (newid()) FOR [workflowId]
GO
/****** Object:  Default [DF_Workflow_isactive]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Workflow] ADD  CONSTRAINT [DF_Workflow_isactive]  DEFAULT ((1)) FOR [isactive]
GO
/****** Object:  ForeignKey [FK_Cylinder_Order_Detail]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Cylinder]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Order_Detail] FOREIGN KEY([order_detailId])
REFERENCES [dbo].[Order_Detail] ([order_detailId])
GO
ALTER TABLE [dbo].[Cylinder] CHECK CONSTRAINT [FK_Cylinder_Order_Detail]
GO
/****** Object:  ForeignKey [FK_Cylinder_Workflow]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Cylinder]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Workflow] FOREIGN KEY([workflowId])
REFERENCES [dbo].[Workflow] ([workflowId])
GO
ALTER TABLE [dbo].[Cylinder] CHECK CONSTRAINT [FK_Cylinder_Workflow]
GO
/****** Object:  ForeignKey [FK_Cylinder_Log_Cylinder]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Cylinder_Log]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Log_Cylinder] FOREIGN KEY([cylinderId])
REFERENCES [dbo].[Cylinder] ([cylinderId])
GO
ALTER TABLE [dbo].[Cylinder_Log] CHECK CONSTRAINT [FK_Cylinder_Log_Cylinder]
GO
/****** Object:  ForeignKey [FK_Cylinder_Log_Employee]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Cylinder_Log]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Log_Employee] FOREIGN KEY([employeeId])
REFERENCES [dbo].[Employee] ([employeeId])
GO
ALTER TABLE [dbo].[Cylinder_Log] CHECK CONSTRAINT [FK_Cylinder_Log_Employee]
GO
/****** Object:  ForeignKey [FK_Cylinder_Log_Step]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Cylinder_Log]  WITH CHECK ADD  CONSTRAINT [FK_Cylinder_Log_Step] FOREIGN KEY([stepId])
REFERENCES [dbo].[Step] ([stepId])
GO
ALTER TABLE [dbo].[Cylinder_Log] CHECK CONSTRAINT [FK_Cylinder_Log_Step]
GO
/****** Object:  ForeignKey [FK_Emp_Role_ref_Employee]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Emp_Role_ref]  WITH CHECK ADD  CONSTRAINT [FK_Emp_Role_ref_Employee] FOREIGN KEY([employeeId])
REFERENCES [dbo].[Employee] ([employeeId])
GO
ALTER TABLE [dbo].[Emp_Role_ref] CHECK CONSTRAINT [FK_Emp_Role_ref_Employee]
GO
/****** Object:  ForeignKey [FK_Emp_Role_ref_Role]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Emp_Role_ref]  WITH CHECK ADD  CONSTRAINT [FK_Emp_Role_ref_Role] FOREIGN KEY([roleId])
REFERENCES [dbo].[Role] ([roleId])
GO
ALTER TABLE [dbo].[Emp_Role_ref] CHECK CONSTRAINT [FK_Emp_Role_ref_Role]
GO
/****** Object:  ForeignKey [FK_Employee_Department]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([departmentId])
REFERENCES [dbo].[Department] ([departmentId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
/****** Object:  ForeignKey [FK_Formula_Step]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Formula]  WITH CHECK ADD  CONSTRAINT [FK_Formula_Step] FOREIGN KEY([stepId])
REFERENCES [dbo].[Step] ([stepId])
GO
ALTER TABLE [dbo].[Formula] CHECK CONSTRAINT [FK_Formula_Step]
GO
/****** Object:  ForeignKey [FK_Order_Customer]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customer] ([customerid])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
/****** Object:  ForeignKey [FK_Order_Detail_Order]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Order_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Order_Detail_Order] FOREIGN KEY([orderId])
REFERENCES [dbo].[Order] ([orderId])
GO
ALTER TABLE [dbo].[Order_Detail] CHECK CONSTRAINT [FK_Order_Detail_Order]
GO
/****** Object:  ForeignKey [FK_Order_Log_Order]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Order_Log]  WITH CHECK ADD  CONSTRAINT [FK_Order_Log_Order] FOREIGN KEY([orderId])
REFERENCES [dbo].[Order] ([orderId])
GO
ALTER TABLE [dbo].[Order_Log] CHECK CONSTRAINT [FK_Order_Log_Order]
GO
/****** Object:  ForeignKey [FK_Order_Log_Workflow]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Order_Log]  WITH CHECK ADD  CONSTRAINT [FK_Order_Log_Workflow] FOREIGN KEY([workflowId])
REFERENCES [dbo].[Workflow] ([workflowId])
GO
ALTER TABLE [dbo].[Order_Log] CHECK CONSTRAINT [FK_Order_Log_Workflow]
GO
/****** Object:  ForeignKey [FK_Printer_Customer]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Printer]  WITH CHECK ADD  CONSTRAINT [FK_Printer_Customer] FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customer] ([customerid])
GO
ALTER TABLE [dbo].[Printer] CHECK CONSTRAINT [FK_Printer_Customer]
GO
/****** Object:  ForeignKey [FK_Role_Right_ref_Access_Right]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Role_Right_ref]  WITH CHECK ADD  CONSTRAINT [FK_Role_Right_ref_Access_Right] FOREIGN KEY([rightId])
REFERENCES [dbo].[Access_Right] ([rightsId])
GO
ALTER TABLE [dbo].[Role_Right_ref] CHECK CONSTRAINT [FK_Role_Right_ref_Access_Right]
GO
/****** Object:  ForeignKey [FK_Role_Right_ref_Role]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Role_Right_ref]  WITH CHECK ADD  CONSTRAINT [FK_Role_Right_ref_Role] FOREIGN KEY([roleId])
REFERENCES [dbo].[Role] ([roleId])
GO
ALTER TABLE [dbo].[Role_Right_ref] CHECK CONSTRAINT [FK_Role_Right_ref_Role]
GO
/****** Object:  ForeignKey [FK_Step_Workflow]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Step]  WITH CHECK ADD  CONSTRAINT [FK_Step_Workflow] FOREIGN KEY([workflowId])
REFERENCES [dbo].[Workflow] ([workflowId])
GO
ALTER TABLE [dbo].[Step] CHECK CONSTRAINT [FK_Step_Workflow]
GO
/****** Object:  ForeignKey [FK_Step_ref_Step]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Step_ref]  WITH CHECK ADD  CONSTRAINT [FK_Step_ref_Step] FOREIGN KEY([from_stepId])
REFERENCES [dbo].[Step] ([stepId])
GO
ALTER TABLE [dbo].[Step_ref] CHECK CONSTRAINT [FK_Step_ref_Step]
GO
/****** Object:  ForeignKey [FK_Step_ref_Step1]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Step_ref]  WITH CHECK ADD  CONSTRAINT [FK_Step_ref_Step1] FOREIGN KEY([to_stepId])
REFERENCES [dbo].[Step] ([stepId])
GO
ALTER TABLE [dbo].[Step_ref] CHECK CONSTRAINT [FK_Step_ref_Step1]
GO
/****** Object:  ForeignKey [FK_Step_ref_Workflow]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Step_ref]  WITH CHECK ADD  CONSTRAINT [FK_Step_ref_Workflow] FOREIGN KEY([workflowId])
REFERENCES [dbo].[Workflow] ([workflowId])
GO
ALTER TABLE [dbo].[Step_ref] CHECK CONSTRAINT [FK_Step_ref_Workflow]
GO
/****** Object:  ForeignKey [FK_Workflow_Department]    Script Date: 01/19/2012 15:19:35 ******/
ALTER TABLE [dbo].[Workflow]  WITH CHECK ADD  CONSTRAINT [FK_Workflow_Department] FOREIGN KEY([departmentId])
REFERENCES [dbo].[Department] ([departmentId])
GO
ALTER TABLE [dbo].[Workflow] CHECK CONSTRAINT [FK_Workflow_Department]
GO
