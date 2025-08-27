using ParkingLotSystem.Core.Enums;
using ParkingLotSystem.Core.Exceptions;
using ParkingLotSystem.Core.Models;
using Xunit;

namespace ParkingLotSystem.Tests;

public class ParkingSpaceTests
{
    [Fact]
    public void ParkingSpace_Constructor_ShouldInitializeCorrectly()
    {
        // Arrange & Act
        var space = new ParkingSpace("S001", SpaceSize.Small);
        
        // Assert
        Assert.Equal("S001", space.Id);
        Assert.Equal(SpaceSize.Small, space.Size);
        Assert.False(space.IsOccupied);
        Assert.Null(space.CurrentVehicle);
    }

    [Fact]
    public void ParkVehicle_InEmptySpace_ShouldSucceed()
    {
        // Arrange
        var space = new ParkingSpace("M001", SpaceSize.Medium);
        var car = new Car("CAR001");
        
        // Act
        space.ParkVehicle(car);
        
        // Assert
        Assert.True(space.IsOccupied);
        Assert.NotNull(space.CurrentVehicle);
        Assert.Equal("CAR001", space.CurrentVehicle.LicensePlate);
    }

    [Fact]
    public void ParkVehicle_InOccupiedSpace_ShouldThrowException()
    {
        // Arrange
        var space = new ParkingSpace("L001", SpaceSize.Large);
        var truck1 = new Truck("TRK001");
        var truck2 = new Truck("TRK002");
        
        // Act
        space.ParkVehicle(truck1);
        
        // Assert
        Assert.Throws<SpaceOccupiedException>(() => space.ParkVehicle(truck2));
    }

    [Fact]
    public void RemoveVehicle_FromOccupiedSpace_ShouldReturnVehicle()
    {
        // Arrange
        var space = new ParkingSpace("S001", SpaceSize.Small);
        var motorcycle = new Motorcycle("MC001");
        space.ParkVehicle(motorcycle);
        
        // Act
        var removedVehicle = space.RemoveVehicle();
        
        // Assert
        Assert.NotNull(removedVehicle);
        Assert.Equal("MC001", removedVehicle.LicensePlate);
        Assert.False(space.IsOccupied);
        Assert.Null(space.CurrentVehicle);
    }

    [Fact]
    public void RemoveVehicle_FromEmptySpace_ShouldThrowException()
    {
        // Arrange
        var space = new ParkingSpace("M001", SpaceSize.Medium);
        
        // Act & Assert
        Assert.Throws<ParkingException>(() => space.RemoveVehicle());
    }

    [Fact]
    public void CanFitVehicle_Motorcycle_ShouldFitInAnySpace()
    {
        // Arrange
        var smallSpace = new ParkingSpace("S001", SpaceSize.Small);
        var mediumSpace = new ParkingSpace("M001", SpaceSize.Medium);
        var largeSpace = new ParkingSpace("L001", SpaceSize.Large);
        var motorcycle = new Motorcycle("MC001");
        
        // Act & Assert
        Assert.True(smallSpace.CanFitVehicle(motorcycle));
        Assert.True(mediumSpace.CanFitVehicle(motorcycle));
        Assert.True(largeSpace.CanFitVehicle(motorcycle));
    }

    [Fact]
    public void CanFitVehicle_Car_ShouldOnlyFitInMediumOrLarge()
    {
        // Arrange
        var smallSpace = new ParkingSpace("S001", SpaceSize.Small);
        var mediumSpace = new ParkingSpace("M001", SpaceSize.Medium);
        var largeSpace = new ParkingSpace("L001", SpaceSize.Large);
        var car = new Car("CAR001");
        
        // Act & Assert
        Assert.False(smallSpace.CanFitVehicle(car));
        Assert.True(mediumSpace.CanFitVehicle(car));
        Assert.True(largeSpace.CanFitVehicle(car));
    }

    [Fact]
    public void CanFitVehicle_Truck_ShouldOnlyFitInLarge()
    {
        // Arrange
        var smallSpace = new ParkingSpace("S001", SpaceSize.Small);
        var mediumSpace = new ParkingSpace("M001", SpaceSize.Medium);
        var largeSpace = new ParkingSpace("L001", SpaceSize.Large);
        var truck = new Truck("TRK001");
        
        // Act & Assert
        Assert.False(smallSpace.CanFitVehicle(truck));
        Assert.False(mediumSpace.CanFitVehicle(truck));
        Assert.True(largeSpace.CanFitVehicle(truck));
    }

    [Fact]
    public void CanFitVehicle_OccupiedSpace_ShouldReturnFalse()
    {
        // Arrange
        var space = new ParkingSpace("M001", SpaceSize.Medium);
        var car1 = new Car("CAR001");
        var car2 = new Car("CAR002");
        space.ParkVehicle(car1);
        
        // Act & Assert
        Assert.False(space.CanFitVehicle(car2));
    }
}