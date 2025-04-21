using CartonCapsRestApi.Web.Models;

namespace CartonCapsRestApi.Web.Services {
    public interface IUserProfileService
    {
        string GetReferral(string userId);
        string GetNewReferral(string userId);
        UserReferralProfile GetUserReferralProfile(string userId);
    }
}