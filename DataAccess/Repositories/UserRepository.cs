using DataAccess.IRepositories;
using Logic;

namespace DataAccess.Repositories {
    public class UserRepository : RepositoryBase<SdDb> ,IUserRepository {
        public User GetUser(int id) {
            return Get<User>(user => user.Id == id);
        }
    }
}
