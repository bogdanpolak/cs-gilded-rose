using System;
using System.Collections.Generic;
using GildedRose.Logic;

namespace GildedRose
{

    public class Program
    {
        private const string DexterityVest = "+5 Dexterity Vest";
        private const string AgedBrie = "Aged Brie";
        private const string ElixirMongoose = "Elixir of the Mongoose";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private const string ConjuredCake = "Conjured Mana Cake";

        public static void Main(string[] args)
        {
            IList<Item> items = new List<Item>
            {
                new Item {Name = DexterityVest, SellIn = 10, Quality = 20},
                new Item {Name = AgedBrie, SellIn = 2, Quality = 0},
                new Item {Name = ElixirMongoose, SellIn = 5, Quality = 7},
                new Item {Name = Sulfuras, SellIn = 0, Quality = 80},
                new Item {Name = BackstagePasses, SellIn = 15, Quality = 20},
                new Item {Name = ConjuredCake, SellIn = 3, Quality = 6}
            };
            Displayitems("Input", items);
            UpdateQuality(items);
            Displayitems("Output", items);
        }

        public static void UpdateQuality(IList<Item> items)
        {
            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Name != AgedBrie && items[i].Name != BackstagePasses)
                {
                    if (items[i].Quality > 0)
                    {
                        if (items[i].Name != Sulfuras)
                        {
                            items[i].Quality = items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (items[i].Quality < 50)
                    {
                        items[i].Quality = items[i].Quality + 1;

                        if (items[i].Name == BackstagePasses)
                        {
                            if (items[i].SellIn < 11)
                            {
                                if (items[i].Quality < 50)
                                {
                                    items[i].Quality = items[i].Quality + 1;
                                }
                            }

                            if (items[i].SellIn < 6)
                            {
                                if (items[i].Quality < 50)
                                {
                                    items[i].Quality = items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (items[i].Name != Sulfuras)
                {
                    items[i].SellIn = items[i].SellIn - 1;
                }

                if (items[i].SellIn < 0)
                {
                    if (items[i].Name != AgedBrie)
                    {
                        if (items[i].Name != BackstagePasses)
                        {
                            if (items[i].Quality > 0)
                            {
                                if (items[i].Name != Sulfuras)
                                {
                                    items[i].Quality = items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            items[i].Quality = items[i].Quality - items[i].Quality;
                        }
                    }
                    else
                    {
                        if (items[i].Quality < 50)
                        {
                            items[i].Quality = items[i].Quality + 1;
                        }
                    }
                }
            }
        }

        private static void Displayitems(string title,
            IEnumerable<Item> updateditems)
        {
            System.Console.WriteLine($"{title}:");
            foreach (var item in updateditems)
                System.Console.WriteLine($"  - {item}");
        }
    }
}

