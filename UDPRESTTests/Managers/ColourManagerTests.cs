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
            sensorData.Colour = "red";
            Assert.AreEqual("red", sensorData.Colour);
            sensorData.Colour = "green";
            Assert.AreEqual("green", sensorData.Colour);
            sensorData.Colour = "yellow";
            Assert.AreEqual("yellow", sensorData.Colour);
            sensorData.Colour = "magenta";
            Assert.AreEqual("magenta", sensorData.Colour);
            //Assert.AreEqual("Azure", sensorData.Colour);
            Assert.ThrowsException<ArgumentException>(() => sensorData.Colour = "Azure");


        }
    }
}