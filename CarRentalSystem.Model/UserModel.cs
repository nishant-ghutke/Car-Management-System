using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CarRentalSystem.Model
{
    public class UserModel
    { 
        public int UserId { get; set; }


        [Display(Name = "First Name")]
        [Required(ErrorMessage = " First Name is Required")]
        [StringLength(50, MinimumLength = 3)]

        public string firstName { get; set; }


        [Display(Name = "Last Name")]
        [Required(ErrorMessage = " Last Name is Required")]
        [StringLength(50, MinimumLength = 3)]

        public string lastName { get; set; }

        [Required(ErrorMessage = "Email ID is Required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression( "[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Required]      
        public string Country { get; set; }

       
         
        [Required]
        public string State { get; set; }
        [Required]
        public string CarRented { get; set; }
    }
}
