/********************************************************************
* Name: Player.cs
* Author: Preston Magee
* Email: preston.magee @ digipen.edu
* Course: WANIC GD Yr 2 26-27
* Desc: This is the main player object the player stores health and available weapons.
********************************************************************/
public class Player
{
    public int Health { get; private set; }
    public readonly List<Weapon> Weapons;

    /// <summary>
    /// Create a new player with health.
    /// </summary>
    /// <param name="health"></param>
    public Player(int health)
    {
        Health = health;
        Weapons = new()
        {
            new Weapon("Dagger", 2, 10),
            new Weapon("Hammer", 10, 2),
            new Weapon("Sword", 4, 5),
        };
    }

    /// <summary>
    /// Prompts the user to select a weapon to attack with.
    /// </summary>
    /// <returns>Returns the weapon the user selected</returns>
    private Weapon SelectWeapon()
    {
        Console.WriteLine("Your weapons are:");
        for (int i = 0; i < Weapons.Count; i++)
        {
            Console.Write($"    {i + 1}. ");
            Weapons[i].Display();
        }

        Console.WriteLine("Which weapon do you want to use:");
        int weaponIndex = Program.InputNumber(1, Weapons.Count) - 1;

        return Weapons[weaponIndex];
    }

    /// <summary>
    /// Attacks the enemy with a specific weapon the user selects.
    /// </summary>
    /// <param name="enemy"></param>
    public void Attack(Enemy enemy)
    {
        // Prompt the user to select a weapon
        Weapon weapon = SelectWeapon();
        weapon.Attack(enemy);

        // Remove the weapon if it can no longer be used.
        if (!weapon.CanUse()) Weapons.Remove(weapon);
        
        Console.WriteLine($"You attack {enemy.Name} for {weapon.Damage} damage.");

        // Print enemy death if the enemy has died after the player attack
        if (enemy.IsDead())
        {
            Console.WriteLine($"{enemy.Name} died");
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Hurt the player with damage.
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        Health -= damage;
    }

    /// <summary>
    /// Returns true if the player is dead or their health is at 0.
    /// </summary>
    /// <returns></returns>
    public bool IsDead() => Health <= 0;

    /// <summary>
    /// Display the current health of the player.
    /// </summary>
    public void DisplayHealth()
    {
        Console.WriteLine($"You have {Health} health.");
    }
}