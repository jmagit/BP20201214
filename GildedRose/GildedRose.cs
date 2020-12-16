using System;
using System.Linq;
using System.Collections.Generic;

namespace GildedRose {
    public class GildedRose {
        public static readonly int CALIDAD_MINIMA = 0;
        public static readonly int CALIDAD_MAXIMA = 50;
        public static readonly int DEGRADACION_ESTANDAR = 1;

        IList<Item> items;
        public GildedRose(IList<Item> Items) {
            this.items = Items;
        }
        public void UpdateQuality() {
            foreach (var item in items) {
                if (EsSulfuras(item))
                    continue; // con sulfuras no se hace nada
                QuitaUnDia(item);
                if (EsQueso(item)) {
                    UpdateQuesoQuality(item);
                } else if (EsEntrada(item)) {
                    UpdateEntradaQuality(item);
                } else if (EsConjurado(item)) {
                    UpdateConjuradoQuality(item);
                } else {
                    UpdateProductosQuality(item);
                }
            }
        }

        private void UpdateQuesoQuality(Item item) {
            AñadeCalidad(item, HaCaducado(item) ? 2 : 1);
        }

        private void UpdateEntradaQuality(Item item) {
            if (HaCaducado(item)) {
                PonACeroCalidad(item);
            } else if (Quedan5DiasOMenos(item)) {
                AñadeCalidad(item, 3);
            } else if (Quedan10diasOMenos(item)) {
                AñadeCalidad(item, 2);
            } else {
                AñadeCalidad(item, 1);
            }
        }

        private void UpdateConjuradoQuality(Item item) {
            if (HaCaducado(item)) {
                // caducado degrada al doble de velocidad
                QuitaCalidad(item, 4 * DEGRADACION_ESTANDAR);
            } else {
                QuitaCalidad(item, 2 * DEGRADACION_ESTANDAR);
            }
        }

        private void UpdateProductosQuality(Item item) {
            if (HaCaducado(item)) {
                QuitaCalidad(item, 2 * DEGRADACION_ESTANDAR);
            } else {
                QuitaCalidad(item, DEGRADACION_ESTANDAR);
            }
        }

        private bool EsSulfuras(Item item) {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        private bool EsEntrada(Item item) {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private bool EsQueso(Item item) {
            return item.Name == "Aged Brie";
        }

        private bool EsConjurado(Item item) {
            return item.Name == "Conjured Mana Cake";
        }

        private bool Quedan5DiasOMenos(Item item) {
            return item.SellIn < 5;
        }

        private bool Quedan10diasOMenos(Item item) {
            return item.SellIn < 10;
        }

        private bool HaCaducado(Item item) {
            // los días negativos son cuando esta caducado
            return item.SellIn < 0;
        }

        private void QuitaUnDia(Item item) {
            item.SellIn = item.SellIn - 1;
        }

        private void PonACeroCalidad(Item item) {
            QuitaCalidad(item, item.Quality);
        }

        private void QuitaCalidad(Item item, int cantidad) {
            //		int rslt = item.Quality - cantidad;
            //		item.Quality = rslt < CALIDAD_MINIMA ? CALIDAD_MINIMA : rslt;
            //
            //		item.Quality = item.Quality - cantidad < CALIDAD_MINIMA ?
            //				CALIDAD_MINIMA : item.Quality - cantidad;

            if (item.Quality - cantidad < CALIDAD_MINIMA) {
                item.Quality = CALIDAD_MINIMA;
            } else {
                item.Quality = item.Quality - cantidad;
            }

            //		item.Quality = item.Quality - cantidad;
            //		if (item.Quality < CALIDAD_MINIMA) {
            //			item.Quality = CALIDAD_MINIMA;
            //		}
        }

        private void AñadeCalidad(Item item, int cantidad) {
            if (item.Quality + cantidad > CALIDAD_MAXIMA) {
                item.Quality = CALIDAD_MAXIMA;
            } else {
                item.Quality = item.Quality + cantidad;
            }
        }

        public IList<Item> Items {
            get {
                if (items is ICloneable cloneable)
                    return cloneable.Clone() as IList<Item>;
                return items;
            }
        }

        public Item this[int productIndex] {
            get {
                if (0 <= productIndex && productIndex < items.Count)
                    return items[productIndex];
                throw new ProductosException("Indice fuera de rango");
            }
        }
        /*
                IList<Item> Items;
                public GildedRose(IList<Item> Items) {
                    this.Items = Items;
                }
                public void UpdateQuality() {
                    foreach (var item in Items) {
                        if (EsSulfuras(item)) continue;
                        if (NoEsQueso(item) && NoEsEntrada(item)) {
                            Quita1aCalidad(item);
                        } else {
                            Añade1aCalidad(item);
                            if (NoEsEntrada(item)) {
                                if (QuedanMenosDe11Dias(item)) {
                                    Añade1aCalidad(item);
                                }
                                if (QuedanMenosDe6Dias(item)) {
                                    Añade1aCalidad(item);
                                }
                            }
                        }
                        QuitaUnDia(item);
                        if (EstaCaducado(item)) {
                            if (NoEsQueso(item)) {
                                if (NoEsEntrada(item)) {
                                    Quita1aCalidad(item);
                                } else {
                                    PonA0Calidad(item);
                                }
                            } else {
                                Añade1aCalidad(item);
                            }
                        }
                    }
                }

                private void PonA0Calidad(Item item) {
                    item.Quality = 0;
                }

                private bool EstaCaducado(Item item) {
                    return item.SellIn < 0;
                }

                private void QuitaUnDia(Item item) {
                    item.SellIn = item.SellIn - 1;
                }

                private bool QuedanMenosDe6Dias(Item item) {
                    return item.SellIn < 6;
                }

                private bool QuedanMenosDe11Dias(Item item) {
                    return item.SellIn < 11;
                }

                private void Añade1aCalidad(Item item) {
                    if (NoEsMaximaCalidad(item)) {
                        item.Quality = item.Quality + 1;
                    }
                }

                private bool NoEsMaximaCalidad(Item item) {
                    return item.Quality < 50;
                }

                private void Quita1aCalidad(Item item) {
                    if (QuedaCalidad(item))
                        item.Quality = item.Quality - 1;
                }

                private bool QuedaCalidad(Item item) {
                    return item.Quality > 0;
                }

                private bool EsSulfuras(Item item) {
                    return item.Name == "Sulfuras, Hand of Ragnaros";
                }
                private bool NoEsSulfuras(Item item) {
                    return !EsSulfuras(item);
                }

                private bool EsEntrada(Item item) {
                    return item.Name == "Backstage passes to a TAFKAL80ETC concert";
                }

                private bool NoEsEntrada(Item item) {
                    return !EsEntrada(item);
                }

                private bool EsQueso(Item item) {
                    return item.Name == "Aged Brie";
                }

                private bool NoEsQueso(Item item) {
                    return !EsQueso(item);
                }
                */
    }
}
