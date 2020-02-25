using System.Collections.Generic;
using HerkulexApi;
using HerkulexGuiMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HerkulexGuiMapperUnitTest
{
    [TestClass]
    public class GuiMapperUnitTests
    {

        private HerkulexInterface myHerkulexInterface12;
        private HerkulexInterface myHerkulexInterface34;
        private HerkulexInterface myHerkulexInterface56;
        private HerkulexInterface myHerkulexInterface78;

        private List<IHerkulexServo> myServos;
        private HerkulexDrs0602 myServo1, myServo2, myServo3, myServo4, myServo5, myServo6, myServo7, myServo8;

        [TestInitialize]
        public void InititalizeMotor()
        {
            myHerkulexInterface12 = new HerkulexInterface("COM11", 57600);
            myHerkulexInterface34 = new HerkulexInterface("COM12", 57600);
            myHerkulexInterface56 = new HerkulexInterface("COM13", 57600);
            myHerkulexInterface78 = new HerkulexInterface("COM14", 57600);
            myServo1 = new HerkulexDrs0602(1, myHerkulexInterface12);
            myServo2 = new HerkulexDrs0602(2, myHerkulexInterface12);
            myServo3 = new HerkulexDrs0602(3, myHerkulexInterface34);
            myServo4 = new HerkulexDrs0602(4, myHerkulexInterface34);
            myServo5 = new HerkulexDrs0602(5, myHerkulexInterface56);
            myServo6 = new HerkulexDrs0602(6, myHerkulexInterface56);
            myServo7 = new HerkulexDrs0602(7, myHerkulexInterface78);
            myServo8 = new HerkulexDrs0602(8, myHerkulexInterface78);
            myServos = new List<IHerkulexServo>()
                {myServo1, myServo2, myServo3, myServo4, myServo5, myServo6, myServo7, myServo8};
        }

        [TestMethod]
        public void TestGuiMapper()
        {
            foreach (var servo in myServos)
            {
                servo.TorqueOn();
                servo.NeutralPosition = -60;
            }

            var replayer = new HerkulexAsyncReplayer(-60, 0);
            //replayer.Move2Position(0.5, myServos);
            replayer.StartSeries(WaveformType.Triangle, 0.5, 1, 1, 10, myServos, true, 4);
        }
    }
}
