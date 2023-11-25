using System.ComponentModel.DataAnnotations;

namespace Final_Project_APW.DAL.Entities
{
        public class AuditBase
        {
            [Key] //DataAnnotation me sirve para definir que esta propiedad ID es un PK
            [Required] //Para campos obligatorios, o sea que deben tener un valor (no permite nulls)
            public virtual Guid Id { get; set; } //PK
            public virtual DateTime? CreatedDate { get; set; } //Campos nulleables, notación elivs (?) 
            public virtual DateTime? ModifiedDate { get; set; }
        }

}
