public class Player
{
    public int Health { get; private set; }

    public Player(int health)
    {
        Health = health;
    }

    public void Damage(int damage)
    {
        Health -= damage;
    }

    public bool IsDead() => Health <= 0;

    public void DisplayHealth()
    {
        Console.WriteLine($"You have {Health} health.");
    }
}