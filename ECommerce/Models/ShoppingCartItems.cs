using ECommerce.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class ShoppingCartItems:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
        public string ShoppingCardId { get; internal set; }
    }
}
