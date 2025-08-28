namespace SeriesApi.Shared.DTOs
{
    public class EpisodeDto
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; } = null!;
    }
}