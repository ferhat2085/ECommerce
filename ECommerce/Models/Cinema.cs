using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models;

public class Cinema
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Ad ")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Logo")]
    public string Logo { get; set; } = string.Empty;

    [Display(Name = "Tanıtım")]
    public string Description { get; set; }= string.Empty;

    //RelationShips
    [ValidateNever]
    public List<Movie> Movies { get; set; } 

}
