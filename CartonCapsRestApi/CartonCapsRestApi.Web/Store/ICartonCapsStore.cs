namespace CartonCapsRestApi.Web.Store {
    public interface ICartonCapsStore
    {
        User GetUser(string userId);
        List<User> GetAllUsers();
        bool SaveRefCode(string userId, string refCode);

         bool SetUser(string userId);
    }
}