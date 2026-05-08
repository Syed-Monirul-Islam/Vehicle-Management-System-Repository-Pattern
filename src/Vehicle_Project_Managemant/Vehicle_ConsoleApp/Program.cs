using System;
using Vehicle_Domain;
using Vehicle_Repository;

namespace Vehicle_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRun = true;
            while (isRun)
            {
                Console.Clear();
                Console.WriteLine("=============== VEHICLE MANAGEMENT SYSTEM ===============");
                Console.WriteLine("1. Vehicles (Factory Pattern)");
                Console.WriteLine("2. Manage Vehicle Types (Factory Method Pattern)");
                Console.WriteLine("3. Exit");
                Console.Write("\nSelect Option: ");

                string inputKey = Console.ReadLine();
                Console.Clear();

                switch (inputKey)
                {
                    case "1":
                        ManageVehicles();
                        break;
                    case "2":
                        ManageVehicleTypes();
                        break;
                    case "3":
                        isRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option! Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ManageVehicles()
        {
            bool vehicleRun = true;
            var source = RepositoryFactory.Create<IVehicleRepository>(ContextTypes.XMLSource);

            while (vehicleRun)
            {
                Console.Clear();
                Console.WriteLine("========== Vehicle (Factory Pattern) ==========");
                Console.WriteLine("1. View All Vehicles");
                Console.WriteLine("2. Add Vehicle");
                Console.WriteLine("3. Update Vehicle");
                Console.WriteLine("4. Delete Vehicle");
                Console.WriteLine("B. Back");
                Console.Write("\nSelect Option: ");

                string choice = Console.ReadLine()?.ToUpper();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        ViewVehicles(source);
                        break;
                    case "2":
                        AddVehicle(source);
                        break;
                    case "3":
                        UpdateVehicle(source);
                        break;
                    case "4":
                        DeleteVehicle(source);
                        break;
                    case "B":
                        vehicleRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option! Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ViewVehicles(IVehicleRepository source)
        {
            var items = source.GetAll();
            Console.WriteLine("=========== Vehicle List ===========");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.ID} | {item.VehicleName}, {item.Brand}, {item.ModelYear}, {item.RegistrationNo}");
            }
            Console.WriteLine("\nPress any key to go back...");
            Console.ReadKey();
        }

        static void AddVehicle(IVehicleRepository source)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========== Add Vehicle ==========");
                Console.WriteLine("B. Back to Vehicle Menu");

                Console.Write("Vehicle Name: ");
                string name = Console.ReadLine();
                if (name.ToUpper() == "B") break;

                Console.Write("Brand: ");
                string brand = Console.ReadLine();
                if (brand.ToUpper() == "B") break;

                Console.Write("Model Year: ");
                string year = Console.ReadLine();
                if (year.ToUpper() == "B") break;

                Console.Write("Registration No: ");
                string reg = Console.ReadLine();
                if (reg.ToUpper() == "B") break;

                Vehicle vh = new Vehicle
                {
                    VehicleName = name,
                    Brand = brand,
                    ModelYear = year,
                    RegistrationNo = reg
                };

                try
                {
                    source.Insert(vh);
                    Console.WriteLine("\nVehicle Added Successfully! (Factory Pattern)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nError: " + ex.Message);
                }

                Console.WriteLine("\nPress any key to continue adding or B to back...");
                string backCheck = Console.ReadLine();
                if (backCheck.ToUpper() == "B") break;
            }
        }

        static void UpdateVehicle(IVehicleRepository source)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========== Update Vehicle ==========");
                Console.WriteLine("B. Back to Vehicle Menu");

                Console.Write("Enter Vehicle ID to Update: ");
                string input = Console.ReadLine();
                if (input.ToUpper() == "B") break;

                if (int.TryParse(input, out int id))
                {
                    var vehicle = source.Get(id);
                    if (vehicle != null)
                    {
                        Console.Write($"Vehicle Name ({vehicle.VehicleName}): ");
                        string name = Console.ReadLine();
                        if (!string.IsNullOrEmpty(name)) vehicle.VehicleName = name;

                        Console.Write($"Brand ({vehicle.Brand}): ");
                        string brand = Console.ReadLine();
                        if (!string.IsNullOrEmpty(brand)) vehicle.Brand = brand;

                        Console.Write($"Model Year ({vehicle.ModelYear}): ");
                        string year = Console.ReadLine();
                        if (!string.IsNullOrEmpty(year)) vehicle.ModelYear = year;

                        Console.Write($"Registration No ({vehicle.RegistrationNo}): ");
                        string reg = Console.ReadLine();
                        if (!string.IsNullOrEmpty(reg)) vehicle.RegistrationNo = reg;

                        if (source.Update(vehicle))
                            Console.WriteLine("\nVehicle Updated Successfully!");
                        else
                            Console.WriteLine("\nUpdate Failed!");
                    }
                    else
                    {
                        Console.WriteLine("Vehicle not found!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID!");
                }

                Console.WriteLine("\nPress any key to continue or B to back...");
                string backCheck = Console.ReadLine();
                if (backCheck.ToUpper() == "B") break;
            }
        }

        static void DeleteVehicle(IVehicleRepository source)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========== Delete Vehicle ==========");
                Console.WriteLine("B. Back to Vehicle Menu");

                Console.Write("Enter Vehicle ID to Delete: ");
                string input = Console.ReadLine();
                if (input.ToUpper() == "B") break;

                if (int.TryParse(input, out int id))
                {
                    if (source.Delete(id))
                        Console.WriteLine("Vehicle Deleted Successfully!");
                    else
                        Console.WriteLine("Vehicle not found or delete failed!");
                }
                else
                {
                    Console.WriteLine("Invalid ID!");
                }

                Console.WriteLine("\nPress any key to continue or B to back...");
                string backCheck = Console.ReadLine();
                if (backCheck.ToUpper() == "B") break;
            }
        }

        static void ManageVehicleTypes()
        {
            bool typeRun = true;
            while (typeRun)
            {
                Console.Clear();
                Console.WriteLine("=========== Vehicle Type  (Factory Method Pattern) ===========");
                Console.WriteLine("1. Car");
                Console.WriteLine("2. Bike");
                Console.WriteLine("3. Truck");
                Console.WriteLine("B. Back");
                Console.Write("\nEnter choice: ");

                string choice = Console.ReadLine()?.ToUpper();
                VehicleTypeCreator creator = null;

                switch (choice)
                {
                    case "1":
                        creator = new CarCreator();
                        break;
                    case "2":
                        creator = new BikeCreator();
                        break;
                    case "3":
                        creator = new TruckCreator();
                        break;
                    case "B":
                        typeRun = false;
                        continue;
                    default:
                        creator = null;
                        break;
                }

                if (creator != null)
                {
                    creator.Show();   
                    Console.WriteLine("\nPress any key to go back...");
                    Console.ReadKey();
                }
                else if (choice != "B")
                {
                    Console.WriteLine("Invalid option!");
                    Console.ReadKey();
                }
            }
        }
    }
}
