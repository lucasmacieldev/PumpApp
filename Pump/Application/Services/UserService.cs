using Firebase.Database;
using Firebase.Database.Query;
using Pump.Application.Models;

namespace Pump.Application.Services
{
    public class UserService /*: IUserService*/
    {
        FirebaseClient firebase = new FirebaseClient("pump-209f1", new FirebaseOptions
        {
            AuthTokenAsyncFactory = () => Task.FromResult("AIzaSyAEbwfahF3pWE_zADkI1lzD13noj1GhJF4")
        });

        public async Task<bool> AddOrUpdateUserInfo(UserInfosModel userInfo)
        {
            if (!string.IsNullOrWhiteSpace(userInfo.UID))
            {
                try
                {
                    await firebase.Child(nameof(UserInfosModel)).Child(userInfo.UID).PutAsync(userInfo);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                var response = await firebase.Child(nameof(userInfo)).PostAsync(userInfo);
                if (response.Key != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public async Task<UserInfosModel> GetUserAsync(UserInfosModel userInfo)
        {
            var response = await firebase.Child(nameof(UserInfosModel)).Child(userInfo.UID).OnceSingleAsync<UserInfosModel>();

            return response;
        }
    }
}
