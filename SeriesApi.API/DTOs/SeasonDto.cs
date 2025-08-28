namespace SeriesApi.API.DTOs
{
    public class SeasonDto
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public List<EpisodeDto> Episodes { get; set; } = new();
    }
}