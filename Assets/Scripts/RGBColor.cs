using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGBColor 
{
    private int red, green, blue; //color components, [0, 255]
    public int Red
    {
        set
        {
            red = value;
        }
        get
        {
            return red;
        }
    }

    public int Green
    {
        set
        {
            green = value;
        }
        get
        {
            return green;
        }
    }

    public int Blue
    {
        set
        {
            blue = value;
        }
        get
        {
            return blue;
        }
    }

    public RGBColor() //default color for new object
    {
        red = 255;
        green = 0;
        blue = 0;
    }

    public RGBColor(int r, int g, int b) //selected color for new object
    {
        red = r;
        green = g;
        blue = b;
    }

    public void Randomize()
    {
        red = Random.Range(0, 256);
        green = Random.Range(0, 256);
        blue = Random.Range(0, 256);
    }
}

