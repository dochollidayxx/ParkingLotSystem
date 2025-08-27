namespace ParkingLotSystem.Core.Models;

public class ParkingTicket
{
    public string TicketId { get; }
    public string LicensePlate { get; }
    public string SpaceId { get; }
    public DateTime EntryTime { get; }
    public DateTime? ExitTime { get; private set; }

    public ParkingTicket(string ticketId, string licensePlate, string spaceId, DateTime entryTime)
    {
        // TODO: Implement constructor
        throw new NotImplementedException();
    }

    public void MarkExit(DateTime exitTime)
    {
        // TODO: Set the exit time
        throw new NotImplementedException();
    }

    public TimeSpan GetParkingDuration()
    {
        // TODO: Calculate parking duration
        // If ExitTime is null, use current time
        throw new NotImplementedException();
    }

    public decimal CalculateFee(decimal hourlyRate)
    {
        // TODO: Calculate parking fee based on duration and hourly rate
        // Round up to the next hour for partial hours
        throw new NotImplementedException();
    }
}