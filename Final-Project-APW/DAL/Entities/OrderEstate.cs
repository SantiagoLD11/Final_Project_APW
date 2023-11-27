using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Final_Project_APW.DAL.Entities
{
    public class OrderEstate:AuditBase
    {
        [Display(Name = "Estado Pedido")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")] //Longitud de caracteres máxima que esta propiedad me permite tener, ejem varchar(50)
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public string NameEsateOrder { get; set; } //varchar(50)
        [Display(Name = "Orden")]
        //Relación con Hotel
        public Order? Order { get; set; } //Este representa un OBJETO DE Hotel

    }
}
