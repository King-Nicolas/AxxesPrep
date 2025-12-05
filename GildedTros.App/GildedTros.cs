using System.Collections.Generic;
using System.Linq;

namespace GildedTros.App
{
    public class GildedTros
    {
        IList<Item> Items;
        private readonly string[] _smellyItemsList = new string[] { "Duplicate Code", "Long Methods", "Ugly Variable Names" };
        public GildedTros(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                IUpdateQuality strategy = _smellyItemsList.Contains(item.Name)
                ? new UpdateQualitySmellyItem()
                : new UpdateQuality();

                strategy.UpdateItemQuality(item);
            }
        }
    }
}
