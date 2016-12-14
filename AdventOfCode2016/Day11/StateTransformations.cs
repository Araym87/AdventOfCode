using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2016.Day11
{
    public static class StateTransformations
    {
        #region Public Methods

        public static IEnumerable<State> GetPossibleTransformations(this State currentState)
        {
            IEnumerable<State> items;
            if (currentState.Elevator == 0)
            {
                items = Move(currentState, 1);
                
            }
            else if (currentState.Elevator == DayEleven.HEIGHT - 1)
            {
                items = Move(currentState, -1);
            }
            else
            {
                items = Move(currentState, 1);
                items = items.Union(Move(currentState, -1));
            }

            foreach (var state in items)
            {
                yield return state;
            }
        }

        #endregion

        #region Private Methods

        private static IEnumerable<State> Move(State currentState, int direction)
        {
            var currentFloor = currentState.GetFloor(currentState.Elevator);
            var floorToCompare = currentState.GetFloor(currentState.Elevator + direction);
            foreach (var shortse in GetFloors(new[] { currentFloor, floorToCompare }))
            {
                var newState = currentState.Clone();
                newState.SetFloor(currentState.Elevator, shortse[0]);
                newState.SetFloor(currentState.Elevator + direction, shortse[1]);
                newState.Elevator += (short)direction;
                newState.Step++;
                yield return newState;
            }
        }

        private static IList<short[][]> GetFloors(short[][] floors)
        {
            var newCombinations = new List<short[][]>();
            for (var currentPosition = 0; currentPosition < floors[0].Length; currentPosition++)
            {
                if (floors[0][currentPosition] == 0)
                    continue;

                var currentFloor = (short[])floors[0].Clone();
                var floorToMove = (short[])floors[1].Clone();
                floorToMove[currentPosition] = currentFloor[currentPosition];
                currentFloor[currentPosition] = 0;
                // Move only one item
                if (State.IsFloorValid(floorToMove) && State.IsFloorValid(currentFloor))
                    newCombinations.Add(new[] { currentFloor, floorToMove });

                for (int forSecondItem = currentPosition + 1; forSecondItem < floors[0].Length; forSecondItem++)
                {
                    if (floors[0][forSecondItem] == 0)
                        continue;

                    var curFloor = (short[])currentFloor.Clone();
                    var floorMove = (short[])floorToMove.Clone();

                    floorMove[forSecondItem] = curFloor[forSecondItem];
                    curFloor[forSecondItem] = 0;
                    // Move two items
                    if (State.IsFloorValid(floorMove) && State.IsFloorValid(curFloor))
                        newCombinations.Add(new[] { curFloor, floorMove });
                }
            }
            return newCombinations;
        }

        #endregion
    }
}
