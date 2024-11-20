using ECommerce.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class OrderItem:IEntityBase
    {
        [Key]
        public int Id { get; set; } 
        public int  Amount   { get; set; }
        public double Price { get; set; }

        [ForeignKey("MovieId")]
        public int MovieId { get; set; }    
   

    //relation
    public Movie Movie {  get; set; }


    [ForeignKey("OrderId")]
    public int OrderId {  get; set; }
    public Order Order {  get; set; }
    }
}
