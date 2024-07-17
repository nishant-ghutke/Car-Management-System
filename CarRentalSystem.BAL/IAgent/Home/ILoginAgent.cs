using CarRentalSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.BAL.IAgent.Home
{
    public interface ILoginAgent
    {
        Task<bool> IsCredentialValid(LoginModel loginDetail);
    }
}
