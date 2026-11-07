use std::io::{self};
mod battle;
use crate::battle::Battle;

fn main() {
    let mut battle : Battle = Battle::default();
    // Setup and display the battle
    battle.setup_battle();
    battle.display_healths();

    // Run Player and Enemy attacks.
    battle.player_turn();
    battle.enemy_turn();

    // Wait for user to press enter to quit
    let mut input = String::new();
    io::stdin()
        .read_line(&mut input)
        .expect("Failed to read line");
}
