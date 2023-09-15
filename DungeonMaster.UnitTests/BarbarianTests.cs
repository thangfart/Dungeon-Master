using DungeonMaster.HeroesBase.Children;
using DungeonMaster.HeroesBase.Parent;
using DungeonMaster.ItemsNEquipmentBase.Enums;
using DungeonMaster.ItemsNEquipmentBase.Equipment;
using DungeonMaster.ItemsNEquipmentBase.Items;

namespace DungeonMaster.UnitTests
{
    public class BarbarianTests
    {
        [Fact]
        public void Barbarian_CanEquipValidWeapon()
        {
            // Arrange
            Barbarian barbarian = new Barbarian("Phil");
            Weapon validWeapon = new Weapon("Hatchet", 1, 5, WeaponType.Hatchets);

            // Act
            barbarian.EquipWeapon(validWeapon);

            // Assert
            Assert.Equal(validWeapon, barbarian.Equipment[Slot.Weapon]);
        }

        [Fact]
        public void Barbarian_CantEquipInvalidWeapon()
        {
            // Arrange
            Barbarian barbarian = new Barbarian("Phil");
            Weapon invalidWeapon = new Weapon("Staff", 1, 5, WeaponType.Staffs);

            // Act & Assert
            InvalidWeaponException exception = Assert.Throws<InvalidWeaponException>(() => barbarian.EquipWeapon(invalidWeapon));
            Assert.Equal("Invalid weapon type for: Staff.", exception.Message);
        }

        [Fact]
        public void Barbarian_CanEquipValidArmor()
        {
            // Arrange
            Barbarian barbarian = new Barbarian("Phil");
            Armor validArmor = new Armor("Plate", 1, ArmorType.Plate, new HeroAttribute(1, 0, 0));

            // Act
            barbarian.EquipArmor(validArmor);

            // Assert
            Assert.Equal(validArmor, barbarian.Equipment[Slot.Armor]);
        }

        [Fact]
        public void Barbarian_CantEquipInvalidArmor()
        {
            // Arrange
            Barbarian barbarian = new Barbarian("Phil");
            Armor invalidArmor = new Armor("Leather", 1, ArmorType.Leather, new HeroAttribute(1, 0, 0));

            // Act & Assert
            InvalidArmorException exception = Assert.Throws<InvalidArmorException>(() => barbarian.EquipArmor(invalidArmor));
            Assert.Equal("Invalid armor type for: Leather.", exception.Message);
        }

        [Fact]
        public void Barbarian_LevelUp_IncreasesAttributes()
        {
            // Arrange
            Barbarian barbarian = new Barbarian("Phil");

            // Act
            barbarian.LevelIncrease();

            // Assert
            Assert.Equal(2, barbarian.Level);
            Assert.Equal(8, barbarian.LevelAttributes.Strength);
            Assert.Equal(4, barbarian.LevelAttributes.Dexterity);
            Assert.Equal(2, barbarian.LevelAttributes.Intelligence);
        }

        [Fact]
        public void Barbarian_EquipValidArmor_IncreasesAttributes()
        {
            // Arrange
            Barbarian barbarian = new Barbarian("Phil");
            Armor validArmor = new Armor("Plate", 1, ArmorType.Plate, new HeroAttribute(1, 0, 0));

            // Act
            barbarian.EquipArmor(validArmor);

            // Assert
            Assert.Equal(6, barbarian.TotalAttributes.Strength); // 5 (base) + 1 (armor)
            Assert.Equal(2, barbarian.TotalAttributes.Dexterity); // Unchanged
            Assert.Equal(1, barbarian.TotalAttributes.Intelligence); // Unchanged 
        }

        [Fact]
        public void Barbarian_EquipValidWeapon_IncreasesDamage()
        {
            // Arrange
            Barbarian barbarian = new Barbarian("Phil");
            Weapon validWeapon = new Weapon("Hatchet", 1, 5, WeaponType.Hatchets);

            // Act
            barbarian.EquipWeapon(validWeapon);

            // Assert
            double expectedHeroDamage = validWeapon.WeaponDamage * (1.0 + (barbarian.TotalAttributes.Strength / 100.0));
            Assert.Equal(expectedHeroDamage, barbarian.HeroDamage());
        }
    }
}