using Logic;

namespace DataAccess.IRepositories {
    public interface IUserRepository : IBaseRepository {
        User GetUser(int id);
    }
}
