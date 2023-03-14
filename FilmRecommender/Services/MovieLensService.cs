using FilmRecommender.Entities;
using System.ComponentModel;
using System.Linq;

namespace FilmRecommender.Services
{
    internal class MovieLensService
    {
        private static Dictionary<int, Profile> Model = new Dictionary<int, Profile>();
        private static List<Film> Films = new List<Film>();

        internal static void LoadModel(BackgroundWorker backgroundWorker)
        {
            backgroundWorker.ReportProgress(0);
            var movies = Properties.Resources.films;
            var movieList = movies.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < movieList.Length; i++)
            {
                var movieData = movieList[i].Split('|');
                var film = new Film();
                film.Id = int.Parse(movieData[0]);
                film.Name = movieData[1];
                Films.Add(film);

                backgroundWorker.ReportProgress((i + 1) * 100 / movieList.Count());
            }

            var userMovies = Properties.Resources.filmsUsers;
            var userMovieList = userMovies.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < userMovieList.Length; i++)
            {
                var userMovieData = userMovieList[i].Split('\t');
                var userId = int.Parse(userMovieData[0]);
                var movieId = int.Parse(userMovieData[1]);
                var rating = int.Parse(userMovieData[2]);

                var movie = new Film();
                movie.Id = movieId;

                if (Model.ContainsKey(userId))
                {
                    var oldProfile = Model[userId];
                    oldProfile.Scores.Add(movie, rating);
                    Model[userId] = oldProfile;
                }
                else
                {
                    var profile = new Profile();
                    profile.UserId = userId;
                    profile.Scores.Add(movie, rating);
                    Model.Add(profile.UserId, profile);
                }
            }
        }

        internal static Dictionary<Film, int> GetFilmsToRate()
        {
            var filmsToRate = new Dictionary<Film, int>();
            var randomGenerator = new Random();

            while (filmsToRate.Count < Configuration.NumberOfFilmsToRate)
            { 
                filmsToRate.TryAdd(Films.ElementAt(randomGenerator.Next(0, Films.Count)), 1);
            }

            return filmsToRate;
        }
    }
}
