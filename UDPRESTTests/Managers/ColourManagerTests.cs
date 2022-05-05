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
    public class ColourManagerTests
    {
        [TestMethod()]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void ColourTest()
        {
            SensorData sensorData = new SensorData(1, "op", "blue");
            Assert.AreEqual("blue", sensorData.Colour);
            sensorData.Colour = null; 
            Assert.AreEqual(null, sensorData.Colour);
            Assert.ThrowsException<ArgumentNullException>(() => sensorData.Colour = null);


        }
    }
}