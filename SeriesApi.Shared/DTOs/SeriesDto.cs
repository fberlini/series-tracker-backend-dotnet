namespace SeriesApi.Shared.DTOs
{
    public class SeriesDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public List<SeasonDto> Seasons { get; set; } = new();
    }
}