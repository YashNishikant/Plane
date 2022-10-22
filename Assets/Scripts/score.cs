using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    float time;
    public Text t;

    void Update(){
        time += Time.deltaTime;
        t.text = (int)time + "";
    }
}
