using System;
using System.Collections.Generic;
using GildedRose.Logic;

namespace GildedRose
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IList<Item> items = new List<Item>
            {
                new Item {Name = Product.DexterityVest, SellIn = 10, Quality = 20},
                new Item {Name = Product.AgedBrie, SellIn = 2, Quality = 0},
                new Item {Name = Product.ElixirMongoose, SellIn = 5, Quality = 7},
                new Item {Name = Product.Sulfuras, SellIn = 0, Quality = 80},
                new Item {Name = Product.BackstagePasses, SellIn = 15, Quality = 20},
                new Item {Name = Product.ConjuredCake, SellIn = 3, Quality = 6}
            };
            Displayitems("Input", items);
            UpdateQuality(items);
            Displayitems("Output", items);
        }

        public static void UpdateQuality(IList<Item> items)
        {
            foreach (var item in items)
            {
                UpdateItemQuality(item);
            }
        }

        private static void UpdateItemQuality(Item item)
        {
            if (item.Name != Product.AgedBrie && item.Name != Product.BackstagePasses)
            {
                if (item.Quality > 0)
                {
                    if (item.Name != Product.Sulfuras)
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == Product.BackstagePasses)
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (item.Name != Product.Sulfuras)
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != Product.AgedBrie)
                {
                    if (item.Name != Product.BackstagePasses)
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != Product.Sulfuras)
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }

        private static void Displayitems(string title,
            IEnumerable<Item> updateditems)
        {
            Console.WriteLine($"{title}:");
            foreach (var item in updateditems)
                Console.WriteLine($"  - {item}");
        }
    }
}

