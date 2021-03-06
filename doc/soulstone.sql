USE [Soulstone]
GO
/****** Object:  Table [dbo].[Host]    Script Date: 10/09/2008 07:38:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Host](
	[HostId] [int] IDENTITY(1,1) NOT NULL,
	[HostName] [varchar](250) NOT NULL,
	[FailedUpdateNumber] [int] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[DateAdded] [datetime] NOT NULL,
 CONSTRAINT [PK_Host] PRIMARY KEY CLUSTERED 
(
	[HostId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[GetHostIdFromName]    Script Date: 10/09/2008 07:38:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mario Moreno
-- Create date: 03/10/2008
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[GetHostIdFromName] 
(
	@hostName VARCHAR(250)
)
RETURNS INT
AS
BEGIN
	-- Declare the return variable here
    DECLARE @hostId INT
    SELECT @hostId = HostId FROM Host WHERE HostName = @hostName
	RETURN @hostId
END
GO
/****** Object:  Table [dbo].[HostShare]    Script Date: 10/09/2008 07:38:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HostShare](
	[HostId] [int] NOT NULL,
	[HostShareId] [int] IDENTITY(1,1) NOT NULL,
	[SharePath] [varchar](250) NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_HostShare] PRIMARY KEY CLUSTERED 
(
	[HostId] ASC,
	[HostShareId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CreateOrUpdateHost]    Script Date: 10/09/2008 07:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mario Moreno
-- Create date: 18/09/2008
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[CreateOrUpdateHost] 
@hostName VARCHAR(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    DECLARE @hostId INT
    SELECT @hostId = HostId FROM Host WHERE HostName = @hostName
    
    IF(@hostId IS NULL)
		BEGIN
			INSERT INTO [Host]
				   ([HostName]
				   ,[FailedUpdateNumber]
				   ,[LastUpdated]
				   ,[DateAdded])
			 VALUES
				   (@hostName
				   ,0
				   ,GetDate()
				   ,GetDate())
       END
	ELSE
		BEGIN
			UPDATE [Host]
			SET [FailedUpdateNumber] = 0
			  ,[LastUpdated] = GetDate()
			WHERE HostId = @hostId
		END
END
GO
/****** Object:  Table [dbo].[Mp3FileLink]    Script Date: 10/09/2008 07:38:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mp3FileLink](
	[HostId] [int] NOT NULL,
	[HostShareId] [int] NOT NULL,
	[FilePath] [varchar](1000) NOT NULL,
	[Artist] [varchar](250) NULL,
	[Album] [varchar](250) NULL,
	[Title] [varchar](250) NULL,
	[Year] [int] NULL,
	[Genre] [varchar](50) NULL,
	[LastUpdated] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[GetHostShareId]    Script Date: 10/09/2008 07:38:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mario Moreno
-- Create date: 03/10/2008
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[GetHostShareId]
(
	@hostId INT,
	@sharePath VARCHAR(250)
)
RETURNS INT
AS
BEGIN
	-- Declare the return variable here
    DECLARE @hostShareId INT
    SELECT @hostShareId = HostShareId FROM HostShare WHERE HostId = @hostId AND SharePath = @sharePath
	RETURN @hostShareId
END
GO
/****** Object:  StoredProcedure [dbo].[CreateOrUpdateMp3FileLink]    Script Date: 10/09/2008 07:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mario Moreno
-- Create date: 03/10/2008
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[CreateOrUpdateMp3FileLink] 
@hostName VARCHAR(250),
@sharePath VARCHAR(250),
@filePath VARCHAR(1000),
@artist VARCHAR(250),
@album VARCHAR(250),
@title VARCHAR(250),
@year INT,
@genre VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    DECLARE @hostId INT
	SET @hostId = dbo.GetHostIdFromName(@hostName)
    DECLARE @hostShareId INT
	SET @hostShareId = dbo.GetHostShareId(@hostId, @sharePath)
	DECLARE @shareExists INT
	SELECT @shareExists = HostId FROM Mp3FileLink WHERE HostId = @hostId AND HostShareId = @hostShareId AND FilePath = @filePath

    IF(@shareExists IS NULL)
		BEGIN
			INSERT INTO [Mp3FileLink]
					   ([HostId]
					   ,[HostShareId]
					   ,[FilePath]
					   ,[Artist]
					   ,[Album]
					   ,[Title]
					   ,[Year]
					   ,[Genre]
					   ,[LastUpdated])
				 VALUES
					   (@hostId
					   ,@hostShareId
					   ,@filePath
					   ,@artist
					   ,@album
					   ,@title
					   ,@year
					   ,@genre
					   ,GetDate())
		END
	ELSE
		BEGIN
			UPDATE [Mp3FileLink]
			   SET
				  [Artist] = @artist
				  ,[Album] = @album
				  ,[Title] = @title
				  ,[Year] = @year
				  ,[Genre] = @genre
				  ,[LastUpdated] = GetDate()
			 WHERE HostId = @hostId AND HostShareId = @hostShareId AND FilePath = @filePath
		END
END
GO
/****** Object:  StoredProcedure [dbo].[CreateOrUpdateHostShare]    Script Date: 10/09/2008 07:38:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mario Moreno
-- Create date: 18/09/2008
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[CreateOrUpdateHostShare] 
@hostName VARCHAR(250),
@sharePath VARCHAR(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    DECLARE @hostId INT
	SET @hostId = dbo.GetHostIdFromName(@hostName)
    DECLARE @hostShareId INT
	SET @hostShareId = dbo.GetHostShareId(@hostId, @sharePath)
    
    IF(@hostShareId IS NULL)
		BEGIN
			INSERT INTO [HostShare]
				   ([HostId]
				   ,[SharePath]
				   ,[LastUpdated])
			 VALUES
				   (@hostId
				   ,@sharePath
				   ,GetDate())
		END
	ELSE
		BEGIN
			UPDATE [HostShare]
			SET [LastUpdated] = GetDate()
			WHERE HostId = @hostId AND HostShareId = @hostShareId
		END
END
GO
/****** Object:  ForeignKey [FK_HostShare_Host]    Script Date: 10/09/2008 07:38:42 ******/
ALTER TABLE [dbo].[HostShare]  WITH CHECK ADD  CONSTRAINT [FK_HostShare_Host] FOREIGN KEY([HostId])
REFERENCES [dbo].[Host] ([HostId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HostShare] CHECK CONSTRAINT [FK_HostShare_Host]
GO
/****** Object:  ForeignKey [FK_Mp3FileLink_Host]    Script Date: 10/09/2008 07:38:42 ******/
ALTER TABLE [dbo].[Mp3FileLink]  WITH CHECK ADD  CONSTRAINT [FK_Mp3FileLink_Host] FOREIGN KEY([HostId], [HostShareId])
REFERENCES [dbo].[HostShare] ([HostId], [HostShareId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Mp3FileLink] CHECK CONSTRAINT [FK_Mp3FileLink_Host]
GO
