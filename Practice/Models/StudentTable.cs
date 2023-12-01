using System.ComponentModel.DataAnnotations;

namespace Practice.Models
{
    public class StudentTable
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="required")]
        public String Name { get; set; }

        [Required(ErrorMessage = "required")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
    }
}
