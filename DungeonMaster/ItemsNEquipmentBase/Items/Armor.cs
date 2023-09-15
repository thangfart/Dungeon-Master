using DungeonMaster.HeroesBase.Parent;
using DungeonMaster.ItemsNEquipmentBase.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMaster.ItemsNEquipmentBase.Items
{
    public class Armor : Item
    {
        public ArmorType ArmorType { get; }
        public HeroAttribute HeroAttribute { get; }

        public Armor(string name, int requiredLevel, 
            ArmorType armorType,
            HeroAttribute heroAttribute)
            : base(name, requiredLevel, Slot.Armor)
        {
            ArmorType = armorType; //default
            HeroAttribute = heroAttribute;
        }
    }
}
