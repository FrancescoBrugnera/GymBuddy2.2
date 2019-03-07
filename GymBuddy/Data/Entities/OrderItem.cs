using System.ComponentModel.DataAnnotations.Schema;

namespace GymBuddy.Data.Entities
{
  public class OrderItem
  {
    public int Id { get; set; }
    public Lesson Lesson { get; set; }
    public int Quantity { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }
    public Order Order { get; set; }
  }
}