public abstract class BaseCharacter
{
    public int Strength { get; set; }
    public int Magic { get; set; }
    public int Health { get; set; }
    public Weapon EquippedWeapon { get; set; }

    protected BaseCharacter(int strength, int magic, int health)
    {
        Strength = strength;
        Magic = magic;
        Health = health;
    }

    public virtual void InflictDamage(BaseCharacter target)
    {
        if (EquippedWeapon == null)
        {
            Console.WriteLine($"{GetType().Name} has no weapon equipped and cannot attack.");
            return;
        }

        int damage = EquippedWeapon.CalculateDamage(this);
        target.Health -= damage;

        if (target.Health < 0)
        {
            target.Health = 0;
        }

        Console.WriteLine($"{GetType().Name} attacks {target.GetType().Name} with {EquippedWeapon.GetType().Name}, inflicting {damage} damage. {target.GetType().Name}'s health is now {target.Health}.");
    }

    public void DisplayStats()
    {
        Console.WriteLine($"{GetType().Name} Stats -> Strength: {Strength}, Magic: {Magic}, Health: {Health}");
    }
}

public class Warrior : BaseCharacter
{
    public Warrior() : base(strength: 5, magic: 0, health: 100) { }
}

public class Mage : BaseCharacter
{
    public Mage() : base(strength: 1, magic: 2, health: 50) { }


    public override void InflictDamage(BaseCharacter target)
    {
        if (EquippedWeapon is FoolStaff)
        {
            Random rnd = new Random();

            if (rnd.Next(2) == 0)
            {
                (Strength, Magic) = (Magic, Strength);
            }

            Console.WriteLine("Характеристики изменены случайным образом (только сила и магия):");
            DisplayStats();
        }
        base.InflictDamage(target);
    }
}

public abstract class Weapon
{
    public abstract int CalculateDamage(BaseCharacter attacker);
}

public class Sword : Weapon
{
    public override int CalculateDamage(BaseCharacter attacker)
    {
        return attacker.Strength * 3;
    }
}

public class MagicStaff : Weapon
{
    public override int CalculateDamage(BaseCharacter attacker)
    {
        return attacker.Magic * 2 + 2;
    }
}

public class FoolStaff : Weapon
{
    private Random random = new Random();

    public override int CalculateDamage(BaseCharacter attacker)
    {
        return random.Next(0, 11);
    }
}

public class CharacterFactory
{
    public BaseCharacter CreateCharacter(string characterType)
    {
        switch (characterType.ToLower())
        {
            case "warrior":
                return new Warrior();
            case "mage":
                return new Mage();
            default:
                throw new ArgumentException("Unknown character type");
        }
    }
}

public class WeaponFactory
{
    public Weapon CreateWeapon(string weaponType)
    {
        switch (weaponType.ToLower())
        {
            case "sword":
                return new Sword();
            case "magicstaff":
                return new MagicStaff();
            case "foolstaff":
                return new FoolStaff();
            default:
                throw new ArgumentException("Unknown weapon type");
        }
    }
}


