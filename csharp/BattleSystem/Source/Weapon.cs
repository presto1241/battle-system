/********************************************************************
* Name: Weapon.cs
* Author: Preston Magee
* Email: preston.magee @ digipen.edu
* Course: WANIC GD Yr 2 26-27
* Desc: This file contains a basic weapon class the player can use to hurt enemies.
********************************************************************/
public class Weapon
{
    public readonly string Name;
    public readonly int Damage;
    public int NumberOfUses { get; private set; }
    private readonly Player _owner;

    public Weapon(Player owner, string name, int damage, int numberOfUses)
    {
        _owner = owner;
        Name = name;
        Damage = damage;
        NumberOfUses = numberOfUses;
    }

    public void Display()
    {
        Console.WriteLine($"{Name} deals {Damage} and has {NumberOfUses} uses remaining.");
    }

    public void Attack(Enemy enemy)
    {
        if (!CanUse()) return;

        enemy.Hurt(Damage);
        NumberOfUses -= 1;

        // Don't really like this architecture
        if (!CanUse()) _owner.Weapons.Remove(this);
    }

    public bool CanUse() => NumberOfUses > 0;
}