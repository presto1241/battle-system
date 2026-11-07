pub struct Enemy
{
    pub name :String,
    pub health :i32,
    pub min_damage :i32,
    pub max_damage :i32
}

impl Enemy
{
    pub fn new(name:String, health:i32, min_damage:i32, max_damage:i32) -> Self
    {
        Self
        {
            name,
            health,
            min_damage,
            max_damage
        }
    }

    pub fn attack(&self) -> i32
    {
        let damage: i32 = fastrand::i32(self.min_damage..=self.max_damage);
        println!("{}", format!("{} attacked you for {} damage", self.name, damage));

        return damage;
    }

    pub fn hurt(&mut self, damage:i32)
    {
        self.health -= damage;
    }

    pub fn display(&self) -> String
    {
        return format!("{} has {} health.", self.name, self.health);
    }

    pub fn alive(&self) -> bool
    {
        return self.health > 0
    }
}
