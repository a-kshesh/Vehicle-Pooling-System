CREATE DATABASE VehiclePooling;
GO

USE VehiclePooling;
GO

CREATE TABLE Users(
	UserId varchar(30) PRIMARY KEY NOT NULL,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	Email varchar(50) NOT NULL,
	Phone varchar(50) NULL,
	Address varchar(360) NULL,
	Type varchar(15) NOT NULL,
	Password varchar(20) NOT NUll);

CREATE TABLE Vehicles(
	VehicleId varchar(30) PRIMARY KEY NOT NULL,
	UserId varchar(30) NOT NULL,
	Type varchar(30) NOT NULL,
	OwnerName varchar(50) NOT NULL,
	LicenseNumber varchar(30) NOT NULL,
	Company varchar(30) NOT NULL,
	Model varchar(20) NOT NULL,
	ManufacturingYear varchar(10) NOT NULL,
	InsuranceNumber varchar(20) NOT NULL,
	VehicleTransmission varchar(15) NOT NULL,
	OwnershipDocFileName varchar(max) NUll,
	InsuranceDocFileName varchar(max) Null,
	Image1Name varchar(max) NULL,
	Image2Name varchar(max) NULL,
	Image3Name varchar(max) NULL,
	PickupAddress varchar(360) NULL,
	CostPerDay float NULL,
	Available bit NULL,
	PickupCity varchar(30) NULL,
	PickupState varchar(30) NULL,
	PickupZipCode varchar(30) NULL,
	VehicleDoors int NOT NULL,
	VehicleSeats int NOT NULL,
	CreatedOn date DEFAULT GETDATE(),
	VehicleIgnition varchar(30) NULL,
	DistanceIncluded int NOT NULL,
	AdditionalDistanceFee float NOT NULL,
	CONSTRAINT FK_UserId_Users FOREIGN KEY (UserId) REFERENCES Users(UserId)); 


CREATE TABLE Booking(
	BookingId varchar(30) PRIMARY KEY NOT NULL,
	VehicleId varchar(30) NOT NULL,
	UserId varchar(30) NOT NULL,
	TripStart Datetime NOT NULL,
	TripEnd Datetime NOT NULL,
	PickupAddress varchar(360) NOT NULL,
	CostPerDay float NOT NULL,
	Status varchar(20) NOT NULL,
	AdditionalDistanceFee float NULL,
	DistanceIncluded int NULL,
	AdditionalDistance float NOT NULL,
	TotalCharges float NOT NULL,
	CreatedOn Datetime NOT NULL,
	CONSTRAINT FK_UserIdForBooking_Users FOREIGN KEY (UserId) REFERENCES Users(UserId),
	CONSTRAINT FK_VehicleIdForBooking_Users FOREIGN KEY (VehicleId) REFERENCES Vehicles(VehicleId));