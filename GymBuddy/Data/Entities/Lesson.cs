using System.ComponentModel.DataAnnotations.Schema;

namespace GymBuddy.Data.Entities
{
    public class Lesson
  {
    public int Id { get; set; }
    public string Category { get; set; }
    public string ClassSize { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public string Title { get; set; }
    public string ClassDescription { get; set; }
    public string Instructor { get; set; }
    public string InstructorNationality { get; set; }
  }
}
