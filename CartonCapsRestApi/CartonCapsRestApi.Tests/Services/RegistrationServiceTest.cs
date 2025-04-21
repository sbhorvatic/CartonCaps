using CartonCapsRestApi.Web.Exceptions;
using CartonCapsRestApi.Web.Services;
using CartonCapsRestApi.Web.Store;
using NSubstitute;

namespace CartonCapsRestApi.Test.Router {
    public class RegistrationServiceTest
    {
        [Test]
        public void Set_User_Without_Ref_Code_Successfully()
        {
            var storeMock = Substitute.For<ICartonCapsStore>();
            storeMock.CreateUser().Returns("145");
            var service = new RegistrationService(storeMock);

            var result = service.AddNewUser(null);

            Assert.That(result, Is.EqualTo("145"));
        }

        [Test]
        public void Set_User_With_Ref_Code_Successfully()
        {
            var storeMock = Substitute.For<ICartonCapsStore>();
            storeMock.CreateUser().Returns("145");
            storeMock.GetUserByRefCode(Arg.Any<string>()).Returns(new User {
                Id = "1",
                RefCode = "123",
                Redeems = 3
            });
            var service = new RegistrationService(storeMock);

            var result = service.AddNewUser("123");
            
            Assert.That(result, Is.EqualTo("145"));
            storeMock.Received(1).UpdateUserRedeems("1", 4);
        }

        [Test]
        public void Set_User_With_Ref_Code_Unsuccessfully()
        {
            var storeMock = Substitute.For<ICartonCapsStore>();
            storeMock.CreateUser().Returns("145");
            storeMock.GetUserByRefCode(Arg.Any<string>()).Returns(x => null);
            var service = new RegistrationService(storeMock);

            Assert.Throws<InvalidRefCodeException>(() => service.AddNewUser("123"));
            
        }
    }
}