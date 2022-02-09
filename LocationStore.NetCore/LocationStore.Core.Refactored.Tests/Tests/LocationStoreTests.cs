using LocationStore.Core.Refactored.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LocationStore.Core.Refactored.Tests.Tests
{
    public class LocationStoreTests
    {
        [Fact]
        public void AddLocation()
        {
            // Arrange
            var store = new LocationStore();

            // Act
            store.AddLocation(1);
            store.AddLocation(2);

            // Assert
            Assert.Equal(2, store.Locations.Count);

            foreach (var direction in Enum.GetValues(typeof(Direction)))
            {
                Assert.Null(store.Locations[1].GetReference((Direction)direction));
                Assert.Null(store.Locations[2].GetReference((Direction)direction));
            }
        }

        [Fact]
        public void AddLocationFromExisting()
        {
            // Arrange
            var store = new LocationStore();

            // Act
            store.AddLocation(1);
            store.AddLocation(2, 1, Direction.East);
            store.AddLocation(3, 2, Direction.South, false);

            // Assert
            Assert.Equal(3, store.Locations.Count);

            Assert.Equal(2, store.Locations[1].GetReference(Direction.East));
            Assert.Equal(1, store.Locations[2].GetReference(Direction.West));

            Assert.Equal(3, store.Locations[2].GetReference(Direction.South));
            Assert.Null(store.Locations[3].GetReference(Direction.North));
        }

        [Fact]
        public void ChangeLocationReference()
        {
            // Arrange
            var store = new LocationStore();
            store.AddLocation(1);
            store.AddLocation(2);
            store.AddLocation(3);

            // Act
            store.ChangeLocationReference(1, 2, Direction.Up);
            store.ChangeLocationReference(3, 2, Direction.West, false);

            // Assert
            Assert.Equal(3, store.Locations.Count);

            Assert.Equal(2, store.Locations[1].GetReference(Direction.Down));
            Assert.Equal(1, store.Locations[2].GetReference(Direction.Up));

            Assert.Equal(3, store.Locations[2].GetReference(Direction.West));
            Assert.Null(store.Locations[3].GetReference(Direction.East));
        }

        [Fact]
        public void ClearLocationReference()
        {
            // Arrange
            var store = new LocationStore();
            store.AddLocation(1);
            store.AddLocation(2, 1, Direction.Down);
            store.AddLocation(3, 2, Direction.North);

            // Act
            store.ClearLocationReference(1, Direction.Down);
            store.ClearLocationReference(2, Direction.North, false);

            // Assert
            Assert.Equal(3, store.Locations.Count);

            Assert.Null(store.Locations[1].GetReference(Direction.Down));
            Assert.Null(store.Locations[2].GetReference(Direction.Up));

            Assert.Null(store.Locations[2].GetReference(Direction.North));
            Assert.Equal(2, store.Locations[3].GetReference(Direction.South));
        }

        [Fact]
        public void DeleteLocation()
        {
            // Arrange
            var store = new LocationStore();
            store.AddLocation(1);
            store.AddLocation(2, 1, Direction.Down);
            store.AddLocation(3, 2, Direction.North);

            // Act
            store.DeleteLocation(1);
            store.DeleteLocation(3, false);

            // Assert
            Assert.Single(store.Locations);

            Assert.Null(store.Locations[2].GetReference(Direction.Up));
            Assert.Equal(3, store.Locations[2].GetReference(Direction.North));
        }
    }
}
