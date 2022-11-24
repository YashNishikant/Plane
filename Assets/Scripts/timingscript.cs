using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timingscript : MonoBehaviour
{
    [SerializeField] private GameObject t;
    float time;

    void Update()
    {
        time += Time.deltaTime;
        t.GetComponent<TMPro.TextMeshProUGUI>().text = "" + (int)time;
    }
}
