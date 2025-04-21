namespace CartonCapsRestApi.Web.Store {
    public interface ICartonCapsStore
    {
        User GetUser(string userId);
        List<User> GetAllUsers();
        bool SaveRefCode(string userId, string refCode);
        string CreateUser();
        User GetUserByRefCode(string refCode);
        bool UpdateUserRedeems(string userId, int redeems);
    }
}