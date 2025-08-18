USE AntiAge;
GO

IF OBJECT_ID('Exercises', 'U') IS NOT NULL
DROP TABLE Exercises
GO

CREATE TABLE Exercises(
	exercise_id INT PRIMARY KEY IDENTITY(1,1),
	exercise_name VARCHAR(20) NOT NULL,
	description TEXT NOT NULL,
	muscle_group VARCHAR(20) NOT NULL,
	equipment_needed VARCHAR(40) NOT NULL,
	difficulty_level VARCHAR(20) NOT NULL,
	demo_video_url VARCHAR(2048) NOT NULL,
);

BULK INSERT Exercises
FROM 'C:\Users\symig\Desktop\AntiAge\AntiAgeData\exercises.csv'
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

SELECT * FROM Exercises