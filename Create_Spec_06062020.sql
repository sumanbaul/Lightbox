USE [Lightbox]
GO
/****** Object:  Table [dbo].[Spec]    Script Date: 6-6-2020 16:37:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Spec](
	[Id] [bigint]  IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ImageId] [bigint] NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Spec] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF ,STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
ALTER TABLE [dbo].[Spec]  WITH CHECK ADD  CONSTRAINT [FK_Spec_Photos] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Photos] ([Id])
GO
ALTER TABLE [dbo].[Spec] CHECK CONSTRAINT [FK_Spec_Photos]
GO
