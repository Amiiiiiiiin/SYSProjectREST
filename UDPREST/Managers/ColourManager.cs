using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UDPLibrary;

namespace UDPREST.Managers
{
    public class ColourManager
    {
        private static List<SensorData> _data = new List<SensorData>();
        private static int _nextId = 1;

        public List<SensorData> GetAll()
        {
            return new List<SensorData>(_data);
        }
        public IEnumerable<string> GetAllUniqueColours()
        {
            //Using LinQ to find the unique names in the list
            return _data.Select(s => s.SensorName).Distinct();
        }

        public int add(SensorData newData)
        {
            newData.Id = _nextId++;
            _data.Add(newData);
            return newData.Id;
        }
    }
}