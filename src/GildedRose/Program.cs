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
            DailyUpdater.UpdateQuality(items);
            Displayitems("Output", items);
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

