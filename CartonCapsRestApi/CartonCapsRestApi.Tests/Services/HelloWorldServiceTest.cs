using CartonCapsRestApi.Web.Router;
using CartonCapsRestApi.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using NSubstitute;

namespace CartonCapsRestApi.Test.Router {
    public class Tests
    {
        [Test]
        public void Get_Hello_World_Successfully()
        {
            var service = new HelloWorldService();

            Assert.That(service.GetHello(), Is.EqualTo("Hello"));
        }
    }
}