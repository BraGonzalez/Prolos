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

    public class Guardar
    {

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
    public class EditarUsuario
    {

        [Required(ErrorMessage = "Introduzca su identificación")]
        public string id_user { get; set; }
        [Required(ErrorMessage = "Introduzca su Nombre")]
        public string nomb { get; set; }
        [Required(ErrorMessage = "Introduzca su correo electrónico")]
        public string ape { get; set; }
        public string cor { get; set; }
        public string tipo { get; set; }
        [Required(ErrorMessage = "Introduzca su contraseña")]
        [DataType(DataType.Password)]
        public string cont { get; set; }
    }
    public class EliminaUsuario
    {
        public string id_usu { get; set; }
        public string nom { get; set; }
        public string apel { get; set; }
        public string corr { get; set; }
        public string tipo { get; set; }
        public string contra { get; set; }
    }

    public class elmentinput
    {
        public string btn { get; set; }
    }


}