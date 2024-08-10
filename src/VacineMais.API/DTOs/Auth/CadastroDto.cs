using System.ComponentModel.DataAnnotations;

namespace VacineMais.API.DTOs.Auth
{
    public class CadastroDto
    {
        [Required(ErrorMessage = "O campo usuário é obrigatório")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo email é obrigatório")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo senha é obrigatório")]
        public string Password { get; set; } = string.Empty;
    }
}
