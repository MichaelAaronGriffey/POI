using System;
using System.Collections.Generic;
using System.Text;

namespace Poi.Data.Exceptions.CityExceptions
{
    public class CityNotFoundException : Exception
    {
        public override string Message => "City was not found";
    }
}
