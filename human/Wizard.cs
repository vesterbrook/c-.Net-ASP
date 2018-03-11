using System;

namespace WizardNinjaSamurai
{
    public class Wizard : Human // Wizard inherits from the Human class
    {
        public int intelligence = 25;
        public int health = 50;
        public Wizard(string n) : base(n)
        {
            System.Console.WriteLine($"The Wizard {name}'s stats are... Strength: {strength}, Intelligence: {intelligence}, Dexterity: {dexterity}, Health: {health}");
        }
        public int heal()
        {
            // Increases Wizard's health by 10 * intelligence
            int heal = 10 * intelligence;
            this.health += heal;
            System.Console.WriteLine($"The WIZARD {name} healed {heal} points! Total health: {health}!");
            return (int)health;
        }
        public int fireball(Human enemy)
        {
            // Does random damage between 20 and 50
            Random rand = new Random();
            int fireball = rand.Next(20, 51);
            enemy.health -= fireball;
            System.Console.WriteLine($"{name}'s Fireball attack dealt {fireball} damage to {enemy.name}! {enemy.name}'s health is: {enemy.health}.");
            return (int)health;
        }

    }
}