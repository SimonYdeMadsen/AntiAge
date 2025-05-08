namespace AntiAge.Controllers.Dto
{
    public class HealthGoalDto
    {
        public int UserId { get; set; }

        public string GoalType { get; set; }

        public decimal TargetValue { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly TargetDate { get; set; }

        public string? Status { get; set; }

        public string? Notes { get; set; }
    }
}