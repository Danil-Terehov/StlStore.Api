namespace StlStore.Core.Domain
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Collection> Collections { get; set; } = new List<Collection>();
        public List<Figure> Figures { get; set; } = new List<Figure>();
    }
}
