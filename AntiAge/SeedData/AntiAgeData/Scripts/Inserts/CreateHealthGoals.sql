USE AntiAge;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.HealthGoals)
BEGIN
    BULK INSERT dbo.HealthGoals
    FROM 'C:\Users\symig\Desktop\AntiAge\AntiAgeData\health-goals.csv'
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

SELECT * FROM dbo.HealthGoals;