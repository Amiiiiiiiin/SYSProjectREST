using System;

namespace UDPLibrary
{
    public class SensorData
    {
        private int _id;
        private string _sensorName;
        private string _colour;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public String SensorName
        {
            get => _sensorName;
            set => _sensorName = value;
        }

        public string Colour
        {
            get => _colour;
            set
            {
                if (value.ToLower() == "red" || value.ToLower() == "blue" || value.ToLower() == "magenta" ||
                    value.ToLower() == "yellow" || value.ToLower() == "green")
                {
                    {
                        _colour = value;
                    }
                }
                else
                {
                    throw new ArgumentException();
                }

            }
        }

        public SensorData()
        {

        }

        public SensorData(int id, String sensorName, string colour)
        {
            Id = id;
            SensorName = sensorName;
            Colour = colour;
        }


        public override string ToString()
        {
            //Simple string containing the property names and thier respective values
            return $"Id: {Id} - SensorName: {SensorName} - Colour: {Colour}";
        }
    }
}

