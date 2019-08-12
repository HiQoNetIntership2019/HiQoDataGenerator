namespace HiQoDataGenerator.Core.Entities
{
    public class UserModel : BaseModel
    {
        public int UserId { get; }
        public string UserName { get; }
        public string UserEmail { get; }
        public string AccessToken { get; }
        public int DataAccessExpirationTime { get; }
        public int ExpiresIn { get; }

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
