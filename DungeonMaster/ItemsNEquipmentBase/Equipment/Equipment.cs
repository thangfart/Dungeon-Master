using DungeonMaster.ItemsNEquipmentBase.Enums;
using DungeonMaster.ItemsNEquipmentBase.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMaster.ItemsNEquipmentBase.Equipment
{
    public class Equipment
    {
        public Dictionary<Slot, Item?> equipmentSlots;

        public Equipment() 
        {
            equipmentSlots = new Dictionary<Slot, Item?>
            {
                { Slot.Weapon, null},
                { Slot.Armor, null},
                { Slot.Head, null},
                { Slot.Body, null},
                { Slot.Legs, null}
            };
        }
    }
}
