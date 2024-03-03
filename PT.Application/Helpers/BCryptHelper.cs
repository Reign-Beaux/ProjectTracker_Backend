using BC = BCrypt.Net.BCrypt;

namespace PT.Application.Helpers
{
    public static class BCryptHelper
    {
        public static string EncriptText(string text)
          => BC.HashPassword(text);

        public static bool MatchText(string text, string hashed)
          => BC.Verify(text, hashed);
    }
}
