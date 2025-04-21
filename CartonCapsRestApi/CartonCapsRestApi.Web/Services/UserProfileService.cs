using CartonCapsRestApi.Web.Exceptions;
using CartonCapsRestApi.Web.Models;
using CartonCapsRestApi.Web.Store;

namespace CartonCapsRestApi.Web.Services {
    public class UserProfileService : IUserProfileService
    {
        private readonly IReferralService _referralService;
        private readonly ICartonCapsStore _userStore;

        public UserProfileService(IReferralService referralService, ICartonCapsStore userStore) {
            _referralService = referralService;
            _userStore = userStore;
        }

        public UserReferralProfile GetUserReferralProfile(string userId) {
            var user = _userStore.GetUser(userId) ?? throw new NoUserException("Can't find user");
            return new UserReferralProfile {
                UserId = user.Id,
                ReferralCode = user.RefCode,
                ReferralCodeUsed = user.Redeems
            };
        }

        public string GetReferral(string userId) {
            var user = _userStore.GetUser(userId) ?? throw new NoUserException("Can't find user");
            if (user.RefCode != null) {
                return user.RefCode;
            }

            return GenReferral(userId);
        }

        public string GetNewReferral(string userId) {
            if(_userStore.GetUser(userId) == null)
            { 
                throw new NoUserException("Can't find user");
            }
            return GenReferral(userId);
        }

        private string GenReferral(string userId) {
            var link = _referralService.GetReferralLink();
            _userStore.SaveRefCode(userId, link);
            return link;
        }
    }
}