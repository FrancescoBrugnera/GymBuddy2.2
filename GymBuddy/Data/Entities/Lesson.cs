using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Data.Entities
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
