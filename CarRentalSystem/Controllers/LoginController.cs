using CarRentalSystem.BAL.IAgent.Home;
using CarRentalSystem.Model;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;


namespace CarRentalSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginAgent login;
        /// <summary>
        ///  It initializes the login field by resolving an instance of ILoginAgent 
        /// </summary>
        #region Public Controller
        public LoginController()
        {
            login = DependencyResolver.Current.GetService<ILoginAgent>();
        }
        #endregion

        #region Public Methods
        // GET: Login
        /// <summary>
        /// Login Method to check the login credentials from database using linq
        /// </summary>
        /// <returns></returns>
        
        public ActionResult UserLogin()
        {
            Session["LoggedIn"] = null; //resetting the session
            return View(new LoginModel());
            
        }
        [HttpPost]
        public async Task<ActionResult> UserLogin(LoginModel loginDetail)
        {
            if (ModelState.IsValid)
            {
                if (await login.IsCredentialValid(loginDetail))
                {
                    FormsAuthentication.SetAuthCookie(loginDetail.Username, true);
                    Session["UserName"] = loginDetail.Username;
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong username or password");
                }
            }
            return View(loginDetail);
        }
        public ActionResult Logout()
        {
            // Clear user information from session
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("UserLogin","Login");
        }

        #endregion
    }
}