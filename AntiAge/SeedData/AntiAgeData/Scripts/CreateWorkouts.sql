USE AntiAge;
GO

IF OBJECT_ID('Workouts', 'U') IS NOT NULL
	DROP TABLE Workouts
GO

CREATE TABLE Workouts(
	
	workout_id INT PRIMARY KEY IDENTITY(1,1),
	program_id INT,
	workout_name VARCHAR(20) NOT NULL,
	week_number INTEGER CHECK (week_number >= 1),
	day_number INTEGER CHECK (day_number >= 1),
	estimated_duration INTEGER CHECK (estimated_duration >= 0),
	instructions TEXT
);

BULK INSERT Workouts
FROM 'C:\Users\symig\Desktop\AntiAge\AntiAgeData\workouts.csv'
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

SELECT * FROM Workouts