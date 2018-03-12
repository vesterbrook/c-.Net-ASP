using System;

namespace dojodachi {
    public class Tomagachi
    {
        public int happiness {get; set;}
        public int fullness {get; set;}
        public int energy {get; set;}
        public int meals {get; set;}
        public string status { get; set; }

        public Tomagachi()
        {
            happiness = 20;
            fullness = 20; 
            energy = 50; 
            meals = 3;
            status = "Welcome to DojoDachi, use buttons below to work with your Tomagachi.";
        }

        public Tomagachi feed()
        {
            Random rando = new Random();
            int chance = rando.Next(0,9);
            if(chance == 0){
                this.meals-=1;
                int amount = rando.Next(51,101);
                this.fullness += amount;
                this.status = $"Your tomagachi found some superdojos and is {amount} fuller!!!";
                return this;
            } else {         
                this.meals-=1;
                int amount = rando.Next(5,11);
                this.fullness += amount;
                this.status = $"Your tomagachi just ate and is {amount} fuller!";
                return this;
            }
        }

        public Tomagachi play()
        {
            Random rando = new Random();
            int chance = rando.Next(0,4);
            if(chance == 0){
                this.status = "Your tomagachi did not want to play now...";
                return this;
            } else {         
                this.energy-=5;
                int amount = rando.Next(5,11);
                this.happiness += amount;
                this.status = $"You played with your tomagachi. He is {amount} happier!";
                return this;
            }
        }

        public Tomagachi work()
        {
            Random rando = new Random();
            this.energy-=5;
            int amount = rando.Next(1,4);
            this.meals += amount;
            this.status = $"Your tomagachi went to work and earned {amount} meals!";
            return this;
        }

        public Tomagachi sleep()
        {
            this.fullness-=5;
            this.happiness-=5;
            this.energy+=15;
            this.status = $"Your tomagachi has been asleep for a while. Happiness and Fullness -5, Energy +15!";
            return this;
        }
    }
}