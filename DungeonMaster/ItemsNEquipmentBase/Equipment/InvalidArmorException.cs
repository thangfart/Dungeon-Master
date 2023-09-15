using DungeonMaster.HeroesBase.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMaster.ItemsNEquipmentBase.Equipment
{
    public class InvalidArmorException : Exception
    {
        public InvalidArmorException(string message) : base(message)
        {}
        public static InvalidArmorException InvalidArmorTypeException(string armorName)
        {
            return new InvalidArmorException($"Invalid armor type for: {armorName}.");
        }
        public static InvalidArmorException Level2Low4Armor(string armorName)
        {
            return new InvalidArmorException($"This hero's level is too low for the armor: {armorName}.");
        }

    }
}
