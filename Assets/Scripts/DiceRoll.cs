using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll
{
   
    public static int Roll(int maxNum) //single roll
    {
        if (maxNum < 1) return -1; //"error"
        return UnityEngine.Random.Range(1, maxNum + 1);
    }

    public static int RollSum(int maxNum, int times) //rolls the dice multiple times and summs the results
    {
        int sum = 0;
        for (int i = 0; i < times; i++)
        {
            sum += Roll(maxNum);
            //Debug.Log("i = " + i + "; sum = " + sum);
        }
        return sum;
        /*
        if sum < 0, then maxNum < 1
        if sum == 0, then times < 1 
        */
    }

    
}