namespace FilmRecommender.Entities
{
    internal class Profile
    {
        internal Dictionary<Film, int> Scores { get; set; } = new Dictionary<Film, int>();
    }
}
