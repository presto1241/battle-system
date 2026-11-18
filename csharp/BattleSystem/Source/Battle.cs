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
    private const int PLAYER_START_HEALTH = 5;
    private const int ENEMY_START_HEALTH = 4;

    private const int PLAYER_DAMAGE_MIN = 2;
    private const int PLAYER_DAMAGE_MAX = 5;

    private const int ENEMY_DAMAGE_MIN = 1;
    private const int ENEMY_DAMAGE_MAX = 4;

    public int PlayerHealth { get; private set; }
    public float EnemyHealth { get; private set; }

    /// <summary>
    /// Sets up a new battle by instantiating enemies, players, and setting their health.
    /// This function as well writes some filler text for scene context.
    /// </summary>
    public void SetupBattle()
    {
        PlayerHealth = PLAYER_START_HEALTH;
        EnemyHealth = ENEMY_START_HEALTH;

        Console.WriteLine("A Goblin attacks you in the woods.");
    }

    /// <summary>
    /// Displays all the healths of every entity in the scene.
    /// </summary>
    public void DisplayHealths()
    {
        Console.WriteLine($"You have {PlayerHealth} health.");
        Console.WriteLine($"Goblin has {EnemyHealth} health.");    
    }

    /// <summary>
    /// Runs a turn for the player to attack etc.
    /// </summary>
    public void PlayerTurn()
    {
        // Generate a random damage number
        Random random = new Random();
        int damage = random.Next(PLAYER_DAMAGE_MIN, PLAYER_DAMAGE_MAX);
        
        // Apply damage to the enemy
        EnemyHealth -= damage;
        
        Console.WriteLine($"You attack Goblin for {damage} damage.");
    }

    /// <summary>
    /// Runs a turn for the enemies to attack, heal etc.
    /// </summary>
    public void EnemyTurn()
    {
        // Generate a random damage number
        Random random = new Random();
        int damage = random.Next(ENEMY_DAMAGE_MIN, ENEMY_DAMAGE_MAX);
        
        // Apply damage to the player
        PlayerHealth -= damage;
        
        Console.WriteLine($"Goblin attacks you for {damage} damage.");
    }
}