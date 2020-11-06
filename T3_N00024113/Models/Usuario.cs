using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace T3_N00024113.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        [Required]
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
    }
}
