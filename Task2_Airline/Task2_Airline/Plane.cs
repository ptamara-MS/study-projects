using System;
using System.Collections.Generic;
using System.Text;
using Task2_Airline.Exceptions;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

namespace Task2_Airline
{
    [Serializable]
    [XmlInclude(typeof(CargoPlane))]
    [XmlInclude(typeof(PassengerPlane))]
    public class Plane
    {
        public ManufacturerEnum Manufacturer { set; get; }
        public string Model { set; get; }
        public int FlightRange { set; get; }
        public int CruiseSpeed { set; get; }
        public int PassengersNumber { set; get; }
        public int CarryingCapacity { set; get; }

        public Plane()
        {

        }

        public Plane(ManufacturerEnum manufacturer, string model, int flightRange, int cruiseSpeed, int passengersNumber, int carryingCapacity)
        {
            if (cruiseSpeed < 0) throw new ArgumentException();
            if (passengersNumber < 0 || passengersNumber > 1000) throw new ArgumentOutOfRangeException();
            Manufacturer = manufacturer;
            Model = model ?? throw new ArgumentNullException();
            FlightRange = flightRange;
            CruiseSpeed = cruiseSpeed;
            PassengersNumber = passengersNumber;
            CarryingCapacity = carryingCapacity;
        }

        public void Fly(int speed)
        {
            if (speed > this.CruiseSpeed)
            {
                throw new ExceededPlaneSpeed($"Maximum speed for the plane is {this.CruiseSpeed}.");
            }
        }

        public void Cargo(int weight)
        {
            if (weight > this.CarryingCapacity)
            {
                throw new ExceededCarryingCapacity($"Maximum carrying capacity for the plane is {this.CarryingCapacity}.");
            }
        }

        public void PasQuantity(int quantity)
        {
            if (quantity > this.PassengersNumber)
            {
                throw new ExceededCarryingCapacity($"Maximum passengers number for the plane '{this.Manufacturer.ToString()}' is {this.PassengersNumber}.");
            }
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }

}
