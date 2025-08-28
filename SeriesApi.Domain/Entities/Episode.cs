namespace SeriesApi.Domain.Entities
{
    public class Episode
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Title { get; set; } = null!;
    public int SeasonId { get; set; }
    public Season Season { get; set; } = null!;
}
}