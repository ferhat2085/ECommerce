using ECommerce.Data.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models;

public class Actor:IEntityBase
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Profil Resmi")]
    [Required(ErrorMessage="Profil resmi zorunludur")]
    public string ProfilePictureUrl { get; set; }=string.Empty;

    [Display(Name = "Ad Soyad")]
    [Required(ErrorMessage = "Ad Soyad bilgisi zorunludur ")]
    [StringLength(maximumLength:50 , ErrorMessage="İsim 3 ile 50 karekter olmalı" ,MinimumLength= 3)]
    public string FullName { get; set; }=string.Empty ;

    [Display(Name = "Biyografi")]
    [Required(ErrorMessage = "Biyografı bilgisi zorunludur")]
    public string Bio { get; set; } = string.Empty;


    //RelationShip
    [ValidateNever]// tabloya ınsert ettıgınde actor-movıes atla demektir..
    public List<Actor_Movie> Actors_Movies  { get; set;}

}
