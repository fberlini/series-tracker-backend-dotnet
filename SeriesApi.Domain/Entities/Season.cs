namespace SeriesApi.Domain.Entities
{
    public class Season
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int SeriesId { get; set; }
        public Series Series { get; set; } = null!;
        public ICollection<Episode> Episodes { get; set; } = [];
    }
}