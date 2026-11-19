/********************************************************************
* Name: Enemy.cs
* Author: Preston Magee
* Email: preston.magee @ digipen.edu
* Course: WANIC GD Yr 2 26-27
* Desc: This file contains a healer enemy that heals all teamates instead of attacking the player.
********************************************************************/
public class EnemyHealer : Enemy
{
    public readonly int HealAmount;

    /// <summary>
    /// Create a new healer with a specific heal amount
    /// </summary>
    /// <param name="name"></param>
    /// <param name="health"></param>
    /// <param name="healAmount"></param>
    public EnemyHealer(string name, int health, int healAmount, int minDamage, int maxDamage)
     : base(name, health, minDamage, maxDamage)
    {
        HealAmount = healAmount;
    }

    public override void Act(Battle battle)
    {
        foreach (var enemy in battle.Enemies)
        {
            enemy.Heal(HealAmount);
        }
    }

    public override void Display()
    {
        Console.WriteLine($"{Name} has {Health} health. {Name} will heal all enemies for {HealAmount} amount.");
    }
}