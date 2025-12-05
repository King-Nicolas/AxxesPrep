using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedTros.App
{
    internal class UpdateQualitySmellyItem : UpdateQuality
    {
        private readonly String[] _smellyItemsList = new String[] { "Duplicate Code", "Long Methods", "Ugly Variable Names" };
        public override void UpdateItemQuality(Item item)
        {
            base.baseDecayRate = 2;
            if (_smellyItemsList.Contains(item.Name))
            {
                base.UpdateItemQuality(item);
            }
        }
    }
}
