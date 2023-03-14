namespace FilmRecommender.Entities
{
    internal class Profile
    {
        internal int UserId { get; set; }
        internal Dictionary<Film, int> Scores { get; set; } = new Dictionary<Film, int>();
    }
}
