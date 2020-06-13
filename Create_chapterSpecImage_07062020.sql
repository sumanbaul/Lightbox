USE [Lightbox]
GO
/****** Object:  Table [dbo].[chapterSpecImage]    Script Date: 7-6-2020 11:44:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chapterSpecImage](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[chapterId] [bigint] NULL,
	[specId] [bigint] NULL,
	[imageId] [bigint] NULL,
 CONSTRAINT [PK_chapterSpecImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
ALTER TABLE [dbo].[chapterSpecImage]  WITH CHECK ADD  CONSTRAINT [FK_chapterSpecImage_Chapters] FOREIGN KEY([chapterId])
REFERENCES [dbo].[Chapters] ([Id])
GO
ALTER TABLE [dbo].[chapterSpecImage] CHECK CONSTRAINT [FK_chapterSpecImage_Chapters]
GO
ALTER TABLE [dbo].[chapterSpecImage]  WITH CHECK ADD  CONSTRAINT [FK_chapterSpecImage_Photos] FOREIGN KEY([imageId])
REFERENCES [dbo].[Photos] ([Id])
GO
ALTER TABLE [dbo].[chapterSpecImage] CHECK CONSTRAINT [FK_chapterSpecImage_Photos]
GO
ALTER TABLE [dbo].[chapterSpecImage]  WITH CHECK ADD  CONSTRAINT [FK_chapterSpecImage_Spec] FOREIGN KEY([specId])
REFERENCES [dbo].[Spec] ([Id])
GO
ALTER TABLE [dbo].[chapterSpecImage] CHECK CONSTRAINT [FK_chapterSpecImage_Spec]
GO
