using System.ComponentModel.DataAnnotations;

namespace ProjectK.Models
{
    public class AdminLogin
    {
        public int Id { get; set; }
        public string AdminId { get; set; }
    [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
