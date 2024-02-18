# Parking Lot Suggestion System

Build a simple parking system skeleton for multi-floor parking lot which suggests the nearest floor where to drive by floor occupancy level (other rules might be added later, e.g. such as electric cars could park only on specific floors. Rules execution order or dependencies does not matter).

## Notes:

- For now implement just one rule - suggesting a nearest floor where there is at least one available parking space
- Boom barrier(s) could be located at any floor (e.g. -1, -2, +1, +2)
- Create a simple dummy data for testing your algorithm

## Example Flow:

1. Vehicle approaches boom barrier (could be located any floor) ->
2. Scans vehicle's plate number ->
3. Resolve from registry system the vehicle details ->
4. Calculate the nearest floor by given rule.
