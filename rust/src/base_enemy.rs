use crate::{enemy::{Action, Enemy, EnemyData}};

pub struct BaseEnemy
{
    pub stats :EnemyData,
    pub min_damage :i32,
    pub max_damage :i32
}

impl BaseEnemy
{
    pub fn new(name:String, health:i32, min_damage:i32, max_damage:i32) -> Self
    {
        Self
        {
            stats: EnemyData::new(name, health),
            min_damage,
            max_damage
        }
    }
}

impl Enemy for BaseEnemy
{
    fn stats(&self) -> &EnemyData { return &self.stats; }

    fn act(&self) -> Action
    {
        let damage: i32 = fastrand::i32(self.min_damage..=self.max_damage);
        println!("{}", format!("{} attacked you for {} damage", self.stats.name, damage));

        return Action::Attack(damage);
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

    fn display(&self) -> String
    {
        return format!("{} has {} health.", self.stats.name, self.stats.health);
    }

    fn alive(&self) -> bool
    {
        return self.stats.health > 0
    }
}
