using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceExamGAP_ORM.Core.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}