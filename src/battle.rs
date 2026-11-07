use crate::input_number;
use crate::enemy::Enemy;
use crate::weapon::Weapon;

#[derive(Default)]
pub struct Battle
{
    pub player_health :i32,
    pub enemies :Vec<Enemy>,
    pub weapons :Vec<Weapon>
}

impl Battle
{
    pub fn setup_battle(&mut self)
    {
        self.player_health = 20;

        self.enemies = Vec::new();

        // Create all the enemies in the battle
        self.enemies.push(Enemy::new(String::from("Goblin Scout"), 4, 1, 3));
        self.enemies.push(Enemy::new(String::from("Goblin Brute"), 10, 1, 2));
        self.enemies.push(Enemy::new(String::from("Goblin Assasin"), 2, 10, 10));
        self.enemies.push(Enemy::new(String::from("Goblin Warrior"), 6, 2, 4));
        self.enemies.push(Enemy::new(String::from("Goblin Warrior"), 6, 2, 4));

        // Create all weapons in the battle
        self.weapons = Vec::new();
        self.weapons.push(Weapon::new(String::from("Dagger"), 2, 10));
        self.weapons.push(Weapon::new(String::from("Hammer"), 10, 2));
        self.weapons.push(Weapon::new(String::from("Sword"), 4, 5));

        println!("A Goblin attacks you in the woods.");
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
        let target_enemy :&mut Enemy = &mut self.enemies[enemy_index as usize];

        // Print a list of all weapons the player has access to
        println!("Your weapons are:");
        for (i, w) in self.weapons.iter().enumerate()
        {
            println!("{}", format!("    {}. {}", i + 1, w.display()));
        }

        // Let the player choose a weapon to attack the enemy with
        println!("Which weapon do you want to use:");
        let weapon_index :i32 = input_number(1, self.weapons.len() as i32) - 1;
        let target_weapon :&mut Weapon = &mut self.weapons[weapon_index as usize];

        // Reduce enemy health and print log.
        target_weapon.attack(target_enemy);
        println!("{}", format!("You attack {} with {} for {} damage.\n", target_enemy.name, target_weapon.name, target_weapon.damage));

        if target_weapon.number_of_uses <= 0
        {
            self.weapons.remove(weapon_index as usize);
        }
    }

    pub fn enemy_turn(&mut self)
    {
        for e in self.enemies.iter()
        {
            // Skip if the current enemy is 0 or less health
            if !e.alive()
            {
                continue;
            }

            // Reduce player health and print log.
            self.player_health -= e.attack();
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
