/********************************************************************
* Name: Program.cs
* Author: Preston Magee
* Email: preston.magee @ digipen.edu
* Course: WANIC GD Yr 2 26-27
* Desc: This file conatins bootstrap code to run a battle system. 
* It is also what the binary runs first.
********************************************************************/
class Program
{
    public static void Main(string[] args)
    {
        // Create a battle
        Battle battle = new();
        battle.SetupBattle();

        // Run game loop until someone dies
        while (!battle.CheckEndGame())
        {
            // First display healths
            battle.DisplayHealths();
            
            // Then run turns for each entity    
            battle.PlayerTurn();
            battle.EnemyTurn();
        }
        
        // Wait for user input
        Console.ReadLine();
    }
}