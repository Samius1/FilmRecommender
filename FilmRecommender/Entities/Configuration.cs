using System.Configuration;
using System.Text.Json;

namespace FilmRecommender.Entities
{
    internal class Configuration
    {
        internal static int NumberOfFilmsToRate { get; private set; } = 20;
        internal static int NumberOfFilmsToRecommend { get; private set; } = 20;
        internal static int NumberOfRandomFilms { get; private set; } = 3;

        private static string ConfigurationFilePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "config.film.recommendations");
        private const string ConfigurationSeparator = ";"; 
        internal static void LoadConfiguration()
        {
            if (!File.Exists(ConfigurationFilePath))
            {
                CreateConfiguration();
            }

            var configurationFileContent = File.ReadAllText(ConfigurationFilePath);
            var configuration = configurationFileContent.Split(ConfigurationSeparator[0]);

            NumberOfFilmsToRate = int.Parse(configuration[0]);
            NumberOfFilmsToRecommend = int.Parse(configuration[1]);
            NumberOfRandomFilms = int.Parse(configuration[2]);
        }

        private static void CreateConfiguration()
        {
            var configuration = $"{NumberOfFilmsToRate}{ConfigurationSeparator}{NumberOfFilmsToRecommend}{ConfigurationSeparator}{NumberOfRandomFilms}";
            File.WriteAllText(ConfigurationFilePath, configuration);
        }
    }
}
