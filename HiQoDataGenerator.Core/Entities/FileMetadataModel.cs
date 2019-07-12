namespace HiQoDataGenerator.Core.Entities
{
    public class FileMetadataModel : BaseModel
    {
        public string Path { get; set; }
        public int StatusId { get; set; }

        public FileMetadataModel(int id, string path, int statusId) : base(id)
        {
            Path = path;
            StatusId = statusId;
        }
    }
}
