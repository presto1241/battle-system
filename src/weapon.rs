use crate::enemy::Enemy;

pub struct Weapon
{
    pub name :String,
    pub number_of_uses :i32,
    pub damage :i32
}

impl Weapon
{
    pub fn new(name:String, number_of_uses:i32, damage:i32) -> Self
    {
        Self
        {
            name,
            number_of_uses,
            damage
        }
    }

    pub fn attack(&mut self, enemy:&mut Enemy) -> bool
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
