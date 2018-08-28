using System;
using System.Collections.Generic;
using System.Text;

namespace Poi.Data.Exceptions.CityExceptions
{
    public class PointOfInterestNotFoundException : Exception
    {
        public override string Message => "Point of Interest was not found";
    }
}
