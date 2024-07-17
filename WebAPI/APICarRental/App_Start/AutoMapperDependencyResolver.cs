using AutoMapper;
using System.Web.Mvc;
using Unity.Mvc5;
using Unity;
using WebAPIModels;
using CarRentalSystem.DAL.DataModel;
using CarRentalSystem.DAL.Services.Home;
using System.Net.Http;
using CarRentalSystem.BAL.Services;
namespace APICarRental.App_Start
{
    public class AutoMapperDependencyResolver
    {
        public static void Initialize()
        {
            var container = new UnityContainer();

            container.RegisterType<LoginService, LoginService>();
            container.RegisterType<UserService, UserService>();
            container.RegisterInstance(new HttpClient());

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<APILoginModel, tbl_Login>().ReverseMap();
                cfg.CreateMap<APIUserModel, tbl_UserRegistration>().ReverseMap();
            });

            // IMapper instance
            container.RegisterInstance(mapperConfiguration.CreateMapper());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}

