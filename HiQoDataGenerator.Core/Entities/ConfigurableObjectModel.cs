using System;

namespace HiQoDataGenerator.Core.Entities
{
    public class ConfigurableObjectModel : BaseModel
    {
        private string _name;

        public DateTime DateCreation { get; }
        public DateTime? DateChange { get; private set; }

        public string Name {
            get => _name;
            set
            {
                _name = value;
                DateChange = DateTime.Now;
            }
        }

        public ConfigurableObjectModel(int id, string name, DateTime dateCreation, DateTime? dateChange) : base(id)
        {
            _name = name;
            DateChange = dateChange;
            DateCreation = dateCreation;
        }

        public ConfigurableObjectModel(int id, string name) : this(id, name, DateTime.Now, null) { }
    }
}
