namespace FilmRecommender.Entities
{
    internal class Profile
    {
        internal int UserId { get; set; }
        public Dictionary<int, int> Scores { get; set; } = new Dictionary<int, int>();
        public List<Film> Recommendations { get; set; } = new List<Film>();
    }
}
