using CartonCapsRestApi.Web.Store;

namespace CartonCapsRestApi.Web.Services {
    public interface IRegistrationService
    {
        string AddNewUser(string? refCode);
    }
}