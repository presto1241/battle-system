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
    private const int ENEMY_START_HEALTH = 4;

    private const int PLAYER_DAMAGE_MIN = 2;
    private const int PLAYER_DAMAGE_MAX = 5;

    private const int ENEMY_DAMAGE_MIN = 1;
    private const int ENEMY_DAMAGE_MAX = 4;

    public int PlayerHealth { get; private set; }
    public float[] Enemies { get; private set; } = Array.Empty<float>();

    /// <summary>
    /// Sets up a new battle by instantiating enemies, players, and setting their health.
    /// This function as well writes some filler text for scene context.
    /// </summary>
    public void SetupBattle()
    {
        PlayerHealth = PLAYER_START_HEALTH;
        Enemies = new float[ENEMY_COUNT];
        Array.Fill(Enemies, ENEMY_START_HEALTH);

        Console.WriteLine("You encounter five Goblins in the woods.");
    }

    /// <summary>
    /// Displays all the healths of every entity in the scene.
    /// </summary>
    public void DisplayHealths()
    {
        Console.WriteLine($"You have {PlayerHealth} health.");
        
        for (int i = 0; i < Enemies.Length; i++)
        {
            Console.WriteLine($"    {i + 1}. Goblin has {Enemies[i]} health.");    
        }
        
        Console.WriteLine();
    }

    /// <summary>
    /// Runs a turn for the player to attack etc.
    /// </summary>
    public void PlayerTurn()
    {
        Console.WriteLine("It is your turn. Which enemy do you want to attack?");
        int input = Program.InputNumber(1, Enemies.Length);
        int inputIndex = input - 1;

        // Generate a random damage number
        Random random = new Random();
        int damage = random.Next(PLAYER_DAMAGE_MIN, PLAYER_DAMAGE_MAX);
        
        // Apply damage to the enemy
        Enemies[inputIndex] -= damage;
        
        Console.WriteLine($"You attack Goblin for {damage} damage.");
    }

    /// <summary>
    /// Runs a turn for the enemies to attack, heal etc.
    /// </summary>
    public void EnemyTurn()
    {
        for (int i = 0; i < Enemies.Length; i++)
        {
            // Generate a random damage number
            Random random = new Random();
            int damage = random.Next(ENEMY_DAMAGE_MIN, ENEMY_DAMAGE_MAX);

            // Apply damage to the player
            PlayerHealth -= damage;

            Console.WriteLine($"{i + 1}. Goblin attacks you for {damage} damage.");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Checks if the game should end, if any of the criteria is met, then this method will print console statements.
    /// </summary>
    /// <returns>Returns true if either player or enemy are dead.</returns>
    public bool CheckEndGame()
    {
        if (PlayerHealth <= 0)
        {
            Console.WriteLine("You died.\nGame over!");
            return true;
        }

        bool anyAlive = false;

        // Go through every enemy, and set "anyAlive" to true if that enemies health is greater than zero
        foreach (var enemy in Enemies) if (enemy > 0) anyAlive = true;

        if (!anyAlive)
        {
            Console.WriteLine("All enemies are dead.\nYou win!");
            return true;
        }

        return false;
    }
}