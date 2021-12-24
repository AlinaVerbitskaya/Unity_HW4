using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimeNumbers 
{
    public static bool IsPrime(int Num)
    {
        if (Num < 2) return false; //the lowest prime number is 2
        for (int i = 2; i < Num; i++)
        {
            if (Num % i == 0) return false; //looking for divisers
        }
        return true;
        //a number n is prime if it is greater than one and if none 
        //of the numbers 2,3,...,n-1 divides n evenly
    }
}
