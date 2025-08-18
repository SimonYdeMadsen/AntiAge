USE AntiAge;
GO

IF OBJECT_ID('Health_goals', 'U') IS NOT NULL
DROP TABLE Health_goals
GO

CREATE TABLE Health_goals(
	goal_id INT PRIMARY KEY IDENTITY(1,1),
	user_id INT, 
	goal_type VARCHAR(20),
	target_value DECIMAL(10,2),
	start_date DATE,
	target_date DATE,
	status VARCHAR(20),
	notes TEXT
);

BULK INSERT Health_goals
FROM 'C:\Users\symig\Desktop\AntiAge\AntiAgeData\health-goals.csv'
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

SELECT * FROM Health_goals