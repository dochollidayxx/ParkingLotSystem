using ParkingLotSystem.Core.Enums;
using ParkingLotSystem.Core.Models;
using Xunit;

namespace ParkingLotSystem.Tests;

public class VehicleTests
{
    [Fact]
    public void Motorcycle_GetCompatibleSpaceSizes_ShouldReturnAllSizes()
    {
        // Arrange
        var motorcycle = new Motorcycle("MC001");
        
        // Act
        var compatibleSizes = motorcycle.GetCompatibleSpaceSizes();
        
        // Assert
        Assert.Contains(SpaceSize.Small, compatibleSizes);
        Assert.Contains(SpaceSize.Medium, compatibleSizes);
        Assert.Contains(SpaceSize.Large, compatibleSizes);
        Assert.Equal(3, compatibleSizes.Count);
    }

    [Fact]
    public void Car_GetCompatibleSpaceSizes_ShouldReturnMediumAndLarge()
    {
        // Arrange
        var car = new Car("CAR001");
        
        // Act
        var compatibleSizes = car.GetCompatibleSpaceSizes();
        
        // Assert
        Assert.DoesNotContain(SpaceSize.Small, compatibleSizes);
        Assert.Contains(SpaceSize.Medium, compatibleSizes);
        Assert.Contains(SpaceSize.Large, compatibleSizes);
        Assert.Equal(2, compatibleSizes.Count);
    }

    [Fact]
    public void Truck_GetCompatibleSpaceSizes_ShouldReturnOnlyLarge()
    {
        // Arrange
        var truck = new Truck("TRK001");
        
        // Act
        var compatibleSizes = truck.GetCompatibleSpaceSizes();
        
        // Assert
        Assert.DoesNotContain(SpaceSize.Small, compatibleSizes);
        Assert.DoesNotContain(SpaceSize.Medium, compatibleSizes);
        Assert.Contains(SpaceSize.Large, compatibleSizes);
        Assert.Single(compatibleSizes);
    }

    [Fact]
    public void Vehicle_Constructor_ShouldSetProperties()
    {
        // Arrange & Act
        var motorcycle = new Motorcycle("MC001");
        var car = new Car("CAR001");
        var truck = new Truck("TRK001");
        
        // Assert
        Assert.Equal("MC001", motorcycle.LicensePlate);
        Assert.Equal(VehicleType.Motorcycle, motorcycle.Type);
        
        Assert.Equal("CAR001", car.LicensePlate);
        Assert.Equal(VehicleType.Car, car.Type);
        
        Assert.Equal("TRK001", truck.LicensePlate);
        Assert.Equal(VehicleType.Truck, truck.Type);
    }

    [Fact]
    public void Vehicle_Constructor_WithEmptyLicensePlate_ShouldThrowException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Motorcycle(""));
        Assert.Throws<ArgumentException>(() => new Car(""));
        Assert.Throws<ArgumentException>(() => new Truck(""));
    }

    [Fact]
    public void Vehicle_Constructor_WithNullLicensePlate_ShouldThrowException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Motorcycle(null!));
        Assert.Throws<ArgumentNullException>(() => new Car(null!));
        Assert.Throws<ArgumentNullException>(() => new Truck(null!));
    }
}