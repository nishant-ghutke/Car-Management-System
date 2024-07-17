using AutoMapper;
using CarRentalSystem.DAL.DataModel;
using CarRentalSystem.DAL.Services.Home;

using System.Web.Http;
using System.Web.Mvc;
using WebAPIModels;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace APICarRental.Controllers
{
    public class APILoginController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly LoginService _loginService;

        public APILoginController(IMapper mapper, LoginService loginService)
        {
            _mapper = mapper;
            _loginService = loginService;
        }

        public APILoginController()
        {
            _mapper = DependencyResolver.Current.GetService<IMapper>();
            _loginService = DependencyResolver.Current.GetService<LoginService>();  
        }

        [HttpPost]

        //POST: /api/APILogin/Verification

        #region
        public IHttpActionResult Verification(APILoginModel loginAPIModel)
        {
            tbl_Login loginDataModel = _mapper.Map<tbl_Login>(loginAPIModel);

            bool isValid = _loginService.IsCredentialValid(loginDataModel);

            if (isValid)
            {
                return Ok(isValid);

            }
            else
            {
                return BadRequest("Invalid user data");
            }
        }
        #endregion

    }
}
