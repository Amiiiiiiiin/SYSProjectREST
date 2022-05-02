using System;

namespace UDPLibrary
{
    public class SensorData
    {
        public int Id { get; set; }
        public String SensorName { get; set; }
        public string Colour { get; set; }

        public SensorData()
        {

        }

        public SensorData(int id, String sensorName, string colour)
        {
            Id = id;
            SensorName = sensorName;
            Colour = colour;
        }
    }
}
