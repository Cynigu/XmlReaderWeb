using Microsoft.AspNetCore.Http;

namespace XmlReader.BLL.Models.Models
{
    public class FolderInfo
    {
        public string? FolderPath { get; set; }
        public float Bet { get; set; }
        public int CountObject { get; set; }
        public float Salary { get; set; }
        public int CountXmlFile { get; set; }
    }
}