namespace AntiAge.Controllers.Dto
{
    public class HealthMetricDto
    {
        public int UserId { get; set; }
        public decimal? BiologicalAge { get; set; }
        public decimal? Bmi { get; set; }

    }
}