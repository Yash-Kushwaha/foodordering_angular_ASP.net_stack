using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UsersMicroservice.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [JsonIgnore]
        public string Role { get; set; }
        [Required]
        public string Address { get; set; }

    }
}
