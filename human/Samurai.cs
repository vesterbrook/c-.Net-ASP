using System;

namespace WizardNinjaSamurai
{
    public class Samurai : Human // Ninja inherits from the Human class
    {
        public int health = 200;
        public static int number; // HOW MANY needs work
        public Samurai(string n) : base(n)
        {
            number++;
            System.Console.WriteLine($"The SAMURAI {name}'s stats are... Strength: {strength}, Intelligence: {intelligence}, Dexterity: {dexterity}, Health: {health}");  
        }
        public int death_blow(Human enemy) // Parameters???
        {
            // Attacks an object and reduce's targets health to 0 if target's health is less than 50
            if(enemy.health < 51)
            {
                enemy.health = 0;
                System.Console.WriteLine($"{enemy.name}'s health is {enemy.health}. DEATH!");
            }
            else
            {
                Random rand = new Random();
                int katana = rand.Next(0, 51);
                enemy.health -= katana;
                System.Console.WriteLine($"{name} uses Death Blow on {enemy.name} and deals {katana} damage. {enemy.name}'s health is now {enemy.health}.");
            }
            return (int)health;
        }
        public int meditate() // Parameters???
        {
            // Heals Samurai back to full health
            this.health = 200;
            System.Console.WriteLine($"{name} meditates... Health is back to {health}.");
            return (int)health;
        }
        public static int how_many() // Needs work... Always returns 0!
        {
            return number;
        }

    }
}