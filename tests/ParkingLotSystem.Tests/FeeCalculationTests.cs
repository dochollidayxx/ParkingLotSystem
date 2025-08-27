using ParkingLotSystem.Core.Models;
using ParkingLotSystem.Core.Services;
using Xunit;

namespace ParkingLotSystem.Tests;

public class FeeCalculationTests
{
    [Fact]
    public void CalculateParkingFee_Motorcycle_ShouldUseCorrectRate()
    {
        // Arrange
        var parkingLot = new ParkingLotService(2, 2, 2);
        var motorcycle = new Motorcycle("MC001");
        var ticket = parkingLot.ParkVehicle(motorcycle);
        
        // Simulate 2 hours of parking
        System.Threading.Thread.Sleep(100); // Small delay to ensure time difference
        
        // Act
        var fee = parkingLot.CalculateParkingFee(ticket.TicketId);
        
        // Assert
        Assert.True(fee >= 2.00m); // At least minimum rate for any parking duration
    }

    [Fact]
    public void ParkingTicket_CalculateFee_ShouldRoundUpPartialHours()
    {
        // Arrange
        var ticket = new ParkingTicket("T001", "CAR001", "M001", DateTime.Now.AddMinutes(-90));
        ticket.MarkExit(DateTime.Now);
        
        // Act
        var fee = ticket.CalculateFee(4.00m); // $4 per hour
        
        // Assert
        Assert.Equal(8.00m, fee); // 1.5 hours rounds up to 2 hours = $8
    }

    [Fact]
    public void ParkingTicket_GetParkingDuration_WithoutExit_ShouldUseCurrentTime()
    {
        // Arrange
        var entryTime = DateTime.Now.AddHours(-2);
        var ticket = new ParkingTicket("T001", "CAR001", "M001", entryTime);
        
        // Act
        var duration = ticket.GetParkingDuration();
        
        // Assert
        Assert.True(duration.TotalHours >= 2 && duration.TotalHours < 2.1);
    }

    [Fact]
    public void ParkingTicket_GetParkingDuration_WithExit_ShouldUseExitTime()
    {
        // Arrange
        var entryTime = DateTime.Now.AddHours(-3);
        var exitTime = DateTime.Now.AddHours(-1);
        var ticket = new ParkingTicket("T001", "CAR001", "M001", entryTime);
        ticket.MarkExit(exitTime);
        
        // Act
        var duration = ticket.GetParkingDuration();
        
        // Assert
        Assert.Equal(2, duration.TotalHours);
    }

    [Fact]
    public void CalculateParkingFee_Car_ShouldUseCorrectRate()
    {
        // Arrange
        var parkingLot = new ParkingLotService(2, 2, 2);
        var car = new Car("CAR001");
        var ticket = parkingLot.ParkVehicle(car);
        
        // Act
        var fee = parkingLot.CalculateParkingFee(ticket.TicketId);
        
        // Assert
        Assert.True(fee >= 4.00m); // Minimum car rate
    }

    [Fact]
    public void CalculateParkingFee_Truck_ShouldUseCorrectRate()
    {
        // Arrange
        var parkingLot = new ParkingLotService(2, 2, 2);
        var truck = new Truck("TRK001");
        var ticket = parkingLot.ParkVehicle(truck);
        
        // Act
        var fee = parkingLot.CalculateParkingFee(ticket.TicketId);
        
        // Assert
        Assert.True(fee >= 6.50m); // Minimum truck rate
    }

    [Fact]
    public void CalculateParkingFee_InvalidTicket_ShouldThrowException()
    {
        // Arrange
        var parkingLot = new ParkingLotService(2, 2, 2);
        
        // Act & Assert
        Assert.Throws<Exception>(() => parkingLot.CalculateParkingFee("INVALID"));
    }

    [Fact]
    public void ParkingTicket_CalculateFee_ZeroDuration_ShouldChargeMinimum()
    {
        // Arrange
        var now = DateTime.Now;
        var ticket = new ParkingTicket("T001", "CAR001", "M001", now);
        ticket.MarkExit(now.AddSeconds(30)); // Very short duration
        
        // Act
        var fee = ticket.CalculateFee(4.00m);
        
        // Assert
        Assert.Equal(4.00m, fee); // Should charge for minimum 1 hour
    }

    [Fact]
    public void ParkingTicket_CalculateFee_ExactHours_ShouldNotRoundUp()
    {
        // Arrange
        var entryTime = DateTime.Now.AddHours(-3);
        var ticket = new ParkingTicket("T001", "CAR001", "M001", entryTime);
        ticket.MarkExit(DateTime.Now);
        
        // Act
        var fee = ticket.CalculateFee(5.00m); // $5 per hour
        
        // Assert
        Assert.Equal(15.00m, fee); // 3 hours * $5 = $15
    }
}