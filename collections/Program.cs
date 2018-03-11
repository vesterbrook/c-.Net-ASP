using System;
using System.Collections.Generic;

namespace collections
{
    class Program
    {
        static void Main(string[] args){
        // Create an array to hold an integer values 0-9
        // {
        // int [] numArray = new int[10];
        // for (int i = 0; i < 10; i++){
        //     numArray[i] = i;
        // { 
        //     Console.WriteLine(i);
        // }
        // }   
        // }

        //Create an array of the names 'Tim, "martin", nikki, & sara'
        string[] nameArray = new string[4];
        nameArray[0] = "Tim";
        nameArray[1] = "martin";
        nameArray[2] = "nikki";
        nameArray[3] = "sara";
        foreach (string name in nameArray){
            // Console.WriteLine(name);
        }

        // bool[] boolArray = new bool[10];
        // for(int i = 0; i < 10; i++){
        //     if (i%2==0){
        //         boolArray[i] = true;
        //     }
        //     else{
        //         boolArray[i] = false;
        //     }
        // }
        // foreach (bool factoid in boolArray){
        //     Console.WriteLine(factoid);
        // }

//    int[,] multiplicationTable = new int[10,10];
//     for (int i = 0; i < 10; i++){
//         for (int j = 0; j < 10; j++){
//             multiplicationTable[i,j] = (Int16)((i + 1) * (j + 1));
//                 Console.WriteLine(multiplicationTable[i,j]);
//                 }
//             }
    List<string> flavors = new List<string>();

    flavors.Add("Choco");
    flavors.Add("Strawberry");
    flavors.Add("blueberry");
    flavors.Add("sherbert");
    flavors.Add("Mint");
    
    // Console.WriteLine(flavors.Count);
    // Console.WriteLine(flavors[2]);
    flavors.RemoveAt(2);
    // Console.WriteLine(flavors.Count);

    Dictionary<string,string> favorites = new Dictionary<string,string>();
    foreach (string name in nameArray){
        favorites.Add(name, null);
    }
    Random rand = new Random();
    List<string> keys = new List<string>(favorites.Keys);
    for (int i = 0; i <keys.Count; i++){
        favorites[keys[i]] = flavors[rand.Next(0,4)];
    }
    foreach (var entry in favorites){
        Console.WriteLine(entry.Key + "-" + entry.Value);
    }
    }
// Multiplication Table

            // With the values 1-10, use code to generate a multiplication table like the one below.

            // int[,] multiplicationTable = new int[10,10];

            // for(int k = 0; k <= 9; k++)

            // {

            //     for(int l = 0; l <= 9; l++)

            //     {

            //         multiplicationTable[k,l]=(k+1)*(l+1);

            //         Console.Write(string.Format("{0} ", multiplicationTable[k,l]));

            //     }

            //     Console.Write(Environment.NewLine);

            // }
    
    }
}
