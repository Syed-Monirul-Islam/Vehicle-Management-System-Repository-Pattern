using Vehicle_Domain;
using Vehicle_Source;

namespace Vehicle_Repository
{
    public class VehicleXMLRepository : XMLRepositoryBase<XMLSet<Vehicle>, Vehicle, int>, IVehicleRepository
    {
        public VehicleXMLRepository() : base("VehicleInformation.xml")
        {
        }
    }
}
