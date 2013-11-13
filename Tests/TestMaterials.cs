using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Updates.Crafter.Materials;

namespace Tests
{
    [TestFixture]
    class TestMaterials
    {

        [Test]
        public void IsPowerAdded()
        {
            var m = new Materials();

            m.w.IsBought = true;
            double SetDone = m.SetTotalPower();
            Assert.That(SetDone, Is.EqualTo(300));

            m.c.IsBought = true;
            SetDone = m.SetTotalPower();
            Assert.That(SetDone, Is.EqualTo(1300));

            m.r.IsBought = true;
            SetDone = m.SetTotalPower();
            Assert.That(SetDone, Is.EqualTo(11300));

        }
        [Test]
        public void AreMaterialsSet()
        {
            var m = new Materials();

            m.w.IsBought = true;
            Assert.That(m.w.IsBought);
        }

        /// <summary>
        /// Test if the upgrades could be added with prerequisite
        /// </summary>
        [Test]
        public void MaterialsInheritanceTest()
        {
            var m = new Materials();
            
            m.r.IsBought = true;
            double SetDone = m.SetTotalPower();
            Assert.That(SetDone, Is.Not.EqualTo(11300));

            m.c.IsBought = true;
            SetDone = m.SetTotalPower();
            Assert.That(SetDone, Is.Not.EqualTo(1300));
        }
    }
}
