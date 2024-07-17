using System.ComponentModel.DataAnnotations;
namespace CarRentalSystem.Model
{
    public class CarModel
    {
        [Display(Name = "Car ID")]
        public  int CarId { get; set; }



        [Display(Name = "Car Name")]
        [Required(ErrorMessage = " Car Name is Required")]
        public string CarName { get; set; }




        [Display(Name = "Car Mileage")]
        
       
        [Required(ErrorMessage = " Car Mileage is Required")]
        public string CarMileage { get; set; }



        
        

        public int Quantity { get; set; }


        /*

        [Display(Name = "Select Car")]
        public string SelectCar { get; set; }*/
    }
}
