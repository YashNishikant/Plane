using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{

    [SerializeField] private GameObject t;
    float time;

    void Update()
    {
        time += Time.deltaTime;
        t.GetComponent<TMPro.TextMeshProUGUI>().text = "" + (int)time;
    }
}
