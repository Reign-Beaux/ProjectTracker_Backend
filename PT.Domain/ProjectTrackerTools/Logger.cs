namespace PT.Domain.ProjectTrackerTools
{
    public class Logger
    {
        public string? Feature { get; set; }
        public string? Method { get; set; }
        public int Code { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
