/********************************************************************
* Name: Enemy.cs
* Author: Preston Magee
* Email: preston.magee @ digipen.edu
* Course: WANIC GD Yr 2 26-27
* Desc: This file contains basic data and actions for an enemy in the battle system.
********************************************************************/
public class Enemy {
    public readonly string Name;
    public int Health { get; private set; }
    public readonly int MinDamage;
    public readonly int MaxDamage;

    /// <summary>
    /// Create a new enemy with a name, health, minimum damage, and maximum damage.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="health"></param>
    /// <param name="minDamage"></param>
    /// <param name="maxDamage"></param>
    public Enemy(string name, int health, int minDamage, int maxDamage)
    {
        Name = name;
        Health = health;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
    }

    /// <summary>
    /// Make the enemy attack a player.
    /// </summary>
    /// <param name="player"></param>
    public void Attack(Player player)
    {
        Random random = new Random();

        int damage = random.Next(MinDamage, MaxDamage);
        player.Damage(damage);

        Console.WriteLine($"{Name} attacked you for {damage} damage");
    }

    /// <summary>
    /// Hurt the enemy with damage.
    /// </summary>
    /// <param name="damage"></param>
    public void Hurt(int damage)
    {
        Health -= damage;
    }

    /// <summary>
    /// Returns true if the enemy  is dead or their health is at 0.
    /// </summary>
    /// <returns></returns>
    public bool IsDead() => Health <= 0;

    /// <summary>
    /// Display the current health of the enemy.
    /// </summary>
    public void DisplayHealth()
    {
        Console.WriteLine($"{Name} has {Health} health.");
    }
}