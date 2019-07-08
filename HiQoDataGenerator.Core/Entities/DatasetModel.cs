namespace HiQoDataGenerator.Core.Entities
{
    public class DatasetModel : BaseModel
    {
        public string Name { get; }
        public int TypeId { get; }
        public bool IsDefined { get; }

        public DatasetModel(int id, string name,int typeId, bool isDefined) : base(id)
        {
            Name = name;
            TypeId = typeId;
            IsDefined = isDefined;
        }
    }
}
