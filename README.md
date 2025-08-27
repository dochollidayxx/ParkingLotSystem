# Parking Lot System - Coding Challenge

## Overview
Design and implement a parking management system for a multi-level parking lot. This system should handle vehicle parking, tracking, and provide various management capabilities.

## Problem Statement

You are tasked with implementing a parking lot management system with the following requirements:

### Core Requirements

1. **Parking Space Management**
   - The parking lot has **3 types of parking spaces**: `Large`, `Medium`, and `Small`
   - Each type has a fixed number of available slots
   - Vehicles must be parked in appropriately sized spaces (or larger if their size is unavailable)

2. **Vehicle Types**
   - Support 3 vehicle types: `Motorcycle`, `Car`, and `Truck`
   - Motorcycles can park in any size space
   - Cars can park in Medium or Large spaces
   - Trucks can only park in Large spaces

3. **Core Operations**
   - `ParkVehicle`: Park a vehicle and return a parking ticket
   - `UnparkVehicle`: Remove a vehicle using its ticket ID
   - `GetAvailableSpaces`: Get count of available spaces by type
   - `IsFull`: Check if the parking lot is completely full

4. **Parking Ticket System**
   - Generate unique ticket IDs
   - Track parking start time
   - Calculate parking duration
   - Store vehicle and space information

### Additional Requirements (Implement at least 2)

5. **Fee Calculation**
   - Implement hourly rate-based fee calculation
   - Different rates for different vehicle types
   - Support for partial hour billing

6. **Search Capabilities**
   - Find a vehicle by license plate
   - Get all vehicles of a specific type
   - Get parking history for a time period

7. **Statistics & Reporting**
   - Track peak usage times
   - Calculate occupancy rate
   - Generate daily summary reports

## Your Task

1. **Complete the implementation** of the classes in the `src/ParkingLotSystem.Core` folder
2. **Fix all failing unit tests** in the `tests/ParkingLotSystem.Tests` folder
3. **Add at least 2 additional features** from the Additional Requirements section
4. **Write tests** for any new features you implement

## Project Structure

```
ParkingLotSystem/
├── src/
│   └── ParkingLotSystem.Core/
│       ├── Models/
│       │   ├── Vehicle.cs
│       │   ├── ParkingSpace.cs
│       │   └── ParkingTicket.cs
│       ├── Services/
│       │   ├── IParkingLotService.cs
│       │   └── ParkingLotService.cs
│       └── Exceptions/
│           └── ParkingException.cs
└── tests/
    └── ParkingLotSystem.Tests/
        ├── ParkingLotServiceTests.cs
        └── FeeCalculationTests.cs
```

## Getting Started

1. Clone this repository
2. Open the solution in Visual Studio or VS Code
3. Build the solution: `dotnet build`
4. Run the tests: `dotnet test`
5. Implement the missing functionality to make all tests pass

## Evaluation Criteria

Your solution will be evaluated based on:

1. **Correctness**: All unit tests pass
2. **Code Quality**: Clean, readable, and maintainable code
3. **Design**: Good use of OOP principles and design patterns
4. **Error Handling**: Appropriate exception handling and validation
5. **Testing**: Comprehensive test coverage for new features
6. **Performance**: Efficient algorithms and data structures
7. **Documentation**: Clear code comments and documentation

## Time Limit

You have **90 minutes** to complete this challenge.

## Submission

1. Ensure all tests pass
2. Commit your changes with meaningful commit messages
3. Push to your fork or create a pull request

Good luck!