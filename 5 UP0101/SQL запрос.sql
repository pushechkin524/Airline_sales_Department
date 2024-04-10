CREATE DATABASE Airline_sales_Department;
GO

USE Airline_sales_Department;
GO

CREATE TABLE Towns(
	TownID  INT PRIMARY KEY IDENTITY(1,1),
	Town_name VARCHAR(20) NOT NULL,
);
GO

CREATE TABLE Airports(
	AirportID INT PRIMARY KEY IDENTITY(1,1),
	Name_ VARCHAR(20) NOT NULL,
	TownID INT,
	FOREIGN KEY (TownID) REFERENCES	Towns(TownID)  ON DELETE CASCADE,
);
GO


CREATE TABLE Companies_carrier(
	Company_carrierID  INT PRIMARY KEY IDENTITY(1,1),
	Name_company VARCHAR (20) NOT NULL,
	Phone_company VARCHAR (11) NOT NULL,
	Email_company VARCHAR (39) NOT NULL,
);
GO

CREATE TABLE Flights(
	FlightID INT PRIMARY KEY IDENTITY(1,1),
	FromAirportID INT,
	ToAirportID INT,
	CompanyID INT,
	Departure_timå VARCHAR(16) NOT NULL,
	Arrival_timå VARCHAR(16) NOT NULL,
	Airplane_number INT NOT NULL,
	FOREIGN KEY (FromAirportID) REFERENCES Airports(AirportID),
	FOREIGN KEY (ToAirportID) REFERENCES Airports(AirportID),
	FOREIGN KEY (CompanyID) REFERENCES Companies_carrier(Company_carrierID) ON DELETE CASCADE,	
);
GO

CREATE TABLE CLASSS(
	CLASSSID  INT PRIMARY KEY IDENTITY(1,1),
	Name_class VARCHAR (9) NOT NULL,
	Fixed_allowance_class INT NOT NULL,
);
GO

CREATE TABLE Baggage_type(
	Baggage_typeID  INT PRIMARY KEY IDENTITY(1,1),
	Type_baggage VARCHAR (15) NOT NULL,
	Fixed_allowance_baggage INT NOT NULL,
);
GO

CREATE TABLE Waiting_hall(
	Waiting_hallID INT PRIMARY KEY IDENTITY(1,1),
	Name_waiting VARCHAR (17) NOT NULL,
	Fixed_allowance_waiting INT NOT NULL,	
	Nubmer_waiting INT NOT NULL,
);
GO

CREATE TABLE Clients(
	ClientsID INT PRIMARY KEY IDENTITY(1,1),
	Passport_number VARCHAR (10) NOT NULL,
	Surname VARCHAR (20) NOT NULL,
	Name_ VARCHAR (20) NOT NULL,
	Patronymic VARCHAR (25) NOT NULL,
	Date_of_birth VARCHAR(10) NOT NULL,
	Email VARCHAR(40) NOT NULL,
);
GO

CREATE TABLE Tickets(
	TicketID  INT PRIMARY KEY IDENTITY(1,1),
	FlightID INT,
	CLASSSID INT,
	Baggage_typeID INT,
	Waiting_hallID iNT,
	ClientID INT,
	Price DECIMAL NOT NULL,
	Animails VARCHAR (3) NOT NULL,
	Eat VARCHAR (3) NOT NULL,
	FOREIGN KEY (FlightID) REFERENCES Flights(FlightID)  ON DELETE CASCADE,
	FOREIGN KEY (CLASSSID) REFERENCES	CLASSS(CLASSSID)  ON DELETE CASCADE,
	FOREIGN KEY (Baggage_typeID) REFERENCES Baggage_type(Baggage_typeID) ON DELETE CASCADE,
	FOREIGN KEY (Waiting_hallID) REFERENCES Waiting_hall(Waiting_hallID) ON DELETE CASCADE,
	FOREIGN KEY (ClientID) REFERENCES Clients(ClientsID) ON DELETE CASCADE,
);
GO

CREATE TABLE User_Roles(
	User_RoleID  INT PRIMARY KEY IDENTITY(1,1),
	Name_role VARCHAR(30) NOT NULL, 
);
GO

--CREATE TABLE Checks(
--	Checks  INT PRIMARY KEY IDENTITY(1,1),
--	Name_role VARCHAR(30) NOT NULL, 
--);
--GO

CREATE TABLE Users(
	UserID  INT PRIMARY KEY IDENTITY(1,1),
	User_RoleID INT,
	Login__ VARCHAR(50) NOT NULL,
	Password__ VARCHAR(30) NOT NULL, 
	FOREIGN KEY (User_RoleID) REFERENCES User_Roles(User_RoleID) ON DELETE CASCADE,
);
GO

CREATE TABLE Employees(
	EmployeåID  INT PRIMARY KEY IDENTITY(1,1),
	UserID INT,
	Surname VARCHAR (20) NOT NULL,
	Name_ VARCHAR (20) NOT NULL,
	Patronymic VARCHAR (25) NOT NULL,
	Passport_number VARCHAR (10) NOT NULL,
	DateOfBirth varchar(10) NOT NULL,
	FOREIGN KEY (UserID) REFERENCES	Users(UserID) ON DELETE CASCADE,
);
GO

CREATE TABLE Orders(
	OrderID  INT PRIMARY KEY IDENTITY(1,1),
	EmployeeID INT,
	ClientID INT,
	TicketID INT,
	FOREIGN KEY (EmployeeID) REFERENCES	Employees(EmployeåID) ON DELETE CASCADE,
	FOREIGN KEY (ClientID) REFERENCES Clients(ClientsID) ON DELETE CASCADE,
	FOREIGN KEY (TicketID) REFERENCES Tickets(TicketID),
);
GO

insert into Users (User_roleID, Login__, Password__)
values
(13,'admin','xyzzy'),
(14,'compiler','xyzzy'),
(15,'manager','xyzzy');
go



insert into User_Roles(Name_role)
values
('Administrator'),
('Compiler'),
('Manager');
go
