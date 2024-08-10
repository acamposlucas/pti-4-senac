namespace VacineMais.API.Models
{
    public class Usuario : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
