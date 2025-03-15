namespace StlStore.Core.Domain
{
    public class StlFile
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
        public StlFileType Type { get; set; }
        public Figure Figure { get; set; }
        public Guid FigureId { get; set; }
    }
}
