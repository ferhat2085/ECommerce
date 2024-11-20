using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class ApplicationUser:IdentityUser
    {
         int Id {  get; set; }
        [Display(Name ="kullanıcı adı ")]
        public string FullName { get; set; }    
    }
}
