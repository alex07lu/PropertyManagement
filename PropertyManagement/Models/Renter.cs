using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyManagement.Models
{
    public class Renter
    {
        [Key]
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public int? PropertyId { get; set; }
        [ForeignKey("PropertyId")]
        public Property? Property { get; set; }
    }
}
