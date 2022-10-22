using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecloud : MonoBehaviour
{

    float x;
    public float speed;
    public float limit;

    private void Start()
    {
        x = speed;   
    }

    void Update()
    {
        transform.position += new Vector3(x, 0 , 0) * Time.deltaTime;
        if (transform.position.x > limit) {
            transform.position = new Vector3(-limit, transform.position.y, transform.position.z);
        }
    }
}
