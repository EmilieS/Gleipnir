using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Game;

namespace Tests
{
        [TestFixture]
    public class TestsFamily
    {
            [Test]
            public void dummy()
            {
                Villager villager = new Villager();
                Assert.That(villager.Gender == Genders.MALE);

            }
    }
}
