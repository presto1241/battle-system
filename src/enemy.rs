#[derive(Debug, Clone)]
pub struct EnemyData
{
    pub name :String,
    pub health :i32,
}

impl EnemyData
{
    pub fn new(name:String, health:i32) -> EnemyData
    {
        EnemyData { name, health }
    }
}

pub enum Action
{
    Attack(i32),
    Heal(i32)
}

pub trait Enemy
{
    fn stats(&self) -> &EnemyData;
    fn act(&self) -> Action;
    fn hurt(&mut self, damage:i32);
    fn heal(&mut self, health:i32);
    fn alive(&self) -> bool;
    fn display(&self) -> String;
}
