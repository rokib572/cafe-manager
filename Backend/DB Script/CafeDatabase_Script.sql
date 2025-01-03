USE [master]
GO
/****** Object:  Database [CafeDatabase]    Script Date: 11/27/2024 11:22:49 PM ******/
CREATE DATABASE [CafeDatabase]
GO
USE [CafeDatabase]
GO
/****** Object:  Table [dbo].[Cafe]    Script Date: 11/27/2024 11:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cafe](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](256) NOT NULL,
	[Logo] [nvarchar](256) NULL,
	[Location] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Cafe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 11/27/2024 11:22:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [nvarchar](11) NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
	[EmailAddress] [nvarchar](150) NOT NULL,
	[PhoneNumber] [nvarchar](8) NOT NULL,
	[Gender] [nvarchar](6) NOT NULL,
	[CafeId] [uniqueidentifier] NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Cafe] ([Id], [Name], [Description], [Logo], [Location]) VALUES (N'0fc0a944-3193-4e87-ac13-06041777ef56', N'Cafe 8', N'Popular for its fast service and great atmosphere.', N'placeholder.png', N'City Center')
INSERT [dbo].[Cafe] ([Id], [Name], [Description], [Logo], [Location]) VALUES (N'd328a824-5fb0-4d79-a50b-0f27b6b6f3fb', N'Cafe 4', N'A family-friendly café with a variety of snacks.', N'placeholder.png', N'Suburbs')
INSERT [dbo].[Cafe] ([Id], [Name], [Description], [Logo], [Location]) VALUES (N'c142c33b-b71f-416b-8119-17cbddfcaf28', N'Cafe 3', N'A quiet café perfect for studying and working.', N'placeholder.png', N'Midtown')
INSERT [dbo].[Cafe] ([Id], [Name], [Description], [Logo], [Location]) VALUES (N'1f848190-8f5b-42c6-ad08-5479cfbc7cef', N'Cafe 13', N'Specializes in vegan and gluten-free options.', N'placeholder.png', N'Healthy District')
INSERT [dbo].[Cafe] ([Id], [Name], [Description], [Logo], [Location]) VALUES (N'ac8d1844-b9f7-4246-b4bc-5885de1a70bb', N'Cafe 6', N'Known for its artisanal coffee and desserts.', N'placeholder.png', N'Beachside')
INSERT [dbo].[Cafe] ([Id], [Name], [Description], [Logo], [Location]) VALUES (N'f1141832-9df0-4c65-96c9-618989f71578', N'Cafe 7', N'An eco-friendly café with organic offerings.', N'placeholder.png', N'Green District')
INSERT [dbo].[Cafe] ([Id], [Name], [Description], [Logo], [Location]) VALUES (N'07454462-a8bd-4fa2-8375-69ce083a0d3d', N'Cafe 20', N'A vibrant café with colorful decor and events.', N'placeholder.png', N'Festival Plaza')
INSERT [dbo].[Cafe] ([Id], [Name], [Description], [Logo], [Location]) VALUES (N'c586974d-9749-4ee0-956b-8bfeee44bae3', N'Cafe 9', N'A unique café with a bookshop ambiance.', N'placeholder.png', N'Library Road')
INSERT [dbo].[Cafe] ([Id], [Name], [Description], [Logo], [Location]) VALUES (N'5a19f332-29d2-48b7-bf1b-9be96a7ee0a8', N'Cafe 14', N'Known for its artistic interior and coffee art.', N'placeholder.png', N'Art Street')
INSERT [dbo].[Cafe] ([Id], [Name], [Description], [Logo], [Location]) VALUES (N'ad061b88-c78e-4f08-8d7b-ad85393681d2', N'Cafe 5', N'A premium café with exquisite beverages.', N'placeholder.png', N'Financial District')
INSERT [dbo].[Cafe] ([Id], [Name], [Description], [Logo], [Location]) VALUES (N'2366c1d6-aa80-432d-beb4-af7afbf39025', N'Cafe 10', N'A café famous for its late-night hours.', N'placeholder.png', N'Night Market')
INSERT [dbo].[Cafe] ([Id], [Name], [Description], [Logo], [Location]) VALUES (N'dd647d03-6910-464e-acfb-c30f4f19b3bb', N'Cafe 15', N'Offers a wide variety of international coffee blends.', N'placeholder.png', N'Airport Zone')
INSERT [dbo].[Cafe] ([Id], [Name], [Description], [Logo], [Location]) VALUES (N'09478546-c1c9-42c9-8d64-c5ecc77c1c7b', N'Cafe 18', N'Famous for its freshly baked pastries and muffins.', N'placeholder.png', N'Bakery Lane')
INSERT [dbo].[Cafe] ([Id], [Name], [Description], [Logo], [Location]) VALUES (N'206db9bb-edbd-4d5f-9a2e-cec89492aef5', N'Cafe 12', N'A pet-friendly café with outdoor seating.', N'placeholder.png', N'Park Lane')
INSERT [dbo].[Cafe] ([Id], [Name], [Description], [Logo], [Location]) VALUES (N'd7692dc1-a805-4dde-b935-e7fb06f3aa4f', N'Cafe 1', N'A cozy café with great coffee and pastries.', N'placeholder.png', N'Downtown')
GO
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000001', N'John G', N'john.doe@example.com', N'91234567', N'Male', N'0fc0a944-3193-4e87-ac13-06041777ef56', CAST(N'2024-06-24T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000002', N'Jane D', N'jane.doe@example.com', N'81234567', N'Female', N'd328a824-5fb0-4d79-a50b-0f27b6b6f3fb', CAST(N'2024-10-02T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000003', N'Alex C', N'alex.smith@example.com', N'82234567', N'Male', N'c142c33b-b71f-416b-8119-17cbddfcaf28', CAST(N'2022-11-02T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000008', N'Emma T', N'emma.black@example.com', N'87234567', N'Female', N'1f848190-8f5b-42c6-ad08-5479cfbc7cef', CAST(N'2022-05-06T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000009', N'Daniel', N'daniel.green@example.com', N'88234567', N'Male', N'ac8d1844-b9f7-4246-b4bc-5885de1a70bb', CAST(N'2022-06-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000010', N'Sophia', N'sophia.blue@example.com', N'89234567', N'Female', N'f1141832-9df0-4c65-96c9-618989f71578', CAST(N'2024-06-24T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000011', N'Oliver K', N'oliver.gray@example.com', N'90234567', N'Male', N'07454462-a8bd-4fa2-8375-69ce083a0d3d', CAST(N'2023-02-10T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000012', N'Isabella', N'isabella.pink@example.com', N'91234568', N'Female', N'c586974d-9749-4ee0-956b-8bfeee44bae3', CAST(N'2023-02-10T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000013', N'Liam G', N'liam.yellow@example.com', N'81234568', N'Male', N'0fc0a944-3193-4e87-ac13-06041777ef56', CAST(N'2022-03-27T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000014', N'Mia Lee', N'mia.orange@example.com', N'82234568', N'Female', N'ad061b88-c78e-4f08-8d7b-ad85393681d2', CAST(N'2024-10-02T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000015', N'Elijah M', N'elijah.brown@example.com', N'83234568', N'Male', N'2366c1d6-aa80-432d-beb4-af7afbf39025', CAST(N'2023-11-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000016', N'Avaa T', N'ava.purple@example.com', N'84234568', N'Female', N'dd647d03-6910-464e-acfb-c30f4f19b3bb', CAST(N'2023-11-24T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000017', N'William', N'william.gold@example.com', N'85234568', N'Male', N'09478546-c1c9-42c9-8d64-c5ecc77c1c7b', CAST(N'2023-08-07T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000018', N'Charlotte', N'charlotte.silver@example.com', N'86234568', N'Female', N'206db9bb-edbd-4d5f-9a2e-cec89492aef5', CAST(N'2024-04-02T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000019', N'Henry P', N'henry.plum@example.com', N'87234568', N'Male', N'd7692dc1-a805-4dde-b935-e7fb06f3aa4f', CAST(N'2023-03-21T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000021', N'John Doe', N'john.doe@example.com', N'91234567', N'Male', N'0fc0a944-3193-4e87-ac13-06041777ef56', CAST(N'2024-11-02T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000022', N'Jane Doe', N'jane.doe@example.com', N'81234567', N'Female', N'd328a824-5fb0-4d79-a50b-0f27b6b6f3fb', CAST(N'2024-11-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000023', N'T Smith', N'alex.smith@example.com', N'82234567', N'Male', N'c142c33b-b71f-416b-8119-17cbddfcaf28', CAST(N'2024-09-21T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000028', N'O Black', N'emma.black@example.com', N'87234567', N'Female', N'1f848190-8f5b-42c6-ad08-5479cfbc7cef', CAST(N'2023-10-26T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000029', N'G Green', N'daniel.green@example.com', N'88234567', N'Male', N'ac8d1844-b9f7-4246-b4bc-5885de1a70bb', CAST(N'2022-09-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000030', N'A Blue', N'sophia.blue@example.com', N'89234567', N'Female', N'f1141832-9df0-4c65-96c9-618989f71578', CAST(N'2024-06-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000031', N'P Gray', N'oliver.gray@example.com', N'90234567', N'Male', N'07454462-a8bd-4fa2-8375-69ce083a0d3d', CAST(N'2024-05-24T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000032', N'T Pink', N'isabella.pink@example.com', N'91234568', N'Female', N'c586974d-9749-4ee0-956b-8bfeee44bae3', CAST(N'2024-02-13T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000033', N'L Yellow', N'liam.yellow@example.com', N'81234568', N'Male', N'5a19f332-29d2-48b7-bf1b-9be96a7ee0a8', CAST(N'2024-08-08T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000034', N'I Orange', N'mia.orange@example.com', N'82234568', N'Female', N'ad061b88-c78e-4f08-8d7b-ad85393681d2', CAST(N'2024-04-19T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000035', N'M Brown', N'elijah.brown@example.com', N'83234568', N'Male', N'2366c1d6-aa80-432d-beb4-af7afbf39025', CAST(N'2023-12-30T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000036', N'N Purple', N'ava.purple@example.com', N'84234568', N'Female', N'dd647d03-6910-464e-acfb-c30f4f19b3bb', CAST(N'2023-09-10T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000037', N'O Gold', N'william.gold@example.com', N'85234568', N'Male', N'09478546-c1c9-42c9-8d64-c5ecc77c1c7b', CAST(N'2023-05-22T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000038', N'U Silver', N'charlotte.silver@example.com', N'86234568', N'Female', N'206db9bb-edbd-4d5f-9a2e-cec89492aef5', CAST(N'2022-10-12T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI000000039', N'S Plum', N'henry.plum@example.com', N'87234568', N'Male', N'ac8d1844-b9f7-4246-b4bc-5885de1a70bb', CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI4c88feaa', N'Yusriyah', N'yusriyah@gmail.com', N'87965214', N'Female', N'f1141832-9df0-4c65-96c9-618989f71578', CAST(N'2024-11-27T22:32:14.3415906' AS DateTime2))
INSERT [dbo].[Employees] ([Id], [Name], [EmailAddress], [PhoneNumber], [Gender], [CafeId], [StartDate]) VALUES (N'UI8208ae07', N'Rokib H', N'rokib572@gmail.com', N'98741235', N'Male', N'c142c33b-b71f-416b-8119-17cbddfcaf28', CAST(N'2024-11-27T12:24:59.5230679' AS DateTime2))
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Employees_Id]    Script Date: 11/27/2024 11:22:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_Employees_Id] ON [dbo].[Employees]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Cafe] FOREIGN KEY([CafeId])
REFERENCES [dbo].[Cafe] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Cafe]
GO
ALTER TABLE [dbo].[Cafe]  WITH CHECK ADD  CONSTRAINT [CK_Cafe_CafeName] CHECK  ((len([Name])>=(6) AND len([Name])<=(10)))
GO
ALTER TABLE [dbo].[Cafe] CHECK CONSTRAINT [CK_Cafe_CafeName]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [CK_Employees_EmployeeId] CHECK  (([Id] like 'UI%' AND len([Id])<=(11)))
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [CK_Employees_EmployeeId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [CK_Employees_EmployeeName] CHECK  ((len([Name])>=(6) AND len([Name])<=(10)))
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [CK_Employees_EmployeeName]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [CK_Employees_Gender] CHECK  (([Gender]='Female' OR [Gender]='Male'))
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [CK_Employees_Gender]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [CK_Employees_PhoneNumber] CHECK  (([PhoneNumber] like '[89]%' AND len([PhoneNumber])=(8)))
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [CK_Employees_PhoneNumber]
GO
USE [master]
GO
ALTER DATABASE [CafeDatabase] SET  READ_WRITE 
GO
