use std::io::{self};
mod battle;
use crate::battle::Battle;

fn main() {
    let mut battle : Battle = Battle::default();
    battle.setup_battle();
    battle.display_healths();

    let mut input = String::new();
    io::stdin()
        .read_line(&mut input)
        .expect("Failed to read line");
}
