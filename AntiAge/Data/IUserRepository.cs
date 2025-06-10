using AntiAge.Data.Identity;
using AntiAge.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AntiAge.Api.Data
{
    public interface IUserRepository
    {
        public Task<User> GetUser(int userId);
        public Task<List<HealthMetricDto>> GetUserHealthMetrics(int page, int pageSize, int userId);

        public Task<int> GetUserHealthMetricsCount(int userId);
    }
}
