namespace CartonCapsRestApi.Web.Services {
    public class HealthService : IHealthService {
        public string GetHealth() {
            return "Ok";
        }
    }
}