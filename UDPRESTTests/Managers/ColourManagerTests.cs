using Microsoft.VisualStudio.TestTools.UnitTesting;
using UDPREST.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPLibrary;

namespace UDPREST.Managers.Tests
{
    [TestClass()]
    public class ColourManagerTest
    {
        public ColourManager _manager = new ColourManager();
        [TestMethod()]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void AddProfileTest()
        {
            int beforeAddCount = _manager.GetAllProfiles().Count();
            string newprofile = "ProfileTest";
            _manager.AddProfile(newprofile);
            Assert.AreEqual(beforeAddCount + 1, _manager.GetAllProfiles().Count() );
        }

        [TestMethod()]
        public void AddAndDeleteProfileTest()
        {
            int beforeAddCount = _manager.GetAllProfiles().Count();
            string newprofile = "ProfileTest2";
            _manager.AddProfile(newprofile);
            Assert.AreEqual(beforeAddCount + 1, _manager.GetAllProfiles().Count());
            _manager.DeleteProfile(newprofile);
            Assert.AreEqual(beforeAddCount, _manager.GetAllProfiles().Count());
        }
    }
}

/*SensorData sensorData = new SensorData(1, "op", "blue");
          Assert.AreEqual("blue", sensorData.Colour);
          sensorData.Colour = "red";
          Assert.AreEqual("red", sensorData.Colour);
          sensorData.Colour = "green";
          Assert.AreEqual("green", sensorData.Colour);
          sensorData.Colour = "yellow";
          Assert.AreEqual("yellow", sensorData.Colour);
          sensorData.Colour = "magenta";
          Assert.AreEqual("magenta", sensorData.Colour);
          //Assert.AreEqual("Azure", sensorData.Colour);
          Assert.ThrowsException<ArgumentException>(() => sensorData.Colour = "Azure");*/