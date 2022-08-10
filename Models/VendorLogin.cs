using System.ComponentModel.DataAnnotations;

namespace ProjectK.Models
{
    public class VendorLogin
    {
        public int Id { get; set; }
        public string VendorId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
