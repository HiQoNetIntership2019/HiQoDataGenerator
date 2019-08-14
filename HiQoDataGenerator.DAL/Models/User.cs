using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.DAL.Models
{
    public class User : BaseModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string AccessToken { get; set; }
        public int DataAccessExpirationTime { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}
