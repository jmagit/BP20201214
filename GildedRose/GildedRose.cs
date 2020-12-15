using System.Collections.Generic;

namespace GildedRose {
    public class GildedRose {
        public static readonly int CALIDAD_MAXIMA = 50;
        public static readonly int DEGRADACION_ESTANDAR = 1;

        IList<Item> items;
        public GildedRose(IList<Item> Items) {
            this.items = Items;
        }
        public void UpdateQuality() {
            for (int productIndex = 0; productIndex < items.Count; productIndex++) {
                if (EsSulfuras(productIndex))
                    continue; // con sulfuras no se hace nada
                QuitaUnDia(productIndex);
                if (EsQueso(productIndex)) {
                    UpdateQuesoQuality(productIndex);
                } else if (EsEntrada(productIndex)) {
                    UpdateEntradaQuality(productIndex);
                } else if (EsConjurado(productIndex)) {
                    UpdateConjuradoQuality(productIndex);
                } else {
                    UpdateProductosQuality(productIndex);
                }
            }
        }

        private void UpdateQuesoQuality(int productIndex) {
            AñadeCalidad(productIndex, HaCaducado(productIndex) ? 2 : 1);
        }

        private void UpdateEntradaQuality(int productIndex) {
            if (HaCaducado(productIndex)) {
                PonACeroCalidad(productIndex);
            } else if (Quedan5DiasOMenos(productIndex)) {
                AñadeCalidad(productIndex, 3);
            } else if (Quedan10diasOMenos(productIndex)) {
                AñadeCalidad(productIndex, 2);
            } else {
                AñadeCalidad(productIndex, 1);
            }
        }

        private void UpdateConjuradoQuality(int productIndex) {
            if (HaCaducado(productIndex)) {
                // caducado degrada al doble de velocidad
                QuitaCalidad(productIndex, 4 * DEGRADACION_ESTANDAR);
            } else {
                QuitaCalidad(productIndex, 2 * DEGRADACION_ESTANDAR);
            }
        }

        private void UpdateProductosQuality(int productIndex) {
            if (HaCaducado(productIndex)) {
                QuitaCalidad(productIndex, 2 * DEGRADACION_ESTANDAR);
            } else {
                QuitaCalidad(productIndex, DEGRADACION_ESTANDAR);
            }
        }

        private bool EsSulfuras(int productIndex) {
            return items[productIndex].Name == "Sulfuras, Hand of Ragnaros";
        }

        private bool EsEntrada(int productIndex) {
            return items[productIndex].Name =="Backstage passes to a TAFKAL80ETC concert";
        }

        private bool EsQueso(int productIndex) {
            return items[productIndex].Name =="Aged Brie";
        }

        private bool EsConjurado(int productIndex) {
            return items[productIndex].Name =="Conjured Mana Cake";
        }

        private bool Quedan5DiasOMenos(int productIndex) {
            return items[productIndex].SellIn < 5;
        }

        private bool Quedan10diasOMenos(int productIndex) {
            return items[productIndex].SellIn < 10;
        }

        private bool HaCaducado(int productIndex) {
            // los dias negativos son cuando esta caducado
            return items[productIndex].SellIn < 0;
        }

        private void QuitaUnDia(int productIndex) {
            items[productIndex].SellIn = items[productIndex].SellIn - 1;
        }

        private void PonACeroCalidad(int productIndex) {
            QuitaCalidad(productIndex, items[productIndex].Quality);
        }

        private void QuitaCalidad(int productIndex, int cantidad) {
            //		int rslt = items[productIndex].Quality - cantidad;
            //		items[productIndex].Quality = rslt < 0 ? 0 : rslt;
            //
            //		items[productIndex].Quality = items[productIndex].Quality - cantidad < 0 ?
            //				0 : items[productIndex].Quality - cantidad;

            if (items[productIndex].Quality - cantidad < 0) {
                items[productIndex].Quality = 0;
            } else {
                items[productIndex].Quality = items[productIndex].Quality - cantidad;
            }

            //		items[productIndex].Quality = items[productIndex].Quality - 1;
            //		if (items[productIndex].Quality < 0) {
            //			items[productIndex].Quality = 0;
            //		}
        }

        private void AñadeCalidad(int productIndex, int cantidad) {
            if (items[productIndex].Quality + cantidad > CALIDAD_MAXIMA) {
                items[productIndex].Quality = CALIDAD_MAXIMA;
            } else {
                items[productIndex].Quality = items[productIndex].Quality + cantidad;
            }
        }

        //public Item[] Items {
        //	get {
        //		if(Items is )
        //		return Items.clone();
        //	}
        //}

        //public Item getItem(int productIndex) {
        //	return Items[productIndex];
        //}
        /*
                public void UpdateQuality() {
                    for (var i = 0; i < Items.Count; i++) {
                        if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert") {
                            if (Items[i].Quality > 0) {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros") {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        } else {
                            if (Items[i].Quality < 50) {
                                Items[i].Quality = Items[i].Quality + 1;

                                if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert") {
                                    if (Items[i].SellIn < 11) {
                                        if (Items[i].Quality < 50) {
                                            Items[i].Quality = Items[i].Quality + 1;
                                        }
                                    }

                                    if (Items[i].SellIn < 6) {
                                        if (Items[i].Quality < 50) {
                                            Items[i].Quality = Items[i].Quality + 1;
                                        }
                                    }
                                }
                            }
                        }

                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros") {
                            Items[i].SellIn = Items[i].SellIn - 1;
                        }

                        if (Items[i].SellIn < 0) {
                            if (Items[i].Name != "Aged Brie") {
                                if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert") {
                                    if (Items[i].Quality > 0) {
                                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros") {
                                            Items[i].Quality = Items[i].Quality - 1;
                                        }
                                    }
                                } else {
                                    Items[i].Quality = Items[i].Quality - Items[i].Quality;
                                }
                            } else {
                                if (Items[i].Quality < 50) {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }
        */
    }
}
