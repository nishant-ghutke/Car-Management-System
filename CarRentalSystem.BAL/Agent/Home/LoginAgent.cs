using AutoMapper;
using CarRentalSystem.BAL.IAgent.Home;
using CarRentalSystem.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPIModels;
namespace CarRentalSystem.BAL.Agent.Home
{
    public class LoginAgent : ILoginAgent
    {
        //LoginService loginService = new LoginService();

        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;
        public LoginAgent(IMapper mapper, HttpClient httpClient)
        {
            _mapper = mapper;
            _httpClient = httpClient;
        }
        #region Public Method
        public async Task<bool> IsCredentialValid(LoginModel loginDetail)
        {
            try
            {
                APILoginModel aPILogiDetail = _mapper.Map<APILoginModel>(loginDetail);

                string jsonData = JsonConvert.SerializeObject(aPILogiDetail);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync("https://localhost:44336/api/APILogin/Verification", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
            catch (Exception ex)
            {
                Console.Out.WriteLine($"Failed to verify user: {ex.Message}");
                return false;
            }
        }
        #endregion
    }
}

