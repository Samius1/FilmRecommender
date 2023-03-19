using FilmRecommender.Entities;
using System.ComponentModel;

namespace FilmRecommender.Services
{
    internal class MovieLensService
    {
        private static Dictionary<int, Profile> Model = new Dictionary<int, Profile>();
        private static List<Film> Films = new List<Film>();

        internal static void LoadModel(BackgroundWorker backgroundWorker)
        {
            RecreateFilms(backgroundWorker);
            RecreateModel();
        }

        internal static Dictionary<int, int> GetFilmsToRate()
        {
            var filmsToRate = new Dictionary<int, int>();
            var randomGenerator = new Random();

            while (filmsToRate.Count < Configuration.NumberOfFilmsToRate)
            { 
                filmsToRate.TryAdd(Films.ElementAt(randomGenerator.Next(0, Films.Count)).Id, 1);
            }

            return filmsToRate;
        }

        internal static string GetFilmName(int id)
        {
            var film = Films.FirstOrDefault(x => x.Id == id);
            
            return film?.Name ?? GetFilmNameFromRestore(id);
        }

        private static void RecreateModel()
        {
            var userMovies = Properties.Resources.filmsUsers;
            var userMovieList = userMovies.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < userMovieList.Length; i++)
            {
                var userMovieData = userMovieList[i].Split('\t');
                var userId = int.Parse(userMovieData[0]);
                var movieId = int.Parse(userMovieData[1]);
                var rating = int.Parse(userMovieData[2]);

                if (Model.ContainsKey(userId))
                {
                    var oldProfile = Model[userId];
                    oldProfile.Scores.Add(movieId, rating);
                    Model[userId] = oldProfile;
                }
                else
                {
                    var profile = new Profile();
                    profile.UserId = userId;
                    profile.Scores.Add(movieId, rating);
                    Model.Add(profile.UserId, profile);
                }
            }
        }

        private static void RecreateFilms(BackgroundWorker? backgroundWorker)
        {
            backgroundWorker?.ReportProgress(0);
            var movies = Properties.Resources.films;
            var movieList = movies.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < movieList.Length; i++)
            {
                var movieData = movieList[i].Split('|');
                Films.Add(
                    new Film
                    {
                        Id = int.Parse(movieData[0]),
                        Name = movieData[1]
                    });

                backgroundWorker?.ReportProgress((i + 1) * 100 / movieList.Count());
            }
        }

        private static string GetFilmNameFromRestore(int id)
        {
            RecreateFilms(null);
            return Films.First(x => x.Id == id).Name;
        }
    }
}
