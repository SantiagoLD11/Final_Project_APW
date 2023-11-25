using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Final_Project_APW.DAL.Entities
{
    public class Product : AuditBase
    {
        [Display(Name = "Productos Disponibles")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")] //Longitud de caracteres máxima que esta propiedad me permite tener, ejem varchar(50)
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public string Name { get; set; } //varchar(50)
        public string Description { get; set; }
        public float Price { get; set; }
        public int Preparation_time_min { get; set; } //Reputación de 1 a 5 estrellas que tiene el hotel.
        public Guid IdEstate { get; set; }
        public Guid IdCategory { get; set; }
    }
}
