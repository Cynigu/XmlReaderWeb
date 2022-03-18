namespace Models;

public class Image
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int FolderId { get; set; }
    public FolderEntity Folder { get; set; }
    public byte[] ImageByte { get; set; }
}