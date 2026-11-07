mod battle;
mod enemy;
mod weapon;
mod base_enemy;
mod enemy_healer;
use std::io::{self};
use crate::battle::Battle;

fn main() {
    let mut battle : Battle = Battle::default();
    // Setup and display the battle
    battle.setup_battle();

    // Check end game condition
    loop
    {
        // Print the healths of every player
        battle.display_healths();
        println!("");

        // Run Player and Enemy attacks.
        battle.player_turn();
        println!("");
        battle.enemy_turn();

        // Whitespace to make reading battle easier
        println!("");

        // Check for end game condition
        if battle.check_end()
        {
            break;
        }
    }

    // Wait for user to press enter to quit
    let mut input = String::new();
    io::stdin()
        .read_line(&mut input)
        .expect("Failed to read line");
}

fn input_number(min:i32, max:i32) -> i32
{
    loop
    {
        let mut input = String::new();
        io::stdin()
            .read_line(&mut input)
            .expect("Failed to read line");

        match input.trim().parse::<i32>()
        {
            Ok(num) =>
            {
                if num >= min && num <= max
                {
                    return num;
                }

                println!("{}", format!("Input {} is out of bounds. Try another input", num));
            }

            Err(_) => println!("{}", format!("Input {} is not a number. Try another input", input))
        }
    }
}
