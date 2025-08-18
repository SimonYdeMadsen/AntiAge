USE AntiAge;
GO

IF OBJECT_ID('Workouts_programs', 'U') IS NOT NULL
	DROP TABLE Workouts_programs
GO

CREATE TABLE Workouts_programs(
	program_id INT PRIMARY KEY IDENTITY(1,1),
	program_name VARCHAR(50),
	description TEXT,
	difficulty_level VARCHAR(20),
	duration_weeks INTEGER CHECK (duration_weeks >= 1),
	focus_area VARCHAR(20),
	created_by INTEGER
);

BULK INSERT Workouts_programs
FROM 'C:\Users\symig\Desktop\AntiAge\AntiAgeData\workout-programs.csv'
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

SELECT * FROM Workouts_programs