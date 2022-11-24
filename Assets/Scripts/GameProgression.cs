using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProgression : MonoBehaviour
{

    float gradualinc;
    int x = 1;
    int increasedelay = 1000;

    void Start()
    {
        gradualinc = 1.1f;    
    }

    void Update() { 

        x++;

        if (x % increasedelay == 0) {

            FindObjectOfType<blocks>().increasespeed(gradualinc);
            FindObjectOfType<PlayerMovement>().increasespeed(gradualinc);
            x = 1;
        }

    }
}
