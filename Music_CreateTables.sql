/*
Object: Drop & Create Tables
Author: Amy Neeland
Script Date: 11/8/2022
Description: This script drops and creates tables based on logical database model
*/

--Drop tables in reverse order to remove foreign key references first
DROP TABLE IF EXISTS PlaylistSongs;
DROP TABLE IF EXISTS Playlists;
DROP TABLE IF EXISTS UserRatings;
DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS ProviderSongs;
DROP TABLE IF EXISTS Providers;
DROP TABLE IF EXISTS Songs;
DROP TABLE IF EXISTS Albums;
DROP TABLE IF EXISTS Genre;
DROP TABLE IF EXISTS Musicians;

--Creates the Musicians table
CREATE TABLE Musicians
(
    MusicianID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    MusicianName NVARCHAR(55) NOT NULL
);
GO

--Creates the Genres table
CREATE TABLE Genre
(
    GenreID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    GenreName NVARCHAR(55) NOT NULL
);
GO

--Creates Albums table, includes a Unique constraint AlbumName & Musician
CREATE TABLE Albums 
(
    AlbumID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    AlbumName NVARCHAR(140),
    MusicianID BIGINT NOT NULL FOREIGN KEY REFERENCES Musicians(MusicianID),
    ReleaseYear INT NOT NULL,
    GenreID INT NOT NULL FOREIGN KEY REFERENCES Genre(GenreID)

    UNIQUE (AlbumName, MusicianID)
);
GO 

/*Creates Songs table, includes two unique constraints
	Unique Constraint 1 = Album & TrackNumber
	Unique Constraint 2 = Album, Track Number, & SongName
*/
CREATE TABLE Songs
(
    SongID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    SongName NVARCHAR(255) NOT NULL,
    AlbumID BIGINT NOT NULL FOREIGN KEY REFERENCES Albums(AlbumID),
    TrackNumber INT

    CONSTRAINT [UK_Songs_Album_Track] UNIQUE
    ( 
        AlbumID, 
        TrackNumber
    ),
    CONSTRAINT [UK_Songs_Album_Song_Track] UNIQUE  --Found an instance where one album in which two different tracks have the same name
    (
        AlbumID,
        SongName,
        TrackNumber
    )
);
GO

--Creates the Providers Table, includes unique constraint ProviderName & URL
CREATE TABLE Providers
(
    ProviderID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    ProviderName NVARCHAR(140) NOT NULL,
    ProviderURL NVARCHAR(600)       

    UNIQUE(ProviderName, ProviderURL)
);
GO

--Creates the Providers Songs table, includes the unique constraint Provider & Song
CREATE TABLE ProviderSongs
(
    ProviderSongID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    SongID BIGINT NOT NULL FOREIGN KEY REFERENCES Songs(SongID),
    ProviderID BIGINT NOT NULL FOREIGN KEY REFERENCES Providers(ProviderID),
    SongURL NVARCHAR(600)

    UNIQUE (ProviderID, SongID)
);
GO

--Creates the Users table, includes unique constraint Username & Email
CREATE TABLE Users
(
    UserID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(140) NOT NULL,
    UserEmail NVARCHAR (255) NOT NULL UNIQUE,
    IsActive BIT

    UNIQUE (Username, UserEmail)
);
GO

--Creates the UserRatings table, with unique constraint user & song
CREATE TABLE UserRatings
(
   UserRatingID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
   UserID BIGINT FOREIGN KEY REFERENCES Users(UserID), 
   SongID BIGINT FOREIGN KEY REFERENCES Songs(SongID),
   Rating TINYINT CHECK(Rating BETWEEN 1 AND 5)

   UNIQUE (UserID, SongID)
);
GO

--Creates the Playlists table, includes the unique constraint user & playlist name
CREATE TABLE Playlists
(
    PlaylistID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    PlaylistName NVARCHAR(140) NOT NULL,
    UserID BIGINT NOT NULL FOREIGN KEY REFERENCES Users(UserID)

    UNIQUE (UserID, PlaylistName)
);
GO

--Creates the PlaylistSongs table, includes the unique constraint playlist & song
CREATE TABLE PlaylistSongs
(
    PlaylistSongID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    PlaylistID BIGINT NOT NULL FOREIGN KEY REFERENCES Playlists(PlaylistID),
    SongID BIGINT NOT NULL FOREIGN KEY REFERENCES Songs(SongID)

    UNIQUE(PlaylistID, SongID)
);
GO