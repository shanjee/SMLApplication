USE [SMLDB]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 8/13/2015 11:14:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[AppointmentId] [int] IDENTITY(1,1) NOT NULL,
	[DoctorId] [int] NOT NULL,
	[PatientId] [int] NOT NULL,
	[AppointmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Appointments] PRIMARY KEY CLUSTERED 
(
	[AppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 8/13/2015 11:14:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[DoctorId] [int] NOT NULL,
	[PatientId] [int] NOT NULL,
	[Bookingdate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Bookings] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 8/13/2015 11:14:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors](
	[DoctorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Age] [int] NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Doctors] PRIMARY KEY CLUSTERED 
(
	[DoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Patients]    Script Date: 8/13/2015 11:14:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Age] [int] NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Patients] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 8/13/2015 11:14:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 8/13/2015 11:14:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL DEFAULT ((0)),
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL DEFAULT ((0)),
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 8/13/2015 11:14:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 8/13/2015 11:14:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 8/13/2015 11:14:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Doctors] ON 

INSERT [dbo].[Doctors] ([DoctorId], [Name], [Age], [Address]) VALUES (1, N'doctor1', 15, N'address3')
INSERT [dbo].[Doctors] ([DoctorId], [Name], [Age], [Address]) VALUES (2, N'doctor2', 25, N'address1')
INSERT [dbo].[Doctors] ([DoctorId], [Name], [Age], [Address]) VALUES (3, N'doctor3', 30, N'address3')
SET IDENTITY_INSERT [dbo].[Doctors] OFF
SET IDENTITY_INSERT [dbo].[Patients] ON 

INSERT [dbo].[Patients] ([PatientId], [Name], [Age], [Address]) VALUES (1, N'patient1', 25, N'address1')
INSERT [dbo].[Patients] ([PatientId], [Name], [Age], [Address]) VALUES (2, N'patient2', 30, N'address2')
INSERT [dbo].[Patients] ([PatientId], [Name], [Age], [Address]) VALUES (3, N'patient2', 40, N'address3')
SET IDENTITY_INSERT [dbo].[Patients] OFF
SET IDENTITY_INSERT [dbo].[UserProfile] ON 

INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (1, N'admin')
INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (2, N'patient1')
INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (3, N'patient2')
INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (4, N'patient3')
INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (5, N'doctor1')
INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (6, N'doctor2')
INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (7, N'doctor3')
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (1, CAST(N'2015-08-13 05:35:06.067' AS DateTime), NULL, 1, CAST(N'2015-08-13 05:39:39.190' AS DateTime), 0, N'AJKL9oe6WLahAhSDcQm/ut5hmbCQnQjE+acO/IyAGeb0fcS5MHYkuhDlrSxB0ciu6Q==', CAST(N'2015-08-13 05:35:06.067' AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (2, CAST(N'2015-08-13 05:37:30.220' AS DateTime), NULL, 1, CAST(N'2015-08-13 05:40:48.233' AS DateTime), 0, N'AOtAm8m7fCu9Xtq0ixgiIbAhp+/uKRMXLUHUdhrBt6LNxd05JcR7FJ/H8oPdUb/49g==', CAST(N'2015-08-13 05:37:30.220' AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (3, CAST(N'2015-08-13 05:38:04.853' AS DateTime), NULL, 1, NULL, 0, N'ADEhEE/tI73XoB2aFfhin5CEPeW0e0r4+DSrqvuuNx7ST9JbBs93/Mv9zvK87cGxlA==', CAST(N'2015-08-13 05:38:04.853' AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (4, CAST(N'2015-08-13 05:38:23.223' AS DateTime), NULL, 1, NULL, 0, N'APBVzNobGXJttoip/B8ck9SCixPtPx0mnVY1zB9NyZbm9/VxnfnU7GtHtTNSTi/4aA==', CAST(N'2015-08-13 05:38:23.223' AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (5, CAST(N'2015-08-13 05:38:40.157' AS DateTime), NULL, 1, NULL, 0, N'AJCmq52UJmOBDkA8IJQiRLIt+JGDHTT5G9dIFm/xhK+1hDIDy8sFBN4UXpVwkc3PuQ==', CAST(N'2015-08-13 05:38:40.157' AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (6, CAST(N'2015-08-13 05:39:02.867' AS DateTime), NULL, 1, NULL, 0, N'ADLXvvOktxHYuZuk4Ei8QoH4RVGd7s4eKfXVolQiM3mQoyAVYUfM4ZEmLZmti98wug==', CAST(N'2015-08-13 05:39:02.867' AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (7, CAST(N'2015-08-13 05:39:18.930' AS DateTime), NULL, 1, NULL, 0, N'ACZ3CWkrctIXvi4cL8b/5Iq0VuqDqTOdd0Lh1r8z/ngLrTOiQZQ2Oh8hD5tl4/9Qiw==', CAST(N'2015-08-13 05:39:18.930' AS DateTime), N'', NULL, NULL)
SET IDENTITY_INSERT [dbo].[webpages_Roles] ON 

INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (2, N'Doctor')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (3, N'Patient')
SET IDENTITY_INSERT [dbo].[webpages_Roles] OFF
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 1)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (2, 3)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (3, 3)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (4, 3)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (5, 2)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (6, 2)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (7, 2)
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__webpages__8A2B6160BA7E8A4C]    Script Date: 8/13/2015 11:14:52 AM ******/
ALTER TABLE [dbo].[webpages_Roles] ADD UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Appointments_dbo.Doctors_DoctorId] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctors] ([DoctorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_dbo.Appointments_dbo.Doctors_DoctorId]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Appointments_dbo.Patients_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([PatientId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_dbo.Appointments_dbo.Patients_PatientId]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Bookings_dbo.Doctors_DoctorId] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctors] ([DoctorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_dbo.Bookings_dbo.Doctors_DoctorId]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Bookings_dbo.Patients_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([PatientId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_dbo.Bookings_dbo.Patients_PatientId]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_RoleId]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_UserId]
GO
