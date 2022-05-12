using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using UDPLibrary;

namespace UDPREST.Managers
{
    public class ColourManager
    {
        private static int _nextId = 1;
        private static readonly List<GenreColour> genreColours = new List<GenreColour>()
        {
            new GenreColour { Id = _nextId++, Genre = "acoustic", Colour = ""},
            new GenreColour { Id = _nextId++, Genre = "afrobeat", Colour = ""},
            new GenreColour { Id = _nextId++, Genre = "alt-rock", Colour = ""},
            new GenreColour { Id = _nextId++, Genre = "alternative", Colour = ""},
            new GenreColour { Id = _nextId++, Genre = "ambient", Colour = ""},
        };

        public List<GenreColour> GetAll(int id, string genre, string colour)
        {
            List<GenreColour> result = genreColours;
            if (id != null) result = result.FindAll(g => g.Id <= id);
            if (!string.IsNullOrWhiteSpace(genre)) result = result.FindAll(g => g.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrWhiteSpace(colour)) result = result.FindAll(g => g.Colour.Contains(colour, StringComparison.OrdinalIgnoreCase));
            return result;
        }

        public GenreColour GetById(int id)
        {
            return genreColours.Find(genreColour => genreColour.Id == id);
        }

        public GenreColour Add(GenreColour newGenreColour)
        {
            newGenreColour.Id = _nextId++;
            genreColours.Add(newGenreColour);
            return newGenreColour;
        }

        public GenreColour Delete(int id)
        {
            GenreColour genreColour = genreColours.Find(genreColour => genreColour.Id == id);
            if (genreColour == null) return null;
            genreColours.Remove(genreColour);
            return genreColour;
        }

        public GenreColour Update(int id, GenreColour updates)
        {
            GenreColour genreColour = genreColours.Find(GenreColour => GenreColour.Id == id);
            if (genreColour == null) return null;
            genreColour.Colour = updates.Colour;
            return genreColour;
        }
    }
    //        public SensorData UpdateSensorData(int id, SensorData updates)
    //        {
    //            SensorData sensorData = _data.Find(SensorData => SensorData.Id == id);
    //            if (sensorData == null) return null;
    //            sensorData.Colour = updates.Colour;
    //            sensorData.SensorName = updates.SensorName;
    //            return sensorData;
    //        }
}

//{
//    public class ColourManager
//    {
//        //private static List<SensorData> _data = new List<SensorData>();

//        private static int _nextId = 1;

//        private static readonly List<SensorData> _data = new List<SensorData>()
//        {

//            new SensorData { Id = _nextId++, Colour = "Blue", SensorName = "op" },
//            new SensorData { Id = _nextId++, Colour = "Red", SensorName = "ned" },
//            new SensorData { Id = _nextId++, Colour = "Yellow", SensorName = "højre" },
//            new SensorData { Id = _nextId++, Colour = "Green", SensorName = "venstre" },
//            new SensorData { Id = _nextId++, Colour = "Magenta", SensorName = "midt" }
//        };

//        public List<SensorData> GetAll(int id, string colour, string sensorName) //string substring = null
//        {
//            List<SensorData> result = new List<SensorData>(_data);
//            if (id != 0)
//            {
//                result = result.FindAll(filterId => filterId.Id == id);
//            }

//            if (colour != null)
//            {
//                result = result.FindAll(filterColour => filterColour.Colour.Contains(colour, StringComparison.OrdinalIgnoreCase));

//            }

//            if (sensorName != null)
//            {
//                result = result.FindAll(filterSensorName => filterSensorName.SensorName.Contains(sensorName, StringComparison.OrdinalIgnoreCase));
//            }
//            return result;
//        }

//        //public List<SensorData> GetAll(string colour, string sensorName)
//        //{
//        //    List<SensorData> result = new List<SensorData>(_data);
//        //    result = result.FindAll();
//        //    return result;
//        //}


//        public SensorData AddSensorData(SensorData newData)
//        {
//            newData.Id = _nextId++;
//            _data.Add(newData);
//            return newData;
//        }

//        public List<SensorData> GetAll()
//        {
//            return new List<SensorData>(_data);
//        }
//        public IEnumerable<string> GetAllUniqueColours()
//        {
//            //Using LinQ to find the unique names in the list
//            return _data.Select(s => s.Colour).Distinct();
//        }
//        public SensorData GetById(int id)
//        {
//            return _data.Find(SensorData => SensorData.Id == id);
//        }

//        public SensorData GetAll(int id)
//        {
//            return _data.Find(SensorData => SensorData.Id == id);
//        }
//        public SensorData Delete(int id)
//        {
//            SensorData sensorData = _data.Find(sensorData => sensorData.Id == id);
//            if (sensorData == null) return null;
//            _data.Remove(sensorData);
//            return sensorData;
//        }

//        public SensorData UpdateSensorData(int id, SensorData updates)
//        {
//            SensorData sensorData = _data.Find(SensorData => SensorData.Id == id);
//            if (sensorData == null) return null;
//            sensorData.Colour = updates.Colour;
//            sensorData.SensorName = updates.SensorName;
//            return sensorData;
//        }
//        //public SensorData AddSensorData(SensorData newSensorData)
//        //{
//        //    newSensorData.Id = _nextId;
//        //    data.Add(newSensorData);
//        //    return newSensorData;
//        //}
//    }
//}