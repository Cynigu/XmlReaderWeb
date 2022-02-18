namespace Models
{
    public class Folder
    {
        public int Id { get; set; }
        public string PathFolder { get; set; }
        public ushort CountObject { get; set; }
        public ushort CountXmlFiles { get; set; }
        public ushort CountFiles { get; set; }
    }
}
