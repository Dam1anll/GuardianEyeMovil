using System;
using System.Collections.Generic;
using System.Text;

namespace GuardianEyeMovil.Models
{
    public class MUsuario
    {
        public string Id = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string ApellidoP { get; set; } = string.Empty;
        public string ApellidoM { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
        public string NumeroCelular { get; set; } = string.Empty;

    }
}
