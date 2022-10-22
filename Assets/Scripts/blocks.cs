using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocks : MonoBehaviour
{
    List<GameObject> obs = new List<GameObject>();
    public GameObject obstacle;
    public GameObject collect;
    public float blockspeed;
    int spawntime = 50;
    int x;

    private void FixedUpdate()
    {
        x++;
        if (x % spawntime == 0) {
            obsgenerate();
            x = 0;
        }
        
        for (int i = 0; i < obs.Count; i++){
            if(obs[i].transform.position.z < -10) {
                Destroy(obs[i].gameObject);
                obs.RemoveAt(i);
            }
        }

        for (int i = 0; i < obs.Count; i++)
        {
            obs[i].transform.position += new Vector3(0, 0, -blockspeed) * Time.deltaTime;
        }

    }

    void obsgenerate() {
            GameObject n;
            n = Instantiate(obstacle) as GameObject;
            n.transform.position = new Vector3(Random.Range(-20, 20), Random.Range(-8, 10), 100);
            n.transform.rotation = Quaternion.Euler(new Vector3(Random.Range(-15,15), Random.Range(0,360), Random.Range(-15, 15)));
            n.transform.localScale = new Vector3(Random.Range(2,5), Random.Range(2, 5), Random.Range(2, 5));
            obs.Add(n);
    }

    void type1obs(float z) {
        GameObject n;
        n = Instantiate(collect) as GameObject;
        n.transform.position = new Vector3(Random.Range(-70,70), Random.Range(-100, 100), z);
        obs.Add(n);
    }

    void type2obs(float z)
    {
        float x = Random.Range(-70, 70);
        float y = Random.Range(-100, 100);
        float z1 = z;

        for (int i = 0; i < 3; i++){
            GameObject n;
            n = Instantiate(obstacle) as GameObject;
            n.transform.position = new Vector3(x, y, z1);
            obs.Add(n);
            z1 += 15;
        }
    }

    public void increasespeed(float inc)
    {
        if (blockspeed < 70){
            blockspeed *= inc;
        }
        if(spawntime > 10)
        spawntime -= 10;

        if (spawntime <= 0) {
            spawntime = 10;
        }
    }


    public void stop() {
        blockspeed = 0;
    }

}
