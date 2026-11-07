use crate::input_number;

#[derive(Default)]
pub struct Battle
{
    pub player_health :i32,
    pub enemies :[i32; 5]
}

impl Battle
{
    pub fn setup_battle(&mut self)
    {
        self.player_health = 20;
        for enemy in &mut self.enemies
        {
            *enemy = 4;
        }

        println!("A Goblin attacks you in the woods.");
    }

    pub fn display_healths(&self)
    {
        println!("{}", format!("You have {} health.", self.player_health));

        for (i, x) in self.enemies.iter().enumerate()
        {
            println!("{}", format!("    {}. Goblin has {} health", i + 1, x));
        }
    }

    pub fn player_turn(&mut self)
    {
        // Fetch who the player wants to attack
        println!("It is your turn. Which enemy do you want to attacK?");
        let goblin_index :i32 = input_number(1, self.enemies.len() as i32);

        // Attack with a damage range between 2-4
        let damage: i32 = fastrand::i32(2..=4);

        // Convert into index so everyone is happy
        let target_idx = (goblin_index - 1) as usize;

        // Reduce enemy health and print log.
        self.enemies[target_idx] -= damage;
        println!("{}", format!("You attack the Goblin for {} damage.", damage))
    }

    pub fn enemy_turn(&mut self)
    {
        for (i, e) in self.enemies.iter().enumerate()
        {
            // Skip if the current enemy is 0 or less health
            if *e <= 0
            {
                continue;
            }

            // Attack with a damage range between 1-3
            let damage: i32 = fastrand::i32(1..=3);

            // Reduce player health and print log.
            self.player_health -= damage;
            println!("{}", format!("{}. Goblin attacks you for {} damage.", i, damage))
        }
    }

    pub fn check_end(&self) -> bool
    {
        if self.player_health <= 0
        {
            println!("You died.\nGame over!");
            return true;
        }

        // Fetch if there are any enemies alive still
        let mut any_alive :bool = false;
        for e in self.enemies
        {
            if e >= 0
            {
                any_alive = true;
            }
        }

        // If there are none alive, then win the game.
        if !any_alive
        {
            println!("All enemies are dead.\nYou win!");
            return true;
        }

        return false;
    }
}
