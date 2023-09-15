using DungeonMaster.ItemsNEquipmentBase.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMaster.ItemsNEquipmentBase.Equipment
{
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException(string message) : base(message) 
        { 
        }
        public static InvalidWeaponException InvalidWeaponType(string weaponName) 
        {
            return new InvalidWeaponException($"Invalid weapon type for: {weaponName}.");
        }
        public static InvalidWeaponException Level2Low4Weapon(string weaponName)
        {
            return new InvalidWeaponException($"This hero's level is too low for the weapon: {weaponName}.");
        }

    }
}
