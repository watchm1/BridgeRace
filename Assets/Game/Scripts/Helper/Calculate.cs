using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Helper
{
    public static class Calculate 
    {
        public static float RandomValForPosition(float value)
        {
            return Random.Range(-value / 2, value / 2);
        }

        public static int RandomChoices(int listSize)
        {
            return Random.Range(0, listSize);
        }
    }

}