using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using CsvHelper;
using System.Globalization;
using AntiAge.Data;
using Microsoft.EntityFrameworkCore;
using AntiAge.Data.Entities;
using EFCore.BulkExtensions;

namespace AntiAge
{
    public class DataImporter
    {
        private readonly AntiAgeContext _context;

        public DataImporter(AntiAgeContext context)
        {
            _context = context;
        }

        public void ImportDummyData()
        {
            string dataFolder = Path.Combine(AppContext.BaseDirectory, "SeedData");

            ImportData<BioAgeFactor>(dataFolder + "bio-age-factors.csv");
            ImportData<Exercise>(dataFolder + "exercises.csv");
            ImportData<HealthGoal>(dataFolder + "health-goals.csv");
            ImportData<HealthMetric>(dataFolder + "health-metrics.csv");
            ImportData<Recipe>(dataFolder + "recipes.csv");
            ImportData<RecipeIngredient>(dataFolder + "recipe-ingredients.csv");
            ImportData<Workout>(dataFolder + "workouts.csv");
            ImportData<WorkoutExercise>(dataFolder + "workout-exercises.csv");
            ImportData<WorkoutsLog>(dataFolder + "workout-logs.csv");
            ImportData<WorkoutsProgram>(dataFolder + "workout-programs.csv");
        }

        public void ImportData<T>(string filePath) where T : class
        {
            if (!_context.Set<T>().Any())
            {
                Console.WriteLine("Assert data is sanitized.");
                var data = ReadCsvData<T>(filePath);
                BulkInsert(data);
            }
            else
            {
                Console.WriteLine("Data already exists.");
            }
        }

        // Step 3: Read CSV file and map to the entity
        private List<T> ReadCsvData<T>(string filePath) where T : class
        {
            var records = new List<T>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,  // Disable header validation
                MissingFieldFound = null, // Ignore missing fields
                PrepareHeaderForMatch = args =>
                {
                    var parts = args.Header.Split('_', StringSplitOptions.RemoveEmptyEntries);
                    return string.Concat(parts.Select(p => char.ToUpperInvariant(p[0]) + p.Substring(1)));
                }
            }))
            {
                records = csv.GetRecords<T>().ToList();
            }
            return records;
        }

        // Step 4: Bulk insert using EFCore.BulkExtensions
        private void BulkInsert<T>(List<T> data) where T : class
        {
            try
            {
                // Bulk insert using EFCore.BulkExtensions for better performance
                _context.BulkInsert(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during bulk insert: {ex.Message}");
            }
        }
    }
}