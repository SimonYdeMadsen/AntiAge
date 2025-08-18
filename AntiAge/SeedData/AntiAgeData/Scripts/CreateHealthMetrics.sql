USE AntiAge;
GO

IF OBJECT_ID('Health_metrics', 'U') IS NOT NULL
DROP TABLE Health_metrics
GO

CREATE TABLE Health_metrics(
	metric_id INT PRIMARY KEY IDENTITY(1,1),
	user_id INT, 
	date_recorded DATE,
	weight_kg DECIMAL(5,2) CHECK (weight_kg >= 0),
	body_fat_percentage DECIMAL(5,2),
	bmi DECIMAL(5,2) CHECK (bmi >= 0),
	blood_pressure_systolic DECIMAL(5,2),
	blood_pressure_diastolic DECIMAL(5,2),
	resting_heart_rate DECIMAL(5,2),
	blood_glucose DECIMAL(5,2),
	hdl_cholesterol DECIMAL(5,2),
	ldl_cholesterol DECIMAL(5,2),
	triglycerides DECIMAL(5,2),
	vo2_max DECIMAL(5,2),
	sleep_hours DECIMAL(5,2) CHECK (sleep_hours >= 0),
	steps_count INTEGER CHECK (steps_count >= 0),
	biological_age DECIMAL(5,2) CHECK (biological_age >= 0)
);

BULK INSERT Health_metrics
FROM 'C:\Users\symig\Desktop\AntiAge\AntiAgeData\health-metrics.csv'
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

SELECT * FROM Health_metrics