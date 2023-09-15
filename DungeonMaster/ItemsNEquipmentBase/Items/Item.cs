using DungeonMaster.ItemsNEquipmentBase.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMaster.ItemsNEquipmentBase.Items
{
    public abstract class Item
    {
        public string Name { get; }
        public int RequiredLevel { get; }
        public Slot Slot { get; }

        public Item(string name, int requiredLevel, Slot slot)
        {
            Name = name;
            RequiredLevel = requiredLevel;
            Slot = slot;
        }
    }
}
