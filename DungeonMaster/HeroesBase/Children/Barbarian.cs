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
    public class Barbarian : Hero
    {
        public Barbarian(string name) : base(name)
        {
            LevelAttributes = new HeroAttribute(5, 2, 1);
            ValidWeaponTypes = new List<WeaponType> { WeaponType.Hatchets, WeaponType.Maces, WeaponType.Swords };
            ValidArmorTypes = new List<ArmorType> { ArmorType.Mail, ArmorType.Plate };
        }
        public override void IncAttributes()
        {
            LevelAttributes.Strength += 3;
            LevelAttributes.Dexterity += 2;
            LevelAttributes.Intelligence += 1;
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
            double heroTotalDamage = tempHeroDamage * (1 + (TotalAttributes.Strength / 100.0));
            return heroTotalDamage;
        }
    }
}
