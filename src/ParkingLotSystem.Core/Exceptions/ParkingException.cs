namespace ParkingLotSystem.Core.Exceptions;

public class ParkingException : Exception
{
    public ParkingException(string message) : base(message)
    {
    }

    public ParkingException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

public class NoAvailableSpaceException : ParkingException
{
    public NoAvailableSpaceException() : base("No available parking spaces for this vehicle type")
    {
    }

    public NoAvailableSpaceException(string vehicleType) : base($"No available parking spaces for {vehicleType}")
    {
    }
}

public class InvalidTicketException : ParkingException
{
    // TODO: Implement InvalidTicketException
    public InvalidTicketException(string message) : base(message)
    {
    }
}

public class SpaceOccupiedException : ParkingException
{
    // TODO: Implement SpaceOccupiedException
    public SpaceOccupiedException(string message) : base(message)
    {
    }
}