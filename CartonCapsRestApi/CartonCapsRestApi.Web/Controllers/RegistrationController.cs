using CartonCapsRestApi.Web.Services;

namespace CartonCapsRestApi.Web.Controllers {
    public class RegistrationController {

        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService) {
            _registrationService = registrationService;
        }

        public IResult CreateUser(string? refCode) {
            try {
                var userId = _registrationService.AddNewUser(refCode);
                return TypedResults.Ok(userId);
            } catch(Exception e) {
                return TypedResults.BadRequest(e.Message);
            }
        }
    }
}