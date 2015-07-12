using System.ComponentModel.DataAnnotations;

namespace MongoDbMVCApp1.Models
{
    public class UserModel
    {
        public object _Id { get; set; }
        public int ID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
    }
}