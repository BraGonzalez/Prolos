using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PROLOSENLINEA.Models
{
    public class UsuarioModel
    {
        [Required(ErrorMessage = "Introduzca su identificación")]
        public string id_Usuario { get; set; }
        [Required(ErrorMessage = "Introduzca su Nombre")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Introduzca su correo electrónico")]
        public string apellido { get; set; }
        public string correo { get; set; }
        public string tipo { get; set; }
        [Required(ErrorMessage = "Introduzca su contraseña")]
        [DataType(DataType.Password)]
        public string contraseña { get; set; }
    }
}