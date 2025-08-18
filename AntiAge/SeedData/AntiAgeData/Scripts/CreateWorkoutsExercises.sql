USE AntiAge;
GO

IF OBJECT_ID('Workout_exercises', 'U') IS NOT NULL
	DROP TABLE Workout_exercises
GO

CREATE TABLE Workout_exercises(
	
	workout_id INT PRIMARY KEY IDENTITY(1,1),
	exercise_id INT,
	sets VARCHAR(50) NOT NULL,
	repeats INTEGER,
	repeats_units VARCHAR(30),
	rest_period DECIMAL(5,2),
	notes TEXT,
	sequence_number INTEGER
);

BULK INSERT Workout_exercises
FROM 'C:\Users\symig\Desktop\AntiAge\AntiAgeData\workout-exercises.csv'
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

SELECT * FROM Workout_exercises