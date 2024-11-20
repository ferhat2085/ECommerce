using ECommerce.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Order:IEntityBase
    {
        [Key]
        public int Id { get; set; } 
        public string Email { get; set; }    
        public int UserId { get; set; }

        public List<OrderItem>  OrdersItems{ get; set; }
    }
}
