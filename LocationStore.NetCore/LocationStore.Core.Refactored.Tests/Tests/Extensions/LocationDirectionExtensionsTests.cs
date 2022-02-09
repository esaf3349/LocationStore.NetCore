using LocationStore.Core.Refactored.Enums;
using LocationStore.Core.Refactored.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LocationStore.Core.Refactored.Tests.Tests.Extensions
{
    public class LocationDirectionExtensionsTests
    {
        [Fact]
        public void Opposite()
        {
            // Arrange
            var directions = new[] { Direction.North, Direction.East, Direction.South, Direction.West };
            var expectedOpposites = new[] { Direction.South, Direction.West, Direction.North, Direction.East };

            // Act

            // Assert
            for (int i = 0; i < directions.Length; i++)
            {
                var act = directions[i].Opposite();
                Assert.Equal(expectedOpposites[i], act);
            }
        }
    }
}
