namespace WebApiTemplate.Services.Contract.Request
{
    public class UserLoginRequest
    {
      
        /// <summary>
        /// User Email
        /// </summary>
        public string UserEmail { get; set; } = null!;

        /// <summary>
        /// User Password
        /// </summary>

        public string Password { get; set; } = null!;

        /// <summary>
        /// User Role
        /// </summary>

        public int Role { get; set; }

    }
}
