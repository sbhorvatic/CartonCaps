namespace CartonCapsRestApi.Web.Store {
    public class InMemoryDb : ICartonCapsStore
    {
        private readonly List<User> _users;
        public InMemoryDb() {
            _users = new List<User>();
            _users.Add(new User {
                Id = "1"
            });
        }

        public bool SetUser(string userId) {
            _users.Add(new User {
                Id = userId
            });
            return true;
        }

        public User GetUser(string userId) {
            return _users.Where(x => x.Id == userId).FirstOrDefault();
        }

        public List<User> GetAllUsers() {
            return _users.ToList();
        }

        public bool SaveRefCode(string userId, string refCode)
        {
            var user = _users.Where(x => x.Id == userId).FirstOrDefault();
            if(user != null) {
                user.RefCode = refCode;
                return true;
            }
            return false;
        }
    }
}