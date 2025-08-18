USE AntiAge;
GO

IF OBJECT_ID('Users', 'U') IS NOT NULL
DROP TABLE Users
GO

CREATE TABLE Users(
    user_id INT PRIMARY KEY IDENTITY(1,1),
	username VARCHAR(40) NOT NULL,
	email VARCHAR(254),
	password_hash VARCHAR(255),
	first_name VARCHAR(50),
	last_name VARCHAR(50),
	date_of_birth DATE,
	gender VARCHAR(10),
	height_cm SMALLINT,
	created_at DATETIME2(0),
	last_login DATETIME2(0)
);

BULK INSERT Users
FROM 'C:\Users\symig\Desktop\AntiAge\AntiAgeData\users.csv'
WITH
(
    FORMAT = 'CSV', 
    FIELDQUOTE = '"',
    FIRSTROW = 2,
    FIELDTERMINATOR = ',',  --CSV field delimiter
    ROWTERMINATOR = '0x0a',   --Use to shift the control to next row
    TABLOCK
)
GO

SELECT * FROM Users