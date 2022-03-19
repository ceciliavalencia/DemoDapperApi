using System;
using System.Collections.Generic;

#nullable disable

namespace DemoDapperApi.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public int? Edad { get; set; }
        public string Usuario1 { get; set; }
        public string Contrasena { get; set; }
    }
}
