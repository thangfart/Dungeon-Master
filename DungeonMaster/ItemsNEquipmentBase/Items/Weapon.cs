using DungeonMaster.ItemsNEquipmentBase.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMaster.ItemsNEquipmentBase.Items
{
    public class Weapon : Item
    {
        public WeaponType WeaponType { get; }
        public double WeaponDamage { get; }
        public Weapon(string name, int requiredLevel, 
            double weaponDamage,
            WeaponType weaponType) 
            : base(name, requiredLevel, Slot.Weapon)
        {
            WeaponType = weaponType;
            WeaponDamage = weaponDamage;
        }
    }
}
