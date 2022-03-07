USE [Movies]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 07/03/2022 14:02:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 07/03/2022 14:02:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](255) NOT NULL,
	[ImgUrl] [varchar](255) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Rate] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([Id], [Title]) VALUES (1, N'Action')
GO
INSERT [dbo].[Categories] ([Id], [Title]) VALUES (2, N'Drama')
GO
INSERT [dbo].[Categories] ([Id], [Title]) VALUES (3, N'Fantasy')
GO
INSERT [dbo].[Categories] ([Id], [Title]) VALUES (4, N'Comedy')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Movie] ON 
GO
INSERT [dbo].[Movie] ([Id], [Title], [ImgUrl], [CategoryId], [Rate]) VALUES (1, N'Forest Gump', N'https://upload.wikimedia.org/wikipedia/pt/c/c0/ForrestGumpPoster.jpg', 2, 9)
GO
INSERT [dbo].[Movie] ([Id], [Title], [ImgUrl], [CategoryId], [Rate]) VALUES (2, N'Samantha: An American Girl Holiday', N'https://m.media-amazon.com/images/M/MV5BMjIzMzE0M2UtZmZhZi00NTA0LWJkZDItNzM3OTM1M2RjZmJjXkEyXkFqcGdeQXVyNjc3MjQzNTI@._V1_.jpg', 2, 8)
GO
INSERT [dbo].[Movie] ([Id], [Title], [ImgUrl], [CategoryId], [Rate]) VALUES (3, N'Cellular', N'https://upload.wikimedia.org/wikipedia/en/6/62/Cellular_poster.JPG', 1, 5)
GO
INSERT [dbo].[Movie] ([Id], [Title], [ImgUrl], [CategoryId], [Rate]) VALUES (4, N'Speed', N'https://upload.wikimedia.org/wikipedia/en/4/45/Speed_movie_poster.jpg', 1, 6)
GO
INSERT [dbo].[Movie] ([Id], [Title], [ImgUrl], [CategoryId], [Rate]) VALUES (5, N'Dinner for Schmucks', N'https://m.media-amazon.com/images/I/51Pe5lnA-ZL.jpg', 4, 4)
GO
INSERT [dbo].[Movie] ([Id], [Title], [ImgUrl], [CategoryId], [Rate]) VALUES (6, N'Titanic', N'https://m.media-amazon.com/images/I/51mTtUGvUCL._SY445_.jpg', 2, 10)
GO
INSERT [dbo].[Movie] ([Id], [Title], [ImgUrl], [CategoryId], [Rate]) VALUES (7, N'Harry Potter 1', N'https://br.web.img3.acsta.net/c_310_420/medias/nmedia/18/95/59/60/20417256.jpg', 3, 2)
GO
INSERT [dbo].[Movie] ([Id], [Title], [ImgUrl], [CategoryId], [Rate]) VALUES (8, N'The Lord of The Rings', N'https://jaynicol1.files.wordpress.com/2015/09/fantasy-film.jpg', 3, 9)
GO
INSERT [dbo].[Movie] ([Id], [Title], [ImgUrl], [CategoryId], [Rate]) VALUES (9, N'Casino Royale', N'https://m.media-amazon.com/images/I/81g5MtvsGtL._AC_SL1500_.jpg', 1, 1)
GO
INSERT [dbo].[Movie] ([Id], [Title], [ImgUrl], [CategoryId], [Rate]) VALUES (10, N'Bad Boys 2', N'https://upload.wikimedia.org/wikipedia/pt/6/62/Bad_Boys_II.jpg', 4, 7)
GO
SET IDENTITY_INSERT [dbo].[Movie] OFF
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
