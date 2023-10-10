using Pump.Application.Models;

namespace Pump.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddOrUpdateUserInfo(UserInfosModel employeeModel);
    }
}
