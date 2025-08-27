using ParkingLotSystem.Core.Enums;

namespace ParkingLotSystem.Core.Models;

public class ParkingSpace
{
    public string Id { get; }
    public SpaceSize Size { get; }
    public bool IsOccupied { get; private set; }
    public Vehicle? CurrentVehicle { get; private set; }

    public ParkingSpace(string id, SpaceSize size)
    {
        Id = id;
        Size = size;
        IsOccupied = false;
        CurrentVehicle = null;
    }

    public void ParkVehicle(Vehicle vehicle)
    {
        // TODO: Implement parking logic
        // Should set IsOccupied to true and store the vehicle
        // Should throw exception if space is already occupied
        throw new NotImplementedException();
    }

    public Vehicle RemoveVehicle()
    {
        // TODO: Implement unparking logic
        // Should return the vehicle and mark space as available
        // Should throw exception if space is not occupied
        throw new NotImplementedException();
    }

    public bool CanFitVehicle(Vehicle vehicle)
    {
        // TODO: Check if this space can accommodate the given vehicle
        throw new NotImplementedException();
    }
}