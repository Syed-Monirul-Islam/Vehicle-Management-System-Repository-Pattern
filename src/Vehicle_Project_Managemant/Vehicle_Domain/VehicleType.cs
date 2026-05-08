using System;

namespace Vehicle_Domain
{
    
    public abstract class VehicleType
    {
        public void ShowVehicleDetails()
        {
            StartVehicle();
            Drive();
            StopVehicle();
        }

        protected abstract void StartVehicle();
        protected abstract void Drive();
        protected abstract void StopVehicle();
    }

    
    public class CarType : VehicleType
    {
        protected override void StartVehicle() => Console.WriteLine("Car Started");
        protected override void Drive() => Console.WriteLine("Car Driving");
        protected override void StopVehicle() => Console.WriteLine("Car Stopped");
    }

    public class BikeType : VehicleType
    {
        protected override void StartVehicle() => Console.WriteLine("Bike Started");
        protected override void Drive() => Console.WriteLine("Bike Driving");
        protected override void StopVehicle() => Console.WriteLine("Bike Stopped");
    }

    public class TruckType : VehicleType
    {
        protected override void StartVehicle() => Console.WriteLine("Truck Started");
        protected override void Drive() => Console.WriteLine("Truck Driving");
        protected override void StopVehicle() => Console.WriteLine("Truck Stopped");
    }
}
