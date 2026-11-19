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
            // First display all characters statuses
            battle.DisplayAll();
            
            // Then run turns for each entity    
            battle.PlayerTurn();
            battle.EnemyTurn();
        }
        
        // Wait for user input before exiting
        Console.ReadLine();
    }

    /// <summary>
    /// Ask the user to input a number within a range.
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns>The number the user gave.</returns>
    public static int InputNumber(int min, int max)
    {
        while (true)
        {
            // I don't like null anymore
            string input = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(input, out int num))
            {
                Console.WriteLine($"Input {input} is not a number. Try another input");
                continue;
            }

            // Print out of bounds if the user writes a number greater or less than max
            if (num < min || num > max)
            {
                Console.WriteLine($"Input {num} is out of bounds. Try another input");
                continue;
            }

            return num;
        }
    }
}