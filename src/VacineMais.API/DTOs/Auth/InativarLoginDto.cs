using System.ComponentModel.DataAnnotations;

namespace VacineMais.API.DTOs.Auth
{
    public class InativarLoginDto
    {
        [Required]
        public string Username { get; set; }
    }
}
