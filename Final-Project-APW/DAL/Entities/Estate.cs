﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Final_Project_APW.DAL.Entities
{
    public class Estate :AuditBase
    {
        [Display(Name = "Estado")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")] //Longitud de caracteres máxima que esta propiedad me permite tener, ejem varchar(50)
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public string Name { get; set; } //varchar(50)
        [Display(Name = "Prodcuto")]
        //Relación con Hotel
        public Product? Products { get; set; } //Este representa un OBJETO DE Hotel
    }
}
