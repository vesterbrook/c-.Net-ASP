using System;

namespace fund1
{
    class Program
    {
        static void Main(string[] args)
        // {
        // for (int i =1; i <= 255; i++){
        //     Console.WriteLine(i);
        // }
        // }
        // {
        // for (int j = 1; j <= 100; j++){
        //     if (j % 5 == 0 && j % 3 == 0){
        //         continue;
        //     }
        //     else
        //     {
        //         Console.WriteLine(j);
        //     }
        // }

        // }
        
        // {
        // for (int j = 1; j <= 100; j++){
        //     if (j % 3 == 0){
        //         Console.WriteLine("Fizz");
        //     }
        //     if (j % 5 == 0)
        //     {
        //         Console.WriteLine("Buzz");
        //     }
        //     if (j % 5 == 0 && j % 3 == 0)
        //     {
        //         Console.WriteLine("FizzBuzz");
        //     }
        // }

        // }
        {
        Random rand = new Random();
        for(int i =0; i < 10; i++){
            Console.Write(rand.Next(1,10) + " " + rand.Next(1,10) + "\n");
        }
        }
            
    }
}
