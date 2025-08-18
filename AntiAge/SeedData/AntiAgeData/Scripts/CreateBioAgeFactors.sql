USE AntiAge;
GO

IF OBJECT_ID('[dbo].[Bio_age_factors]', 'U') IS NOT NULL
DROP TABLE [dbo].[Bio_age_factors]
GO

CREATE TABLE [dbo].[Bio_age_factors](
    factor_id INT PRIMARY KEY IDENTITY(1,1),
    factor_name VARCHAR(40) NOT NULL,
    description TEXT NOT NULL,
	weight_coefficient DECIMAL(6,3), 
	unit_of_measure VARCHAR(20) NOT NULL,
	optimal_range_min DECIMAL(10,2),
	optimal_range_max DECIMAL(10,2)
);

BULK INSERT dbo.Bio_age_factors
FROM 'C:\Users\symig\Desktop\AntiAge\AntiAgeData\bio-age-factors.csv'
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

SELECT * FROM dbo.Bio_age_factors