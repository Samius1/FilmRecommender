using FilmRecommender.Entities;
using System.ComponentModel;

namespace FilmRecommender.Services
{
    internal class MovieLensService
    {
        private static Dictionary<int, Profile> Model = new();
        private static List<Film> Films = new();
        private static Dictionary<int, (double, double)> Neighborhood = new(); // UserId - Similitude, film mean

        internal static void LoadModel(BackgroundWorker backgroundWorker)
        {
            Films = new List<Film>();
            Model = new Dictionary<int, Profile>();
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
            if (!Model.Any())
            {
                RecreateModel();
            }

            Neighborhood = PearsonCorrelationNeighborhood(userProfile);
        }

        internal static IEnumerable<Recommendation> GetFilmsRated(Profile userProfile)
        {
            var ratedFilms = new List<Recommendation>();
            var filteredFilmIds = Films.Select(x => x.Id).Except(userProfile.Scores.Keys);
            var similarUsers = Neighborhood.Where(x => x.Value.Item1 > 0);
            if (similarUsers.Any())
            {
                similarUsers = similarUsers.OrderByDescending(x => x.Value).Take(similarUsers.Count() / 5);
            }
            else
            {
                similarUsers = Neighborhood.OrderByDescending(x => x.Value).Take(similarUsers.Count() / 5);
            }

            if (similarUsers?.Any() ?? false)
            {
                var principalUserMean = userProfile.Scores.Values.Sum() * 1.0 / userProfile.Scores.Count;
                foreach (var filmId in filteredFilmIds)
                {
                    var nominator = 0d;
                    var denominator = 0d;

                    foreach (var user in similarUsers)
                    {
                        var score = GetScoreByIds(user.Key, filmId);
                        if(score > 0)
                        {
                            nominator += (user.Value.Item1 * (score - user.Value.Item2));
                            denominator += Math.Abs(user.Value.Item1);
                        }
                    }

                    var rating = principalUserMean + nominator / denominator;
                    ratedFilms.Add(new Recommendation { Id = filmId, Name = GetFilmName(filmId), Rating = (int)rating });
                }
            }

            return ratedFilms;
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
            Model[userId].Scores.TryGetValue(filmId, out var score);
            return score;
        }

        private static Dictionary<int, (double, double)> PearsonCorrelationNeighborhood(Profile userProfile)
        {
            var userSimilitudes = new Dictionary<int, (double, double)>();
            var userMean = userProfile.Scores.Values.Sum() * 1.0 / userProfile.Scores.Count;
            foreach (var profile in Model.Select(x => x.Value))
            {
                var filmsInCommon = profile.Scores.Where(x => userProfile.Scores.ContainsKey(x.Key));
                if (filmsInCommon.Any())
                {
                    var comparerMean = profile.Scores.Select(x => x.Value).Sum() * 1.0 / profile.Scores.Count();

                    var numerator = 0d;
                    foreach (var film in filmsInCommon)
                    {
                        var userNumerator = userProfile.Scores.First(x => x.Key == film.Key).Value - userMean;
                        var comparerNumerator = filmsInCommon.First(x => x.Key == film.Key).Value - comparerMean;
                        numerator += (userNumerator * comparerNumerator);
                    }

                    var userDenominator = userProfile.Scores.Select(x => (x.Value - userMean) * (x.Value - userMean)).Sum();
                    var comparerDenominator = profile.Scores.Select(x => (x.Value - comparerMean) * (x.Value - comparerMean)).Sum();
                    var denominator = Math.Sqrt(userDenominator) * Math.Sqrt(comparerDenominator);

                    var similitude = numerator / denominator;
                    userSimilitudes.Add(profile.UserId, (similitude, comparerMean));
                }
            }
            return userSimilitudes;
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
