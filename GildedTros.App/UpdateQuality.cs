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
        public void UpdateItemQuality(Item item)
        {
            if (item.Quality == 80)
            {
                return;
            }
            item.SellIn--;
            if (item.Name == "Good Wine")
            {
                IncreaseQuality(item, 1 * baseDecayRate);
                return;
            }

            if (item.SellIn < 0)
            {
                DecreaseQuality(item, 2 * baseDecayRate);
            }
        }

        protected static void IncreaseQuality(Item item, int amount)
        {
            if (item.Quality == 80)
            {
                return;
            }

            item.Quality += amount;
            item.Quality = Math.Clamp(item.Quality, 0, 50);
        }

        protected static void DecreaseQuality(Item item, int amount)
        {
            if (item.Quality == 80)
            {
                return;
            }

            item.Quality -= amount;
            item.Quality = Math.Clamp(item.Quality, 0, 50);
        }
    }
}
