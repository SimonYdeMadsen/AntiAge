USE AntiAge;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Exercises)
BEGIN
    BULK INSERT dbo.Exercises
    FROM 'C:\Users\symig\Desktop\AntiAge\AntiAgeData\exercises.csv'
    WITH
    (
        FORMAT = 'CSV', 
        FIELDQUOTE = '"',
        FIRSTROW = 2,
        FIELDTERMINATOR = ',',  --CSV field delimiter
        ROWTERMINATOR = '0x0a',   --Use to shift the control to next row
        TABLOCK
    );
END
ELSE
BEGIN
    PRINT 'Data already exists in the table.'
END
GO

SELECT * FROM dbo.Exercises;