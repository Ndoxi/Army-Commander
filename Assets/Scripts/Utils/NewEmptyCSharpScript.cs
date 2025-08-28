using System;
using UnityEngine;

namespace Utils
{
    public static class TimeUtils
    {
        public static int ToMilliseconds(float seconds)
        {
            return Convert.ToInt32(seconds * 1000);
        }
    }
}