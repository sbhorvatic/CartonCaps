using CartonCapsRestApi.Web.Services;

namespace CartonCapsRestApi.Web.Router {
    public class Routes {
        public IServiceCollection SetDi(IServiceCollection serviceCollection) {
            serviceCollection.AddScoped<IHelloWorldService, HelloWorldService>();
            return serviceCollection;
        }
        
        public IEndpointRouteBuilder SetRoutes(IEndpointRouteBuilder app) {
            app = SetHelloRoutes(app);
            return app;
        }

        private IEndpointRouteBuilder SetHelloRoutes(IEndpointRouteBuilder app) {
            app.MapGet("/hello", (IHelloWorldService helloWorldService) => helloWorldService.GetHello())
                .WithDescription("Display Hello World")
                .WithTags("Helo Service");
            return app;
        }
    }
}