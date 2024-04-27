namespace PT.Infraestructure.Persistence.ProjectTracker.Users.Models
{
    public class UserGetByFiltersPayload
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string PaternalLastName { get; set; }
        public string MaternalLastname { get; set; }
        public string Email { get; set; }
    }
}
