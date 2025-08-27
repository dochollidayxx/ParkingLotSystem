using ParkingLotSystem.Core.Enums;
using ParkingLotSystem.Core.Exceptions;
using ParkingLotSystem.Core.Models;
using ParkingLotSystem.Core.Services;
using Xunit;

namespace ParkingLotSystem.Tests;

public class ParkingLotServiceTests
{
    private ParkingLotService CreateParkingLot(int small = 2, int medium = 2, int large = 2)
    {
        return new ParkingLotService(small, medium, large);
    }

    [Fact]
    public void ParkVehicle_Motorcycle_ShouldParkSuccessfully()
    {
        // Arrange
        var parkingLot = CreateParkingLot();
        var motorcycle = new Motorcycle("MC001");

        // Act
        var ticket = parkingLot.ParkVehicle(motorcycle);

        // Assert
        Assert.NotNull(ticket);
        Assert.Equal("MC001", ticket.LicensePlate);
        Assert.NotNull(ticket.TicketId);
        Assert.NotNull(ticket.SpaceId);
    }

    [Fact]
    public void ParkVehicle_Car_ShouldParkInMediumOrLargeSpace()
    {
        // Arrange
        var parkingLot = CreateParkingLot();
        var car = new Car("CAR001");

        // Act
        var ticket = parkingLot.ParkVehicle(car);
        var availableSpaces = parkingLot.GetAvailableSpaces();

        // Assert
        Assert.NotNull(ticket);
        Assert.True(availableSpaces[SpaceSize.Small] == 2); // Small spaces should be untouched
    }

    [Fact]
    public void ParkVehicle_Truck_ShouldOnlyParkInLargeSpace()
    {
        // Arrange
        var parkingLot = CreateParkingLot();
        var truck = new Truck("TRK001");

        // Act
        var ticket = parkingLot.ParkVehicle(truck);
        var availableSpaces = parkingLot.GetAvailableSpaces();

        // Assert
        Assert.NotNull(ticket);
        Assert.True(ticket.SpaceId.StartsWith("L")); // Should be in a large space
        Assert.Equal(1, availableSpaces[SpaceSize.Large]); // One large space used
    }

    [Fact]
    public void ParkVehicle_WhenNoSpaceAvailable_ShouldThrowException()
    {
        // Arrange
        var parkingLot = CreateParkingLot(0, 0, 1); // Only 1 large space
        var truck1 = new Truck("TRK001");
        var truck2 = new Truck("TRK002");

        // Act
        parkingLot.ParkVehicle(truck1);

        // Assert
        Assert.Throws<NoAvailableSpaceException>(() => parkingLot.ParkVehicle(truck2));
    }

    [Fact]
    public void UnparkVehicle_ValidTicket_ShouldReturnVehicle()
    {
        // Arrange
        var parkingLot = CreateParkingLot();
        var car = new Car("CAR001");
        var ticket = parkingLot.ParkVehicle(car);

        // Act
        var unparkedVehicle = parkingLot.UnparkVehicle(ticket.TicketId);

        // Assert
        Assert.NotNull(unparkedVehicle);
        Assert.Equal("CAR001", unparkedVehicle.LicensePlate);
    }

    [Fact]
    public void UnparkVehicle_InvalidTicket_ShouldThrowException()
    {
        // Arrange
        var parkingLot = CreateParkingLot();

        // Act & Assert
        Assert.Throws<InvalidTicketException>(() => parkingLot.UnparkVehicle("INVALID"));
    }

    [Fact]
    public void GetAvailableSpaces_ShouldReturnCorrectCounts()
    {
        // Arrange
        var parkingLot = CreateParkingLot(3, 4, 5);

        // Act
        var availableSpaces = parkingLot.GetAvailableSpaces();

        // Assert
        Assert.Equal(3, availableSpaces[SpaceSize.Small]);
        Assert.Equal(4, availableSpaces[SpaceSize.Medium]);
        Assert.Equal(5, availableSpaces[SpaceSize.Large]);
    }

    [Fact]
    public void GetAvailableSpaces_AfterParking_ShouldUpdateCounts()
    {
        // Arrange
        var parkingLot = CreateParkingLot(2, 2, 2);
        var motorcycle = new Motorcycle("MC001");
        var car = new Car("CAR001");

        // Act
        parkingLot.ParkVehicle(motorcycle);
        parkingLot.ParkVehicle(car);
        var availableSpaces = parkingLot.GetAvailableSpaces();

        // Assert
        Assert.True(availableSpaces.Values.Sum() == 4); // 2 spaces used out of 6
    }

    [Fact]
    public void IsFull_WhenNotFull_ShouldReturnFalse()
    {
        // Arrange
        var parkingLot = CreateParkingLot();

        // Act & Assert
        Assert.False(parkingLot.IsFull());
    }

    [Fact]
    public void IsFull_WhenCompletelyFull_ShouldReturnTrue()
    {
        // Arrange
        var parkingLot = CreateParkingLot(1, 1, 1);
        parkingLot.ParkVehicle(new Motorcycle("MC001"));
        parkingLot.ParkVehicle(new Car("CAR001"));
        parkingLot.ParkVehicle(new Truck("TRK001"));

        // Act & Assert
        Assert.True(parkingLot.IsFull());
    }

    [Fact]
    public void FindVehicleByLicensePlate_WhenExists_ShouldReturnVehicle()
    {
        // Arrange
        var parkingLot = CreateParkingLot();
        var car = new Car("CAR001");
        parkingLot.ParkVehicle(car);

        // Act
        var foundVehicle = parkingLot.FindVehicleByLicensePlate("CAR001");

        // Assert
        Assert.NotNull(foundVehicle);
        Assert.Equal("CAR001", foundVehicle.LicensePlate);
    }

    [Fact]
    public void FindVehicleByLicensePlate_WhenNotExists_ShouldReturnNull()
    {
        // Arrange
        var parkingLot = CreateParkingLot();

        // Act
        var foundVehicle = parkingLot.FindVehicleByLicensePlate("NOTEXIST");

        // Assert
        Assert.Null(foundVehicle);
    }

    [Fact]
    public void GetAllVehiclesOfType_ShouldReturnCorrectVehicles()
    {
        // Arrange
        var parkingLot = CreateParkingLot();
        parkingLot.ParkVehicle(new Car("CAR001"));
        parkingLot.ParkVehicle(new Car("CAR002"));
        parkingLot.ParkVehicle(new Motorcycle("MC001"));

        // Act
        var cars = parkingLot.GetAllVehiclesOfType(VehicleType.Car);

        // Assert
        Assert.Equal(2, cars.Count);
        Assert.All(cars, car => Assert.Equal(VehicleType.Car, car.Type));
    }

    [Fact]
    public void GetOccupancyRate_ShouldCalculateCorrectly()
    {
        // Arrange
        var parkingLot = CreateParkingLot(2, 2, 2); // Total 6 spaces
        parkingLot.ParkVehicle(new Car("CAR001"));
        parkingLot.ParkVehicle(new Motorcycle("MC001"));
        parkingLot.ParkVehicle(new Truck("TRK001"));

        // Act
        var occupancyRate = parkingLot.GetOccupancyRate();

        // Assert
        Assert.Equal(50.0, occupancyRate); // 3 out of 6 spaces = 50%
    }

    [Fact]
    public void GetTotalCapacity_ShouldReturnCorrectTotal()
    {
        // Arrange
        var parkingLot = CreateParkingLot(3, 4, 5);

        // Act
        var totalCapacity = parkingLot.GetTotalCapacity();

        // Assert
        Assert.Equal(12, totalCapacity); // 3 + 4 + 5 = 12
    }

    [Fact]
    public void ParkVehicle_DuplicateLicensePlate_ShouldThrowException()
    {
        // Arrange
        var parkingLot = CreateParkingLot();
        var car1 = new Car("CAR001");
        var car2 = new Car("CAR001"); // Same license plate

        // Act
        parkingLot.ParkVehicle(car1);

        // Assert
        Assert.Throws<ParkingException>(() => parkingLot.ParkVehicle(car2));
    }

    [Fact]
    public void Motorcycle_CanParkInAnySpace()
    {
        // Arrange
        var parkingLot = CreateParkingLot(1, 0, 0); // Only small spaces
        var motorcycle = new Motorcycle("MC001");

        // Act
        var ticket = parkingLot.ParkVehicle(motorcycle);

        // Assert
        Assert.NotNull(ticket);
        Assert.True(ticket.SpaceId.StartsWith("S")); // Should park in small space
    }

    [Fact]
    public void Car_CannotParkInSmallSpace()
    {
        // Arrange
        var parkingLot = CreateParkingLot(2, 0, 0); // Only small spaces
        var car = new Car("CAR001");

        // Act & Assert
        Assert.Throws<NoAvailableSpaceException>(() => parkingLot.ParkVehicle(car));
    }
}