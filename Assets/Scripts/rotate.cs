using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{

    float y;
    public float rotationspeed;

    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0,y,0));
        y += rotationspeed;
    }
}
