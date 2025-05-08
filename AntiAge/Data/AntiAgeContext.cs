using Microsoft.EntityFrameworkCore;
using AntiAge.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AntiAge.Data.Identity;

namespace AntiAge.Data
{
    public class AntiAgeContext(DbContextOptions<AntiAgeContext> options) : IdentityDbContext<User, IdentityRole<int>, int>(options)
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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BioAgeFactor>(entity =>
            {
                entity.HasKey(e => e.FactorId);
                entity.Property(e => e.Description).HasColumnType("text");
                entity.Property(e => e.FactorName).HasMaxLength(40);
                entity.Property(e => e.OptimalRangeMax).HasColumnType("decimal(10,2)");
                entity.Property(e => e.OptimalRangeMin).HasColumnType("decimal(10,2)");
                entity.Property(e => e.UnitOfMeasure).HasMaxLength(20);
                entity.Property(e => e.WeightCoefficient).HasColumnType("decimal(6,3)");
            });

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.HasKey(e => e.ExerciseId);
                entity.Property(e => e.ExerciseName).HasMaxLength(20);
                entity.Property(e => e.DifficultyLevel).HasMaxLength(20);
                entity.Property(e => e.EquipmentNeeded).HasMaxLength(40);
                entity.Property(e => e.MuscleGroup).HasMaxLength(20);
            });

            modelBuilder.Entity<HealthGoal>(entity =>
            {
                entity.HasKey(e => e.GoalId);
                entity.Property(e => e.GoalType).HasMaxLength(20);
                entity.Property(e => e.Status).HasMaxLength(20);
                entity.Property(e => e.TargetValue).HasColumnType("decimal(10,2)");
            });
            modelBuilder.Entity<HealthGoal>()
                .HasOne(h => h.User)  // HealthGoal has one User
                .WithMany()  // User can have many HealthGoals
                .HasForeignKey(h => h.UserId)  // Foreign key is UserId in HealthGoal
                .OnDelete(DeleteBehavior.Cascade);  // Define delete behavior (optional)

            modelBuilder.Entity<HealthMetric>(entity =>
            {
                entity.HasKey(e => e.MetricId);
                entity.Property(e => e.BiologicalAge).HasColumnType("decimal(5,2)");
                entity.Property(e => e.BloodGlucose).HasColumnType("decimal(5,2)");
                entity.Property(e => e.BloodPressureDiastolic).HasColumnType("decimal(5,2)");
                entity.Property(e => e.BloodPressureSystolic).HasColumnType("decimal(5,2)");
                entity.Property(e => e.Bmi).HasColumnType("decimal(5,2)");
                entity.Property(e => e.BodyFatPercentage).HasColumnType("decimal(5,2)");
                entity.Property(e => e.HdlCholesterol).HasColumnType("decimal(5,2)");
                entity.Property(e => e.LdlCholesterol).HasColumnType("decimal(5,2)");
                entity.Property(e => e.RestingHeartRate).HasColumnType("decimal(5,2)");
                entity.Property(e => e.SleepHours).HasColumnType("decimal(5,2)");
                entity.Property(e => e.StepsCount).HasColumnName("steps_count");
                entity.Property(e => e.Triglycerides).HasColumnType("decimal(5,2)");
                entity.Property(e => e.Vo2Max).HasColumnType("decimal(5,2)");
                entity.Property(e => e.WeightKg).HasColumnType("decimal(5,2)");

                entity
                    .HasOne(h => h.User)
                    .WithMany(u => u.HealthMetrics)
                    .HasForeignKey(h => h.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasKey(e => e.RecipeId);
                entity.Property(e => e.CaloriesPerServing).HasColumnType("decimal(5,2)");
                entity.Property(e => e.CarbsGrams).HasColumnType("decimal(5,2)");
                entity.Property(e => e.PreparationTime).HasColumnType("decimal(5,2)");
                entity.Property(e => e.CookingTime).HasColumnType("decimal(5,2)");
                entity.Property(e => e.FatGrams).HasColumnType("decimal(5,2)");
                entity.Property(e => e.ProteinGrams).HasColumnType("decimal(5,2)");
                entity.Property(e => e.Servings).HasColumnType("decimal(5,2)");
                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<RecipeIngredient>(entity =>
            {
                entity.HasKey(ri => new { ri.RecipeId, ri.IngredientName });
                entity.Property(e => e.IngredientName).HasMaxLength(50);
                entity.Property(e => e.Quantity).HasColumnType("decimal(6,2)");
                entity.Property(e => e.Unit).HasMaxLength(50);

                entity
                    .HasOne(ri => ri.Recipe)
                    .WithMany(r => r.RecipeIngredients)
                    .HasForeignKey(ri => ri.RecipeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Workout>(entity =>
            {
                entity.HasKey(e => e.WorkoutId);
                entity.Property(e => e.WorkoutName).HasMaxLength(20);
                entity.Property(e => e.Instructions).HasColumnType("text");

                entity
                    .HasOne(w => w.WorkoutsProgram)
                    .WithMany(p => p.Workouts)
                    .HasForeignKey(w => w.ProgramId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            

            modelBuilder.Entity<WorkoutExercise>(entity =>
            {
                entity.HasKey(e => e.WorkoutId);
                entity.Property(e => e.RepeatsUnits).HasMaxLength(30);
                entity.Property(e => e.RestPeriod).HasColumnType("decimal(5,2)");
                entity.Property(e => e.Sets).HasMaxLength(50);
            });

            modelBuilder.Entity<WorkoutsLog>(entity =>
            {
                entity.HasKey(e => e.LogId);
            });

            modelBuilder.Entity<WorkoutsProgram>(entity =>
            {
                entity.HasKey(e => e.ProgramId);
                entity.Property(e => e.ProgramName).HasMaxLength(50);
                entity.Property(e => e.DifficultyLevel).HasMaxLength(20);
                entity.Property(e => e.Description).HasColumnType("text");

                entity
                    .HasOne(wp => wp.Creator)
                    .WithMany()
                    .HasForeignKey(wp => wp.CreatedBy)
                    .OnDelete(DeleteBehavior.SetNull);
            }); 
        }
    }
}