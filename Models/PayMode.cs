using System.ComponentModel.DataAnnotations;
using SupermarketWEB.Models;



namespace SupermarketWEB.Models
{
    public class PayMode
    {
        public int Id { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
