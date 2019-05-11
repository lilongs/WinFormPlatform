USE [Test]
GO
/****** Object:  Table [dbo].[department]    Script Date: 2019/5/11 16:37:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[department](
	[deptno] [int] IDENTITY(1,1) NOT NULL,
	[deptname] [nvarchar](20) NULL,
	[remark] [nvarchar](100) NULL,
	[createby] [nvarchar](20) NOT NULL,
	[createtime] [datetime] NULL,
	[updateby] [nvarchar](20) NULL,
	[updatetime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[deptno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[loginlog]    Script Date: 2019/5/11 16:37:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loginlog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](20) NULL,
	[createdate] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[menuinfo]    Script Date: 2019/5/11 16:37:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[menuinfo](
	[menuid] [int] IDENTITY(1,1) NOT NULL,
	[menuname] [nvarchar](20) NULL,
	[path] [nvarchar](100) NULL,
	[parentid] [int] NULL,
	[sort] [int] NULL,
	[createby] [nvarchar](20) NOT NULL,
	[createtime] [datetime] NULL,
	[updateby] [nvarchar](20) NULL,
	[updatetime] [datetime] NULL,
 CONSTRAINT [PK__menuinfo__3B5F7D5CDDDB9AED] PRIMARY KEY CLUSTERED 
(
	[menuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[role_menu]    Script Date: 2019/5/11 16:37:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role_menu](
	[roleid] [int] NULL,
	[menuid] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[roleinfo]    Script Date: 2019/5/11 16:37:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roleinfo](
	[roleid] [int] IDENTITY(1,1) NOT NULL,
	[rolename] [nvarchar](15) NULL,
	[remark] [nvarchar](100) NULL,
	[createby] [nvarchar](20) NOT NULL,
	[createtime] [datetime] NULL,
	[updateby] [nvarchar](20) NULL,
	[updatetime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[roleid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sysuser]    Script Date: 2019/5/11 16:37:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysuser](
	[username] [nvarchar](20) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[realname] [nvarchar](10) NOT NULL,
	[telephone] [nvarchar](20) NOT NULL,
	[deptno] [int] NULL,
	[roleid] [int] NULL,
	[createtime] [datetime] NULL,
	[createby] [nvarchar](20) NOT NULL,
	[status] [int] NULL,
	[updateby] [nvarchar](20) NULL,
	[updatetime] [datetime] NULL,
 CONSTRAINT [PK__sysuser__F3DBC57305C2E6B3] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_pathValue]    Script Date: 2019/5/11 16:37:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_pathValue](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[path] [nvarchar](200) NULL,
	[filename] [nvarchar](100) NULL,
	[testItem] [nvarchar](200) NULL,
	[testValue] [decimal](10, 4) NULL,
	[testTime] [datetime] NULL,
	[createTime] [datetime] NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[department] ON 

INSERT [dbo].[department] ([deptno], [deptname], [remark], [createby], [createtime], [updateby], [updatetime]) VALUES (1, N'信息技术部', N'', N'admin', CAST(0x0000AA48009EFDE6 AS DateTime), NULL, NULL)
INSERT [dbo].[department] ([deptno], [deptname], [remark], [createby], [createtime], [updateby], [updatetime]) VALUES (2, N'生产技术部', N'生产', N'admin', CAST(0x0000AA4A01066A6E AS DateTime), N'admin', CAST(0x0000AA4A0107776D AS DateTime))
SET IDENTITY_INSERT [dbo].[department] OFF
SET IDENTITY_INSERT [dbo].[loginlog] ON 

INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (1, N'123', CAST(0x0000AA450120A6EC AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (2, N'1', CAST(0x0000AA4601097F94 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (3, N'lilong', CAST(0x0000AA46010B04A4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (4, N'1', CAST(0x0000AA46010DCACC AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (8, N'1', CAST(0x0000AA4700A4E098 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (9, N'1', CAST(0x0000AA4700A50D20 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (10, N'1', CAST(0x0000AA4700A99FD4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (11, N'lilong', CAST(0x0000AA4700AA7D50 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (12, N'1', CAST(0x0000AA4700B11854 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (13, N'1', CAST(0x0000AA4700B4BD24 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (14, N'1', CAST(0x0000AA4700B54190 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (21, N'123', CAST(0x0000AA4700F00870 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (22, N'123', CAST(0x0000AA4700F159F0 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (23, N'123', CAST(0x0000AA4700F1BFE4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (24, N'123', CAST(0x0000AA4700F1EA14 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (26, N'123', CAST(0x0000AA4700F4EAD4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (27, N'123', CAST(0x0000AA4700F73AA0 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (28, N'123', CAST(0x0000AA4700F7D2F8 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (29, N'123', CAST(0x0000AA4700F7EA68 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (30, N'123', CAST(0x0000AA4701007C28 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (31, N'123', CAST(0x0000AA4701025214 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (32, N'123', CAST(0x0000AA470102B5B0 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (33, N'admin', CAST(0x0000AA4800A460DC AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (34, N'admin', CAST(0x0000AA4800A48E90 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (35, N'admin', CAST(0x0000AA4800AC8DD4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (36, N'admin', CAST(0x0000AA4800ACDB2C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (37, N'admin', CAST(0x0000AA4800B24B5C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (39, N'admin', CAST(0x0000AA4800B47A58 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (40, N'admin', CAST(0x0000AA4800E7CE94 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (41, N'admin', CAST(0x0000AA4800E7FFCC AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (42, N'admin', CAST(0x0000AA4800E813B8 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (43, N'admin', CAST(0x0000AA4800EA73EC AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (44, N'admin', CAST(0x0000AA4800EA8C88 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (45, N'admin', CAST(0x0000AA4800EC4528 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (46, N'admin', CAST(0x0000AA4800ED1494 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (47, N'admin', CAST(0x0000AA4800ED3690 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (48, N'admin', CAST(0x0000AA4800ED68F4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (49, N'admin', CAST(0x0000AA4800EDBE80 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (50, N'admin', CAST(0x0000AA4800F2F094 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (51, N'admin', CAST(0x0000AA4800F33810 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (56, N'admin', CAST(0x0000AA4800F85890 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (57, N'admin', CAST(0x0000AA4800F883EC AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (60, N'admin', CAST(0x0000AA4800FAF230 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (61, N'admin', CAST(0x0000AA4800FB4B40 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (62, N'admin', CAST(0x0000AA4800FCD3D4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (64, N'admin', CAST(0x0000AA4800FFEE5C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (65, N'admin', CAST(0x0000AA480100DE98 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (67, N'admin', CAST(0x0000AA48010329B4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (80, N'admin', CAST(0x0000AA480110D03C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (81, N'admin', CAST(0x0000AA480112F4AC AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (82, N'admin', CAST(0x0000AA4801131EDC AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (84, N'admin', CAST(0x0000AA48011481F0 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (85, N'admin', CAST(0x0000AA480114C390 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (86, N'admin', CAST(0x0000AA4801151EF8 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (87, N'admin', CAST(0x0000AA4801155738 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (88, N'admin', CAST(0x0000AA4801156D7C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (89, N'admin', CAST(0x0000AA480115C560 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (91, N'admin', CAST(0x0000AA480117F7E0 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (92, N'admin', CAST(0x0000AA4801186BE4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (93, N'admin', CAST(0x0000AA480119B080 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (94, N'admin', CAST(0x0000AA48011ADC80 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (97, N'admin', CAST(0x0000AA48011E5BD0 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (99, N'admin', CAST(0x0000AA4900ABBAE4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (100, N'admin', CAST(0x0000AA4900AC2EE8 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (101, N'admin', CAST(0x0000AA4900AD8194 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (102, N'admin', CAST(0x0000AA4900ADD270 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (103, N'admin', CAST(0x0000AA4900AE3288 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (104, N'admin', CAST(0x0000AA4900AE699C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (105, N'admin', CAST(0x0000AA4900AE72FC AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (106, N'admin', CAST(0x0000AA4900B64DEC AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (107, N'admin', CAST(0x0000AA4900B68500 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (108, N'admin', CAST(0x0000AA4900B76024 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (109, N'admin', CAST(0x0000AA4900B786D0 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (110, N'admin', CAST(0x0000AA4900B7BDE4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (114, N'admin', CAST(0x0000AA4900E07A68 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (115, N'admin', CAST(0x0000AA4900E0B2A8 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (116, N'admin', CAST(0x0000AA4900E0E50C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (131, N'admin', CAST(0x0000AA4901093B9C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (132, N'admin', CAST(0x0000AA490109DAFC AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (134, N'admin', CAST(0x0000AA49010BAD64 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (135, N'admin', CAST(0x0000AA49010BE0F4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (141, N'admin', CAST(0x0000AA49011A8BA4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (142, N'admin', CAST(0x0000AA49011AB4A8 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (143, N'admin', CAST(0x0000AA49011CC658 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (144, N'admin', CAST(0x0000AA49011CEE30 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (145, N'admin', CAST(0x0000AA490120BE5C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (147, N'admin', CAST(0x0000AA4A00A34C4C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (154, N'admin', CAST(0x0000AA4A00AEF768 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (157, N'admin', CAST(0x0000AA4A00B7A9F8 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (158, N'admin', CAST(0x0000AA4A00B7CE4C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (159, N'admin', CAST(0x0000AA4A00B815C8 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (160, N'lilong', CAST(0x0000AA4A00B89908 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (161, N'lilong', CAST(0x0000AA4A00B8B3FC AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (162, N'lilong', CAST(0x0000AA4A00B8CDC4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (163, N'admin', CAST(0x0000AA4A00B90028 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (164, N'admin', CAST(0x0000AA4A00B9292C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (5, N'1', CAST(0x0000AA46010E0A14 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (6, N'1', CAST(0x0000AA46010E0EC4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (7, N'1', CAST(0x0000AA46010F12EC AS DateTime))
GO
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (15, N'lilong', CAST(0x0000AA4700BABC4C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (16, N'1', CAST(0x0000AA4700BB3D34 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (17, N'1', CAST(0x0000AA4700C2D300 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (18, N'1', CAST(0x0000AA4700C32058 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (19, N'1', CAST(0x0000AA4700E3E11C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (20, N'123', CAST(0x0000AA4700E8D76C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (25, N'123', CAST(0x0000AA4700F3A2B4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (38, N'admin', CAST(0x0000AA4800B335BC AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (54, N'admin', CAST(0x0000AA4800F41460 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (55, N'admin', CAST(0x0000AA4800F46FC8 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (66, N'admin', CAST(0x0000AA4801012614 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (72, N'admin', CAST(0x0000AA48010C9B48 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (73, N'admin', CAST(0x0000AA48010CED50 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (74, N'admin', CAST(0x0000AA48010D766C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (75, N'admin', CAST(0x0000AA48010EAE24 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (76, N'admin', CAST(0x0000AA48010F3740 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (77, N'admin', CAST(0x0000AA48010FD31C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (78, N'admin', CAST(0x0000AA4801101E1C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (79, N'admin', CAST(0x0000AA4801104BD0 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (95, N'admin', CAST(0x0000AA48011B497C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (96, N'admin', CAST(0x0000AA48011B992C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (111, N'admin', CAST(0x0000AA4900BCBEC0 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (113, N'admin', CAST(0x0000AA4900C5AF6C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (117, N'admin', CAST(0x0000AA4900E77B60 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (118, N'admin', CAST(0x0000AA4900E8E900 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (119, N'admin', CAST(0x0000AA4900EA56A0 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (125, N'admin', CAST(0x0000AA4901040AB4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (126, N'admin', CAST(0x0000AA4901043994 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (127, N'admin', CAST(0x0000AA490104D0C0 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (128, N'admin', CAST(0x0000AA490105426C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (129, N'admin', CAST(0x0000AA490107C6F4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (130, N'admin', CAST(0x0000AA4901081DAC AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (146, N'admin', CAST(0x0000AA4A009BB428 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (52, N'admin', CAST(0x0000AA4800F39CD8 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (53, N'admin', CAST(0x0000AA4800F3DFA4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (58, N'admin', CAST(0x0000AA4800F92DD8 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (59, N'admin', CAST(0x0000AA4800F9EF34 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (63, N'admin', CAST(0x0000AA4800FE022C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (68, N'admin', CAST(0x0000AA48010B3CE4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (69, N'admin', CAST(0x0000AA48010B7C2C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (70, N'admin', CAST(0x0000AA48010BB7F0 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (71, N'admin', CAST(0x0000AA48010BDFC8 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (83, N'admin', CAST(0x0000AA480113C8C8 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (90, N'admin', CAST(0x0000AA480116FF70 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (98, N'admin', CAST(0x0000AA4900A724AC AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (112, N'admin', CAST(0x0000AA4900BE0CBC AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (120, N'admin', CAST(0x0000AA4900EAA650 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (121, N'admin', CAST(0x0000AA4900EC3718 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (122, N'admin', CAST(0x0000AA4900ECE6E0 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (123, N'admin', CAST(0x0000AA4900FF8034 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (124, N'admin', CAST(0x0000AA4900FFAF14 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (133, N'admin', CAST(0x0000AA49010A2980 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (136, N'admin', CAST(0x0000AA490114FE28 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (137, N'admin', CAST(0x0000AA490115434C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (138, N'admin', CAST(0x0000AA49011562F0 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (139, N'admin', CAST(0x0000AA4901198B00 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (140, N'admin', CAST(0x0000AA490119B8B4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (148, N'admin', CAST(0x0000AA4A00A67F70 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (149, N'admin', CAST(0x0000AA4A00A710C0 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (150, N'admin', CAST(0x0000AA4A00A9A6DC AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (151, N'admin', CAST(0x0000AA4A00AB642C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (152, N'admin', CAST(0x0000AA4A00AC2A38 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (153, N'admin', CAST(0x0000AA4A00ACAEA4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (155, N'admin', CAST(0x0000AA4A00B1F954 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (156, N'admin', CAST(0x0000AA4A00B2A340 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (165, N'admin', CAST(0x0000AA4A00E8B0C0 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (166, N'admin', CAST(0x0000AA4A00E9A228 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (167, N'admin', CAST(0x0000AA4A00FB6AE4 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (168, N'admin', CAST(0x0000AA4A00FB9190 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (169, N'admin', CAST(0x0000AA4A00FC3F00 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (170, N'admin', CAST(0x0000AA4A00FCB0AC AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (171, N'admin', CAST(0x0000AA4A00FD5714 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (172, N'admin', CAST(0x0000AA4A00FDD7FC AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (173, N'admin', CAST(0x0000AA4A00FE6F28 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (174, N'admin', CAST(0x0000AA4A01005450 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (175, N'admin', CAST(0x0000AA4A0100A8B0 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (176, N'admin', CAST(0x0000AA4A0101D258 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (177, N'admin', CAST(0x0000AA4A0102B100 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (178, N'admin', CAST(0x0000AA4A0104085C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (179, N'admin', CAST(0x0000AA4A01044420 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (180, N'admin', CAST(0x0000AA4A0104D444 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (181, N'admin', CAST(0x0000AA4A0105138C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (182, N'admin', CAST(0x0000AA4A01058D6C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (183, N'admin', CAST(0x0000AA4A0105FDEC AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (184, N'admin', CAST(0x0000AA4A01061C64 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (185, N'admin', CAST(0x0000AA4A01065A80 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (186, N'admin', CAST(0x0000AA4A01072FC8 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (187, N'admin', CAST(0x0000AA4A010DE944 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (188, N'admin', CAST(0x0000AA4A010E2D3C AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (189, N'admin', CAST(0x0000AA4A010E7260 AS DateTime))
INSERT [dbo].[loginlog] ([id], [username], [createdate]) VALUES (190, N'admin', CAST(0x0000AA4A010EA4C4 AS DateTime))
SET IDENTITY_INSERT [dbo].[loginlog] OFF
SET IDENTITY_INSERT [dbo].[menuinfo] ON 

INSERT [dbo].[menuinfo] ([menuid], [menuname], [path], [parentid], [sort], [createby], [createtime], [updateby], [updatetime]) VALUES (1, N'实时图表', N'', 0, 0, N'admin', CAST(0x0000AA4800DF68A5 AS DateTime), N'admin', CAST(0x0000AA4A01041D23 AS DateTime))
INSERT [dbo].[menuinfo] ([menuid], [menuname], [path], [parentid], [sort], [createby], [createtime], [updateby], [updatetime]) VALUES (2, N'Curve图', N'WindowsForms.ChartManager.frmCurve', 1, 1, N'admin', CAST(0x0000AA4800DF68A5 AS DateTime), N'admin', CAST(0x0000AA4A010452FA AS DateTime))
INSERT [dbo].[menuinfo] ([menuid], [menuname], [path], [parentid], [sort], [createby], [createtime], [updateby], [updatetime]) VALUES (9, N'用户信息', NULL, 0, NULL, N'admin', CAST(0x0000AA4900B9F7FC AS DateTime), NULL, NULL)
INSERT [dbo].[menuinfo] ([menuid], [menuname], [path], [parentid], [sort], [createby], [createtime], [updateby], [updatetime]) VALUES (10, N'用户管理', N'WindowsForms.UserManager.frmUserManager', 9, 1, N'admin', CAST(0x0000AA4900BA56FB AS DateTime), NULL, NULL)
INSERT [dbo].[menuinfo] ([menuid], [menuname], [path], [parentid], [sort], [createby], [createtime], [updateby], [updatetime]) VALUES (12, N'权限管理', N'WindowsForms.UserManager.frmPermissionManager', 9, 2, N'admin', CAST(0x0000AA490114BD0A AS DateTime), NULL, NULL)
INSERT [dbo].[menuinfo] ([menuid], [menuname], [path], [parentid], [sort], [createby], [createtime], [updateby], [updatetime]) VALUES (13, N'菜单管理', N'WindowsForms.UserManager.frmMenuManager', 9, 3, N'admin', CAST(0x0000AA4A00FB301C AS DateTime), NULL, NULL)
INSERT [dbo].[menuinfo] ([menuid], [menuname], [path], [parentid], [sort], [createby], [createtime], [updateby], [updatetime]) VALUES (14, N'部门管理', N'WindowsForms.UserManager.frmDeptManager', 9, 4, N'admin', CAST(0x0000AA4A0105AB6C AS DateTime), N'admin', CAST(0x0000AA4A0105D6BA AS DateTime))
SET IDENTITY_INSERT [dbo].[menuinfo] OFF
INSERT [dbo].[role_menu] ([roleid], [menuid]) VALUES (1, 2)
INSERT [dbo].[role_menu] ([roleid], [menuid]) VALUES (1, 10)
INSERT [dbo].[role_menu] ([roleid], [menuid]) VALUES (1, 12)
INSERT [dbo].[role_menu] ([roleid], [menuid]) VALUES (2, 2)
INSERT [dbo].[role_menu] ([roleid], [menuid]) VALUES (1, 13)
INSERT [dbo].[role_menu] ([roleid], [menuid]) VALUES (1, 14)
SET IDENTITY_INSERT [dbo].[roleinfo] ON 

INSERT [dbo].[roleinfo] ([roleid], [rolename], [remark], [createby], [createtime], [updateby], [updatetime]) VALUES (1, N'管理员', NULL, N'admin', CAST(0x0000AA48009F5CAC AS DateTime), NULL, NULL)
INSERT [dbo].[roleinfo] ([roleid], [rolename], [remark], [createby], [createtime], [updateby], [updatetime]) VALUES (2, N'职员', NULL, N'admin', CAST(0x0000AA4A00B851A9 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[roleinfo] OFF
INSERT [dbo].[sysuser] ([username], [password], [realname], [telephone], [deptno], [roleid], [createtime], [createby], [status], [updateby], [updatetime]) VALUES (N'admin', N'202cb962ac59075b964b07152d234b70', N'admin', N'1234567', 1, 1, CAST(0x0000AA4800A04979 AS DateTime), N'admin', 1, N'admin', CAST(0x0000AA4A010EB849 AS DateTime))
INSERT [dbo].[sysuser] ([username], [password], [realname], [telephone], [deptno], [roleid], [createtime], [createby], [status], [updateby], [updatetime]) VALUES (N'lilong', N'202cb962ac59075b964b07152d234b70', N'李龙', N'13625692222', 2, 2, CAST(0x0000AA4A00B88834 AS DateTime), N'admin', 1, N'admin', CAST(0x0000AA4A010ED661 AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_pathValue] ON 

INSERT [dbo].[tbl_pathValue] ([id], [path], [filename], [testItem], [testValue], [testTime], [createTime]) VALUES (1, N'E:\data\2019\05\test2.txt', N'test2.txt', N'test1', CAST(289.1034 AS Decimal(10, 4)), CAST(0x0000AA4000CB3F40 AS DateTime), CAST(0x0000AA4600B69EFC AS DateTime))
INSERT [dbo].[tbl_pathValue] ([id], [path], [filename], [testItem], [testValue], [testTime], [createTime]) VALUES (2, N'E:\data\2019\05\test2.txt', N'test2.txt', N'test2', CAST(200.0962 AS Decimal(10, 4)), CAST(0x0000AA4000CDFE60 AS DateTime), CAST(0x0000AA4600B69F19 AS DateTime))
INSERT [dbo].[tbl_pathValue] ([id], [path], [filename], [testItem], [testValue], [testTime], [createTime]) VALUES (5, N'E:\data\2019\05\test2.txt', N'test2.txt', N'test1', CAST(250.0458 AS Decimal(10, 4)), CAST(0x0000AA4000C5C100 AS DateTime), CAST(0x0000AA4600B69EFC AS DateTime))
INSERT [dbo].[tbl_pathValue] ([id], [path], [filename], [testItem], [testValue], [testTime], [createTime]) VALUES (6, N'E:\data\2019\05\test2.txt', N'test2.txt', N'test2', CAST(300.0639 AS Decimal(10, 4)), CAST(0x0000AA4000D0BD80 AS DateTime), CAST(0x0000AA4600B69F19 AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_pathValue] OFF
ALTER TABLE [dbo].[department] ADD  CONSTRAINT [DF_department_createtime]  DEFAULT (getdate()) FOR [createtime]
GO
ALTER TABLE [dbo].[menuinfo] ADD  CONSTRAINT [DF_menuinfo_createtime]  DEFAULT (getdate()) FOR [createtime]
GO
ALTER TABLE [dbo].[roleinfo] ADD  CONSTRAINT [DF_roleinfo_createtime]  DEFAULT (getdate()) FOR [createtime]
GO
ALTER TABLE [dbo].[sysuser] ADD  CONSTRAINT [DF_sysuser_createtime]  DEFAULT (getdate()) FOR [createtime]
GO
ALTER TABLE [dbo].[role_menu]  WITH CHECK ADD  CONSTRAINT [FK__role_menu__menui__45F365D3] FOREIGN KEY([menuid])
REFERENCES [dbo].[menuinfo] ([menuid])
GO
ALTER TABLE [dbo].[role_menu] CHECK CONSTRAINT [FK__role_menu__menui__45F365D3]
GO
ALTER TABLE [dbo].[role_menu]  WITH CHECK ADD FOREIGN KEY([roleid])
REFERENCES [dbo].[roleinfo] ([roleid])
GO
ALTER TABLE [dbo].[sysuser]  WITH CHECK ADD  CONSTRAINT [FK__sysuser__deptno__4222D4EF] FOREIGN KEY([deptno])
REFERENCES [dbo].[department] ([deptno])
GO
ALTER TABLE [dbo].[sysuser] CHECK CONSTRAINT [FK__sysuser__deptno__4222D4EF]
GO
ALTER TABLE [dbo].[sysuser]  WITH CHECK ADD  CONSTRAINT [FK__sysuser__roleid__4316F928] FOREIGN KEY([roleid])
REFERENCES [dbo].[roleinfo] ([roleid])
GO
ALTER TABLE [dbo].[sysuser] CHECK CONSTRAINT [FK__sysuser__roleid__4316F928]
GO
