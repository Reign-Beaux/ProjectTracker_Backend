namespace PT.Infraestructure.Persistence.ProjectTracker.Users.Models
{
    public class UserUpdateParameters
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? PaternalLastname { get; set; }
        public string? MaternalLastname { get; set; }
    }
}
