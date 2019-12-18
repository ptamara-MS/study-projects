using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_Airline
{
    [Serializable]
    public class PassengerPlane : Plane
    {
        public PassengerPlane() : base()
        {

        }
        public PassengerPlane(ManufacturerEnum manufacturer,
            string model,
            int flightRange,
            int cruiseSpeed,
            int passengersNumber,
            int carryingCapacity,
            string passengerClass,
            bool luggage) : base(manufacturer, model, flightRange, cruiseSpeed, passengersNumber, carryingCapacity)
        {
            PassengersClass = passengerClass;
            Luggage = luggage;
        }

        public string PassengersClass { set; get; }
        public bool Luggage { set; get; }

    }
}
