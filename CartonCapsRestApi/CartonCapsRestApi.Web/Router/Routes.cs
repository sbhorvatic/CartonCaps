using System.Net;
using CartonCapsRestApi.Web.Controllers;
using CartonCapsRestApi.Web.Services;
using CartonCapsRestApi.Web.Store;
using Microsoft.AspNetCore.Mvc;

namespace CartonCapsRestApi.Web.Router {
    public class Routes {
        public IServiceCollection SetDi(IServiceCollection serviceCollection) {
            serviceCollection.AddScoped<IHealthService, HealthService>();
            serviceCollection.AddScoped<IUserAuthService, UserAuthService>();
            serviceCollection.AddScoped<IReferralService, ReferralService>();
            serviceCollection.AddScoped<IRegistrationService, RegistrationService>();
            serviceCollection.AddScoped<IUserProfileService, UserProfileService>();
            serviceCollection.AddScoped<UserController>();
            serviceCollection.AddSingleton<ICartonCapsStore, InMemoryDb>();

            return serviceCollection;
        }
        
        public IEndpointRouteBuilder SetRoutes(IEndpointRouteBuilder app) {
            app = SetHealthRoutes(app);
            app = SetUserRoutes(app);
            return app;
        }

        private IEndpointRouteBuilder SetHealthRoutes(IEndpointRouteBuilder app) {
            app.MapGet("/health", (IHealthService healthService) => healthService.GetHealth())
                .WithDescription("Display Health Check")
                .WithTags("Health Service");
            return app;
        }

        private IEndpointRouteBuilder SetUserRoutes(IEndpointRouteBuilder app) {
            app.MapPost("/user/{id}/referral", ([FromRoute] string id, UserController userController) => userController.GetReferral(id))
                .WithDescription("Will gen and get referral. If referral is already gen then will fetch current referral")
                .WithTags("User Service")
                .Produces((int)HttpStatusCode.Unauthorized)
                .Produces((int)HttpStatusCode.BadRequest)
                .Produces((int)HttpStatusCode.Accepted);
            
            app.MapPost("/user/{id}/newreferral", ([FromRoute] string id, UserController userController) => userController.GetNewReferral(id))
                .WithDescription("Will gen and get referral. Will always gen a new referral")
                .WithTags("User Service")
                .Produces((int)HttpStatusCode.Unauthorized)
                .Produces((int)HttpStatusCode.BadRequest)
                .Produces((int)HttpStatusCode.Accepted);
            return app;
        }
    }
}