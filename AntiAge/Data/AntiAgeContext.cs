using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApplication1.Data.Entities;

namespace WebApplication1.Data;

public partial class AntiAgeContext
{
    

    public virtual DbSet<BioAgeFactor> BioAgeFactors { get; set; }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<HealthGoal> HealthGoals { get; set; }

    public virtual DbSet<HealthMetric> HealthMetrics { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    public virtual DbSet<Workout> Workouts { get; set; }

    public virtual DbSet<WorkoutExercise> WorkoutExercises { get; set; }

    public virtual DbSet<WorkoutsLog> WorkoutsLogs { get; set; }

    public virtual DbSet<WorkoutsProgram> WorkoutsPrograms { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-59J1PM4\\SQLEXPRESS;Initial Catalog=AntiAge;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("identity");

        modelBuilder.Entity<User>(entity =>
        {
            // Specify the primary key column name
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id).HasColumnName("user_id"); // Map Id to user_id

            // Set the table name
            entity.ToTable("Users");
        });


        modelBuilder.Entity<BioAgeFactor>(entity =>
        {
            entity.HasKey(e => e.FactorId).HasName("PK__Bio_age___21172E73552A6FD2");

            entity.ToTable("Bio_age_factors");

            entity.Property(e => e.FactorId).HasColumnName("factor_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.FactorName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("factor_name");
            entity.Property(e => e.OptimalRangeMax)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("optimal_range_max");
            entity.Property(e => e.OptimalRangeMin)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("optimal_range_min");
            entity.Property(e => e.UnitOfMeasure)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("unit_of_measure");
            entity.Property(e => e.WeightCoefficient)
                .HasColumnType("decimal(6, 3)")
                .HasColumnName("weight_coefficient");
        });

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.ExerciseId).HasName("PK__Exercise__C121418E8D0E14E0");

            entity.Property(e => e.ExerciseId).HasColumnName("exercise_id");
            entity.Property(e => e.DemoVideoUrl)
                .HasMaxLength(2048)
                .IsUnicode(false)
                .HasColumnName("demo_video_url");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DifficultyLevel)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("difficulty_level");
            entity.Property(e => e.EquipmentNeeded)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("equipment_needed");
            entity.Property(e => e.ExerciseName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("exercise_name");
            entity.Property(e => e.MuscleGroup)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("muscle_group");
        });

        modelBuilder.Entity<HealthGoal>(entity =>
        {
            entity.HasKey(e => e.GoalId).HasName("PK__Health_g__76679A2438B8684E");

            entity.ToTable("Health_goals");

            entity.Property(e => e.GoalId).HasColumnName("goal_id");
            entity.Property(e => e.GoalType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("goal_type");
            entity.Property(e => e.Notes)
                .HasColumnType("text")
                .HasColumnName("notes");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TargetDate).HasColumnName("target_date");
            entity.Property(e => e.TargetValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("target_value");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<HealthMetric>(entity =>
        {
            entity.HasKey(e => e.MetricId).HasName("PK__Health_m__13D5DCA401952E8C");

            entity.ToTable("Health_metrics");

            entity.Property(e => e.MetricId).HasColumnName("metric_id");
            entity.Property(e => e.BiologicalAge)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("biological_age");
            entity.Property(e => e.BloodGlucose)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("blood_glucose");
            entity.Property(e => e.BloodPressureDiastolic)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("blood_pressure_diastolic");
            entity.Property(e => e.BloodPressureSystolic)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("blood_pressure_systolic");
            entity.Property(e => e.Bmi)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("bmi");
            entity.Property(e => e.BodyFatPercentage)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("body_fat_percentage");
            entity.Property(e => e.DateRecorded).HasColumnName("date_recorded");
            entity.Property(e => e.HdlCholesterol)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("hdl_cholesterol");
            entity.Property(e => e.LdlCholesterol)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("ldl_cholesterol");
            entity.Property(e => e.RestingHeartRate)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("resting_heart_rate");
            entity.Property(e => e.SleepHours)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("sleep_hours");
            entity.Property(e => e.StepsCount).HasColumnName("steps_count");
            entity.Property(e => e.Triglycerides)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("triglycerides");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Vo2Max)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("vo2_max");
            entity.Property(e => e.WeightKg)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("weight_kg");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.RecipeId).HasName("PK__Recipes__3571ED9BEF8B1603");

            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.CaloriesPerServing)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("calories_per_serving");
            entity.Property(e => e.CarbsGrams)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("carbs_grams");
            entity.Property(e => e.CookingTime)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("cooking_time");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.FatGrams)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("fat_grams");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(2048)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.Instructions)
                .HasColumnType("text")
                .HasColumnName("instructions");
            entity.Property(e => e.PreparationTime)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("preparation_time");
            entity.Property(e => e.ProteinGrams)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("protein_grams");
            entity.Property(e => e.RecipeCategory)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("recipe_category");
            entity.Property(e => e.Servings)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("servings");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity.HasKey(e => e.RecipeId).HasName("PK__Recipe_I__3571ED9BB9A5E195");

            entity.ToTable("Recipe_Ingredients");

            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.IngredientName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ingredient_name");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("quantity");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("unit");
        });

        modelBuilder.Entity<Workout>(entity =>
        {
            entity.HasKey(e => e.WorkoutId).HasName("PK__Workouts__02AB2F8EDA7925F0");

            entity.Property(e => e.WorkoutId).HasColumnName("workout_id");
            entity.Property(e => e.DayNumber).HasColumnName("day_number");
            entity.Property(e => e.EstimatedDuration).HasColumnName("estimated_duration");
            entity.Property(e => e.Instructions)
                .HasColumnType("text")
                .HasColumnName("instructions");
            entity.Property(e => e.ProgramId).HasColumnName("program_id");
            entity.Property(e => e.WeekNumber).HasColumnName("week_number");
            entity.Property(e => e.WorkoutName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("workout_name");
        });

        modelBuilder.Entity<WorkoutExercise>(entity =>
        {
            entity.HasKey(e => e.WorkoutId).HasName("PK__Workout___02AB2F8EDEA9C95B");

            entity.ToTable("Workout_exercises");

            entity.Property(e => e.WorkoutId).HasColumnName("workout_id");
            entity.Property(e => e.ExerciseId).HasColumnName("exercise_id");
            entity.Property(e => e.Notes)
                .HasColumnType("text")
                .HasColumnName("notes");
            entity.Property(e => e.Repeats).HasColumnName("repeats");
            entity.Property(e => e.RepeatsUnits)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("repeats_units");
            entity.Property(e => e.RestPeriod)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("rest_period");
            entity.Property(e => e.SequenceNumber).HasColumnName("sequence_number");
            entity.Property(e => e.Sets)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sets");
        });

        modelBuilder.Entity<WorkoutsLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Workouts__9E2397E094655130");

            entity.ToTable("Workouts_logs");

            entity.Property(e => e.LogId).HasColumnName("log_id");
            entity.Property(e => e.DateCompleted).HasColumnName("date_completed");
            entity.Property(e => e.DurationMinutes).HasColumnName("duration_minutes");
            entity.Property(e => e.Notes)
                .HasColumnType("text")
                .HasColumnName("notes");
            entity.Property(e => e.PerceivedEffort).HasColumnName("perceived_effort");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WorkoutId).HasColumnName("workout_id");
        });

        modelBuilder.Entity<WorkoutsProgram>(entity =>
        {
            entity.HasKey(e => e.ProgramId).HasName("PK__Workouts__3A7890AC2210279F");

            entity.ToTable("Workouts_programs");

            entity.Property(e => e.ProgramId).HasColumnName("program_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DifficultyLevel)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("difficulty_level");
            entity.Property(e => e.DurationWeeks).HasColumnName("duration_weeks");
            entity.Property(e => e.FocusArea)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("focus_area");
            entity.Property(e => e.ProgramName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("program_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
