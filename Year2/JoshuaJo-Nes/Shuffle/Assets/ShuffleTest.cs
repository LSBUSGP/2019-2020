using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShuffleTest : MonoBehaviour
{

    public List<string> list;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shuffle.Shuffler(list);

    }
}
