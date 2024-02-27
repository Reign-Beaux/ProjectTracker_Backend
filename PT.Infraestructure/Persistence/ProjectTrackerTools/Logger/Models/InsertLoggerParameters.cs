namespace PT.Infraestructure.Persistence.ProjectTrackerTools.Logger.Models
{
    public class InsertLoggerParameters
    {
        public string? Feature { get; set; }
        public string? Method { get; set; }
        public int Code { get; set; }
        public string? Description { get; set; }
    }
}
