using System;

namespace GildedRose {
    public class Item : ICloneable {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public object Clone() {
            return new Item { Name = this.Name, SellIn = this.SellIn, Quality = this.Quality };
        }

        public override string ToString() {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }
    }
}
