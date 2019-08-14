using System;

namespace HiQoDataGenerator.Core.Entities
{
    public class UserModel
    {
        public string UserId { get; }
        public string UserName { get; }
        public string UserEmail { get; }
        public string AccessToken { get; }
        public int DataAccessExpirationTime { get; }
        public DateTime ExpiresIn { get; }

        public UserModel(string userId, string userName, string userEmail, string accessToken,
            int dataAccessExpirationTime, int expiresIn)
        {
            UserId = userId;
            UserName = userName;
            UserEmail = userEmail;
            AccessToken = accessToken;
            DataAccessExpirationTime = dataAccessExpirationTime;
            ExpiresIn = GenerateExpireDateTime(expiresIn);
        }

        private DateTime GenerateExpireDateTime(int expiresIn)
            => DateTime.UtcNow.AddSeconds(expiresIn);
    }
}
