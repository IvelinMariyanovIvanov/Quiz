
namespace Quiz.Helpers
{
    public class Constants
    {
        public const string AdminRole = "Admin";
        public const string UserRole = "User";

        public const string AdminPassword = "Admin123$";
        public const string UserPassword = "User123$";

        public enum QuestionType
        {
            /// <summary>
            /// Yes or No
            /// </summary>
            Binary,
            /// <summary>
            /// Showing three possible answers, one of which must be the right one
            /// </summary>
            Multiple
        }
    }
}
