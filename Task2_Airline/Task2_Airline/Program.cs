using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Task2_Airline
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalPassengersNumber = 0, totalPlaneCarrying = 0;

            List<Plane> airline = new List<Plane>();
            airline.Add(new PassengerPlane(ManufacturerEnum.Airbus, "A380", 12000, 910, 580, 102000, "business", true));
            airline.Add(new PassengerPlane(ManufacturerEnum.Boeing, "777-300", 11120, 905, 550, 90000, "business", true));
            airline.Add(new PassengerPlane(ManufacturerEnum.Concorde, "G-BOAC", 7223, 2158, 120, 76000, "business", true));
            airline.Add(new PassengerPlane(ManufacturerEnum.Embraer, "E-175", 3334, 890, 76, 54000, "economy", false));
            airline.Add(new PassengerPlane(ManufacturerEnum.Tupolev, "Tu-154", 2850, 900, 95, 67000, "economy", false));
            airline.Add(new CargoPlane(ManufacturerEnum.Antonov, "An-124", 3700, 865, 20, 150000, "military"));
            airline.Add(new CargoPlane(ManufacturerEnum.Bombardier, "Q-400", 2040, 667, 15, 4700, "commercial"));
            airline.Add(new CargoPlane(ManufacturerEnum.Douglas, "DC-10-30", 5790, 908, 7, 77000, "commercial"));
            airline.Add(new CargoPlane(ManufacturerEnum.Lockheed, "C-5", 4440, 919, 12, 122470, "military"));
            airline.Add(new CargoPlane(ManufacturerEnum.McDonnell, "MD-11", 7320, 945, 16, 91670, "commercial"));

            foreach (Plane p in airline)
            {
                totalPassengersNumber += p.PassengersNumber;
                totalPlaneCarrying += p.CarryingCapacity;
            }

            Console.WriteLine("Calculating total passengers number : {0} passengers \n", totalPassengersNumber);
            //Console.WriteLine();
            Console.WriteLine("Calculating total carrying capacity : {0} kg", totalPlaneCarrying);


            airline = airline.OrderBy(p => p.FlightRange).ToList();
            Console.WriteLine("Sorting by flight range :");
            airline.ForEach(p => Console.WriteLine(p.FlightRange));

            Console.WriteLine("Plane selection by parameters: ");
            airline.Where(p => p.CruiseSpeed > 900 && p.PassengersNumber > 50).ToList().ForEach(p => Console.WriteLine($"Manufactorer: {p.Manufacturer}, cruise speed: {p.CruiseSpeed} km/h, passangerNumber: {p.PassengersNumber} pas"));

            try
            {
                var planeA = airline[0];
                planeA.Fly(700);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            try
            {
                var planeB = airline[1];
                planeB.Cargo(100000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            try
            {
                var planeC = airline[4];
                planeC.PasQuantity(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                var planeD = airline[5];
                planeD.Swim();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //saving planes to txt file
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\Users\Inspiron\source\repos\Task2_Airline\planes.txt"))
            {
                foreach (Plane plane in airline)
                {
                    var type = plane.GetType();
                    switch (type.Name)
                    {
                        case "CargoPlane":
                            CargoPlane cargoPlane = (CargoPlane)plane;
                            file.WriteLine($"{type.Name}:{cargoPlane.Manufacturer.ToString()} - {cargoPlane.Model} - {cargoPlane.FlightRange} - {cargoPlane.CruiseSpeed} - {cargoPlane.PassengersNumber} - {cargoPlane.CarryingCapacity} - {cargoPlane.Usage}");
                            break;
                        case "PassengerPlane":
                            PassengerPlane passengerPlane = (PassengerPlane)plane;
                            file.WriteLine($"{type.Name}:{passengerPlane.Manufacturer.ToString()} - {passengerPlane.Model} - {passengerPlane.FlightRange} - {passengerPlane.CruiseSpeed} - {passengerPlane.PassengersNumber} - {passengerPlane.CarryingCapacity} - {passengerPlane.PassengersClass} - {passengerPlane.Luggage}");
                            break;
                    }
                }
            }
            //reading planes from txt file
            string[] planes = File.ReadAllLines(@"c:\Users\Inspiron\source\repos\Task2_Airline\planes.txt");

            List<Plane> airlineFromTxt = new List<Plane>();
            foreach (string plane in planes)
            {
                string type = plane.Split(":")[0];
                string[] properties = plane.Split(":")[1].Split(" - ");
                switch (type)
                {
                    case "CargoPlane":
                        CargoPlane cargoPlane = new CargoPlane((ManufacturerEnum)Enum.Parse(typeof(ManufacturerEnum), properties[0]), properties[1], int.Parse(properties[2]), int.Parse(properties[3]), int.Parse(properties[4]), int.Parse(properties[5]), properties[6]);
                        airlineFromTxt.Add(cargoPlane);
                        break;
                    case "PassengerPlane":
                        PassengerPlane passengerPlane = new PassengerPlane((ManufacturerEnum)Enum.Parse(typeof(ManufacturerEnum), properties[0]), properties[1], int.Parse(properties[2]), int.Parse(properties[3]), int.Parse(properties[4]), int.Parse(properties[5]), properties[6], bool.Parse(properties[7]));
                        airlineFromTxt.Add(passengerPlane);
                        break;
                }
            }

            //serialize to binary file
            //Create the stream to add object into it.
            Stream ms = File.OpenWrite(@"c:\Users\Inspiron\source\repos\Task2_Airline\planes.bin");
            //Format the object as Binary

            BinaryFormatter formatter = new BinaryFormatter();
            //It serialize the airline object
            formatter.Serialize(ms, airline);
            ms.Flush();
            ms.Close();
            ms.Dispose();

            //Reading the file from the server
            FileStream fs = File.Open(@"c:\Users\Inspiron\source\repos\Task2_Airline\planes.bin", FileMode.Open);

            object obj = formatter.Deserialize(fs);
            List<Plane> newAirline = (List<Plane>)obj;
            fs.Flush();
            fs.Close();
            fs.Dispose();
            Console.ReadKey();

            //serialization XML file
            XmlSerializer formatterXML = new XmlSerializer(typeof(List<Plane>));
            using (FileStream fs1 = new FileStream(@"c:\Users\Inspiron\source\repos\Task2_Airline\airline.xml", FileMode.OpenOrCreate))
            {
                formatterXML.Serialize(fs1, airline);
            }
            using (FileStream fs2 = new FileStream(@"c:\Users\Inspiron\source\repos\Task2_Airline\airline.xml", FileMode.OpenOrCreate))
            {
                List<Plane> xmlAirline = (List<Plane>)formatterXML.Deserialize(fs2);

            }
            // сохранение данных
            using (StreamWriter file = File.CreateText(@"c:\Users\Inspiron\source\repos\Task2_Airline\airline.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, airline);
            }

            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(@"c:\Users\Inspiron\source\repos\Task2_Airline\airline.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<Plane> jsonAirline = (List<Plane>)serializer.Deserialize(file, typeof(List<Plane>));
            }
        }
    }
}
