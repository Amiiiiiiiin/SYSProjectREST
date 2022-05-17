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
        private static int actualGenre;
        private static string actualProfile;
        private static int _nextId = 1;
        private static string _standardColour = "green";
        private static readonly List<GenreColour> genreColoursMaster = new List<GenreColour>()
        {
            new GenreColour { Id = _nextId++, Genre = "acoustic", Colour = _standardColour },
            new GenreColour { Id = _nextId++, Genre = "afrobeat", Colour = _standardColour },
            new GenreColour { Id = _nextId++, Genre = "alt-rock", Colour = _standardColour },
            new GenreColour { Id = _nextId++, Genre = "alternative", Colour = _standardColour },
            new GenreColour { Id = _nextId++, Genre = "ambient", Colour = _standardColour },
        };

        private static readonly Dictionary<string, List<GenreColour>> profiles = new Dictionary<String, List<GenreColour>>();
        
        public string SetActualProfile(string profileName)
        {
            actualProfile = profileName;
            return "Currently in profile: " + profileName;
        }

        public string SetActualGenre(int id)
        {
            actualGenre = id;
            return "Currently updating genre number: " + id;
        }

        public IEnumerable<string> GetAllProfiles()
        {
            return profiles.Keys;
        }

        public List<GenreColour> GetAllGenreColours(string profileName)
        {
            List<GenreColour> result = profiles[profileName];
            //if (id != 0) result = result.FindAll(g => g.Id <= id);
            //if (!string.IsNullOrWhiteSpace(genre)) result = result.FindAll(g => g.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase));
            //if (!string.IsNullOrWhiteSpace(colour)) result = result.FindAll(g => g.Colour.Contains(colour, StringComparison.OrdinalIgnoreCase));
            return result;
        }

        public GenreColour GetGenreColourByGenre(string profileName, string genre)
        {
            return profiles[profileName].Find(genreColour => genreColour.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
        }

        public GenreColour UpdateGenreColour(string colour)
        {
            GenreColour genreColour = profiles[actualProfile].Find(g => g.Id == actualGenre);
            if (genreColour == null) return null;
            genreColour.Colour = colour;
            return genreColour;
        }

        public void AddProfile(string profileName)
        {
            if (profiles.ContainsKey(profileName))
            {
                throw new ArgumentException("Profile already exists. Please use a unique name");
            }

            List<GenreColour> newList = new List<GenreColour>();
            foreach (GenreColour genreColour in genreColoursMaster)
            {
                newList.Add(new GenreColour() { Id = genreColour.Id, Colour = genreColour.Colour, Genre = genreColour.Genre });
            }
            profiles.Add(profileName, newList);
        }

        public bool DeleteProfile(string profileName)
        {
            if (profiles.ContainsKey(profileName))
            {
                profiles.Remove(profileName);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

//Metode for at oprette ny entry i en liste, det bruges ikke i denne version af programmet
//public GenreColour Add(GenreColour newGenreColour)
//{
//    newGenreColour.Id = _nextId++;
//    newGenreColour.Colour = _standardColour;
//    genreColours.Add(newGenreColour);
//    return newGenreColour;
//}

//Metode for at slette genre på en liste, det bruges ikke i denne version af programmet
//public GenreColour Delete(int id)
//{
//    GenreColour genreColour = genreColours.Find(genreColour => genreColour.Id == id);
//    if (genreColour == null) return null;
//    genreColours.Remove(genreColour);
//    return genreColour;
//}

//public List<GenreColour> GetAllProfiles(int id, string genre, string colour)
//{
//    List<GenreColour> result = genreColours;
//    if (id != 0) result = result.FindAll(g => g.Id <= id);
//    if (!string.IsNullOrWhiteSpace(genre)) result = result.FindAll(g => g.Genre.Contains(genre, StringComparison.OrdinalIgnoreCase));
//    if (!string.IsNullOrWhiteSpace(colour)) result = result.FindAll(g => g.Colour.Contains(colour, StringComparison.OrdinalIgnoreCase));
//    return result;
//}