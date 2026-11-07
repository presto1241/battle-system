use crate::enemy::Enemy;

pub struct Weapon
{
    pub name :String,
    pub number_of_uses :i32,
    pub damage :i32
}

impl Weapon
{
    pub fn new(name:String, damage:i32, number_of_uses:i32) -> Self
    {
        Self
        {
            name,
            damage,
            number_of_uses
        }
    }

    pub fn attack(&mut self, enemy:&mut dyn Enemy) -> bool
    {
        if self.number_of_uses <= 0
        {
            return false;
        }

        enemy.hurt(self.damage);

        self.number_of_uses -= 1;
        return self.number_of_uses > 0;
    }

    pub fn display(&self) -> String
    {
        return format!("{} deals {} and has {} uses remaining.", self.name, self.damage, self.number_of_uses);
    }
}
