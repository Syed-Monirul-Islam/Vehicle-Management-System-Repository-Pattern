namespace Vehicle_Domain
{
    public class CarCreator : VehicleTypeCreator
    {
        public override VehicleType CreateVehicleType() => new CarType();
    }

    public class BikeCreator : VehicleTypeCreator
    {
        public override VehicleType CreateVehicleType() => new BikeType();
    }

    public class TruckCreator : VehicleTypeCreator
    {
        public override VehicleType CreateVehicleType() => new TruckType();
    }

     
}
