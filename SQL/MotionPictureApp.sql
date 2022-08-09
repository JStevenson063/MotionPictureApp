CREATE DATABASE MotionPictureApp;
 GO

USE MotionPictureApp;

CREATE TABLE dbo.motion_pictures (
id int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
name NVARCHAR(50),
description NVARCHAR(500) NULL,
releaseYear int NOT NULL
);

INSERT INTO dbo.motion_pictures values ('Godzilla', 'A movie about a massive dinosaur destroying japan', 1954)
INSERT INTO dbo.motion_pictures values ('Top Gun', 'The Top Gun Naval Fighter Weapons School is where the best of the best train to refine their elite flying skills. When hotshot fighter pilot Maverick (Tom Cruise) is sent to the school, his reckless attitude and cocky demeanor put him at odds with the other pilots.', 1986)
INSERT INTO dbo.motion_pictures values ('The Departed', 'South Boston cop Billy Costigan (Leonardo DiCaprio) goes under cover to infiltrate the organization of gangland chief Frank Costello (Jack Nicholson).', 2006)
