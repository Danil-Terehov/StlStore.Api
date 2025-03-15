namespace StlStore.Core.Domain
{
    public class Figure
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();
        public Collection? Collection { get; set; }
        public Guid? CollectionId { get; set; }
        public List<StlFile> StlFiles { get; set; } = new List<StlFile>();
    }
}
