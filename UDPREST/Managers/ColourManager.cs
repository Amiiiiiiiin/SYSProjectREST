using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UDPLibrary;

namespace UDPREST.Managers
{
    public class ColourManager
    {
        //private static List<SensorData> _data = new List<SensorData>();

        private static int _nextId = 1;

        private static readonly List<SensorData> _data = new List<SensorData>()
        {

            new SensorData { Id = _nextId++, Colour = "Blue", SensorName = "" },
            new SensorData { Id = _nextId++, Colour = "Red", SensorName = "" },
            new SensorData { Id = _nextId++, Colour = "Yellow", SensorName = "" },
            new SensorData { Id = _nextId++, Colour = "Green", SensorName = "" },
            new SensorData { Id = _nextId++, Colour = "Magenta", SensorName = "" }
        };




        public List<SensorData> GetAll()
        {
            return new List<SensorData>(_data);
        }
        public IEnumerable<string> GetAllUniqueColours()
        {
            //Using LinQ to find the unique names in the list
            return _data.Select(s => s.SensorName).Distinct();
        }

        public SensorData AddSensorData(SensorData newData)
        {
            newData.Id = _nextId++;
            _data.Add(newData);
            return newData;
        }

        public SensorData GetAll(int id)
        {
            return _data.Find(SensorData => SensorData.Id == id);
        }

        //public SensorData AddSensorData(SensorData newSensorData)
        //{
        //    newSensorData.Id = _nextId;
        //    data.Add(newSensorData);
        //    return newSensorData;
        //}
    }
}