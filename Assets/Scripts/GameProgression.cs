using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgression : MonoBehaviour
{

    public float gradualinc;
    int x = 1;
    public int increasedelay = 1000;

    void Update()
    {
        x++;

        if (x % increasedelay == 0) {

            FindObjectOfType<blocks>().increasespeed(gradualinc);
            FindObjectOfType<PlayerMovement>().increasespeed(gradualinc);
            x = 1;
        }

    }
}
