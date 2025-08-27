using ParkingLotSystem.Core.Enums;
using ParkingLotSystem.Core.Exceptions;
using ParkingLotSystem.Core.Models;

namespace ParkingLotSystem.Core.Services;

public class ParkingLotService : IParkingLotService
{
    private readonly Dictionary<SpaceSize, List<ParkingSpace>> _spaces;
    private readonly Dictionary<string, ParkingTicket> _activeTickets;
    private readonly Dictionary<VehicleType, decimal> _hourlyRates;
    private int _ticketCounter;

    public ParkingLotService(int smallSpaces, int mediumSpaces, int largeSpaces)
    {
        _spaces = new Dictionary<SpaceSize, List<ParkingSpace>>();
        _activeTickets = new Dictionary<string, ParkingTicket>();
        _ticketCounter = 1000;
        
        // Initialize hourly rates
        _hourlyRates = new Dictionary<VehicleType, decimal>
        {
            { VehicleType.Motorcycle, 2.00m },
            { VehicleType.Car, 4.00m },
            { VehicleType.Truck, 6.50m }
        };

        // TODO: Initialize parking spaces based on the provided counts
        InitializeParkingSpaces(smallSpaces, mediumSpaces, largeSpaces);
    }

    private void InitializeParkingSpaces(int smallSpaces, int mediumSpaces, int largeSpaces)
    {
        // TODO: Create parking spaces for each size category
        // Small spaces: S001, S002, etc.
        // Medium spaces: M001, M002, etc.
        // Large spaces: L001, L002, etc.
        throw new NotImplementedException();
    }

    public ParkingTicket ParkVehicle(Vehicle vehicle)
    {
        // TODO: Implement parking logic
        // 1. Validate input
        // 2. Find an available space that can fit the vehicle
        // 3. Park the vehicle in the space
        // 4. Create and return a parking ticket
        // 5. Store the ticket in _activeTickets
        throw new NotImplementedException();
    }

    public Vehicle UnparkVehicle(string ticketId)
    {
        // TODO: Implement unparking logic
        // 1. Validate ticket exists
        // 2. Find the parked vehicle and space
        // 3. Remove vehicle from space
        // 4. Mark ticket as completed (set exit time)
        // 5. Remove ticket from _activeTickets
        // 6. Return the vehicle
        throw new NotImplementedException();
    }

    public Dictionary<SpaceSize, int> GetAvailableSpaces()
    {
        // TODO: Return count of available spaces for each size
        throw new NotImplementedException();
    }

    public bool IsFull()
    {
        // TODO: Check if all spaces are occupied
        throw new NotImplementedException();
    }

    public Vehicle? FindVehicleByLicensePlate(string licensePlate)
    {
        // TODO: Search for a vehicle by license plate
        throw new NotImplementedException();
    }

    public List<Vehicle> GetAllVehiclesOfType(VehicleType type)
    {
        // TODO: Return all currently parked vehicles of the specified type
        throw new NotImplementedException();
    }

    public decimal CalculateParkingFee(string ticketId)
    {
        // TODO: Calculate the parking fee for a given ticket
        // Use the hourly rates defined in _hourlyRates
        throw new NotImplementedException();
    }

    public int GetTotalCapacity()
    {
        // TODO: Return total number of parking spaces
        throw new NotImplementedException();
    }

    public int GetOccupiedSpaces()
    {
        // TODO: Return number of occupied spaces
        throw new NotImplementedException();
    }

    public double GetOccupancyRate()
    {
        // TODO: Calculate and return occupancy rate as a percentage
        throw new NotImplementedException();
    }

    private ParkingSpace? FindAvailableSpace(Vehicle vehicle)
    {
        // TODO: Find the first available space that can fit the vehicle
        // Should check spaces in order of preference (smallest suitable size first)
        throw new NotImplementedException();
    }

    private string GenerateTicketId()
    {
        return $"T{++_ticketCounter:D6}";
    }
}