USE AntiAge;
GO

IF OBJECT_ID('Recipes', 'U') IS NOT NULL
	DROP TABLE Recipes
GO

CREATE TABLE Recipes(
	recipe_id INT PRIMARY KEY IDENTITY(1,1),
	title VARCHAR(50) NOT NULL,
	description TEXT,
	preparation_time DECIMAL(5,2),
	cooking_time DECIMAL(5,2),
	servings DECIMAL(5,2),
	calories_per_serving DECIMAL(5,2),
	protein_grams DECIMAL(5,2),
	carbs_grams DECIMAL(5,2),
	fat_grams DECIMAL(5,2),
	recipe_category VARCHAR(50) NOT NULL,
	instructions TEXT,
	image_url VARCHAR(2048)
);

BULK INSERT Recipes
FROM 'C:\Users\symig\Desktop\AntiAge\AntiAgeData\recipes.csv'
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

SELECT * FROM Recipes