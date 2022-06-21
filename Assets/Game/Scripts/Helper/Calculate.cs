using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Calculate 
{
    public static float RandomVal(float value)
    {
        return Random.Range(-value / 2, value / 2);
    }
}
