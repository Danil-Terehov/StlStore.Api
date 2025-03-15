namespace StlStore.Core.Domain
{
    public class Collection
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Figure> Figures { get; set; } = new List<Figure>();
        public List<Author> Authors { get; set; } = new List<Author>();
    }
}
