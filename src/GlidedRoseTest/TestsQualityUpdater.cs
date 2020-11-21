using NUnit.Framework;
using GildedRose;
using System.Collections.Generic;
using System.Linq;
using GildedRose.Logic;

namespace GlidedRoseTest
{
    [TestFixture()]
    public class TestQualityUpdater
    {
        private class Product
        {
            public const string Dexterity = "+5 Dexterity Vest";
            public const string AgedBrie = "Aged Brie";
            public const string ElixirMongoose = "Elixir of the Mongoose";
            public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
            public const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
            public const string ConjuredMana = "Conjured Mana Cake";
        }

        private const int In10days = 10;
        private const int In11days = 11;
        private const int In5days = 5;
        private const int InTomorrow = 1;
        private const int InToday = 0;
        private const int Over1day = -1;

        // --- Sulfuras -----------------------------------
        // [TestCase(In10days, 90)] - exception
        [TestCase(In10days, 50)]
        [TestCase(In10days, InToday)]
        [TestCase(InToday, 50)]
        public void UpdateItem_WithSulfuras(
            int sellIn, int quality)
        {
            var items = new List<Item>() {
                new Item(){ Name = Product.Sulfuras, SellIn = sellIn, Quality = quality }
            };
            DailyUpdater.UpdateQuality(items);
            var actualItem = items[0];
            Assert.AreEqual(sellIn, actualItem.SellIn);
            Assert.AreEqual(quality, actualItem.Quality);
        }

        // --- Standard Products --------------------------
        [TestCase(Product.Dexterity, In10days, 50, 49)]
        [TestCase(Product.Dexterity, In10days, 20, 19)]
        [TestCase(Product.Dexterity, In10days, 1, 0)]
        [TestCase(Product.Dexterity, In10days, 0, 0)]
        [TestCase(Product.Dexterity, InToday, 20, 18)]
        [TestCase(Product.Dexterity, Over1day, 20, 18)]
        [TestCase(Product.ElixirMongoose, In10days, 50, 49)]
        [TestCase(Product.ElixirMongoose, InToday, 20, 18)]
        [TestCase(Product.ElixirMongoose, Over1day, 20, 18)]
        public void UpadateQuality_WithOther(
            string name, int sellIn, int quality, int expectedQuality)
        {
            var items = new List<Item>() {
                new Item(){ Name = name, SellIn = sellIn, Quality = quality }
            };
            DailyUpdater.UpdateQuality(items);
            var actualItem = items[0];
            Assert.AreEqual(sellIn - 1, actualItem.SellIn);
            Assert.AreEqual(expectedQuality, actualItem.Quality);
        }

        // --- Aged Cheese Products ----------------------------------
        [TestCase(In10days, 50, 50)]
        [TestCase(In10days, 0, 1)]
        [TestCase(In10days + 1, 20, 21)]
        [TestCase(In10days, 20, 21)]
        [TestCase(InTomorrow, 20, 21)]
        [TestCase(InToday, 20, 22)]
        [TestCase(Over1day, 20, 22)]
        [TestCase(Over1day - 1, 20, 22)]
        public void UpadateQuality_WithAgedBrie(
            int sellIn, int quality, int expectedQuality)
        {
            var items = new List<Item>() {
                new Item(){ Name = Product.AgedBrie, SellIn = sellIn, Quality = quality }
            };
            DailyUpdater.UpdateQuality(items);
            var actualItem = items[0];
            Assert.AreEqual(sellIn - 1, actualItem.SellIn);
            Assert.AreEqual(expectedQuality, actualItem.Quality);
        }

        // --- Backstage Passes ----------------------------------
        [TestCase(In11days, 20, 21)]
        [TestCase(In10days, 20, 22)]
        [TestCase(In10days - 1, 20, 22)]
        [TestCase(In5days + 1, 20, 22)]
        [TestCase(In5days, 20, 23)]
        [TestCase(In5days - 1, 20, 23)]
        [TestCase(In5days, 49, 50)]
        [TestCase(In5days, 50, 50)]
        [TestCase(InTomorrow, 20, 23)]
        [TestCase(InToday, 20, 0)]
        [TestCase(Over1day, 20, 0)]
        public void UpadateQuality_WithBackstagePasses(
            int sellIn, int quality, int expectedQuality)
        {
            var items = new List<Item>() {
                new Item(){ Name = Product.BackstagePasses, SellIn = sellIn, Quality = quality }
            };
            DailyUpdater.UpdateQuality(items);
            var actualItem = items[0];
            Assert.AreEqual(sellIn - 1, actualItem.SellIn);
            Assert.AreEqual(expectedQuality, actualItem.Quality);
        }

        // --- Conjured Products ----------------------------------
        //[TestCase(In10days, 20, 18)]
        //[TestCase(In10days, 1, 0)]
        //[TestCase(In10days, 0, 0)]
        //[TestCase(InTomorrow, 20, 18)]
        //[TestCase(InToday, 20, 16)]
        //[TestCase(Over1day, 20, 16)]
        public void UpadateQuality_WithConjuredMana(
            int sellIn, int quality, int expectedQuality)
        {
            var items = new List<Item>() {
                new Item(){ Name = Product.ConjuredMana, SellIn = sellIn, Quality = quality }
            };
            DailyUpdater.UpdateQuality(items);
            var actualItem = items[0];
            Assert.AreEqual(sellIn-1, actualItem.SellIn);
            Assert.AreEqual(expectedQuality, actualItem.Quality);
        }
    }
}