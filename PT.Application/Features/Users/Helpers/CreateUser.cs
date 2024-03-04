using PT.Domain.ProjectTracker;

namespace PT.Application.Features.Users.Helpers
{
    public static class CreateUser
    {
        public static string Handle(string fullname)
        {
            var names = fullname.ToLower().Split(' ');
            var result = "";
            foreach (var name in names)
            {
                result += name[..2];
            }
            return result;
        }
    }
}
