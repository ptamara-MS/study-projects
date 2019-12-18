using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_Airline
{
    [Serializable]
    public class CargoPlane : Plane
    {

        public CargoPlane() : base()
        {

        }
        public CargoPlane(ManufacturerEnum manufacturer,
            string model,
            int flightRange,
            int cruiseSpeed,
            int passengersNumber,
            int carryingCapacity,
            string usage) : base(manufacturer, model, flightRange, cruiseSpeed, passengersNumber, carryingCapacity)

        {
            Usage = usage;
        }

        public string Usage { set; get; }

    }
}
