USE AntiAge;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.WorkoutExercises)
BEGIN
    BULK INSERT dbo.WorkoutExercises
    FROM 'C:\Users\symig\Desktop\AntiAge\AntiAgeData\workout-exercises.csv'
    WITH
    (
        FORMAT = 'CSV', 
        FIELDQUOTE = '"',
        FIRSTROW = 2,
        FIELDTERMINATOR = ',',  --CSV field delimiter
        ROWTERMINATOR = '0x0a',   --Use to shift the control to next row
        TABLOCK
    );
	
SELECT * FROM dbo.WorkoutExercises;
END
ELSE
BEGIN
    PRINT 'Data already exists in the table.'
END
GO
