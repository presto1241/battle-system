/********************************************************************
* Name: Battle.cs
* Author: Preston Magee
* Email: preston.magee @ digipen.edu
* Course: WANIC GD Yr 2 26-27
* Desc: This file contains code to handle a battle scene and turns for each entity.
********************************************************************/
public class Battle
{
    // I hate magic variables in code so we define starting health values here.
    private const int PLAYER_START_HEALTH = 5;
    private const int ENEMY_START_HEALTH = 4;

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
}