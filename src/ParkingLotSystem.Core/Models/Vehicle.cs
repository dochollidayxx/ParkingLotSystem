using ParkingLotSystem.Core.Enums;

namespace ParkingLotSystem.Core.Models;

public abstract class Vehicle
{
    public string LicensePlate { get; }
    public VehicleType Type { get; }
    public DateTime EntryTime { get; set; }

    protected Vehicle(string licensePlate, VehicleType type)
    {
        // TODO: Implement constructor
        throw new NotImplementedException();
    }

    // TODO: Add method to determine which parking space sizes this vehicle can use
    public abstract List<SpaceSize> GetCompatibleSpaceSizes();
}

public class Motorcycle : Vehicle
{
    public Motorcycle(string licensePlate) : base(licensePlate, VehicleType.Motorcycle)
    {
    }

    public override List<SpaceSize> GetCompatibleSpaceSizes()
    {
        // TODO: Motorcycles can park in any size space
        throw new NotImplementedException();
    }
}

public class Car : Vehicle
{
    public Car(string licensePlate) : base(licensePlate, VehicleType.Car)
    {
    }

    public override List<SpaceSize> GetCompatibleSpaceSizes()
    {
        // TODO: Cars can park in Medium or Large spaces
        throw new NotImplementedException();
    }
}

public class Truck : Vehicle
{
    // TODO: Implement Truck class
    // Trucks can only park in Large spaces
    public Truck(string licensePlate) : base(licensePlate, VehicleType.Truck)
    {
    }

    public override List<SpaceSize> GetCompatibleSpaceSizes()
    {
        // TODO: Trucks can only park in Large spaces
        throw new NotImplementedException();
    }
}