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
        println!("{}", format!("Player Health: {}", self.player_health));
        println!("{}", format!("Enemy Health: {}", self.enemy_health));
    }
}
