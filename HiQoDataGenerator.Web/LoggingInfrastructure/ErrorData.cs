using System;

namespace HiQoDataGenerator.Web.LoggingInfrastructure
{
    public class ErrorData
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Info { get; set; }
    }
}
