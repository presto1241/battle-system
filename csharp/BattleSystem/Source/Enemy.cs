public class Enemy {
    public readonly string Name;
    public int Health { get; private set; }
    public readonly int MinDamage;
    public readonly int MaxDamage;

    public Enemy(string name, int health, int minDamage, int maxDamage)
    {
        Name = name;
        Health = health;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
    }

    public void DisplayHealth()
    {
        Console.WriteLine($"{Name} has {Health} health.");
    }

    public void Attack(Player player)
    {
        Random random = new Random();

        int damage = random.Next(MinDamage, MaxDamage);
        player.Damage(damage);

        Console.WriteLine($"{Name} attacked you for {damage} damage");
    }

    public void Hurt(int damage)
    {
        Health -= damage;
    }

    public bool IsDead() => Health <= 0;
}