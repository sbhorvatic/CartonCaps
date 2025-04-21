using CartonCapsRestApi.Web.Router;
using CartonCapsRestApi.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using NSubstitute;

namespace CartonCapsRestApi.Test.Router {
    public class Tests
    {
        [Test]
        public void Get_Health_Successfully()
        {
            var service = new HealthService();

            Assert.That(service.GetHealth(), Is.EqualTo("Ok"));
        }
    }
}