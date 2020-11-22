using System;
using System.Collections.Generic;

namespace GildedRose.Logic
{
    public class DailyUpdater
    {
        public static void UpdateQuality(IList<Item> items)
        {
            foreach (var item in items)
            {
                UpdateItemQuality(item);
            }
        }

        private static void UpdateItemQuality(Item item)
        {
            switch (item.Name)
            {
                case (Product.AgedBrie):
                    UpdateAgedCheeseProduct(item);
                    return;
                case (Product.BackstagePasses):
                    UpdateBackstagePasses(item);
                    return;
                case (Product.Sulfuras):
                    return;
            }
            UpdateStandard(item);
        }

        private static void UpdateAgedCheeseProduct(Item item)
        {
            item.SellIn -= 1;
            var qualityDelta = item.SellIn < 0 ? 2 : 1;
            item.Quality = Math.Min(item.Quality + qualityDelta, Product.MaxQuality);
        }

        private static void UpdateBackstagePasses(Item item)
        {
            item.SellIn -= 1;
            var delta = item.SellIn >= 10 ? 1 :
                (item.SellIn >= 5) ? 2 :
                    (item.SellIn >= 0) ? 3 : -item.Quality;
            item.Quality = Math.Min(item.Quality + delta, Product.MaxQuality);
        }

        private static void UpdateStandard(Item item)
        {
            item.SellIn -= 1;
            var q = item.Quality - (item.SellIn >= 0 ? 1 : 2);
            item.Quality = Math.Max(q, 0);
        }
    }
}

