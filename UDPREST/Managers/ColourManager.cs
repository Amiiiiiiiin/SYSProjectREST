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

        public int Add(SensorData newData)
        {
            newData.Id = _nextId++;
            _data.Add(newData);
            return newData.Id;
        }
    }
}
