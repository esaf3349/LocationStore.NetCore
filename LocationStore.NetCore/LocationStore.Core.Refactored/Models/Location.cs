using LocationStore.Core.Refactored.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocationStore.Core.Refactored.Models
{
    public class Location
    {
        private int? North;
        private int? East;
        private int? South;
        private int? West;
        private int? Up;
        private int? Down;

        public void SetReference(Direction direction, int? reference)
        {
            switch (direction)
            {
                case Direction.North:
                    North = reference;
                    break;
                case Direction.East:
                    East = reference;
                    break;
                case Direction.South:
                    South = reference;
                    break;
                case Direction.West:
                    West = reference;
                    break;
                case Direction.Up:
                    Up = reference;
                    break;
                case Direction.Down:
                    Down = reference;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public int? GetReference(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return North;
                case Direction.East:
                    return East;
                case Direction.South:
                    return South;
                case Direction.West:
                    return West;
                case Direction.Up:
                    return Up;
                case Direction.Down:
                    return Down;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
