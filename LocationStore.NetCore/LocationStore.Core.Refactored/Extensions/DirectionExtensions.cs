using LocationStore.Core.Refactored.Attributes;
using LocationStore.Core.Refactored.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocationStore.Core.Refactored.Extensions
{
    public static class DirectionExtensions
    {
        public static Direction Opposite(this Direction direction)
        {
            var enumType = direction.GetType();
            var memberInfos = enumType.GetMember(direction.ToString());

            var attribute = (OppositeDirectionAttribute)Attribute.GetCustomAttribute(memberInfos[0], typeof(OppositeDirectionAttribute));

            return attribute.OppositeDirection;
        }
    }
}
