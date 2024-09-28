namespace NisanKurumsalSite.Entities
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
