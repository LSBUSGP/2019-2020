using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Shuffle
{
    public static void Shuffler<T>(this IList<T> list)
    {
        var rnd = new System.Random();

        for (var i = list.Count; i > 0; i--)
        {
            list.Swap(0, rnd.Next(0, i));
        }
    }

    public static void Swap<T>(this IList<T> list, int i, int j)
    {
        var temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }
}
