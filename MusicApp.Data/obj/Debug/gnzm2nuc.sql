﻿IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Albums] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    CONSTRAINT [PK_Albums] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Artists] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Artists] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Songs] (
    [Id] int NOT NULL IDENTITY,
    [Length] int NOT NULL,
    [Title] nvarchar(max) NULL,
    CONSTRAINT [PK_Songs] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AlbumSong] (
    [AlbumSongId] int NOT NULL IDENTITY,
    [AlbumId] int NOT NULL,
    [SongId] int NOT NULL,
    CONSTRAINT [PK_AlbumSong] PRIMARY KEY ([AlbumSongId]),
    CONSTRAINT [FK_AlbumSong_Albums_AlbumId] FOREIGN KEY ([AlbumId]) REFERENCES [Albums] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AlbumSong_Songs_SongId] FOREIGN KEY ([SongId]) REFERENCES [Songs] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ArtistSong] (
    [ArtistSongId] int NOT NULL IDENTITY,
    [ArtistId] int NOT NULL,
    [SongId] int NOT NULL,
    CONSTRAINT [PK_ArtistSong] PRIMARY KEY ([ArtistSongId]),
    CONSTRAINT [FK_ArtistSong_Artists_ArtistId] FOREIGN KEY ([ArtistId]) REFERENCES [Artists] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ArtistSong_Songs_SongId] FOREIGN KEY ([SongId]) REFERENCES [Songs] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_AlbumSong_AlbumId] ON [AlbumSong] ([AlbumId]);

GO

CREATE INDEX [IX_AlbumSong_SongId] ON [AlbumSong] ([SongId]);

GO

CREATE INDEX [IX_ArtistSong_ArtistId] ON [ArtistSong] ([ArtistId]);

GO

CREATE INDEX [IX_ArtistSong_SongId] ON [ArtistSong] ([SongId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180411184701_Initial', N'2.0.2-rtm-10011');

GO

ALTER TABLE [Albums] ADD [ArtistId] int NULL;

GO

CREATE INDEX [IX_Albums_ArtistId] ON [Albums] ([ArtistId]);

GO

ALTER TABLE [Albums] ADD CONSTRAINT [FK_Albums_Artists_ArtistId] FOREIGN KEY ([ArtistId]) REFERENCES [Artists] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180411185735_ArtistUpdate', N'2.0.2-rtm-10011');

GO

ALTER TABLE [ArtistSong] DROP CONSTRAINT [PK_ArtistSong];

GO

DROP INDEX [IX_ArtistSong_ArtistId] ON [ArtistSong];

GO

ALTER TABLE [AlbumSong] DROP CONSTRAINT [PK_AlbumSong];

GO

DROP INDEX [IX_AlbumSong_AlbumId] ON [AlbumSong];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'ArtistSong') AND [c].[name] = N'ArtistSongId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ArtistSong] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [ArtistSong] DROP COLUMN [ArtistSongId];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'AlbumSong') AND [c].[name] = N'AlbumSongId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [AlbumSong] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [AlbumSong] DROP COLUMN [AlbumSongId];

GO

ALTER TABLE [ArtistSong] ADD CONSTRAINT [PK_ArtistSong] PRIMARY KEY ([ArtistId], [SongId]);

GO

ALTER TABLE [AlbumSong] ADD CONSTRAINT [PK_AlbumSong] PRIMARY KEY ([AlbumId], [SongId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180412161554_ManyToManyPkKeys', N'2.0.2-rtm-10011');

GO

