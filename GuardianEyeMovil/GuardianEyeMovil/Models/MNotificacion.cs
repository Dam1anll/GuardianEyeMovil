using System;
using System.Collections.Generic;
using System.Text;

namespace GuardianEyeMovil.Models
{
    public class MNotificacion
    {
        public string Id { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public string Imagen { get; set; } = string.Empty;  
        public string Tipo { get; set; } = string.Empty;
        public string Video { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;  
        
    }
}
