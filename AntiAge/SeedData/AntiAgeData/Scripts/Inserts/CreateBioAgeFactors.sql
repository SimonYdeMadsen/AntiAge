USE AntiAge;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.BioAgeFactors)
BEGIN
    BULK INSERT dbo.BioAgeFactors
    FROM 'C:\Users\symig\Desktop\AntiAge\AntiAgeData\bio-age-factors.csv'
    WITH
    (
        FORMAT = 'CSV', 
        FIELDQUOTE = '"',
        FIRSTROW = 2,
        FIELDTERMINATOR = ',',  --CSV field delimiter
        ROWTERMINATOR = '0x0a',   --Use to shift the control to next row
        TABLOCK
    );
	SELECT * FROM dbo.BioAgeFactors;
END
ELSE
BEGIN
    PRINT 'Data already exists in the table.'
END
GO

