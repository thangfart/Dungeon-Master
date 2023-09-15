using DungeonMaster.HeroesBase.Parent;
using DungeonMaster.ItemsNEquipmentBase.Enums;
using DungeonMaster.ItemsNEquipmentBase.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMaster.HeroesBase.Children
{
    public class Wizard : Hero
    {
        public Wizard(string name) : base(name)
        {
            LevelAttributes = new HeroAttribute(1, 1, 8);
            ValidWeaponTypes = new List<WeaponType> { WeaponType.Staffs, WeaponType.Wand };
            ValidArmorTypes = new List<ArmorType> { ArmorType.Cloth };
        }
        public override void IncAttributes()
        {
            LevelAttributes.Strength += 1;
            LevelAttributes.Dexterity += 1;
            LevelAttributes.Intelligence += 5;
        }
        public override double HeroDamage()
        {
            double tempHeroDamage;
            if (Equipment[Slot.Weapon] is Weapon weapon)
            {
                tempHeroDamage = weapon.WeaponDamage;
            }
            else
            {
                tempHeroDamage = 1.0;
            }
            double heroTotalDamage = tempHeroDamage * (1 + (TotalAttributes.Intelligence / 100.0));
            return heroTotalDamage;
        }
    }
}
