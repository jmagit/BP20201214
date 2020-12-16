using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedRose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace GildedRose.Tests {
    [TestClass()]
    public class GildedRoseTests {
        protected object FuncionPrivate(object instancia, string metodo, object[] parameters = null) {
            MethodInfo privado = instancia.GetType()
                .GetMethod(metodo, BindingFlags.NonPublic | BindingFlags.Instance);
            return privado.Invoke(instancia, parameters);
        }
        protected void MetodoPrivate(object instancia, string metodo, object[] parameters = null) {
            MethodInfo privado = instancia.GetType()
                .GetMethod(metodo, BindingFlags.NonPublic | BindingFlags.Instance);
            privado.Invoke(instancia, parameters);
        }

        [TestMethod()]
        public void GildedRoseTest() {
            IList<Item> Items = new List<Item> { new Item { Name = "Normal Product", SellIn = 1, Quality = 2 } };
            GildedRose app = new GildedRose(Items);
            Assert.IsNotNull(app.GetType().GetField("items", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(app));
            CollectionAssert.AreEqual(Items as List<Item>, app.GetType().GetField("items", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(app) as List<Item>);
            
        }

        private void UpdateQualityTest(string name, int sellIn, int quality, int sellInResult, int qualityResult) {
            UpdateQualityTest(new Item { Name = name, SellIn = sellIn, Quality = quality }, sellInResult, qualityResult);
        }

        private void UpdateQualityTest(Item item, int sellInResult, int qualityResult) {
            string name = item.Name;
            IList<Item> Items = new List<Item> { item };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            //Assert.AreEqual(name, Items[0].Name);
            //Assert.AreEqual(sellInResult, Items[0].SellIn, "SellIn");
            //Assert.AreEqual(qualityResult, Items[0].Quality, "Quality");
            string msg = "";
            if (name != Items[0].Name)
                msg += $"Name: Se esperaba <{name}>, pero es <{Items[0].Name}>. ";
            if (sellInResult != Items[0].SellIn)
                msg += $"SellIn: Se esperaba <{sellInResult}>, pero es <{Items[0].SellIn}>. ";
            if (qualityResult != Items[0].Quality)
                msg += $"Quality: Se esperaba <{qualityResult}>, pero es <{Items[0].Quality}>. ";
            if (msg != "")
                Assert.Fail(msg);
        }

        [TestMethod()]
        [DataRow(-1, 1, -2, 0)]
        [DataRow(-10, 3, -11, 1)]
        [DataRow(0, 0, -1, 0)]
        [DataRow(7, 6, 6, 5)]
        public void NormalProductTest(int sellIn, int quality, int sellInResult, int qualityResult) {
            UpdateQualityTest("Normal Product", sellIn, quality, sellInResult, qualityResult);
        }

        [TestMethod()]
        [DataRow(1, 80, 1, 80)]
        [DataRow(-1, 80, -1, 80)]
        public void ProductSulfurasValidTest(int sellIn, int quality, int sellInResult, int qualityResult) {
            UpdateQualityTest("Sulfuras, Hand of Ragnaros", sellIn, quality, sellInResult, qualityResult);
        }

        [TestMethod()]
        [DataRow(-2, 49, -3, 50)]
        [DataRow(-1, 48, -2, 50)]
        [DataRow(2, 50, 1, 50)]
        [DataRow(2, 0, 1, 1)]
        public void ProductAgedBrieTest(int sellIn, int quality, int sellInResult, int qualityResult) {
            UpdateQualityTest("Aged Brie", sellIn, quality, sellInResult, qualityResult);
        }
        [TestMethod()]
        [DataRow(11, 0, 10, 1)]
        [DataRow(6, 1, 5, 3)]
        [DataRow(3, 49, 2, 50)]
        [DataRow(5, 3, 4, 6)]
        [DataRow(0, 3, -1, 0)]
        [DataRow(1, 3, 0, 6)]
        public void ProductBackstagePassesTest(int sellIn, int quality, int sellInResult, int qualityResult) {
            UpdateQualityTest("Backstage passes to a TAFKAL80ETC concert", sellIn, quality, sellInResult, qualityResult);
        }
        [TestMethod()]
        //[Ignore]
        [DataRow(11, 10, 10, 8)]
        [DataRow(7, 1, 6, 0)]
        [DataRow(-5, 10, -6, 6)]
        [DataRow(0, 3, -1, 0)]
        public void ProductConjuredTest(int sellIn, int quality, int sellInResult, int qualityResult) {
            UpdateQualityTest("Conjured Mana Cake", sellIn, quality, sellInResult, qualityResult);
        }
        [TestMethod()]
        [DataRow(3, 2, 1)]
        [DataRow(0, 0, 1)]
        [DataRow(3, 0, 4)]
        public void QuitaCalidadTest(int quality, int qualityResult, int cantidad) {
            var item = new Item { Name = "Normal Product", SellIn = 1, Quality = quality };
            IList<Item> Items = new List<Item> { item };
            GildedRose app = new GildedRose(Items);
            MetodoPrivate(app, "QuitaCalidad", new object[] { item, cantidad });
            Assert.AreEqual(qualityResult, item.Quality);
        }


    }
}