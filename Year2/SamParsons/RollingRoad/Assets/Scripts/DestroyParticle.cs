﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    public float timeTillDestroy;

    void Start()
    {
        Destroy(gameObject, timeTillDestroy);
    }
}
