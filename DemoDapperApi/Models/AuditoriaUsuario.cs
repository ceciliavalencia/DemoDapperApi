using System;
using System.Collections.Generic;

#nullable disable

namespace DemoDapperApi.Models
{
    public partial class AuditoriaUsuario
    {
        public int? IdUsuario { get; set; }
        public string Nombres { get; set; }
        public int? Edad { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string UsuarioCreador { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
