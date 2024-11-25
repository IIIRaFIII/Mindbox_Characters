public class Program
{
    public static void Main(string[] args)
    {
        CharacterFactory characterFactory = new CharacterFactory();
        WeaponFactory weaponFactory = new WeaponFactory();

        BaseCharacter mage = characterFactory.CreateCharacter("mage");
        BaseCharacter warrior = characterFactory.CreateCharacter("warrior");


        Weapon magicStaff = weaponFactory.CreateWeapon("magicstaff");
        Weapon foolStaff = weaponFactory.CreateWeapon("foolstaff");

        // Демонстрация атаки мага с обычным посохом
        Console.WriteLine("\n=== Маг атакует с обычным посохом (MagicStaff) ===");
        mage.EquippedWeapon = magicStaff;
        Console.WriteLine("Характеристики мага перед атакой:");
        mage.DisplayStats();
        mage.InflictDamage(warrior);
        Console.WriteLine("Характеристики мага после атаки:");
        mage.DisplayStats();

        // Демонстрация атаки мага с Посохом Дурака
        Console.WriteLine("\n=== Маг экипирует Посох Дурака и атакует ===");
        mage.EquippedWeapon = foolStaff;
        Console.WriteLine("Характеристики мага перед атакой:");
        mage.DisplayStats();
        mage.InflictDamage(warrior);
        Console.WriteLine("Характеристики мага после атаки:");
        mage.DisplayStats();
    }
}