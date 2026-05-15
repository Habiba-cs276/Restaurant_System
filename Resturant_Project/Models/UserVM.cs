using System.ComponentModel.DataAnnotations;

namespace Resturant_Project.Models
{
    public class CreateUserVM
    {
      public  int id; 
        public string FullName { get; set; }

        public string ?Email { get; set; }
        [DataType(DataType.Password)]   
        public string Password { get; set; }
    }
}
