namespace SocialMedia.Infrastructure.Data.Constants
{
    public class DbConstants
    {
        public static class UserConstants
        {
            public const int MaxUsernameLength = 200;
            public const int MaxEmailLength = 200;
            public const int MaxBioLength = 2000;
        }

        public static class PostConstants
        {
            public const int MaxPostLength = 2000;
        }
    }
}