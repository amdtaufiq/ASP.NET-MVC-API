namespace Logique_api.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool TermAndCondition { get; set; }
        public string Password { get; set; }
        public bool IsLogin { get; set; }
        public virtual DetailUser DetailUser { get; set; }
    }

    public class LoginRequest {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}