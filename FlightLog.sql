-- Create Database
CREATE DATABASE AviationLogbook;
GO

USE AviationLogbook;

-- Aircraft Table
CREATE TABLE Aircraft (
    AircraftId INT PRIMARY KEY IDENTITY(1,1),
    TailNumber NVARCHAR(20) NOT NULL, -- Örn: TC-JRY
    Model NVARCHAR(50),               -- Örn: Cessna 172
    Type NVARCHAR(20)                 -- Örn: Single Engine Prop
);

-- Flight Logs Table
CREATE TABLE FlightLogs (
    LogId INT PRIMARY KEY IDENTITY(1,1),
    FlightDate DATETIME NOT NULL,
    OriginICAO NVARCHAR(4) NOT NULL,      -- Örn: LTBA (İstanbul)
    DestinationICAO NVARCHAR(4) NOT NULL, -- Örn: LTAI (Antalya)
    DurationMinutes INT NOT NULL,
    DayHours FLOAT,
    NightHours FLOAT,
    Takeoffs INT DEFAULT 1,
    Landings INT DEFAULT 1,
    AircraftId INT FOREIGN KEY REFERENCES Aircraft(AircraftId),
    Notes NVARCHAR(MAX)
);