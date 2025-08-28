namespace SeriesApi.Domain.Entities
{
    public class Episode
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public string Title { get; set; } = null!;
    public Guid SeasonId { get; set; }
    public Season Season { get; set; } = null!;
}
}