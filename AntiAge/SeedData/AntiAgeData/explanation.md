# Biological Age & Health Tracking CSV Files Guide

This guide provides an overview of the CSV files I've created for your health tracking database, with explanations of how they fit together.

## Core Tables

### 1. `users.csv`
Contains the basic information for each user in the system, including:
- Demographic data (name, date of birth, gender)
- Physical attributes (height)
- Account details (username, email)

### 2. `health_metrics.csv`
Stores all health measurements for users over time:
- Weekly health data for 3 sample users (3 months of history)
- Tracks weight, BMI, blood pressure, heart rate, etc.
- Includes biological age calculations

### 3. `health_goals.csv`
Contains personal health objectives users are working toward:
- Various goal types (weight, steps, blood pressure, etc.)
- Tracks status (active, completed, abandoned)
- Includes start/target dates and notes

### 4. `recipes.csv` and `recipe_ingredients.csv`
Stores nutritional information and ingredients for healthy meals:
- 10 sample recipes across different meal categories
- Nutritional breakdown (calories, protein, carbs, fat)
- Detailed ingredients with quantities and units

### 5. `workout_programs.csv`, `workouts.csv`, and `exercises.csv`
Structured workout data:
- Programs: Overall workout plans (e.g., "30-Day Fat Burn Challenge")
- Workouts: Individual sessions within programs
- Exercises: Specific movements with muscle groups and difficulty levels

### 6. `workout_exercises.csv`
Junction table connecting workouts and exercises:
- Details sets, reps/duration, and rest periods
- Includes notes and sequence ordering

### 7. `user_workout_logs.csv`
Tracks completed workouts by users:
- Records date, duration, and perceived effort
- Includes personal notes on performance

### 8. `user_favorite_recipes.csv`
Junction table showing which users have favorited which recipes.

### 9. `biological_age_factors.csv`
Reference table for the factors used in biological age calculation:
- Weight coefficients for each factor
- Optimal ranges for each measurement
- Units of measure and descriptions

## Relationships Between Tables

- `users.csv` contains the user profiles referenced by `user_id` in other tables.
- `health_metrics.csv` tracks health data for users over time.
- `health_goals.csv` stores personal objectives for users.
- `workout_programs.csv` → `workouts.csv` → `workout_exercises.csv` → `exercises.csv` forms a hierarchy of workout data.
- `user_workout_logs.csv` connects users to completed workouts.
- `recipes.csv` and `recipe_ingredients.csv` form the recipe catalog.
- `user_favorite_recipes.csv` connects users to their favorite recipes.

## Using This Data

1. **Loading into a Database**: These CSV files can be loaded directly into PostgreSQL, MySQL, or another database system.

2. **Data Analysis**: The structured format allows for analyzing trends in:
   - Health metrics over time
   - Biological vs. chronological age
   - Workout adherence and effectiveness
   - Recipe popularity and nutrition

3. **Application Development**: This dataset provides a solid foundation for building:
   - User dashboards showing health metrics
   - Goal tracking systems
   - Workout planning tools
   - Recipe recommendation features

4. **Biological Age Calculation**: The `biological_age_factors.csv` provides the reference data for implementing the biological age algorithm in your application.

## File Formats

All files are standard CSV format with:
- First row containing column headers
- Comma-separated values
- Text values not enclosed in quotes unless necessary
- Dates in ISO format (YYYY-MM-DD)
