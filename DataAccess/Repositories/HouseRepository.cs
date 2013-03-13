using System.Linq;
using DataAccess.IRepositories;
using Logic;

namespace DataAccess.Repositories {
    class HouseRepository : RepositoryBase<SdDb>, IHouseRepository {
        private IQueryable<House> _houses;
        public IQueryable<House> Houses {
            get { return _houses ?? (_houses = GetAll<House>()); }
        } 

        public House GetHouse(int houseId) {
            return Get<House>( house => house.Id == houseId);
        }
    }
}
