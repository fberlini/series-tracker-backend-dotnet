namespace SeriesApi.Domain.Entities
{
    public class Series
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public ICollection<Season> Seasons { get; set; } = [];
    }

}