USE AntiAge;
GO

IF OBJECT_ID('Recipe_Ingredients', 'U') IS NOT NULL
    DROP TABLE Recipe_Ingredients
GO

CREATE TABLE Recipe_Ingredients(
	recipe_id INT PRIMARY KEY IDENTITY(1,1),
	ingredient_name VARCHAR(50) NOT NULL,
	quantity DECIMAL(6,2) CHECK (quantity >= 0) NOT NULL,
	unit VARCHAR(50) NOT NULL
);

BULK INSERT Recipe_Ingredients
FROM 'C:\Users\symig\Desktop\AntiAge\AntiAgeData\recipe-ingredients.csv'
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

SELECT * FROM Recipe_Ingredients