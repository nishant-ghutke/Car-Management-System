using AutoMapper;

using System.Web.Mvc;
using Unity.Mvc5;
using Unity;
using WebGrease;
using CarRentalSystem.BAL.Agent.Home;
using CarRentalSystem.Model;
using CarRentalSystem.DAL.DataModel;
using CarRentalSystem.BAL.IAgent.Home;
using WebAPIModels;
using System.Net.Http;

namespace CarRentalSystem.App_Start
{
    public class AutoMapperDependencyResolver
    {
        public static void Initialize()
        {
            var container = new UnityContainer();
            container.RegisterType<IUserAgent, UserAgent>();
            container.RegisterType<ICarAgent, CarAgent>();
            container.RegisterType<ILoginAgent, LoginAgent>();
            container.RegisterType<HttpClient, HttpClient>();


            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                // cfg.CreateMap<UserViewModel, User>().ReverseMap();
                cfg.CreateMap<LoginModel, APILoginModel>().ReverseMap();
                cfg.CreateMap<UserModel, APIUserModel>().ReverseMap();
                //cfg.CreateMap<UserModel, tbl_UserRegistration>().ReverseMap();
                cfg.CreateMap<CarModel, tbl_CarRegistration>().ReverseMap();
            });

            // IMapper instance
            container.RegisterInstance(mapperConfiguration.CreateMapper());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}