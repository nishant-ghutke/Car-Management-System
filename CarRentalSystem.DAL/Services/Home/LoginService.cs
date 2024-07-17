using CarRentalSystem.DAL.DataModel;
using System.Collections.Generic;
using System.Linq;




namespace CarRentalSystem.DAL.Services.Home
{
    public class LoginService
    {
        CarRentalEntities dbObj = new CarRentalEntities();

        /// <summary>
        /// Method to check login credentials from database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        #region Public Method
        public List<tbl_Login> GetUsers()
        {

            return dbObj.tbl_Login.ToList();

        }



        /// <summary>
        /// Method to verify login credentials.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool IsCredentialValid(tbl_Login model)
        {
            var users = GetUsers();
            var correctPerson = users.Find(x => model.Username.Equals(x.Username));
            var correctPassword = correctPerson != null && correctPerson.Password.Equals(model.Password);

            return correctPassword;
        }
        #endregion


    }
}
