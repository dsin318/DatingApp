using System.ComponentModel.DataAnnotations;

namespace DattingApp.API.Dtos
{
    public class UserRegisterDto
    {
        [Required]
        public string  Username { get; set; }

[Required]
[StringLength(8,MinimumLength = 5,ErrorMessage="You must have between 5 and 8 characters")]
         public string  Password { get; set; }
    }
}