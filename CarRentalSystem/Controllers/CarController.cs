using CarRentalSystem.BAL.Agent.Home;
using CarRentalSystem.Model;
using System.Linq;
using System.Web.Mvc;



namespace CarRentalSystem.Controllers
{
    [Authorize]
    public class CarController : Controller
    {

        private readonly ICarAgent carAgent;
        #region Public Constructor
        public CarController()
        {
            carAgent = DependencyResolver.Current.GetService<ICarAgent>();
        }
        #endregion

        #region Public Methods
        public ActionResult Index()
        {
            var listofData = carAgent.GetAllCars().ToList();
            return View(listofData);
        }
        /// <summary>
        /// Get method for Insert car
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertCar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertCar(CarModel model)
        {
            if (ModelState.IsValid)
            {
                carAgent.InsertCar(model);
                ViewBag.Message = "Data Insert Successfully";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        /// <summary>
        /// Get method for Update Car
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateCar(int id)
        {
            var data = carAgent.GetCarById(id);
            if (data == null)
            {
                return HttpNotFound(); // Or any other appropriate action
            }
            return View(data);
        }

        [HttpPost]
        public ActionResult UpdateCar(CarModel model)
        {
            if (ModelState.IsValid)
            {
                carAgent.UpdateCar(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        /// <summary>
        /// Method for delete car
        /// </summary>
        /// <param name="id"></param>
        /// <param name="carObj"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            carAgent.DeleteCar(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Method to display
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(int id)
        {
            var data = carAgent.GetCarById(id);
            if (data == null)
            {
                return HttpNotFound(); // Or any other appropriate action
            }

            return View(data);
        }
        #endregion

       

    }
}









        







