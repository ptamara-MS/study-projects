using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_Airline.Exceptions
{
    class ExceededPassengersNumber : Exception
    {
        public ExceededPassengersNumber() : base()
        {

        }
        public ExceededPassengersNumber(string message) : base(message)
        {

        }
    }
}
