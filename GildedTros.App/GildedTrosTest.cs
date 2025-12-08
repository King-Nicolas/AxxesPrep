using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class GildedTrosTest
    {
        [Fact]
        public void NormalItem_DecreasesQualityAndSellDate()
        {
            Item item = new Item { Name = "foo", SellIn = 1, Quality = 1 };
            IUpdateQuality updater = new UpdateQuality();

            updater.UpdateItemQuality(item);

            Assert.Equal(0, item.SellIn);  // SellIn decreased by 1
            Assert.Equal(0, item.Quality); // Quality decreased by 1
        }

        [Fact]
        public void NormalItem_DoubleQualityDecrease_Expired()
        {
            Item item = new Item { Name = "foo", SellIn = -1, Quality = 2 };
            IUpdateQuality updater = new UpdateQuality();

            updater.UpdateItemQuality(item);

            Assert.Equal(-2, item.SellIn);  // SellIn decreased by 1
            Assert.Equal(0, item.Quality); // Quality decreased by 2
        }

        [Theory]
        [InlineData(1, 0, 0, 0)] // SellIn 1 -> 0 & Quality 0 -> 0
        [InlineData(1, 50, 0, 49)] //SellIn 1 -> 0 & Quality 50 -> 49

        public void NormalItem_QualityOverAndUnderLimit(int initialSellIn, int initialQuality, int expectedSellIn, int expectedQuality)
        {
            Item item = new Item { Name = "foo", SellIn = initialSellIn, Quality = initialQuality };
            IUpdateQuality updater = new UpdateQuality();

            updater.UpdateItemQuality(item);

            Assert.Equal(expectedSellIn, item.SellIn);
            Assert.Equal(expectedQuality, item.Quality);
        }

        [Fact]
        public void GoodWine_QualityIncrease()
        {
            Item item = new Item { Name = "Good Wine", SellIn = 10, Quality = 10 };

            var updater = new UpdateQuality();

            updater.UpdateItemQuality(item);

            Assert.Equal(9, item.SellIn);  // SellIn decreased by 1
            Assert.Equal(11, item.Quality); // Quality increased by 1
        }

        [Fact]
        public void GoodWine_DoubleQualityIncrease_Expired()
        {
            Item item = new Item { Name = "Good Wine", SellIn = -1, Quality = 10 };

            var updater = new UpdateQuality();

            updater.UpdateItemQuality(item);

            Assert.Equal(-2, item.SellIn);  // SellIn decreased by 1
            Assert.Equal(12, item.Quality); // Quality increased by 2
        }

        [Fact]
        public void GoodWine_QualityStopAt50()
        {
            Item item = new Item { Name = "Good Wine", SellIn = -1, Quality = 50 };

            var updater = new UpdateQuality();

            updater.UpdateItemQuality(item);

            Assert.Equal(-2, item.SellIn);  // SellIn decreased by 1
            Assert.InRange(item.Quality,0,50); // Quality increased by 2
        }

        [Theory]
        [InlineData(0, 10, -1, 0)]      // SellIn=0, Quality=10  -> after update SellIn=-1, Quality=0   // SellIn Range < 0
        [InlineData(4, 10, 3, 13)]      // SellIn=4, Quality=10  -> after update SellIn=3, Quality=13   // SellIn Range between 0 - 5
        [InlineData(9, 10, 8, 12)]      // SellIn=9, Quality=10  -> after update SellIn=8, Quality=12   // SellIn Range between 6 - 10
        [InlineData(15, 10, 14, 11)]    // SellIn=15, Quality=10 -> after update SellIn=14, Quality=12  // SellIn Range > 10
        public void BackstagePasses_QualityIncreaseAtRanges(int initialSellIn, int initialQuality, int expectedSellIn, int expectedQuality)
        {
            var item = new Item { Name = "Backstage passes to HAXX", SellIn = initialSellIn, Quality = initialQuality };
            var updater = new UpdateQuality();

            updater.UpdateItemQuality(item);

            Assert.Equal(expectedSellIn, item.SellIn);
            Assert.Equal(expectedQuality, item.Quality);
        }


        [Fact]
        public void SmellyItem_DoubleDecreaseQuality_NotExpired()
        {
            Item item = new Item { Name = "Duplicate Code", SellIn = 5, Quality = 10 };
            IUpdateQuality updater = new UpdateQualitySmellyItem();

            updater.UpdateItemQuality(item);

            Assert.Equal(4, item.SellIn);  // SellIn decreased by 1
            Assert.Equal(8, item.Quality); // Quality decreased by 2
        }

        [Fact]
        public void SmellyItem_DoubleDecreaseQuality_Expired()
        {
            Item item = new Item { Name = "Duplicate Code", SellIn = -1, Quality = 10 };
            IUpdateQuality updater = new UpdateQualitySmellyItem();

            updater.UpdateItemQuality(item);

            Assert.Equal(-2, item.SellIn);  // SellIn decreased by 1
            Assert.Equal(6, item.Quality); // Quality decreased by 4
        }
    }
}