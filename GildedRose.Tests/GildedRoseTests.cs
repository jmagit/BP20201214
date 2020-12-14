using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedRose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Tests {
    [TestClass()]
    public class GildedRoseTests {
        [TestMethod()]
        public void GildedRoseTest() {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateQualityTest() {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("fixme", Items[0].Name);
        }
    }
}