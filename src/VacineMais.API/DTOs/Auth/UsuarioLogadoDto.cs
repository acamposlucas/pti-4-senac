﻿namespace VacineMais.API.DTOs.Auth
{
    public class UsuarioLogadoDto
    {
        public int Id { get; set; }
        public int FamiliaId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
