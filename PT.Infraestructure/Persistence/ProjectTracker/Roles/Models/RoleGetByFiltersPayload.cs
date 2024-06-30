namespace PT.Infraestructure.Persistence.ProjectTracker.Roles.Models
{
    public class RoleGetByFiltersPayload
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string OrderBy { get; set; }
        public string SortDirection { get; set; }
    }
}
