using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Final_Project_APW.DAL.Entities
{
    public class Order : AuditBase
    {
        public Guid Estate_OrderId { get; set; }
        public Guid  ClientId { get; set; }
        public string Observation { get; set;}
        public int NumOrder { get; set; }
        public DateTime FechaDespacho { get; set; }

        [Display(Name = "Productos")]
        //relación con Rooms 
        public ICollection<OrderDetails>? OrdersDetails { get; set; }
    }
}
