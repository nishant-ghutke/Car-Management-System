using AutoMapper;
using CarRentalSystem.BAL.Services;
using CarRentalSystem.DAL.DataModel;
using CarRentalSystem.Model;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using WebAPIModels;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;



namespace APICarRental.Controllers
{
    public class APIUserController : ApiController
    {
        private readonly IMapper _mapper;
        UserService userService = new UserService();

        public APIUserController()
        {
            _mapper = DependencyResolver.Current.GetService<IMapper>();
        }

        #region Public methods
        [HttpGet]
        public IHttpActionResult Index()
        {
            List<tbl_UserRegistration> users = userService.GetAllUsers();
            if (users != null)
            {
                return Ok(users);
            }
            return NotFound();

        }

        [HttpPost]
        public IHttpActionResult InsertUser(APIUserModel userAPI)
        {
            try
            {
                tbl_UserRegistration userData = _mapper.Map<tbl_UserRegistration>(userAPI);

                bool userEntered = userService.InsertUser(userData);

                if (userEntered)
                {
                    return Ok(userEntered);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting data: {ex.Message}");
                return InternalServerError();
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateUser(APIUserModel userAPI)
        {
            try
            {
                tbl_UserRegistration userData = _mapper.Map<tbl_UserRegistration>(userAPI);

                bool userEntered = userService.UpdateUser(userData);

                if (userEntered)
                {
                    return Ok(userEntered);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Update data: {ex.Message}");
                return InternalServerError();
            }

        }

        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            try
            {
                userService.DeleteUser(id);
                return Ok("User deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting data: {ex.Message}");
                return InternalServerError();
            }
        }

        #endregion


    }
}