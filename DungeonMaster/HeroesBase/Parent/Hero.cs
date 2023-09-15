using DungeonMaster.ItemsNEquipmentBase.Enums;
using DungeonMaster.ItemsNEquipmentBase.Equipment;
using DungeonMaster.ItemsNEquipmentBase.Items;
using System.Text;

namespace DungeonMaster.HeroesBase.Parent
{
    abstract public class Hero
    {
        public string Name { get; }
        public int Level { get; protected set; }
        public HeroAttribute LevelAttributes { get; protected set; }
        public Dictionary<Slot, Item?> Equipment { get; }
        public List<WeaponType> ValidWeaponTypes { get; protected set; }
        public List<ArmorType> ValidArmorTypes { get; protected set; }
        public HeroAttribute TotalAttributes
        {
            get
            {
                HeroAttribute total = new HeroAttribute(0, 0, 0);
                total.Strength += LevelAttributes.Strength;
                total.Dexterity += LevelAttributes.Dexterity;
                total.Intelligence += LevelAttributes.Intelligence;

                foreach (Item item in Equipment.Values)
                {
                    if (item is Armor armor)
                    {
                        // inc aattributes given armor specs
                        total.Strength += armor.HeroAttribute.Strength;
                        total.Dexterity += armor.HeroAttribute.Dexterity;
                        total.Intelligence += armor.HeroAttribute.Intelligence;
                    }
                }
                return total;

            }
        }
   
        public Hero(string name)
        {
            Name = name;
            Level = 1;
            LevelAttributes = new HeroAttribute(0,0,0);
            Equipment = new Dictionary<Slot, Item?>();
            ValidWeaponTypes = new List<WeaponType>();
            ValidArmorTypes = new List<ArmorType>();
        }
        public void LevelIncrease()
        {
            Level++;
            // should invoke another method that increases Hero ATTRIBUTES accordignly
            IncAttributes();
        }
        public void EquipWeapon(Weapon weapon)
        {
            if (!ValidWeaponTypes.Contains(weapon.WeaponType)) 
            {
                throw InvalidWeaponException.InvalidWeaponType(weapon.Name);
            }
            if (Level < weapon.RequiredLevel)
            {
                throw InvalidWeaponException.Level2Low4Weapon(weapon.Name);
            }
            // else equip the hero
            Equipment[Slot.Weapon] = weapon;
        }
        public void EquipArmor(Armor armor)
        {
            if (!ValidArmorTypes.Contains(armor.ArmorType))
            {
                throw InvalidArmorException.InvalidArmorTypeException(armor.Name);
            }
            if (Level < armor.RequiredLevel)
            {
                throw InvalidArmorException.Level2Low4Armor(armor.Name);
            }
            // else equip the hero
            Equipment[Slot.Armor] = armor;
        }
        public abstract void IncAttributes();
        public abstract double HeroDamage();
        public virtual string DisplayHeroInfo()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine($"Name: {Name}");
            info.AppendLine($"Class: {GetType().Name}");
            info.AppendLine($"Level: {Level}");
            info.AppendLine($"Total Strength: {TotalAttributes.Strength}");
            info.AppendLine($"Total Dexterity: {TotalAttributes.Dexterity}");
            info.AppendLine($"Total Intelligence: {TotalAttributes.Intelligence}");
            info.AppendLine($"Damage: {HeroDamage()}");

            return info.ToString();
        }
    }
}
