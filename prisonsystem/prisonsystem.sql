USE [prisonsystem]
GO
/****** Object:  Table [dbo].[dependent]    Script Date: 12/30/2021 9:25:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dependent](
	[did] [int] IDENTITY(1,1) NOT NULL,
	[pid] [int] NULL,
	[prisonid] [int] NULL,
	[dfname] [nchar](10) NULL,
	[dlname] [nchar](10) NULL,
	[realationship] [nchar](10) NULL,
	[phone] [int] NULL,
 CONSTRAINT [PK_dependent] PRIMARY KEY CLUSTERED 
(
	[did] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[emploee]    Script Date: 12/30/2021 9:25:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[emploee](
	[eid] [int] IDENTITY(1,1) NOT NULL,
	[pcid] [int] NULL,
	[fname] [nchar](10) NULL,
	[lname] [nchar](10) NULL,
	[birthday] [date] NULL,
	[job] [nchar](10) NULL,
	[salary] [int] NULL,
 CONSTRAINT [PK_emploee] PRIMARY KEY CLUSTERED 
(
	[eid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[jailor]    Script Date: 12/30/2021 9:25:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[jailor](
	[jeid] [int] NOT NULL,
	[jprisonid] [int] NULL,
 CONSTRAINT [PK_jailor] PRIMARY KEY CLUSTERED 
(
	[jeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[manager]    Script Date: 12/30/2021 9:25:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[manager](
	[meid] [int] NOT NULL,
	[start] [date] NULL,
	[pmeid] [int] NULL,
 CONSTRAINT [PK_manager] PRIMARY KEY CLUSTERED 
(
	[meid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prison]    Script Date: 12/30/2021 9:25:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prison](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](10) NULL,
	[address] [nchar](10) NULL,
	[phone] [int] NULL,
 CONSTRAINT [PK_prison] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prisoncell]    Script Date: 12/30/2021 9:25:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prisoncell](
	[pcid] [int] IDENTITY(1,1) NOT NULL,
	[prisonid] [int] NULL,
	[jeid] [int] NULL,
	[name] [nchar](10) NULL,
 CONSTRAINT [PK_prisoncell] PRIMARY KEY CLUSTERED 
(
	[pcid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prisoner]    Script Date: 12/30/2021 9:25:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prisoner](
	[pid] [int] IDENTITY(1,1) NOT NULL,
	[pjeid] [int] NULL,
	[pcid] [int] NULL,
	[prisonid] [int] NULL,
	[pfname] [nchar](10) NULL,
	[plname] [nchar](10) NULL,
	[birthday] [date] NULL,
	[offence] [nchar](10) NULL,
	[startdate] [date] NULL,
	[freedate] [date] NULL,
 CONSTRAINT [PK_prisoner] PRIMARY KEY CLUSTERED 
(
	[pid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[dependent]  WITH CHECK ADD  CONSTRAINT [FK_dependent_prison] FOREIGN KEY([prisonid])
REFERENCES [dbo].[prison] ([id])
GO
ALTER TABLE [dbo].[dependent] CHECK CONSTRAINT [FK_dependent_prison]
GO
ALTER TABLE [dbo].[dependent]  WITH CHECK ADD  CONSTRAINT [FK_dependent_prisoner] FOREIGN KEY([pid])
REFERENCES [dbo].[prisoner] ([pid])
GO
ALTER TABLE [dbo].[dependent] CHECK CONSTRAINT [FK_dependent_prisoner]
GO
ALTER TABLE [dbo].[emploee]  WITH CHECK ADD  CONSTRAINT [FK_emploee_prison] FOREIGN KEY([pcid])
REFERENCES [dbo].[prison] ([id])
GO
ALTER TABLE [dbo].[emploee] CHECK CONSTRAINT [FK_emploee_prison]
GO
ALTER TABLE [dbo].[jailor]  WITH CHECK ADD  CONSTRAINT [FK_jailor_emploee] FOREIGN KEY([jeid])
REFERENCES [dbo].[emploee] ([eid])
GO
ALTER TABLE [dbo].[jailor] CHECK CONSTRAINT [FK_jailor_emploee]
GO
ALTER TABLE [dbo].[jailor]  WITH CHECK ADD  CONSTRAINT [FK_jailor_prison] FOREIGN KEY([jprisonid])
REFERENCES [dbo].[prison] ([id])
GO
ALTER TABLE [dbo].[jailor] CHECK CONSTRAINT [FK_jailor_prison]
GO
ALTER TABLE [dbo].[manager]  WITH CHECK ADD  CONSTRAINT [FK_manager_emploee] FOREIGN KEY([meid])
REFERENCES [dbo].[emploee] ([eid])
GO
ALTER TABLE [dbo].[manager] CHECK CONSTRAINT [FK_manager_emploee]
GO
ALTER TABLE [dbo].[manager]  WITH CHECK ADD  CONSTRAINT [FK_manager_prison] FOREIGN KEY([pmeid])
REFERENCES [dbo].[prison] ([id])
GO
ALTER TABLE [dbo].[manager] CHECK CONSTRAINT [FK_manager_prison]
GO
ALTER TABLE [dbo].[prisoncell]  WITH CHECK ADD  CONSTRAINT [FK_prisoncell_jailor] FOREIGN KEY([jeid])
REFERENCES [dbo].[jailor] ([jeid])
GO
ALTER TABLE [dbo].[prisoncell] CHECK CONSTRAINT [FK_prisoncell_jailor]
GO
ALTER TABLE [dbo].[prisoncell]  WITH CHECK ADD  CONSTRAINT [FK_prisoncell_prison] FOREIGN KEY([prisonid])
REFERENCES [dbo].[prison] ([id])
GO
ALTER TABLE [dbo].[prisoncell] CHECK CONSTRAINT [FK_prisoncell_prison]
GO
ALTER TABLE [dbo].[prisoner]  WITH CHECK ADD  CONSTRAINT [FK_prisoner_jailor] FOREIGN KEY([pjeid])
REFERENCES [dbo].[jailor] ([jeid])
GO
ALTER TABLE [dbo].[prisoner] CHECK CONSTRAINT [FK_prisoner_jailor]
GO
ALTER TABLE [dbo].[prisoner]  WITH CHECK ADD  CONSTRAINT [FK_prisoner_prison] FOREIGN KEY([prisonid])
REFERENCES [dbo].[prison] ([id])
GO
ALTER TABLE [dbo].[prisoner] CHECK CONSTRAINT [FK_prisoner_prison]
GO
ALTER TABLE [dbo].[prisoner]  WITH CHECK ADD  CONSTRAINT [FK_prisoner_prisoncell] FOREIGN KEY([pcid])
REFERENCES [dbo].[prisoncell] ([pcid])
GO
ALTER TABLE [dbo].[prisoner] CHECK CONSTRAINT [FK_prisoner_prisoncell]
GO
