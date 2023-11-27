using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Final_Project_APW.DAL.Entities
{
    public class OrderDetails :AuditBase
    {
        public Guid ProductId{ get; set; }
        [Display(Name = "Orden")]
        //Relación con Orden pedido
        public Order? Orders { get; set; } //Este representa un OBJETO DE Orden

        [Display(Name = "Id Order")]
        public Guid PedidoId { get; set; } //FK

    }

}
