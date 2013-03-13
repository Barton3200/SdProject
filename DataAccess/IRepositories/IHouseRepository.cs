using System.Collections.Generic;
using System.Linq;
using Logic;

namespace DataAccess.IRepositories {
    public interface IHouseRepository : IBaseRepository {
        House GetHouse(int houseId);
        IQueryable<House> Houses { get; }
    }
}
