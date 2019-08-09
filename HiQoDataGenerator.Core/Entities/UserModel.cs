namespace HiQoDataGenerator.Core.Entities
{
    public class UserModel : BaseModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string AccessToken { get; set; }
        public int DataAccessExpirationTime { get; set; }
        public int ExpiresIn { get; set; }

        public UserModel(int id, int userId, string userName, string userEmail, string accessToken, int dataAccessExpirationTime, int expiresIn) : base(id)
        {
            UserId = userId;
            UserName = userName;
            UserEmail = userEmail;
            AccessToken = accessToken;
            DataAccessExpirationTime = dataAccessExpirationTime;
            ExpiresIn = expiresIn;
        }
    }
}
