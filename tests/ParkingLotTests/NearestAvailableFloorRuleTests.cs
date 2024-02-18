using FluentAssertions;
using ParkingLot;

namespace ParkingLotTests;

public class NearestAvailableFloorRuleTests
{
    private readonly Vehicle _vehicle = new();
    private readonly NearestAvailableFloorRule _rule = new();


    [Fact]
    public void SelectFloor_AvailableSpacesInSomeFloors_ReturnsNearestFloor()
    {
        // Arrange
        var floors = new List<ParkingFloor>
        {
            new() { Level = -2, AvailableSpaces = 1 },
            new() { Level = -1, AvailableSpaces = 0 },
            new() { Level = 0, AvailableSpaces = 0 },
            new() { Level = 1, AvailableSpaces = 0 },
            new() { Level = 2, AvailableSpaces = 0 },
            new() { Level = 3, AvailableSpaces = 1 },
        };

        var approachedFloor = new ParkingFloor { Level = 0 };

        // Act
        var selectedFloor = _rule.SelectFloor(_vehicle, approachedFloor, floors);

        // Assert
        const int expectedSelectedLevel = -2;

        selectedFloor.Should().NotBeNull();
        selectedFloor!.Level.Should().Be(expectedSelectedLevel);
    }

    [Fact]
    public void SelectFloor_AvailableSpacesInTheApproachedFloor_ReturnsSameApproachedFloor()
    {
        // Arrange
        const int approachedLevel = 4;
        var floors = new List<ParkingFloor>
        {
            new() { Level = approachedLevel, AvailableSpaces = 3 },
        };

        var approachedFloor = new ParkingFloor { Level = approachedLevel };

        // Act
        var selectedFloor = _rule.SelectFloor(_vehicle, approachedFloor, floors);

        // Assert
        selectedFloor.Should().NotBeNull();
        selectedFloor!.Level.Should().Be(approachedLevel);
    }

    [Fact]
    public void SelectFloor_NoAvailableSpacesInAnyFloor_ReturnsNull()
    {
        // Arrange
        var floors = new List<ParkingFloor>
        {
            new() { Level = 1, AvailableSpaces = 0 },
            new() { Level = 2, AvailableSpaces = 0 },
            new() { Level = 3, AvailableSpaces = 0 },
        };
        var approachedFloor = new ParkingFloor { Level = 2 };

        // Act
        var selectedFloor = _rule.SelectFloor(_vehicle, approachedFloor, floors);

        // Assert
        selectedFloor.Should().BeNull();
    }
}
