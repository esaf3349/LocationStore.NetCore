using LocationStore.Core.Refactored.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocationStore.Core.Refactored.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class OppositeDirectionAttribute : Attribute
    {
        public Direction OppositeDirection { get; private set; }

        public OppositeDirectionAttribute(Direction direction)
        {
            OppositeDirection = direction;
        }
    }
}
