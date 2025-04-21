using CartonCapsRestApi.Web.Services;

namespace CartonCapsRestApi.Web.Router {
    public class Routes {
        public IServiceCollection SetDi(IServiceCollection serviceCollection) {
            serviceCollection.AddScoped<IHealthService, HealthService>();
            return serviceCollection;
        }
        
        public IEndpointRouteBuilder SetRoutes(IEndpointRouteBuilder app) {
            app = SetHealthRoutes(app);
            return app;
        }

        private IEndpointRouteBuilder SetHealthRoutes(IEndpointRouteBuilder app) {
            app.MapGet("/health", (IHealthService healthService) => healthService.GetHealth())
                .WithDescription("Display Health Check")
                .WithTags("Health Service");
            return app;
        }
    }
}