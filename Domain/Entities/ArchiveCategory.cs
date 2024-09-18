namespace Domain.Entities
{
    public class ArchiveCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime DeletedDate { get; set; } = DateTime.Now;
    }
}
