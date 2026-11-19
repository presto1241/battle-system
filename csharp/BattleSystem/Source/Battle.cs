/********************************************************************
* Name: Battle.cs
* Author: Preston Magee
* Email: preston.magee @ digipen.edu
* Course: WANIC GD Yr 2 26-27
* Desc: This file contains code to handle a battle scene and turns for each entity.
********************************************************************/
public class Battle
{
    // I hate magic variables in code so we define values here.
    private const int ENEMY_COUNT = 5;
    private const int PLAYER_START_HEALTH = 20;

    public Player Player { get; private set; } = new(PLAYER_START_HEALTH);
    public List<Enemy> Enemies { get; private set; } = new(ENEMY_COUNT);

    /// <summary>
    /// Sets up a new battle by instantiating enemies, players, and setting their health.
    /// This function as well writes some filler text for scene context.
    /// </summary>
    public void SetupBattle()
    {
        Enemies.Add(new Enemy("Goblin Scout", 4, 1, 4));
        Enemies.Add(new Enemy("Goblin Brute", 10, 1, 3));
        Enemies.Add(new Enemy("Goblin Assassin", 2, 10, 10));
        Enemies.Add(new Enemy("Goblin Warrior", 6, 2, 5));
        Enemies.Add(new EnemyHealer("Goblin Healer", 5, 1, 0, 0));

        Console.WriteLine("You encounter five Goblins in the woods.");
    }

    /// <summary>
    /// Displays all the healths of every entity in the scene. It does not print the health of anyone dead.
    /// </summary>
    public void DisplayAll()
    {
        Player.DisplayHealth();
        
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (Enemies[i].IsDead()) continue;

            Console.Write($"    {i + 1}. ");
            Enemies[i].Display();
        }
        
        Console.WriteLine();
    }

    /// <summary>
    /// Runs a turn for the player to attack etc.
    /// </summary>
    public void PlayerTurn()
    {
        Console.WriteLine("It is your turn. Which enemy do you want to attack?");
        int enemyIndex = Program.InputNumber(1, Enemies.Count) - 1;
        Enemy enemy = Enemies[enemyIndex];

        Player.Attack(enemy);
    }

    /// <summary>
    /// Runs a turn for the enemies to attack, heal etc.
    /// </summary>
    public void EnemyTurn()
    {
        foreach (var enemy in Enemies)
        {
            if (enemy.IsDead()) continue;
            enemy.Act(this);
        }

        Console.WriteLine();
        Console.ReadLine();
    }

    /// <summary>
    /// Checks if the game should end, if any of the criteria is met, then this method will print console statements.
    /// </summary>
    /// <returns>Returns true if either player or enemy are dead.</returns>
    public bool CheckEndGame()
    {
        if (Player.IsDead())
        {
            Console.WriteLine("You died.\nGame over!");
            return true;
        }

        bool anyAlive = false;
        // Go through every enemy, and set "anyAlive" to true if that enemy is not dead.
        foreach (var enemy in Enemies) if (!enemy.IsDead()) anyAlive = true;

        if (!anyAlive)
        {
            Console.WriteLine("All enemies are dead.\nYou win!");
            return true;
        }

        return false;
    }
}