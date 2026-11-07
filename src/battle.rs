use crate::base_enemy::BaseEnemy;
use crate::enemy_healer::HealerEnemy;
use crate::input_number;
use crate::enemy::{Action, Enemy};
use crate::weapon::Weapon;

#[derive(Default)]
pub struct Battle
{
    pub player_health :i32,
    pub enemies :Vec<Box<dyn Enemy>>,
    pub weapons :Vec<Weapon>
}

impl Battle
{
    pub fn setup_battle(&mut self)
    {
        self.player_health = 20;

        self.enemies = Vec::new();

        // Create all the enemies in the battle
        self.enemies.push(Box::new(BaseEnemy::new(String::from("Goblin Scout"), 4, 1, 3)));
        self.enemies.push(Box::new(BaseEnemy::new(String::from("Goblin Brute"), 10, 1, 2)));
        self.enemies.push(Box::new(BaseEnemy::new(String::from("Goblin Assasin"), 2, 10, 10)));
        self.enemies.push(Box::new(BaseEnemy::new(String::from("Goblin Warrior"), 6, 2, 4)));
        self.enemies.push(Box::new(HealerEnemy::new(String::from("Goblin Healer"), 5, 1)));

        // Create all weapons in the battle
        self.weapons = Vec::new();
        self.weapons.push(Weapon::new(String::from("Dagger"), 2, 10));
        self.weapons.push(Weapon::new(String::from("Hammer"), 10, 2));
        self.weapons.push(Weapon::new(String::from("Sword"), 4, 5));

        println!("A Goblin attacks you in the woods.");
    }

    pub fn damage_player(&mut self, damage:i32)
    {
        self.player_health -= damage;
    }

    pub fn display_healths(&self)
    {
        println!("{}", format!("You have {} health.", self.player_health));

        for (i, x) in self.enemies.iter().enumerate()
        {
            println!("{}", format!("    {}. {}", i + 1, x.display()));
        }
    }

    pub fn player_turn(&mut self)
    {
        // Fetch who the player wants to attack
        println!("It is your turn. Which enemy do you want to attacK?");
        let enemy_index :i32 = input_number(1, self.enemies.len() as i32) - 1;
        let target_enemy :&mut dyn Enemy = &mut *self.enemies[enemy_index as usize];

        // Print a list of all weapons the player has access to
        println!("\nYour weapons are:");
        for (i, w) in self.weapons.iter().enumerate()
        {
            println!("{}", format!("    {}. {}", i + 1, w.display()));
        }

        // Let the player choose a weapon to attack the enemy with
        println!("\nWhich weapon do you want to use:");
        let weapon_index :i32 = input_number(1, self.weapons.len() as i32) - 1;
        let target_weapon :&mut Weapon = &mut self.weapons[weapon_index as usize];

        // Reduce enemy health and print log.
        println!("{}", format!("\nYou attack {} with {} for {} damage.", target_enemy.stats().name, target_weapon.name, target_weapon.damage));
        target_weapon.attack(target_enemy);

        if !target_enemy.alive()
        {
            self.enemies.remove(enemy_index as usize);
        }

        if target_weapon.number_of_uses <= 0
        {
            self.weapons.remove(weapon_index as usize);
        }

    }

    pub fn enemy_turn(&mut self)
    {
        // Go through every enemy and process actions.
        for i in 0..self.enemies.len()
        {
            // Skip if the current enemy is 0 or less health
            if !self.enemies[i].alive()
            {
                continue;
            }

            // Reduce player health and print log.
            let action:Action = self.enemies[i].act();

            // Parse and run the action the enemy has done.
            match action
            {
                Action::Attack(dmg) => { self.damage_player(dmg); }
                Action::Heal(health) =>
                {
                    for a in 0..self.enemies.len()
                    {
                        self.enemies[a].heal(health);
                    }
                }
            }
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
        for e in self.enemies.iter()
        {
            if e.alive()
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
