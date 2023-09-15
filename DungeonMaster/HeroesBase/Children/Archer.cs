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
    public class Archer : Hero
    {
        public Archer(string name) : base(name)
        {
            LevelAttributes = new HeroAttribute(1, 7, 1);
            ValidWeaponTypes = new List<WeaponType> { WeaponType.Bows };
            ValidArmorTypes = new List<ArmorType> { ArmorType.Leather, ArmorType.Mail };
        }
        public override void IncAttributes()
        {
            LevelAttributes.Strength += 1;
            LevelAttributes.Dexterity += 5;
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
            double heroTotalDamage = tempHeroDamage * (1 + (TotalAttributes.Dexterity / 100.0));
            return heroTotalDamage;
        }
    }

}
