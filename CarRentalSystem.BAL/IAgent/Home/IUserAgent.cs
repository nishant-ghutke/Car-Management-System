
using CarRentalSystem.Model;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace CarRentalSystem.BAL.Agent.Home
{
    public interface IUserAgent
    {
        UserModel GetUserById(int id);
        List<UserModel> GetAllUsers();
        List<string> GetCountriesList();
        List<string> GetCarList();
        List<string> GetStatesList();
        void InsertUser(UserModel model);
        void UpdateUser(UserModel model);
        void DeleteUser(int id);
        void Detail(int id);

    }
}
