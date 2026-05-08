using System;

namespace Vehicle_Domain
{
    // Abstract Factory
    public abstract class VehicleTypeCreator
    {
        // Factory Method
        public abstract VehicleType CreateVehicleType();

        // Template workflow
        public void Show()
        {
            VehicleType vehicle = CreateVehicleType();
            vehicle.ShowVehicleDetails();
        }
    }
}
