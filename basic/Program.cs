using System;
using System.Collections.Generic;

namespace basic
{
    class Program
    {
        //print 1 to 255
    public static void print1to255()
    {
     for(int i = 1;i <=255; i++)
        {
            // Console.WriteLine(i);
        }
    }

        //print odd num from 1 to 255
    public static void printOdd()
    {
        for (int i = 1; i <= 255; i++)
        {
            if(i % 2 != 0)
            {
                // Console.WriteLine(i);
            }
        }
    }       

        //print the sum of 1 to 255
    public static void printSum()
    {
        int sum = 0;
        for(int i = 0; i <= 255; i++)
        {
            sum += i;
            // Console.WriteLine("New Number: " + i + ", Sum: " + sum);
        }
    }

        //iterate through an array
    public static void iterateArr(int[] arr)
    {
        for(int i = 0; i < arr.Length; i++){
            // Console.WriteLine(arr[i]);
        }
    }

    //find max
public static void findMax(int[] arr)
{
        int max = arr[0];
        for(int i = 0; i < arr.Length; i++)
        {
            if (max < arr[i])
            {
                max = arr[i];
            }
        }
        // Console.WriteLine("The Max Number is: " + max);
}

    //find the average of an array 
public static void findAverage(int[] arr)
{
    int sum = 0;
    for (int i = 0; i < arr.Length + 1; i++)
    {
        sum += i;
    }
    int avg = sum/arr.Length;
    // Console.WriteLine("The Average Number is: " + avg);
}

    //greaterThanY
public static void greaterThanY(int[] arr, int y)
{
    int count = 0; 
    for(int i = 0; i <arr.Length; i++)
    {
        if (arr[i] > y)
        {
            count += 1;
        }
    }
    Console.WriteLine("There are " + count + " numbers greater than Y.");
}
        //square the values in an array
public static void squareValues(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = arr[i] * arr[i];
        Console.WriteLine(arr[i]);
        }
    }
    //remove the negative values in an array
public static void removeNeg()
{
    int [] removeNeg = new int[6] {1,2,3,14,5,-88};
    for (int i =0; i < removeNeg.Length; i++)
    {
        if (removeNeg[i] < 0)
        {
            removeNeg[i] = 0;
        }
        Console.WriteLine(removeNeg[i]);
    }
}

public static void findMinMaxAvg(int[] arr)
{
int max = arr[0];
    int min = arr[0];
    int sum = 0;
    for(int i = 0; i < arr.Length; i++)
    {
        if (max < arr[i])
        {
            max = arr[i];
            }
            if (min > arr[i])
            {
                min = arr[i];
            }
            sum = sum + arr[i];
        }
        int avg = sum / arr.Length;
        // Console.WriteLine("The results are: Min is " + min + ", Max is " + max + ", Sum is " + sum + ", and Avg is " + avg);
}

        // shift values left
public static  int[] shiftValues(int[] arr)
{
    
    for(int i = 0; i < arr.Length-1; i++)
    {
        arr[i] = arr[i+1];

    }
    arr[arr.Length-1]= 0;
    return arr;

}

        //turn numbers to a string
public static object[] NumToString(int[] arr)
    {
    object[] newArray = new object[arr.Length];
    for (int i = 0; i < arr.Length; ++i)
        {
        if (arr[i] < 0)
        {
            newArray[i] = "Dojo";
        }
        else
        {
            newArray[i] = arr[i];
        }
            }
        return newArray;
        }
public static void Main(string[] args){
    print1to255();
    printOdd();
    printSum();
    int[] arr = new int[4] {1,5,10,-2};
    iterateArr(arr);
    findMax(arr);
    findAverage(arr);
    greaterThanY(arr, 2);
    squareValues(arr);
    findMinMaxAvg(arr);
    shiftValues(arr);
    NumToString(arr);


        }
    }
}
