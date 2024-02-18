namespace ParkingLot
{
    public class FloorSelectionService
    {
        /* While the problem statement suggests that the order of rule execution doesn't matter and in that case IEnumerable 
         * is utilized, certain rules may have precedence over others. For instance, the electric car specific rule, 
         * which dictates where electric cars can be parked, likely needs to be applied before other rules. 
         * This implies a sequential order of execution. In such cases, employing the Chain of Responsibility (CoR) pattern
         * could provide a clearer structure. Although we're presently concentrating on the detailed description of one rule, 
         * it's essential to consider how it fits within the broader context of rule interactions. */
        private readonly IEnumerable<IFloorSelectionRule> _rules;
        private readonly IEnumerable<ParkingFloor> _parkingFloors;

        public FloorSelectionService(IEnumerable<IFloorSelectionRule> rules, 
            IEnumerable<ParkingFloor> parkingFloors)
        {
            _rules = rules;
            _parkingFloors = parkingFloors;
        }

        /* It is worth noting that due to limited domain context it's not clear whether we should return only the selected
         * parking floor or some sort of selection result which defines whether the boom barrier opens or not.
         * For the simplicity of the problem first not null selected parking floor is returned */
        public ParkingFloor? SelectParkingFloor(Vehicle vehicle, ParkingFloor approachedFloor)
        {
            var selectedFloors = _rules.Select(rule => rule.SelectFloor(vehicle, approachedFloor, _parkingFloors));

            return selectedFloors.FirstOrDefault(floor => floor != null);
        }
    }
}
