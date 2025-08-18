USE AntiAge;
GO

IF OBJECT_ID('Workouts_logs', 'U') IS NOT NULL
	DROP TABLE Workouts_logs
GO

CREATE TABLE Workouts_logs(
	log_id INT PRIMARY KEY IDENTITY(1,1),
	user_id INT,
	workout_id INT,
	date_completed DATE,
	duration_minutes INTEGER CHECK (duration_minutes >= 0),
	perceived_effort INTEGER CHECK (perceived_effort >= 0),
	notes TEXT
);

BULK INSERT Workouts_logs
FROM 'C:\Users\symig\Desktop\AntiAge\AntiAgeData\workout-logs.csv'
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

SELECT * FROM Workouts_logs