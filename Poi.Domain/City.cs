using System;
using System.Collections.Generic;

namespace Poi.Domain
{
    public class City
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ICollection<PointOfInterest> PointsOfInterest { get; private set; } = new List<PointOfInterest>();
        public int NumberOfPointsOfInterest
        {
            get
            {
                return PointsOfInterest.Count;
            }
        }
    }
}
