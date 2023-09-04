using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Studies.Domain.Model
{
    [Table("employee")]
    public class EmployeeModel
    {
        [Key]
        public int id { get; private set; }
        public string name { get; private set; }
        public int age { get; private set; }
        public string? photo { get; private set; }


        public EmployeeModel(int id, string name, int age, string photo)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.photo = photo;
        }

        public EmployeeModel(string name, int age, string photo)
        {
            this.name = name;
            this.age = age;
            this.photo = photo;
        }
    }
}
