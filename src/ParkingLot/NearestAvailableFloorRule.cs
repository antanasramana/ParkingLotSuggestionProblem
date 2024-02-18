namespace ParkingLot
{
    public class NearestAvailableFloorRule : IFloorSelectionRule
    {
        public ParkingFloor? SelectFloor(Vehicle vehicle, 
            ParkingFloor approachedFloor, 
            IEnumerable<ParkingFloor> parkingFloors)
        {
            return parkingFloors.Where(floor => floor.AvailableSpaces > 0)
                .MinBy(floor => FloorDistance(approachedFloor, floor));
        }

        private static int FloorDistance(ParkingFloor approachedFloor, ParkingFloor floor)
        {
            return Math.Abs(approachedFloor.Level - floor.Level);
        }
    }
}
