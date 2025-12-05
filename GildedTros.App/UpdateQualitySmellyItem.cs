using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedTros.App
{
    internal class UpdateQualitySmellyItem : UpdateQuality
    {
        public override void UpdateItemQuality(Item item)
        {
            base.baseDecayRate = 2;
            base.UpdateItemQuality(item);
        }
    }
}
