using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_Airline.Exceptions
{   //exception appears if Carrying Capacity of the defined plane is over predefined value
    class ExceededCarryingCapacity : Exception
    {
        public ExceededCarryingCapacity() : base()
        {

        }
        public ExceededCarryingCapacity(string message) : base(message)
        {

        }
    }
}
