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
        public int Preparation_time { get; set; } //Reputación de 1 a 5 estrellas que tiene el hotel.
        public int IdEstdado { get; set; }
        public int IdCategorie { get; set; }

        [Display(Name = "Categoria")]
        //relación con Rooms 
        public ICollection<Category>? Categories { get; set; }
        [Display(Name = "Estado")]
        //relación con Rooms 
        public ICollection<Estate>? Estates { get; set; }
    }
}
