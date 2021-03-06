USE [Soulstone]
GO
/****** Object:  Table [dbo].[MusicTrack]    Script Date: 02/10/2009 01:09:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MusicTrack](
	[MusicTrackId] [uniqueidentifier] NOT NULL,
	[Artist] [varchar](250) NULL,
	[Album] [varchar](250) NULL,
	[Title] [varchar](250) NULL,
	[Year] [int] NULL,
	[Genre] [varchar](50) NULL,
 CONSTRAINT [PK_MusicTrack] PRIMARY KEY CLUSTERED 
(
	[MusicTrackId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_MusicTrackArtist] ON [dbo].[MusicTrack] 
(
	[Artist] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_MusicTrackTitle] ON [dbo].[MusicTrack] 
(
	[Title] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Host]    Script Date: 02/10/2009 01:09:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Host](
	[HostId] [uniqueidentifier] NOT NULL,
	[HostName] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Host] PRIMARY KEY CLUSTERED 
(
	[HostId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Host_MusicTrack]    Script Date: 02/10/2009 01:09:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Host_MusicTrack](
	[HostId] [uniqueidentifier] NOT NULL,
	[MusicTrackId] [uniqueidentifier] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
	[FailedUpdateNumber] [int] NOT NULL,
	[Path] [varchar](1000) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[GetMusicTrackId]    Script Date: 02/10/2009 01:09:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mario Moreno
-- Create date: 09/01/2008
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[GetMusicTrackId]
(
	@artist varchar(250),
	@album varchar(250),
	@title varchar(250),
	@year int,
	@genre varchar(250)
)
RETURNS uniqueidentifier
AS
BEGIN
	-- Declare the return variable here
    DECLARE @musicTrackId uniqueidentifier
    SELECT @musicTrackId = MusicTrackId 
    FROM MusicTrack 
    WHERE (Artist = @artist OR @artist IS NULL) AND 
		(Album = @album OR @album IS NULL) AND 
		(Title = @title OR @title IS NULL) AND
		(Year = @year OR @year IS NULL) AND 
		(Genre = @genre OR @genre IS NULL) 
	RETURN @musicTrackId
END
GO
/****** Object:  StoredProcedure [dbo].[GetMusicTrack]    Script Date: 02/10/2009 01:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mario Moreno
-- Create date: 10/01/2009
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetMusicTrack] 
@musicTrackId uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    SELECT Artist, Album, Title, Year, Genre 
    FROM MusicTrack
    WHERE MusicTrackId = @musicTrackId
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteObsoleteEntries]    Script Date: 02/10/2009 01:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mario Moreno
-- Create date: 10/01/2009
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[DeleteObsoleteEntries]
@failedUpdateNumber INT 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    UPDATE Host_MusicTrack
    SET FailedUpdateNumber = FailedUpdateNumber + 1
    WHERE Datediff("dd", LastUpdated, GetDate()) <> 0

	DELETE FROM Host_MusicTrack
	WHERE FailedUpdateNumber > @failedUpdateNumber

	DELETE FROM MusicTrack
	WHERE (SELECT MusicTrackId FROM Host_MusicTrack WHERE MusicTrackId = MusicTrack.MusicTrackId) IS NULL
 
 	DELETE FROM Host
	WHERE (SELECT HostId FROM Host_MusicTrack WHERE HostId = Host.HostId) IS NULL	
END
GO
/****** Object:  StoredProcedure [dbo].[Search]    Script Date: 02/10/2009 01:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mario Moreno
-- Create date: 09/01/2009
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[Search] 
	@artist varchar(250),
	@album varchar(250),
	@title varchar(250),
	@genre varchar(50),
	@year int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT HostId, MusicTrack.MusicTrackId, Artist, Album, Title, Year, Genre, Path  
	FROM MusicTrack, Host_MusicTrack
	WHERE (Artist like '%'+@artist+'%' or @artist is null) 
		and (Title like '%'+@title+'%' or @title is null)
		and (Album like '%'+@album+'%' or @album is null) 
		and (Genre like '%'+@genre+'%' or @genre is null)
		and (Year = @year or @year is null)
		and MusicTrack.MusicTrackId = Host_MusicTrack.MusicTrackId
	ORDER BY Artist, Album, Title, Year, Genre
END
GO
/****** Object:  StoredProcedure [dbo].[GetFileFontCount]    Script Date: 02/10/2009 01:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mario Moreno
-- Create date: 10/02/2009
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetFileFontCount] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    DECLARE @host_musicTrackCount INT
    SELECT @host_musicTrackCount = count(MusicTrackId) FROM Host_MusicTrack
    
    SELECT count(MusicTrackId) AS FileCount, @host_musicTrackCount AS FileFontCount FROM MusicTrack
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllHosts]    Script Date: 02/10/2009 01:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mario Moreno
-- Create date: 10/01/2009
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetAllHosts] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [HostId]
			,[HostName]
	FROM [Host]
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetHostIdFromName]    Script Date: 02/10/2009 01:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mario Moreno
-- Create date: 01/10/2008
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[GetHostIdFromName] 
(
	@hostName VARCHAR(250)
)
RETURNS uniqueidentifier
AS
BEGIN
	-- Declare the return variable here
    DECLARE @hostId uniqueidentifier
    SELECT @hostId = HostId FROM Host WHERE HostName = @hostName
	RETURN @hostId
END
GO
/****** Object:  StoredProcedure [dbo].[CreateHost]    Script Date: 02/10/2009 01:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mario Moreno
-- Create date: 09/01/2009
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[CreateHost] 
@hostName VARCHAR(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    DECLARE @hostId uniqueidentifier
    SELECT @hostId = HostId FROM Host WHERE HostName = @hostName
    
    IF(@hostId IS NULL)
		BEGIN
			INSERT INTO [Host]
				   ([HostId]
				   ,[HostName])
			 VALUES
				   (Newid()
				   ,@hostName
				   )
		END
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateFailedEntries]    Script Date: 02/10/2009 01:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mario Moreno
-- Create date: 10/01/2009
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[UpdateFailedEntries]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    UPDATE Host_MusicTrack
    SET FailedUpdateNumber = FailedUpdateNumber + 1
    WHERE Datediff("dd", LastUpdated, GetDate()) <> 0
	
END
GO
/****** Object:  StoredProcedure [dbo].[CreateOrUpdateMusicTrack]    Script Date: 02/10/2009 01:09:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mario Moreno
-- Create date: 09/01/2008
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[CreateOrUpdateMusicTrack] 
	@hostName VARCHAR(250),
	@path VARCHAR(1000),
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
    DECLARE @hostId uniqueidentifier
	SET @hostId = dbo.GetHostIdFromName(@hostName)
    
    IF(@hostId IS NOT NULL)
		BEGIN
			DECLARE @musicTrackId uniqueidentifier
			SET @musicTrackId = dbo.GetMusicTrackId(@artist, @album, @title, @year, @genre)
			
			IF(@musicTrackId IS NULL)
				BEGIN
					SELECT @musicTrackId = NewId()
					INSERT INTO [MusicTrack]
						   ([MusicTrackId]
						   ,[Artist]
						   ,[Album]
						   ,[Title]
						   ,[Year]
						   ,[Genre])
					 VALUES
						   (@musicTrackId
						   ,@artist
						   ,@album
						   ,@title
						   ,@year
						   ,@genre)
				END

			DECLARE @hostMusicTrackExists uniqueidentifier
			SELECT @hostMusicTrackExists = MusicTrackId FROM Host_MusicTrack WHERE HostId = @hostId AND MusicTrackId = @musicTrackId

			IF(@hostMusicTrackExists IS NULL)
				BEGIN
					INSERT INTO [Host_MusicTrack]
						   ([HostId]
						   ,[MusicTrackId]
						   ,[LastUpdated]
						   ,[FailedUpdateNumber]
						   ,[Path])
					 VALUES
						   (@hostId
						   ,@MusicTrackId
						   ,GetDate()
						   ,0
						   ,@path)
				END
			ELSE
				BEGIN
					UPDATE [Host_MusicTrack]
					   SET [LastUpdated] = GetDate()
						  ,[FailedUpdateNumber] = 0
						  ,[Path] = @path
					 WHERE HostId = @HostId AND MusicTrackId = @MusicTrackId
				END
	END
END
GO
/****** Object:  ForeignKey [FK_Host_MusicTrack_Host]    Script Date: 02/10/2009 01:09:31 ******/
ALTER TABLE [dbo].[Host_MusicTrack]  WITH CHECK ADD  CONSTRAINT [FK_Host_MusicTrack_Host] FOREIGN KEY([HostId])
REFERENCES [dbo].[Host] ([HostId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Host_MusicTrack] CHECK CONSTRAINT [FK_Host_MusicTrack_Host]
GO
/****** Object:  ForeignKey [FK_Host_MusicTrack_MusicTrack]    Script Date: 02/10/2009 01:09:31 ******/
ALTER TABLE [dbo].[Host_MusicTrack]  WITH CHECK ADD  CONSTRAINT [FK_Host_MusicTrack_MusicTrack] FOREIGN KEY([MusicTrackId])
REFERENCES [dbo].[MusicTrack] ([MusicTrackId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Host_MusicTrack] CHECK CONSTRAINT [FK_Host_MusicTrack_MusicTrack]
GO
