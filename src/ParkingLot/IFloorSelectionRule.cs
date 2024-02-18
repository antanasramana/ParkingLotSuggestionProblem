namespace ParkingLot
{
    public interface IFloorSelectionRule
    {
        ParkingFloor? SelectFloor(Vehicle vehicle, 
            ParkingFloor approachedFloor, 
            IEnumerable<ParkingFloor> parkingFloors);
    }
}
