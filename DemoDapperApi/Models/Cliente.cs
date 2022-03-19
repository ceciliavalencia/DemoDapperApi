using System;
using System.Collections.Generic;

#nullable disable

namespace DemoDapperApi.Models
{
    public partial class Cliente
    {
        public int id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int? Carne { get; set; }
        public int? Dpi { get; set; }
        public string Correo { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
    }
}
