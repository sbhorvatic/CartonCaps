using CartonCapsRestApi.Web.Store;

namespace CartonCapsRestApi.Web.Services {
    public class ReferralService : IReferralService
    {

        private readonly ICartonCapsStore _userStore;

        public ReferralService(ICartonCapsStore userStore) {
            _userStore = userStore;
        }

        public string GetReferralLink()
        {
            var code = Guid.NewGuid().ToString().Substring(0, 8);
            if(_userStore.GetAllUsers().Where(x => x.RefCode == code).ToList().Count > 0) {
                return GetReferralLink();
            }
            return code;

        }
    }
}