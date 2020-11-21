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
            if (item.Quality < Product.MaxQuality)
            {
                item.Quality = item.Quality + 1;
            }
            item.SellIn = item.SellIn - 1;
            if (item.SellIn < 0)
            {
                if (item.Quality < Product.MaxQuality)
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }

        private static void UpdateBackstagePasses(Item item)
        {
            if (item.Quality < Product.MaxQuality)
            {
                item.Quality = item.Quality + 1;

                if (item.Name == Product.BackstagePasses)
                {
                    if (item.SellIn < 11)
                    {
                        if (item.Quality < Product.MaxQuality)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }

                    if (item.SellIn < 6)
                    {
                        if (item.Quality < Product.MaxQuality)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - item.Quality;
            }
        }

        private static void UpdateStandard(Item item)
        {
                if (item.Quality > 0)
                {
                    if (item.Name != Product.Sulfuras)
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
                item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality = item.Quality - 1;
                }
            }
        }
    }
}

