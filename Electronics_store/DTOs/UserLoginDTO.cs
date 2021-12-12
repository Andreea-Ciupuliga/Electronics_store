using System.ComponentModel.DataAnnotations;

namespace Electronics_store.DTOs
{
    public class UserLoginDTO
    {
        //aici sunt datele transmise de noi ca sa ne logam
        
        [Required]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }
}