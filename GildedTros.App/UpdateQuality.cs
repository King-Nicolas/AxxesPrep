using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedTros.App
{
    internal class UpdateQuality : IUpdateQuality
    {
        protected int baseDecayRate = 1;
        public virtual void UpdateItemQuality(Item item)
        {
            if (item.Name == "B-DAWG Keychain")
            {
                return;
            }

            item.SellIn--;

            if (item.Name == "Good Wine")
            {
                IncreaseQuality(item, 1 * baseDecayRate);
                return;
            }

            if (item.Name.StartsWith("Backstage passes"))
            {
                if (item.SellIn <= 0)
                {
                    item.Quality = 0;
                }
                if (item.SellIn > 0 && item.SellIn <= 5)
                {
                    IncreaseQuality(item, 3 * baseDecayRate);
                }
                if (item.SellIn > 5 && item.SellIn <= 10)
                {
                    IncreaseQuality(item, 2 * baseDecayRate);
                }
                if (item.SellIn > 10)
                {
                    IncreaseQuality(item, 1 * baseDecayRate);
                }
                return;
            }

            if (item.SellIn < 0)
            {
                DecreaseQuality(item, 2 * baseDecayRate);
            }
            else
            {
                DecreaseQuality(item, 1 * baseDecayRate);
            }

            item.Quality = Math.Clamp(item.Quality, 0, 50);
        }

        protected static void IncreaseQuality(Item item, int amount)
        {
            item.Quality += amount;
            item.Quality = Math.Clamp(item.Quality, 0, 50);
        }

        protected static void DecreaseQuality(Item item, int amount)
        {
            item.Quality -= amount;
            item.Quality = Math.Clamp(item.Quality, 0, 50);
        }
    }
}
