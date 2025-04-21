using CartonCapsRestApi.Web.Exceptions;
using CartonCapsRestApi.Web.Services;
using CartonCapsRestApi.Web.Store;
using NSubstitute;

namespace CartonCapsRestApi.Test.Router {
    public class UserProfileServiceTest
    {
        [Test]
        public void Get_Referral_Successfully()
        {
            var referralMock = Substitute.For<IReferralService>();
            referralMock.GetReferralLink().Returns("12345");
            var storeMock = Substitute.For<ICartonCapsStore>();
            storeMock.GetUser(Arg.Any<string>()).Returns(new User{
                Id = "1"
            });
            var service = new UserProfileService(referralMock, storeMock);

            var result = service.GetReferral("1");

            Assert.That(result, Is.EqualTo("12345"));
        }

        [Test]
        public void Get_Aleady_Created_Referral_Successfully()
        {
            var referralMock = Substitute.For<IReferralService>();
            referralMock.GetReferralLink().Returns("12345");
            var storeMock = Substitute.For<ICartonCapsStore>();
            storeMock.GetUser(Arg.Any<string>()).Returns(new User{
                Id = "1",
                RefCode = "cd9w0f"
            });
            var service = new UserProfileService(referralMock, storeMock);

            var result = service.GetReferral("1");

            Assert.That(result, Is.EqualTo("cd9w0f"));
        }

        [Test]
        public void Referral_Find_User_Unsuccessfully()
        {
            var referralMock = Substitute.For<IReferralService>();
            referralMock.GetReferralLink().Returns("12345");
            var storeMock = Substitute.For<ICartonCapsStore>();
            storeMock.GetUser(Arg.Any<string>()).Returns<User>(x => null);
            var service = new UserProfileService(referralMock, storeMock);

            Assert.Throws<NoUserException>(() => service.GetReferral("1"));
        }

        [Test]
        public void New_Referral_Find_User_Unsuccessfully()
        {
            var referralMock = Substitute.For<IReferralService>();
            referralMock.GetReferralLink().Returns("12345");
            var storeMock = Substitute.For<ICartonCapsStore>();
            storeMock.GetUser(Arg.Any<string>()).Returns<User>(x => null);
            var service = new UserProfileService(referralMock, storeMock);

            Assert.Throws<NoUserException>(() => service.GetNewReferral("1"));
        }

        [Test]
        public void Get_New_Referral_Successfully()
        {
            var referralMock = Substitute.For<IReferralService>();
            referralMock.GetReferralLink().Returns("12345");
            var storeMock = Substitute.For<ICartonCapsStore>();
            storeMock.GetUser(Arg.Any<string>()).Returns(new User{
                Id = "1"
            });
            var service = new UserProfileService(referralMock, storeMock);

            var result = service.GetNewReferral("1");

            Assert.That(result, Is.EqualTo("12345"));
        }

        [Test]
        public void Get_New_Referral_With_Already_Created_Referral_Successfully()
        {
            var referralMock = Substitute.For<IReferralService>();
            referralMock.GetReferralLink().Returns("12345");
            var storeMock = Substitute.For<ICartonCapsStore>();
            storeMock.GetUser(Arg.Any<string>()).Returns(new User{
                Id = "1",
                RefCode = "cd9w0f"
            });
            var service = new UserProfileService(referralMock, storeMock);

            var result = service.GetNewReferral("1");
            
            Assert.That(result, Is.EqualTo("12345"));
        }

        [Test]
        public void Get_Referral_Profile_Successfully()
        {
            var referralMock = Substitute.For<IReferralService>();
            referralMock.GetReferralLink().Returns("12345");
            var storeMock = Substitute.For<ICartonCapsStore>();
            storeMock.GetUser(Arg.Any<string>()).Returns(new User{
                Id = "1",
                RefCode = "cd9w0f",
                Redeems = 4
            });
            var service = new UserProfileService(referralMock, storeMock);

            var result = service.GetUserReferralProfile("1");
            
            Assert.That(result.UserId, Is.EqualTo("1"));
            Assert.That(result.ReferralCode, Is.EqualTo("cd9w0f"));
            Assert.That(result.ReferralCodeUsed, Is.EqualTo(4));
        }

        [Test]
        public void Get_Referral_Profile_Find_User_Unsuccessfully()
        {
            var referralMock = Substitute.For<IReferralService>();
            referralMock.GetReferralLink().Returns("12345");
            var storeMock = Substitute.For<ICartonCapsStore>();
            storeMock.GetUser(Arg.Any<string>()).Returns<User>(x => null);
            var service = new UserProfileService(referralMock, storeMock);

            Assert.Throws<NoUserException>(() => service.GetUserReferralProfile("1"));
        }
    }
}