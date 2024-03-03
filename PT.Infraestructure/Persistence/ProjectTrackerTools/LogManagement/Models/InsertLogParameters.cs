namespace PT.Infraestructure.Persistence.ProjectTrackerTools.LogManagement.Models
{
    public class InsertLogParameters
    {
        public string? Feature { get; set; }
        public string? Method { get; set; }
        public int Code { get; set; }
        public string? Description { get; set; }
    }
}
