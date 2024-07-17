using AutoMapper;
using CarRentalSystem.BAL.Services;

using CarRentalSystem.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

using WebAPIModels;


namespace CarRentalSystem.BAL.Agent.Home
{

    public class UserAgent : IUserAgent
    {
        Uri baseAddress = new Uri("http://localhost:44336/api/");
        HttpClient client;
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        public UserAgent(IMapper mapper, UserService userService)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _mapper = mapper;
            _userService = userService;
        }

        /// <summary>
        /// This list will eventually hold user data retrieved from the API.
        /// </summary>
        /// <returns></returns>

        #region Public Method
        public List<UserModel> GetAllUsers()
        {
            List<APIUserModel> listOfUsersAPI = new List<APIUserModel>();
               
            HttpResponseMessage response = client.GetAsync("https://localhost:44336/api/APIUser/Index").Result;

            string data = response.Content.ReadAsStringAsync().Result;

            listOfUsersAPI = JsonConvert.DeserializeObject<List<APIUserModel>>(data);

            List<UserModel> users =  _mapper.Map<List<UserModel>>(listOfUsersAPI);
            return users;
        }

        public UserModel GetUserById(int id)
        {
            List<UserModel> users = GetAllUsers();
            UserModel user = users.Find(x => x.UserId == id);
            return user;
        }

        public void InsertUser(UserModel user)
        {
            APIUserModel userAPI = _mapper.Map<APIUserModel>(user);
            string jsonData = JsonConvert.SerializeObject(userAPI);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = client.PostAsync("https://localhost:44336/api/APIUser/InsertUser", content);
        }

        public void UpdateUser(UserModel user)
        {
            APIUserModel userAPI = _mapper.Map<APIUserModel>(user);
            string jsonData = JsonConvert.SerializeObject(userAPI);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = client.PutAsync("https://localhost:44336/api/APIUser/UpdateUser", content);
        }

        public List<string> GetCountriesList()
        {
            return _userService.GetCountriesList();
        }

        public List<string> GetCarList()
        {
            return _userService.GetCarList();
        }
        public List<string> GetStatesList()
        {
            return _userService.GetStatesList();
        }
        public void DeleteUser(int id)
        {
            
            HttpResponseMessage response = client.DeleteAsync($"https://localhost:44336/api/APIUser/DeleteUser/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("User deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to delete user. Status code: {response.StatusCode}");
            }
        }

        public void Detail(int id)
        {
            _userService.Detail(id);
        }
        #endregion 
    }
}