using CartonCapsRestApi.Web.Services;

namespace CartonCapsRestApi.Test.Router {
    public class HealthServiceTest
    {
        [Test]
        public void Get_Health_Successfully()
        {
            var service = new HealthService();

            Assert.That(service.GetHealth(), Is.EqualTo("Ok"));
        }
    }
}