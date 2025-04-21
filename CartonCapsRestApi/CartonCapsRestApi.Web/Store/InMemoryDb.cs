namespace CartonCapsRestApi.Web.Store {
    public class InMemoryDb : ICartonCapsStore
    {
        private readonly List<User> _users;
        public InMemoryDb() {
            _users =
            [
                new User {
                    Id = "1",
                    Redeems = 0
                },
            ];
        }

        public string CreateUser() {
            var id =  Guid.NewGuid().ToString();
            _users.Add(new User {
                Id = id
            });
            return id;
        }

        public bool UpdateUserRedeems(string userId, int redeems) {
            var user = _users.Where(x => x.Id == userId).FirstOrDefault();
            if(user != null) {
                user.Redeems = redeems;
                return true;
            }
            return false;
        }

        public User GetUser(string userId) {
            return _users.FirstOrDefault(x => x.Id == userId);
        }

        public User GetUserByRefCode(string refCode) {
            return _users.FirstOrDefault(x => x.RefCode == refCode);
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