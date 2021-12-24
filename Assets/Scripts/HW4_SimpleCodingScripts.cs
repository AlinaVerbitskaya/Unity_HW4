using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;
using System;

public class HW4_SimpleCodingScripts : MonoBehaviour
{
    [SerializeField] private GameObject firstPanel; //for changing panels                            
    [SerializeField] private InputField numberOfDice, diceRollOutput; //for dice rolls
    [SerializeField] private Dropdown dropdownDiceKind;  //for dice rolls
    private GameObject currentScreen;
    [SerializeField] private Slider sliderR, sliderG, sliderB; //for color panel
    [SerializeField] private Image colorImage; //for color panel
    [SerializeField] private Text colorCode; //for color panel
    private RGBColor currentColor;
    [SerializeField] private InputField primeFirstNum, primeSecondNum, primeNumsOutput; //for prime numbers

    void Start()
    {
        firstPanel.SetActive(true);
        currentScreen = firstPanel; //assigning the starting panel
        currentColor = new RGBColor();
        SlidersUpdade(); //making sure sliders, color code and the image match
    }

    public void CalculatePrimeNumsInRange()
    {
        int firstNum, secondNum, step;
        if ((primeFirstNum.text == "") || (primeSecondNum.text == ""))
        {
            return; 
        }
        primeNumsOutput.text = "";
        firstNum = Convert.ToInt32(primeFirstNum.text);
        secondNum = Convert.ToInt32(primeSecondNum.text);
        if ( firstNum == secondNum)
        {
            primeNumsOutput.text = Convert.ToString(PrimeNumbers.IsPrime(firstNum));
            return; //if numbers are equal just check one of them
        }
        step = Math.Sign(secondNum - firstNum); //first can be greater than second
        for (int i = firstNum; i != secondNum; i += step) //checking all numbers between the two
        {
            if (PrimeNumbers.IsPrime(i)) primeNumsOutput.text += Convert.ToString(i) + " ";
        }
        if (primeNumsOutput.text == "") primeNumsOutput.text = "There are no prime numbers on this interval";
    }

    public void SlidersUpdade() //takes values from sliders and converts them to color and color code
    {
        if (currentColor != null)
        {
            currentColor.Red = Convert.ToInt32(sliderR.value);
            currentColor.Green = Convert.ToInt32(sliderG.value);
            currentColor.Blue = Convert.ToInt32(sliderB.value); //getting color from sliders in app
            colorImage.color = new Color(currentColor.Red / 255F, currentColor.Green / 255F, currentColor.Blue / 255F, 1); //matching image to sliders
            colorCode.text = "#" + currentColor.Red.ToString("X2") +
                                   currentColor.Green.ToString("X2") +
                                   currentColor.Blue.ToString("X2"); //converting color to #XXXXXX code
        }
    }

    public void RandomizeColorButton() //randomizes color sliders
    {
        sliderB.value = UnityEngine.Random.Range(0, 256);
        sliderG.value = UnityEngine.Random.Range(0, 256);
        sliderR.value = UnityEngine.Random.Range(0, 256);
    }


    public void RollDiceToOutputField() //rolls chosen dice Num times, calculates the sum and puts it into output field
    {
        short diceKind;
        if (numberOfDice.text == "")
        {
            return;
        }
        int Num = Convert.ToInt32(numberOfDice.text);
        switch (dropdownDiceKind.captionText.text)
        {
            case "D4":
                diceKind = 4;
                break;
            case "D6":
                diceKind = 6;
                break;
            case "D8":
                diceKind = 8;
                break;
            case "D10":
                diceKind = 10;
                break;
            case "D12":
                diceKind = 12;
                break;
            case "D20":
                diceKind = 20;
                break;
            default:
                diceKind = 0;
                break;
        }
        if (Num < 1) diceRollOutput.text = "0";
        else diceRollOutput.text = Convert.ToString(DiceRoll.RollSum(diceKind, Num));
    }

    public void ChangeScreen(GameObject screen) //changes panels
    {
        if (currentScreen != null)
        {
            currentScreen.SetActive(false);
            screen.SetActive(true);
            currentScreen = screen;
        }
    }

    public void CopyToBuffer(Text str)
    {
        GUIUtility.systemCopyBuffer = str.text;
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif

    }

}



