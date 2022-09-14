using System.ComponentModel.DataAnnotations;

namespace fclanov.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Jmeno { get; set; } = String.Empty;

        [Required]
        public string Mail { get; set; } = String.Empty;

        [Required]
        public string Heslo_hashed { get; set; } = String.Empty;

        [Required]
        public bool JePrihlasen { get; set; } = false;
    }
}