using FilmRecommender.Entities;
using System.Text.Json;

namespace FilmRecommender.Services
{
    internal class FileHandler
    {
        internal static Profile GetUserProfile()
        {
            if (File.Exists(GetProfilePath()))
            {
                var content = File.ReadAllText(GetProfilePath());
                return JsonSerializer.Deserialize<Profile>(content);
            }
            return new Profile();
        }

        internal static void UpdateUserRatings(Profile userProfile)
        {
            var content = JsonSerializer.Serialize(userProfile);
            File.WriteAllText(GetProfilePath(), content);
        }

        private static string GetProfilePath()
        {
            var systemPath = Environment.GetFolderPath(
                                 Environment.SpecialFolder.CommonApplicationData
                             );
            return Path.Combine(systemPath, "FilmRecommender.json");
        }
    }
}
