namespace HiQoDataGenerator.Core.Entities
{
    public class FileStatusModel : BaseModel
    {
        public string Status { get; set; }

        public FileStatusModel(int id, string status) : base(id)
        {
            Status = status;
        }
    }
}
