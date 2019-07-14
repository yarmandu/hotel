using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_Hoteleria.Models.Login
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "Usuario")]
        [MaxLength(5, ErrorMessage ="Usuario incorrecto")]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contraseña { get; set; }

    }
}