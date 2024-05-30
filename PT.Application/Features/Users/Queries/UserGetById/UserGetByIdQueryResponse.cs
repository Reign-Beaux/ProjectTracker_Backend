namespace PT.Application.Features.Users.Queries.UserGetById
{
    public class UserGetByIdQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PaternalLastname { get; set; }
        public string MaternalLastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
