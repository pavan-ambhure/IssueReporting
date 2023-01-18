using WebApiTemplate.Contracts.Enums;

namespace WebApiTemplate.Services.Contract.Response
{
    public class UserResponse
    {
        /// <summary>
        /// User Id
        /// </summary>
        public int UserId
        {
            get; set;
        }

        /// <summary>
        /// User email
        /// </summary>
        public string UserEmail { get; set; } = string.Empty;

        /// <summary>
        /// User Role
        /// </summary>
        public UserRole Role { get; set; }
    }
}
