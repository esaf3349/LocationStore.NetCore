using LocationStore.Core.Refactored.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocationStore.Core.Refactored.Enums
{
    public enum Direction : byte
    {
        [OppositeDirection(South)]
        North = 0,

        [OppositeDirection(West)]
        East = 1,

        [OppositeDirection(North)]
        South = 2,

        [OppositeDirection(East)]
        West = 3,

        [OppositeDirection(Down)]
        Up = 4,

        [OppositeDirection(Up)]
        Down = 5
    }
}
