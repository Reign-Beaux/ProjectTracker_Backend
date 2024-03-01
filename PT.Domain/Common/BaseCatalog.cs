namespace PT.Domain.Common
{
    public abstract class BaseCatalog
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
}
