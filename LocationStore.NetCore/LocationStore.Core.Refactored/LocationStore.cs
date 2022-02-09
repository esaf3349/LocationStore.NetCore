using LocationStore.Core.Refactored.Enums;
using LocationStore.Core.Refactored.Extensions;
using LocationStore.Core.Refactored.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocationStore.Core.Refactored
{
    public class LocationStore
    {
        public Dictionary<int, Location> Locations { get; private set; }

        public LocationStore()
        {
            Locations = new Dictionary<int, Location>();
        }

        /// <summary>
        /// Add new location without references.
        /// </summary>
        public void AddLocation(int newReference)
        {
            if (Locations.ContainsKey(newReference))
                throw new Exception($"{newReference} already exists.");

            Locations[newReference] = new Location();
        }

        /// <summary>
        /// Add new location and attach to existing one.
        /// </summary>
        /// <param name="makeInvertedConnection">Make inverted connection, that leads to source reference from new reference.</param>
        public void AddLocation(int newReference, int sourceReference, Direction direction, bool makeInvertedConnection = true)
        {
            if (Locations.ContainsKey(newReference))
                throw new Exception($"{newReference} already exists.");

            var sourceLocation = Locations[sourceReference];

            if (sourceLocation.GetReference(direction) != default)
                throw new Exception($"{sourceReference}.{direction} already occupied.");

            sourceLocation.SetReference(direction, newReference);

            var newLocation = new Location();

            if (makeInvertedConnection)
                newLocation.SetReference(direction.Opposite(), sourceReference);

            Locations.Add(newReference, newLocation);
        }

        /// <summary>
        /// Change location reference at given direction.
        /// Accepts reference of existing location.
        /// </summary>
        /// <param name="makeInvertedConnection">Make inverted connection, that leads to source reference from destination reference.</param>
        public void ChangeLocationReference(int destinationReference, int sourceReference, Direction direction, bool makeInvertedConnection = true)
        {
            var sourceLocation = Locations[sourceReference];

            var newLocation = Locations[destinationReference];

            if (newLocation == null)
                throw new Exception($"{destinationReference} doesn't exist.");

            sourceLocation.SetReference(direction, destinationReference);

            if (makeInvertedConnection)
                newLocation.SetReference(direction.Opposite(), sourceReference);
        }

        /// <summary>
        /// Delete location reference at given direction.
        /// </summary>
        /// <param name="clearOuterConnection">Delete connection on other side of given direction.</param>
        public void ClearLocationReference(int sourceReference, Direction direction, bool clearOuterConnection = true)
        {
            var sourceLocation = Locations[sourceReference];

            var referenceToClear = sourceLocation.GetReference(direction);

            sourceLocation.SetReference(direction, null);

            if (clearOuterConnection && referenceToClear != null)
            {
                var otherSideLocation = Locations[(int)referenceToClear];

                otherSideLocation.SetReference(direction.Opposite(), null);
            }
        }

        /// <summary>
        /// Delete location from store.
        /// </summary>
        /// <param name="clearOuterConnections">Delete connections to this location inside each linked location.</param>
        public void DeleteLocation(int reference, bool clearOuterConnections = true)
        {
            var location = Locations[reference];

            if (clearOuterConnections)
            {
                foreach (var direction in Enum.GetValues(typeof(Direction)))
                {
                    var directionReference = location.GetReference((Direction)direction);

                    if (directionReference != null)
                    {
                        var otherSideLocation = Locations[(int)directionReference];

                        otherSideLocation.SetReference(((Direction)direction).Opposite(), null);
                    }
                }
            }

            Locations.Remove(reference);
        }
    }
}
