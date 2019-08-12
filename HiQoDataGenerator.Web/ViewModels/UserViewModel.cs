namespace HiQoDataGenerator.Web.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string AccessToken { get; set; }
        public int DataAccessExpirationTime { get; set; }
        public int ExpiresIn { get; set; }
    }
}
