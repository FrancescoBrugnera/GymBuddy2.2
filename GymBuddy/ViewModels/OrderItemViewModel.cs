using System.ComponentModel.DataAnnotations;

namespace GymBuddy.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        //[Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal UnitPrice { get; set; }
        
    }
}