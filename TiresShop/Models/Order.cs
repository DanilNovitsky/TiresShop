using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace TiresShop.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Enter your name")]
        [StringLength(20)]
        [Required(ErrorMessage = "The name must contain no more than 20 characters long")]
        public string FirstName { get; set; }

        [Display(Name = "Enter your surname")]
        [StringLength(20)]
        [Required(ErrorMessage = "The surname must contain no more than 20 characters long")]
        public string LastName { get; set; }

        [Display(Name = "Enter your address")]
        [StringLength(40)]
        [Required(ErrorMessage = "The address must contain no more than 40 characters.")]
        public string Address { get; set; }

        [Display(Name = "Enter your phone number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15)]
        [Required(ErrorMessage = "The phone number must contain no more than 15 characters.")]
        public string Phone { get; set; }

        [Display(Name = "Enter your email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(35)]
        [Required(ErrorMessage = "The email must contain no more than 35 characters long")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
    
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
