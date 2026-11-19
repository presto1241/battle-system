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
    /// A method that makes the enemy run an action. This can be overriden to create more actions.
    /// By default, act will call attack.
    /// </summary>
    /// <param name="battle"></param>
    public virtual void Act(Battle battle)
    {
        Attack(battle.Player);
    }

    /// <summary>
    /// Make the enemy attack a player.
    /// </summary>
    /// <param name="player"></param>
    private void Attack(Player player)
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
    /// Heal the enemy with health.
    /// </summary>
    /// <param name="health"></param>
    public void Heal(int health)
    {
        if (IsDead()) return;
        Health += health;
    }

    /// <summary>
    /// Returns true if the enemy  is dead or their health is at 0.
    /// </summary>
    /// <returns></returns>
    public bool IsDead() => Health <= 0;

    /// <summary>
    /// Display the current status of the enemy.
    /// </summary>
    public virtual void Display()
    {
        Console.WriteLine($"{Name} has {Health} health.");
    }
}