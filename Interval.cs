using System;
using System.Collections.Generic;
using System.Text;

public class Interval
{
    public float Start { get; set; }
    public float End { get; set; }

    public Interval(float start, float end)
    {
        Start = start;
        End = end;
    }

    public bool InRange(float value)
    {
        if(value>=Start && value<=End)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
