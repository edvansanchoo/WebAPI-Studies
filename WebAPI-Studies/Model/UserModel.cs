using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Studies.Model
{
    [Table("userauthentication")]
    public class UserModel
    {
        [Key]
        public int id { get; set; }
        public string username{ get; set; }
        public string password { get; set; }

        public UserModel()
        {
        }

        public UserModel( string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public UserModel(int id, string username, string password)
        {
            this.id = id;
            this.username = username;
            this.password = password;
        }
    }
}
