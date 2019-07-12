namespace HiQoDataGenerator.DAL.Models.FileMetadataModels
{
    public class FileMetadata : BaseModel
    {
        public string Path { get; set; }
        public int StatusId { get; set; }
        public FileStatus Status { get; set; }
    }
}
