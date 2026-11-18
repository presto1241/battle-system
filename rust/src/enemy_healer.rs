use crate::enemy::{Action, Enemy, EnemyData};

pub struct HealerEnemy
{
    pub stats :EnemyData,
    pub healing_amount :i32
}

impl HealerEnemy
{
    pub fn new(name:String, health:i32, healing_amount:i32) -> Self
    {
        Self
        {
            stats: EnemyData::new(name, health),
            healing_amount
        }
    }
}

impl Enemy for HealerEnemy
{
    fn stats(&self) -> &EnemyData { return &self.stats; }

    fn act(&self) -> Action
    {
        println!("{}", format!("{} heals every goblin with {} health.", self.stats.name, self.healing_amount));
        return Action::Heal(self.healing_amount);
    }

    fn hurt(&mut self, damage:i32)
    {
        self.stats.health -= damage;

        if self.stats.health <= 0
        {
            println!("{}", format!("{} has died.", self.stats.name));
        }
    }

    fn heal(&mut self, health:i32)
    {
        if !self.alive() { return; }
        self.stats.health += health;
    }

    fn alive(&self) -> bool {
        return self.stats.health > 0;
    }

    fn display(&self) -> String {
        return format!("{} has {} health. {} will heal all enemies for {}.", self.stats.name, self.stats.health, self.stats.name, self.healing_amount);
    }
}
