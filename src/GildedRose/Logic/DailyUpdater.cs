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
    }
}

