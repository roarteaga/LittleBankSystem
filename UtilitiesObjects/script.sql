USE [LITBANKSYS]
GO
/****** Object:  Table [dbo].[CLIENT]    Script Date: 12/03/2019 10:42:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENT](
	[CL_ID] [int] IDENTITY(1,1) NOT NULL,
	[CL_NAME] [nvarchar](200) NOT NULL,
	[CL_PASSWORD] [nvarchar](200) NOT NULL,
	[CL_CREATION_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_CLIENT] PRIMARY KEY CLUSTERED 
(
	[CL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ACCOUNT]    Script Date: 12/03/2019 10:42:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACCOUNT](
	[AC_ID] [int] IDENTITY(1,1) NOT NULL,
	[AC_CL_ID] [int] NOT NULL,
	[AC_BALANCE] [decimal](18, 2) NOT NULL,
	[AC_ACT_ID] [int] NOT NULL,
	[AC_CREATION_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_ACCOUNT] PRIMARY KEY CLUSTERED 
(
	[AC_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vwCLIENT_FIRST_ACCOUNT]    Script Date: 12/03/2019 10:42:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwCLIENT_FIRST_ACCOUNT]
AS
SELECT        cli.CL_ID, cli.CL_NAME, cli.CL_PASSWORD, cli.CL_CREATION_DATE, aco.AC_ACT_ID, aco.AC_BALANCE
FROM            dbo.CLIENT AS cli INNER JOIN
                         dbo.ACCOUNT AS aco ON cli.CL_ID = aco.AC_CL_ID
GO
/****** Object:  Table [dbo].[ACCOUNT_TYPE]    Script Date: 12/03/2019 10:42:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACCOUNT_TYPE](
	[ACT_ID] [int] IDENTITY(1,1) NOT NULL,
	[ACT_DESCRIPTION] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_ACCOUNT_TYPE] PRIMARY KEY CLUSTERED 
(
	[ACT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OPERATION_LOG]    Script Date: 12/03/2019 10:42:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OPERATION_LOG](
	[OP_ID] [int] IDENTITY(1,1) NOT NULL,
	[OP_DESCRIPTION] [nvarchar](500) NOT NULL,
	[OP_CL_ID] [int] NOT NULL,
	[OP_AC_ID] [int] NOT NULL,
	[OP_DATE] [datetime] NULL,
 CONSTRAINT [PK_OPERATION_LOG] PRIMARY KEY CLUSTERED 
(
	[OP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ACCOUNT] ON 

INSERT [dbo].[ACCOUNT] ([AC_ID], [AC_CL_ID], [AC_BALANCE], [AC_ACT_ID], [AC_CREATION_DATE]) VALUES (1, 1, CAST(2100000.00 AS Decimal(18, 2)), 1, CAST(N'2019-03-10T00:20:01.153' AS DateTime))
INSERT [dbo].[ACCOUNT] ([AC_ID], [AC_CL_ID], [AC_BALANCE], [AC_ACT_ID], [AC_CREATION_DATE]) VALUES (2, 2, CAST(10219999.00 AS Decimal(18, 2)), 1, CAST(N'2019-03-10T01:17:07.953' AS DateTime))
INSERT [dbo].[ACCOUNT] ([AC_ID], [AC_CL_ID], [AC_BALANCE], [AC_ACT_ID], [AC_CREATION_DATE]) VALUES (5, 8, CAST(2000000.00 AS Decimal(18, 2)), 1, CAST(N'2019-03-10T19:43:38.417' AS DateTime))
SET IDENTITY_INSERT [dbo].[ACCOUNT] OFF
SET IDENTITY_INSERT [dbo].[ACCOUNT_TYPE] ON 

INSERT [dbo].[ACCOUNT_TYPE] ([ACT_ID], [ACT_DESCRIPTION]) VALUES (1, N'Cuenta corriente')
SET IDENTITY_INSERT [dbo].[ACCOUNT_TYPE] OFF
SET IDENTITY_INSERT [dbo].[CLIENT] ON 

INSERT [dbo].[CLIENT] ([CL_ID], [CL_NAME], [CL_PASSWORD], [CL_CREATION_DATE]) VALUES (1, N'rodolfo.arteaga', N'rarteaga', CAST(N'2019-03-09T20:46:30.773' AS DateTime))
INSERT [dbo].[CLIENT] ([CL_ID], [CL_NAME], [CL_PASSWORD], [CL_CREATION_DATE]) VALUES (2, N'juan.perez', N'jperez', CAST(N'2019-03-10T01:16:37.057' AS DateTime))
INSERT [dbo].[CLIENT] ([CL_ID], [CL_NAME], [CL_PASSWORD], [CL_CREATION_DATE]) VALUES (4, N'fernando.fernandez', N'1234', CAST(N'2019-03-10T18:53:21.243' AS DateTime))
INSERT [dbo].[CLIENT] ([CL_ID], [CL_NAME], [CL_PASSWORD], [CL_CREATION_DATE]) VALUES (5, N'mario.mendez', N'123', CAST(N'2019-03-10T18:57:24.287' AS DateTime))
INSERT [dbo].[CLIENT] ([CL_ID], [CL_NAME], [CL_PASSWORD], [CL_CREATION_DATE]) VALUES (6, N'pedro.pereira', N'1234', CAST(N'2019-03-10T19:35:55.673' AS DateTime))
INSERT [dbo].[CLIENT] ([CL_ID], [CL_NAME], [CL_PASSWORD], [CL_CREATION_DATE]) VALUES (7, N'juan.perez', N'123', CAST(N'2019-03-10T19:39:27.913' AS DateTime))
INSERT [dbo].[CLIENT] ([CL_ID], [CL_NAME], [CL_PASSWORD], [CL_CREATION_DATE]) VALUES (8, N'carlos.sierra', N'666', CAST(N'2019-03-10T19:43:35.060' AS DateTime))
SET IDENTITY_INSERT [dbo].[CLIENT] OFF
SET IDENTITY_INSERT [dbo].[OPERATION_LOG] ON 

INSERT [dbo].[OPERATION_LOG] ([OP_ID], [OP_DESCRIPTION], [OP_CL_ID], [OP_AC_ID], [OP_DATE]) VALUES (56, N'Consignación exitosa.', 1, 1, CAST(N'2019-03-12T22:35:07.663' AS DateTime))
INSERT [dbo].[OPERATION_LOG] ([OP_ID], [OP_DESCRIPTION], [OP_CL_ID], [OP_AC_ID], [OP_DATE]) VALUES (57, N'Se ha obtenido el saldo exitosamente.', 1, 1, CAST(N'2019-03-12T22:36:05.457' AS DateTime))
INSERT [dbo].[OPERATION_LOG] ([OP_ID], [OP_DESCRIPTION], [OP_CL_ID], [OP_AC_ID], [OP_DATE]) VALUES (58, N'Se ha obtenido el saldo exitosamente.', 1, 1, CAST(N'2019-03-12T22:37:21.477' AS DateTime))
INSERT [dbo].[OPERATION_LOG] ([OP_ID], [OP_DESCRIPTION], [OP_CL_ID], [OP_AC_ID], [OP_DATE]) VALUES (59, N'Retiro exitoso', 1, 1, CAST(N'2019-03-12T22:37:31.847' AS DateTime))
INSERT [dbo].[OPERATION_LOG] ([OP_ID], [OP_DESCRIPTION], [OP_CL_ID], [OP_AC_ID], [OP_DATE]) VALUES (60, N'Se ha obtenido el saldo exitosamente.', 1, 1, CAST(N'2019-03-12T22:37:33.410' AS DateTime))
INSERT [dbo].[OPERATION_LOG] ([OP_ID], [OP_DESCRIPTION], [OP_CL_ID], [OP_AC_ID], [OP_DATE]) VALUES (61, N'Consignación exitosa.', 1, 1, CAST(N'2019-03-12T22:37:46.270' AS DateTime))
INSERT [dbo].[OPERATION_LOG] ([OP_ID], [OP_DESCRIPTION], [OP_CL_ID], [OP_AC_ID], [OP_DATE]) VALUES (62, N'Se ha obtenido el saldo exitosamente.', 1, 1, CAST(N'2019-03-12T22:37:46.357' AS DateTime))
INSERT [dbo].[OPERATION_LOG] ([OP_ID], [OP_DESCRIPTION], [OP_CL_ID], [OP_AC_ID], [OP_DATE]) VALUES (63, N'Consignación exitosa.', 1, 1, CAST(N'2019-03-12T22:38:01.813' AS DateTime))
INSERT [dbo].[OPERATION_LOG] ([OP_ID], [OP_DESCRIPTION], [OP_CL_ID], [OP_AC_ID], [OP_DATE]) VALUES (64, N'Se ha obtenido el saldo exitosamente.', 1, 1, CAST(N'2019-03-12T22:38:02.070' AS DateTime))
INSERT [dbo].[OPERATION_LOG] ([OP_ID], [OP_DESCRIPTION], [OP_CL_ID], [OP_AC_ID], [OP_DATE]) VALUES (65, N'Se ha obtenido el saldo exitosamente.', 1, 1, CAST(N'2019-03-12T22:40:12.390' AS DateTime))
INSERT [dbo].[OPERATION_LOG] ([OP_ID], [OP_DESCRIPTION], [OP_CL_ID], [OP_AC_ID], [OP_DATE]) VALUES (66, N'Retiro exitoso', 1, 1, CAST(N'2019-03-12T22:40:21.723' AS DateTime))
INSERT [dbo].[OPERATION_LOG] ([OP_ID], [OP_DESCRIPTION], [OP_CL_ID], [OP_AC_ID], [OP_DATE]) VALUES (67, N'Consignación exitosa.', 2, 2, CAST(N'2019-03-12T22:40:21.987' AS DateTime))
INSERT [dbo].[OPERATION_LOG] ([OP_ID], [OP_DESCRIPTION], [OP_CL_ID], [OP_AC_ID], [OP_DATE]) VALUES (68, N'Transferencia realizada correctamente.', 1, 1, CAST(N'2019-03-12T22:40:22.407' AS DateTime))
INSERT [dbo].[OPERATION_LOG] ([OP_ID], [OP_DESCRIPTION], [OP_CL_ID], [OP_AC_ID], [OP_DATE]) VALUES (69, N'Se ha obtenido el saldo exitosamente.', 1, 1, CAST(N'2019-03-12T22:40:22.527' AS DateTime))
INSERT [dbo].[OPERATION_LOG] ([OP_ID], [OP_DESCRIPTION], [OP_CL_ID], [OP_AC_ID], [OP_DATE]) VALUES (70, N'Retiro exitoso', 1, 1, CAST(N'2019-03-12T22:40:45.337' AS DateTime))
INSERT [dbo].[OPERATION_LOG] ([OP_ID], [OP_DESCRIPTION], [OP_CL_ID], [OP_AC_ID], [OP_DATE]) VALUES (71, N'Consignación exitosa.', 2, 2, CAST(N'2019-03-12T22:40:45.853' AS DateTime))
INSERT [dbo].[OPERATION_LOG] ([OP_ID], [OP_DESCRIPTION], [OP_CL_ID], [OP_AC_ID], [OP_DATE]) VALUES (72, N'Transferencia realizada correctamente.', 1, 1, CAST(N'2019-03-12T22:40:46.063' AS DateTime))
INSERT [dbo].[OPERATION_LOG] ([OP_ID], [OP_DESCRIPTION], [OP_CL_ID], [OP_AC_ID], [OP_DATE]) VALUES (73, N'Se ha obtenido el saldo exitosamente.', 1, 1, CAST(N'2019-03-12T22:40:46.130' AS DateTime))
INSERT [dbo].[OPERATION_LOG] ([OP_ID], [OP_DESCRIPTION], [OP_CL_ID], [OP_AC_ID], [OP_DATE]) VALUES (74, N'Se ha obtenido el saldo exitosamente.', 1, 1, CAST(N'2019-03-12T22:41:08.763' AS DateTime))
SET IDENTITY_INSERT [dbo].[OPERATION_LOG] OFF
ALTER TABLE [dbo].[ACCOUNT]  WITH CHECK ADD  CONSTRAINT [FK_ACCOUNT_ACCOUNT_TYPE] FOREIGN KEY([AC_ACT_ID])
REFERENCES [dbo].[ACCOUNT_TYPE] ([ACT_ID])
GO
ALTER TABLE [dbo].[ACCOUNT] CHECK CONSTRAINT [FK_ACCOUNT_ACCOUNT_TYPE]
GO
ALTER TABLE [dbo].[ACCOUNT]  WITH CHECK ADD  CONSTRAINT [FK_ACCOUNT_CLIENT] FOREIGN KEY([AC_CL_ID])
REFERENCES [dbo].[CLIENT] ([CL_ID])
GO
ALTER TABLE [dbo].[ACCOUNT] CHECK CONSTRAINT [FK_ACCOUNT_CLIENT]
GO
ALTER TABLE [dbo].[OPERATION_LOG]  WITH CHECK ADD  CONSTRAINT [FK_OPERATION_LOG_ACCOUNT] FOREIGN KEY([OP_AC_ID])
REFERENCES [dbo].[ACCOUNT] ([AC_ID])
GO
ALTER TABLE [dbo].[OPERATION_LOG] CHECK CONSTRAINT [FK_OPERATION_LOG_ACCOUNT]
GO
ALTER TABLE [dbo].[OPERATION_LOG]  WITH CHECK ADD  CONSTRAINT [FK_OPERATION_LOG_CLIENT] FOREIGN KEY([OP_CL_ID])
REFERENCES [dbo].[CLIENT] ([CL_ID])
GO
ALTER TABLE [dbo].[OPERATION_LOG] CHECK CONSTRAINT [FK_OPERATION_LOG_CLIENT]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "cli"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 237
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "aco"
            Begin Extent = 
               Top = 6
               Left = 275
               Bottom = 136
               Right = 476
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwCLIENT_FIRST_ACCOUNT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwCLIENT_FIRST_ACCOUNT'
GO
