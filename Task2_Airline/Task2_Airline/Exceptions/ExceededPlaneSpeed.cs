using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_Airline.Exceptions
{   //exception appears if Cruise Speed of the defined plane is over predefined speed
    [Serializable]
    class ExceededPlaneSpeed : Exception
    {
        public ExceededPlaneSpeed() : base()
        {

        }
        public ExceededPlaneSpeed(string message) : base(message)
        {

        }
    }
}
