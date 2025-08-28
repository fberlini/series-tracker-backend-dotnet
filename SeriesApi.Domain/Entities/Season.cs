namespace SeriesApi.Domain.Entities
{
    public class Season
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public Guid SeriesId { get; set; }
        public Series Series { get; set; } = null!;
        public ICollection<Episode> Episodes { get; set; } = [];
    }
}