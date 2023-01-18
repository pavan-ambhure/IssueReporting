using WebApiTemplate.Contracts.Enums;

namespace WebApiTemplate.Services.Contract.Request
{
    public class CreateUserRequest
    {
        /// <summary>
        /// User Id
        /// </summary>
        public int UserId { get; set; }

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

        public UserRole Role { get; set; }


        /// <summary>
        /// Is User active
        /// </summary>
        public bool? IsActive { get; set; }

    }
}
