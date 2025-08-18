USE AntiAge;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.WorkoutsPrograms)
BEGIN
    BULK INSERT dbo.WorkoutsPrograms
    FROM 'C:\Users\symig\Desktop\AntiAge\AntiAgeData\workout-programs.csv'
    WITH
    (
        FORMAT = 'CSV', 
        FIELDQUOTE = '"',
        FIRSTROW = 2,
        FIELDTERMINATOR = ',',  --CSV field delimiter
        ROWTERMINATOR = '0x0a',   --Use to shift the control to next row
        TABLOCK
    );
	
SELECT * FROM dbo.WorkoutsPrograms;
END
ELSE
BEGIN
    PRINT 'Data already exists in the table.'
END
GO
