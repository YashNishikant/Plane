using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;

    float x;
    float y;
    float z;
    public float smoothspeed;

    private void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }

    void FixedUpdate()
    {

        Vector3 desiredpos = player.transform.position + new Vector3(x, y, z);
        Vector3 smoothedpos = Vector3.Lerp(transform.position, desiredpos, smoothspeed);

        transform.position = smoothedpos;
    }
}
