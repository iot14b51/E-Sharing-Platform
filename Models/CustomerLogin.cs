using System.ComponentModel.DataAnnotations;

namespace ProjectK.Models
{
    public class CustomerLogin
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
