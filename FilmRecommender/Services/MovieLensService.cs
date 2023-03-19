using FilmRecommender.Entities;
using System.ComponentModel;

namespace FilmRecommender.Services
{
    internal class MovieLensService
    {
        private static Dictionary<int, Profile> Model = new Dictionary<int, Profile>();
        private static List<Film> Films = new List<Film>();
        private static Dictionary<int, double> Neighborhood = new Dictionary<int, double>();

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

        internal static void CreateNeighborhood(Profile userProfile)
        {
            var userMean = userProfile.Scores.Values.Sum() * 1.0 / userProfile.Scores.Count;
            var userSimilitudes = new Dictionary<int, double>();

            if (!Model.Any())
            {
                RecreateModel();
            }

            foreach (var profile in Model.Select(x => x.Value))
            {
                var filmsInCommon = profile.Scores.Where(x => userProfile.Scores.ContainsKey(x.Key));
                var comparerMean = filmsInCommon.Select(x => x.Value).Sum() * 1.0 / filmsInCommon.Count();

                var similitude = 0d;
                var numerator = 0d;
                var denominator = 0d;
                foreach (var film in filmsInCommon)
                {
                    var userNumerator = userProfile.Scores.First(x => x.Key == film.Key).Value - userMean;
                    var comparerNumerator = filmsInCommon.First(x => x.Key == film.Key).Value - comparerMean;
                    numerator += userNumerator * comparerNumerator;
                }

                var userDenominator = userProfile.Scores.Where(x => profile.Scores.ContainsKey(x.Key))
                                        .Select(x => (x.Value - userMean) * (x.Value - userMean)).Sum();
                var comparerDenominator = filmsInCommon
                                        .Select(x => (x.Value - userMean) * (x.Value - userMean)).Sum();
                denominator = Math.Sqrt(userDenominator) * Math.Sqrt(comparerDenominator);

                similitude = numerator / denominator;
                userSimilitudes.Add(profile.UserId, similitude);
            }

            Neighborhood = userSimilitudes;
        }

        internal static List<Film> GetRecommendations(Profile userProfile)
        {
            var recommendations = new List<Film>();
            var filteredFilmIds = Films.Select(x => x.Id).Except(userProfile.Scores.Keys);
            IEnumerable<int>? similarUsers = null;
            var similarity = 0.8;
            while (similarUsers == null || !similarUsers.Any() || similarity > 0) 
            {
                similarUsers = Neighborhood.Where(x => x.Value >= similarity).Select(x => x.Key);
                similarity = similarity - 0.2;
            }

            if (similarUsers?.Any() ?? false)
            {
                foreach (var filmId in filteredFilmIds)
                {
                    var ratingSum = 0;
                    var numberOfHits = 0;

                    foreach (var userId in similarUsers)
                    {
                        var score = GetScoreByIds(userId, filmId);
                        if(score > 0)
                        {
                            ratingSum += score;
                            numberOfHits++;
                        }
                    }

                    if (ratingSum * 1.0 / numberOfHits >= 4)
                    {
                        recommendations.Add(new Film { Id = filmId, Name = GetFilmName(filmId) });
                    }
                }
            }

            return recommendations;
        }

        internal static string GetFilmName(int id)
        {
            var film = Films.FirstOrDefault(x => x.Id == id);
            
            return film?.Name ?? GetFilmNameFromRestore(id);
        }

        private static string GetFilmNameFromRestore(int id)
        {
            RecreateFilms(null);
            return Films.First(x => x.Id == id).Name;
        }

        private static int GetScoreByIds(int userId, int filmId)
        {
            try
            {
                return Model[userId].Scores[filmId];
            }
            catch (Exception)
            {
                return 0;
            }
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
                    var profile = new Profile
                    {
                        UserId = userId
                    };
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
    }
}
