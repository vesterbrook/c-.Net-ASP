using System;

namespace puzzles
{
    public class Program
    {
        static void Main(string[] args)
        {
            RandomArray();
            TossCoin();
            TossMultipleCoins(5);
            Names();
        }
        // Puzzles
        public static int[] RandomArray()
        {
            // Random Array
            // Place 10 random integer values between 5-25 into the array
            // Print the min and max values of the array
            // Print the sum of all the values
            System.Console.WriteLine("********** RANDOM ARRAY **********");
            Random rand = new Random();
            int[] rand_Array = new int[10];
            int max = rand_Array[0]; // It's giving me the length of the array??? Always 10???
            int min = rand_Array[0]; // Always 0???
            int sum = 0;
            for (int i = 0; i < rand_Array.Length; i++)
            {
                rand_Array[i] = rand.Next(0,11);
                if (max < rand_Array[i])
                {
                    max = rand_Array[i];
                }
                if (min > rand_Array[i])
                {
                    min = rand_Array[i];
                }
                sum += rand_Array[i];
                System.Console.WriteLine(rand_Array[i]);
            }
            System.Console.WriteLine("Max is: " + max + ", Min is: " + min + ", and Sum is: " + sum);
            return rand_Array;
        }
        public static string TossCoin()
        {
            // Coin Flip #1
            // Have the function print "Tossing a Coin!"
            // Randomize a coin toss with a result signaling either side of the coin 
            // Have the function print either "Heads" or "Tails"
            // Finally, return the result
            System.Console.WriteLine("********** TOSS A COIN **********");
            System.Console.WriteLine("Tossing a Coin!");
            Random rand = new Random();
            string head_tail;
            if (rand.Next(0,2) == 0)
            {
                head_tail = "Heads!";
                System.Console.WriteLine(head_tail);
            }
            else
            {
                head_tail = "Tails!";
                System.Console.WriteLine(head_tail);
            }
            return head_tail;
        }
        public static Double TossMultipleCoins(int num)
        {
            // Coin Flip #2
            // Have the function call the tossCoin function multiple times based on num value
            // Have the function return a Double that reflects the ratio of head toss to total toss']
            System.Console.WriteLine("********** TOSS MULTIPLE COINS **********");
            System.Console.WriteLine("Tossing Multiple Coins!");
            double ratio = 0;
            double heads = 0;
            double tails = 0;
            for (int i = 0; i < num; i++)
            {
                string head_tail = TossCoin();
                if (head_tail == "Heads!")
                {
                    heads++;
                }
                if (head_tail == "Tails!")
                {
                    tails++;
                }
            }
            ratio = heads/(heads + tails); // Not showing on terminal???
            System.Console.WriteLine("The ratio is: " + ratio);
            return ratio;
        }
        public static string Names()
        {
            // Create an array with the values: Todd, Tiffany, Charlie, Geneva, Sydney
            // Shuffle the array and print the values in the new order
            // Return an array that only includes names longer than 5 characters
            string[] nameArray = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            Random rand = new Random();
            string temp = "";
            for (int index = 0; index < nameArray.Length; index++)
            {
                int shuffle = rand.Next(index, nameArray.Length); // Shuffle! Contains the start (index) and the exclusion (nameArray.Length which is 5).
                temp = nameArray[index]; // temp now contains nameArray[index] which is Todd
                nameArray[index] = nameArray[shuffle]; // nameArray[index] which WAS Todd is now going to be a Shuffled name
                nameArray[shuffle] = temp; // Then the Shuffled name's index is now replaced with Charlie
                Console.WriteLine("Index {0} contains the name {1}.", index, nameArray[index]);
            }
            return temp;
        }
    }
}