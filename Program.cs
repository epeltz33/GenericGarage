using System;
using System.Collections.Generic;

namespace GenericGarage
{
    // Part 1: Defining the Vehicle with common properties
    public class Vehicle
    {
        // Common properties for all vehicles
        public string Make { get; set; }
        public string Model { get; set; }

        // Constructor to initialize common properties
        public Vehicle(string make, string model)
        {
            Make = make;
            Model = model;
        }

        // Virtual method to display vehicle information
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Vehicle Make: {Make}, Model: {Model}");
        }
    }

    // Derived class Car, inherits from Vehicle
    public class Car : Vehicle
    {
        // Unique property for Car
        public int Year { get; set; }

        // Constructor to initialize Car properties
        public Car(string make, string model, int year) : base(make, model)
        {
            Year = year;
        }

        // Override DisplayInfo to include Car specific info
        public override void DisplayInfo()
        {
            Console.WriteLine($"Car Make: {Make}, Model: {Model}, Year: {Year}");
        }
    }

    // Derived class Motorcycle, inherits from Vehicle
    public class Motorcycle : Vehicle
    {
        // Unique property for Motorcycle
        public bool HasSidecar { get; set; }

        // Constructor to initialize Motorcycle properties
        public Motorcycle(string make, string model, bool hasSidecar)
            : base(make, model)
        {
            HasSidecar = hasSidecar;
        }

        // Override DisplayInfo to include Motorcycle-specific information
        public override void DisplayInfo()
        {
            Console.WriteLine($"Motorcycle Make: {Make}, Model: {Model}, Has Sidecar: {HasSidecar}");
        }
    }

    // Derived class Bicycle, inherits from Vehicle
    public class Bicycle : Vehicle
    {
        // Unique property for Bicycle
        public string Type { get; set; } // e.g., road, mountain

        // Constructor to initialize Bicycle properties
        public Bicycle(string make, string model, string type)
            : base(make, model)
        {
            Type = type;
        }

        // Override DisplayInfo to include Bicycle-specific information
        public override void DisplayInfo()
        {
            Console.WriteLine($"Bicycle Make: {Make}, Model: {Model}, Type: {Type}");
        }
    }

    // Part 2: The Generic Garage
    // Generic Garage class that stores vehicles of type T
    public class GenericGarage<T> where T : Vehicle
    {
        // Internal list to store vehicles
        private List<T> vehicles;

        // Constructor to initialize the internal list
        public GenericGarage()
        {
            vehicles = new List<T>();
        }

        // Method to add a vehicle to the garage
        public void AddVehicle(T vehicle)
        {
            // Bonus Challenge: Check if vehicle already exists
            if (vehicles.Exists(v => v.Make == vehicle.Make && v.Model == vehicle.Model))
            {
                Console.WriteLine($"The vehicle {vehicle.Make} {vehicle.Model} already exists in the garage.");
            }
            else
            {
                vehicles.Add(vehicle);
                Console.WriteLine($"Added {vehicle.Make} {vehicle.Model} to the garage.");
            }
        }

        // Method to remove a vehicle from the garage by make and model
        public void RemoveVehicle(string make, string model)
        {
            // Find the vehicle in the list
            T vehicleToRemove = vehicles.Find(v => v.Make == make && v.Model == model);

            if (vehicleToRemove != null)
            {
                vehicles.Remove(vehicleToRemove);
                Console.WriteLine($"Removed {make} {model} from the garage.");
            }
            else
            {
                Console.WriteLine($"Vehicle {make} {model} not found in the garage.");
            }
        }

        // Method to display all vehicles in the garage
        public void DisplayVehicles()
        {
            if (vehicles.Count == 0)
            {
                Console.WriteLine("The garage is empty.");
            }
            else
            {
                Console.WriteLine("Vehicles currently in the garage:");
                foreach (T vehicle in vehicles)
                {
                    vehicle.DisplayInfo();
                }
            }
        }
    }

    // Part 3: Testing the Garage
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of GenericGarage<Vehicle>
            GenericGarage<Vehicle> garage = new GenericGarage<Vehicle>();

            // Adding vehicles to the garage

            // Create Car objects
            Car car1 = new Car("Toyota", "Corolla", 2020);
            Car car2 = new Car("Porsche", "911", 2019);

            // Create Motorcycle objects
            Motorcycle motorcycle1 = new Motorcycle("Harley-Davidson", "Street 750", false);
            Motorcycle motorcycle2 = new Motorcycle("Ducati", "Panigale V4", false);

            // Create Bicycle objects
            Bicycle bicycle1 = new Bicycle("Giant", "Defy Advanced", "Road");
            Bicycle bicycle2 = new Bicycle("Trek", "Marlin 7", "Mountain");

            // Add vehicles to the garage
            garage.AddVehicle(car1);
            garage.AddVehicle(car2);
            garage.AddVehicle(motorcycle1);
            garage.AddVehicle(motorcycle2);
            garage.AddVehicle(bicycle1);
            garage.AddVehicle(bicycle2);

            // Attempt to add a duplicate vehicle (bonus challenge)
            garage.AddVehicle(car1); // Should not add and display a message

            // Display all vehicles in the garage
            garage.DisplayVehicles();

            Console.WriteLine();

            // Remove a specific vehicle by make and model
            garage.RemoveVehicle("Honda", "Civic"); // Remove car2

            // Attempt to remove a vehicle that doesn't exist
            garage.RemoveVehicle("Tesla", "Model S"); // Should display not found message

            Console.WriteLine();

            // Display remaining vehicles in the garage
            garage.DisplayVehicles();

            Console.ReadLine(); // Wait for user input before closing
        }
    }
}
