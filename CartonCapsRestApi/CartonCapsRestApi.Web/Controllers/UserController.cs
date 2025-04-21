using CartonCapsRestApi.Web.Services;

namespace CartonCapsRestApi.Web.Controllers {
    public class UserController {

        private readonly IUserProfileService _userProfileService;
        private readonly IUserAuthService _userAuthService;

        public UserController(IUserAuthService userAuthService, IUserProfileService userProfileService) {
            _userAuthService = userAuthService;
            _userProfileService = userProfileService;
        }

        public IResult GetReferral(string id) {
            if(!_userAuthService.IsUserAuth()) { //This could be middleware but I went this direction as it was eaiser for a mocking API
                return TypedResults.Unauthorized();
            }
            try {
                var refCode = _userProfileService.GetReferral(id);
                return TypedResults.Ok(refCode);
            } catch(Exception e) {
                return TypedResults.BadRequest(e.Message);
            }
        }

        public IResult GetNewReferral(string id) {
            if(!_userAuthService.IsUserAuth()) {
                return TypedResults.Unauthorized();
            }
            try {
                var refCode = _userProfileService.GetNewReferral(id);
                return TypedResults.Ok(refCode);
            } catch(Exception e) {
                return TypedResults.BadRequest(e.Message);
            }
        }

        public IResult GetUserReferralProfile(string id) {
            if(!_userAuthService.IsUserAuth()) {
                return TypedResults.Unauthorized();
            }
            try {
                var user = _userProfileService.GetUserReferralProfile(id);
                return TypedResults.Ok(user);
            } catch(Exception e) {
                return TypedResults.BadRequest(e.Message);
            }
        }
    }
}