#[derive(Default)]
pub struct Battle
{
    pub player_health :i32,
    pub enemy_health :i32
}

impl Battle
{
    pub fn setup_battle(&mut self)
    {
        self.player_health = 5;
        self.enemy_health = 4;

        println!("A Goblin attacks you in the woods.");
    }

    pub fn display_healths(&self)
    {
        println!("{}", format!("You have {} health.", self.player_health));
        println!("{}", format!("Goblin has {} health.", self.enemy_health));
    }

    pub fn player_turn(&mut self)
    {
        // Attack with a damage range between 2-4
        let damage: i32 = fastrand::i32(2..=4);

        // Reduce enemy health and print log.
        self.enemy_health -= damage;
        println!("{}", format!("You attack the Goblin for {} damage.", damage))
    }

    pub fn enemy_turn(&mut self)
    {
        // Attack with a damage range between 1-3
        let damage: i32 = fastrand::i32(1..=3);

        // Reduce player health and print log.
        self.player_health -= damage;
        println!("{}", format!("Goblin attacks you for {} damage.", damage))
    }
}
