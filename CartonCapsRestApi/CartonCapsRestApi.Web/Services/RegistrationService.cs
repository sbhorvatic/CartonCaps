using CartonCapsRestApi.Web.Exceptions;
using CartonCapsRestApi.Web.Store;

namespace CartonCapsRestApi.Web.Services {
    public class RegistrationService : IRegistrationService
    {
        private readonly ICartonCapsStore _userStore;

        public RegistrationService(ICartonCapsStore userStore) {
            _userStore = userStore;
        }

        public string AddNewUser(string? refCode)
        {
            if(refCode != null) {
                var refUser = _userStore.GetUserByRefCode(refCode) ?? throw new InvalidRefCodeException($"{refCode} is not a vaild code");
                _userStore.UpdateUserRedeems(refUser.Id, refUser.Redeems + 1);
            }
            return _userStore.CreateUser();
        }
    }
}