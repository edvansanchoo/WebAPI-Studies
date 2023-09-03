using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Studies.Models
{
    [Table("employee")]
    public class EmployeeModel
    {
        [Key]
        public int id { get; private set; }
        public string name{ get; private set; }
        public int age { get; private set; }
        public string? photo { get; private set; }

        public EmployeeModel(string name, int age, string photo)
        {
            this.name = name;
            this.age = age;
            this.photo = photo;
        }
    }
}
