using System;

namespace WizardNinjaSamurai
{
    public class Ninja : Human // Ninja inherits from the Human class
    {
        public int dexterity = 175;

        public Ninja(string n) : base(n)
        {
            System.Console.WriteLine($"The NINJA {name}'s stats are... Strength: {strength}, Intelligence: {intelligence}, Dexterity: {dexterity}, Health: {health}");
        }
        public int steal(Human enemy) // Attacks an object?? I don't get it...
        {
            // Attacks an object and increases Ninja's health by 10
            int steal = 10;
            this.health += steal;
            System.Console.WriteLine($"{name} stole from {enemy.name}! Health increased by {steal}. Total health is: {health}");
            return (int)health;
        }
        public int get_away()
        {
            // Decreases health by 15
            int away_we_go = 15;
            this.health -= away_we_go;
            System.Console.WriteLine($"{name} gets away! Health decreased by {away_we_go}. Total health is: {health}");
            return (int)health;
        }

    }
}