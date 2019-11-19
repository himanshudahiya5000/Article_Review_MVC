INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd0c65128-dd01-442f-992d-65cd6976f832', N'admin@articles.com', N'ADMIN@ARTICLES.COM', N'admin@articles.com', N'ADMIN@ARTICLES.COM', 1, N'AQAAAAEAACcQAAAAEOO8CqVY1CqmBGa2yjZXS8aCCuf/A8cmO5X993y1NDQA8yHT/TNTMLLbCJAB2ZoSzw==', N'OD4QMAYATAFE4VLE3OOTJQVVL7DB7Y3I', N'49f0f7c1-8064-4044-975a-3f6762a39c1a', NULL, 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Author] ON
INSERT INTO [dbo].[Author] ([Id], [Name], [Email]) VALUES (1, N'Henry Wilkinson', N'henry@articles.com')
INSERT INTO [dbo].[Author] ([Id], [Name], [Email]) VALUES (2, N'Bob Davidson', N'bob@articles.com')
INSERT INTO [dbo].[Author] ([Id], [Name], [Email]) VALUES (3, N'Samson Kent', N'sam@articles.com')
SET IDENTITY_INSERT [dbo].[Author] OFF
SET IDENTITY_INSERT [dbo].[Reviewer] ON
INSERT INTO [dbo].[Reviewer] ([Id], [Name], [Email]) VALUES (1, N'Dave Franklin', N'dave@articles.com')
INSERT INTO [dbo].[Reviewer] ([Id], [Name], [Email]) VALUES (2, N'John Smith', N'john@articles.com')
SET IDENTITY_INSERT [dbo].[Reviewer] OFF
SET IDENTITY_INSERT [dbo].[Article] ON
INSERT INTO [dbo].[Article] ([Id], [Name], [AuthorId], [ReviewerId], [ReviewComment], [Rating]) VALUES (1, N'The Scientific World', 1, 1, N'Explains concepts in a natural and a simple phrases', 5)
INSERT INTO [dbo].[Article] ([Id], [Name], [AuthorId], [ReviewerId], [ReviewComment], [Rating]) VALUES (2, N' Artificial Intelligence and Humans', 1, 1, N'Details out the reality behind the information revolution', 5)
SET IDENTITY_INSERT [dbo].[Article] OFF
