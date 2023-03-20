namespace FilmRecommender.Entities
{
    internal class Profile
    {
        internal int UserId { get; set; }
        public Dictionary<int, int> Scores { get; set; } = new();
        public List<Recommendation> Recommendations { get; set; } = new();
    }
}
