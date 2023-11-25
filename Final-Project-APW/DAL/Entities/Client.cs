using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Xml.Linq;

namespace Final_Project_APW.DAL.Entities
{
    public class Client : AuditBase
    {
        [Display(Name = "Cliente")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")] //Longitud de caracteres máxima que esta propiedad me permite tener, ejem varchar(50)

        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public string FirstName { get; set; } //varchar(50)
        //caracteres máxima que esta propiedad me permite tener, ejem varchar(50)

        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public string LastName { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")] //Longitud de 
        public string Mail { get; set; }

        public Int32 Phone { get; set; } 
        public Int64 NumDoc { get; set; }
        public DateTime Birthday { get; set; }
        [Display(Name = "Id Estate")]
        public int EstateId { get; set; } //FK


        [Display(Name = "Id Tipo Documento")]
        public int TypeDocumentId { get; set; } //FK

    }
}
