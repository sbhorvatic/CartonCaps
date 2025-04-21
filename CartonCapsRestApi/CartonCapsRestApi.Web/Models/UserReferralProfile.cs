namespace CartonCapsRestApi.Web.Models {
    public class UserReferralProfile {
        public required string UserId { get; set; }
        public string? ReferralCode { get; set; }
        public int ReferralCodeUsed { get; set;}
    }
}