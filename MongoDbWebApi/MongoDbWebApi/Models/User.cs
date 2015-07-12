using System.ComponentModel.DataAnnotations;

namespace MongoDbWebApi.Models
{
    public class User
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