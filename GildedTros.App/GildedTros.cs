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

            //    for (var i = 0; i < Items.Count; i++)
            //    {
            //        if (Items[i].Name != "Good Wine"
            //            && Items[i].Name != "Backstage passes for Re:factor"
            //            && Items[i].Name != "Backstage passes for HAXX")
            //        {
            //            if (Items[i].Quality > 0)
            //            {
            //                if (Items[i].Name != "B-DAWG Keychain")
            //                {
            //                    Items[i].Quality = Items[i].Quality - 1;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (Items[i].Quality < 50)
            //            {
            //                Items[i].Quality = Items[i].Quality + 1;

            //                if (Items[i].Name == "Backstage passes for Re:factor"
            //                || Items[i].Name == "Backstage passes for HAXX")
            //                {
            //                    if (Items[i].SellIn < 11)
            //                    {
            //                        if (Items[i].Quality < 50)
            //                        {
            //                            Items[i].Quality = Items[i].Quality + 1;
            //                        }
            //                    }

            //                    if (Items[i].SellIn < 6)
            //                    {
            //                        if (Items[i].Quality < 50)
            //                        {
            //                            Items[i].Quality = Items[i].Quality + 1;
            //                        }
            //                    }
            //                }
            //            }
            //        }

            //        if (Items[i].Name != "B-DAWG Keychain")
            //        {
            //            Items[i].SellIn = Items[i].SellIn - 1;
            //        }

            //        if (Items[i].SellIn < 0)
            //        {
            //            if (Items[i].Name != "Good Wine")
            //            {
            //                if (Items[i].Name != "Backstage passes for Re:factor"
            //                    && Items[i].Name != "Backstage passes for HAXX")
            //                {
            //                    if (Items[i].Quality > 0)
            //                    {
            //                        if (Items[i].Name != "B-DAWG Keychain")
            //                        {
            //                            Items[i].Quality = Items[i].Quality - 1;
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    Items[i].Quality = Items[i].Quality - Items[i].Quality;
            //                }
            //            }
            //            else
            //            {
            //                if (Items[i].Quality < 50)
            //                {
            //                    Items[i].Quality = Items[i].Quality + 1;
            //                }
            //            }
            //        }
            //    }
        }
    }
}
