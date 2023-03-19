using FilmRecommender.Entities;

namespace FilmRecommender.Services
{
    internal class UserService
    {
        internal static Profile LoadUserProfile()
        {
            return FileHandler.GetUserProfile();
        }

        internal static void SaveUserProfile(Profile userProfile)
        {
            FileHandler.UpdateUserRatings(userProfile);
        }
    }
}
