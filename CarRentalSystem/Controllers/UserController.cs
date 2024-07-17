using CarRentalSystem.BAL.Agent.Home;
using CarRentalSystem.Controllers;
using CarRentalSystem.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace UserRentalSystem.Controllers

{
    public class UserController : Controller
    {

        private readonly IUserAgent userAgent;
        #region Public Constructor
        public UserController()
        {
            userAgent = DependencyResolver.Current.GetService<IUserAgent>();
        }
        #endregion


        #region Public Methods
        //[Route("Index")]
        // GET: User
        [Authorize]
        public ActionResult Index()
        {
            var listofData = userAgent.GetAllUsers();
            return View(listofData);
        }
        /// <summary>
        /// countries, states, and cars are variables of type List<string> that will hold the lists returned by the respective methods.
        /// </summary>
        /// <returns></returns>
       // [Route("Insert")]
        public ActionResult InsertUser()
        {
            List<string> countries = userAgent.GetCountriesList();
            Session["Countries"] = countries;

            List<string> states = userAgent.GetStatesList();
            Session["States"] = states;

            List<string> cars = userAgent.GetCarList();
            Session["Cars"] = cars;

            return View();
        }


        [HttpPost]
        public ActionResult InsertUser(UserModel model)
        {
            if (ModelState.IsValid)
            {
                userAgent.InsertUser(model);
                ViewBag.Message = "Data Insert Successfully";
                return RedirectToAction("Index");
            }
            return View(model);
        }



        /// <summary>
        /// Get method for Update User Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult UpdateUser(int id)
        {
            List<string> countries = userAgent.GetCountriesList();
            ViewBag.Countries = countries;
            List<string> states = userAgent.GetStatesList();
            ViewBag.States = states;
            List<string> cars = userAgent.GetCarList();
            ViewBag.Cars = cars;
            var data = userAgent.GetUserById(id);
            if (data == null)
            {
                return HttpNotFound(); // Or any other appropriate action
            }
            return View(data);
        }
        [HttpPost]

        public ActionResult UpdateUser(UserModel model)
        {
            if (ModelState.IsValid)
            {
                userAgent.UpdateUser(model);
                //return View("Index", model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        /// <summary>
        /// Method for delete User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 

        
        public ActionResult DeleteUser(int id)
        {
            userAgent.DeleteUser(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Method to display Details of User
        /// </summary>
        /// <param name="id"></param>
        /// <returns>data</returns>
        public ActionResult Detail(int id)
        {
            var data = userAgent.GetUserById(id);
            if (data == null)
            {
                return HttpNotFound(); // Or any other appropriate action
            }

            return View(data);
        }
        #endregion

    }
}
