using System;
using System.Collections.Generic;

namespace box
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> emptyList = new List<object>();
            
            emptyList.Add(7);
            emptyList.Add(28);
            emptyList.Add(-1);
            emptyList.Add(true);
            emptyList.Add("chair");

            int sum = new int();
            sum = 0;

            foreach (var entry in emptyList){

                System.Console.WriteLine(entry);

                if (entry is int){
                    sum +=(int)entry;
                }
            }

        System.Console.WriteLine(sum);
        }
    }
}
