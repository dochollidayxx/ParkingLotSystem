using ParkingLotSystem.Core.Enums;
using ParkingLotSystem.Core.Models;

namespace ParkingLotSystem.Core.Services;

public interface IParkingLotService
{
    // Core operations
    ParkingTicket ParkVehicle(Vehicle vehicle);
    Vehicle UnparkVehicle(string ticketId);
    Dictionary<SpaceSize, int> GetAvailableSpaces();
    bool IsFull();
    
    // Additional operations
    Vehicle? FindVehicleByLicensePlate(string licensePlate);
    List<Vehicle> GetAllVehiclesOfType(VehicleType type);
    decimal CalculateParkingFee(string ticketId);
    
    // Statistics
    int GetTotalCapacity();
    int GetOccupiedSpaces();
    double GetOccupancyRate();
}