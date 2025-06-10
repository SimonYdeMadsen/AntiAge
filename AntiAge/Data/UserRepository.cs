using AntiAge.Data;
using AntiAge.Data.Entities;
using AntiAge.Data.Identity;
using AntiAge.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace AntiAge.Api.Data
{
    public class UserRepository : GenericRepository, IUserRepository
    {
        private readonly AntiAgeContext context;
        private readonly ILogger<UserRepository> logger;

        public UserRepository(AntiAgeContext context, ILogger<UserRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<User> GetUser(int userId)
        {
            var user = await context.Users.SingleOrDefaultAsync(u => u.Id == userId);
            if (user is null)
            {
                logger.LogError(new KeyNotFoundException($"No user registered for {userId}"), $"No user registered for {userId}");
                return null!;
            }
            return user;
        }

        public async Task<List<HealthMetricDto>> GetUserHealthMetrics(int page, int pageSize, int userId)
        {
            Expression<Func<HealthMetric, HealthMetricDto>> selector = m => new HealthMetricDto
            {
                BiologicalAge = m.BiologicalAge,
                Bmi = m.Bmi,
                DateRecorded = m.DateRecorded,
                WeightKg = m.WeightKg,
                BodyFatPercentage = m.BodyFatPercentage,
                BloodPressureSystolic = m.BloodPressureSystolic,
                BloodPressureDiastolic = m.BloodPressureDiastolic,
                RestingHeartRate = m.RestingHeartRate,
                BloodGlucose = m.BloodGlucose,
                HdlCholesterol = m.HdlCholesterol,
                LdlCholesterol = m.LdlCholesterol,
                Triglycerides = m.Triglycerides,
                Vo2Max = m.Vo2Max,
                SleepHours = m.SleepHours,
                StepsCount = m.StepsCount
            };

            Expression<Func<HealthMetric, bool>> filter = m => m.UserId == userId;

            Expression<Func<HealthMetric, object>> ordering = m => m.UserId;

            List<HealthMetricDto> healthMetrics = await GetPagedAsync(page, pageSize, filter, ordering, selector);

            return healthMetrics;
        }

        public async Task<int> GetUserHealthMetricsCount(int userId)
        {
            return await context.HealthMetrics
                .Where(m => m.UserId == userId)
                .CountAsync();
        }
        

    }
}
