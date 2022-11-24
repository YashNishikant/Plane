using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float velocity = 0;
    float velocityupward = 0;
    public float increase = 0;
    float increaseupward = 0;
    public float rotate = 0;
    public float rotateY = 0;
    bool hitwall;
    bool hitwall2;
    float rotateprop = 0;
    public float bounds;
    public float boundsTOP;
    public float boundsBOTTOM;
    public float scaledownrotation;
    public Camera c;
    bool end;
    bool timelock = false;
    float newtime;
    float time = 0;
    [SerializeField] private List<ParticleSystem> particles = new List<ParticleSystem>();
    [SerializeField] private ParticleSystem explosion;

    private void Start()
    {
        increaseupward = increase;
        scaledownrotation = 1;
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (end)
        {
            c.transform.LookAt(transform);
            if (!timelock) { 
                newtime = time + 3;
                timelock = true;
            }
            if (time > newtime)
            {
                FindObjectOfType<gamemanager>().endgame();
            }
        }
        else {
            playerMovement();
        }
    }

    void playerMovement()
    {

        if ((int)velocityupward == 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotate * -10));
        }
        rotateprop += 25f;
        if (rotateprop == 1000)
        {
            rotateprop = 0;
        }

        if (Input.GetKey(KeyCode.W) && transform.position.y < boundsTOP)
        {

            if (hitwall2)
            {
                velocityupward = 0;
            }

            velocityupward += increaseupward * Time.deltaTime;
                rotateY = velocityupward / scaledownrotation;
            
            hitwall2 = false;
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > boundsBOTTOM)
        {

            if (hitwall2)
            {
                velocityupward = 0;
            }

            velocityupward -= increaseupward * Time.deltaTime;
                rotateY = velocityupward / scaledownrotation;
            hitwall2 = false;
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < bounds)
        {

            if (hitwall)
            {
                velocity = 0;
            }
            velocity += increase * Time.deltaTime;
                rotate = velocity / scaledownrotation;
            
            hitwall = false;
        }
        else if (transform.position.x > bounds)
        {
            transform.position = new Vector3(bounds, transform.position.y, transform.position.z);
            hitwall = true;
            adjrotation();
        }
        if (transform.position.y > boundsTOP)
        {
            transform.position = new Vector3(transform.position.x, boundsTOP, transform.position.z);
            hitwall2 = true;
            adjrotation2();
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -bounds)
        {

            if (hitwall)
            {
                velocity = 0;
            }
            velocity -= increase * Time.deltaTime;
                rotate = velocity / scaledownrotation;
            
            hitwall = false;
        }
        else if (transform.position.x < -bounds)
        {
            transform.position = new Vector3(-bounds, transform.position.y, transform.position.z);
            hitwall = true;
            adjrotation();
        }
        if (transform.position.y < boundsBOTTOM)
        {
            transform.position = new Vector3(transform.position.x, boundsBOTTOM, transform.position.z);
            hitwall2 = true;
            adjrotation2();
        }

        transform.rotation = Quaternion.Euler(new Vector3(rotateY * -10, 0, rotate * -10));
        transform.position += new Vector3(velocity, velocityupward, 0) * Time.deltaTime;
    }

    void adjrotation()
    {
        if (rotate > 0)
        {
            rotate -= 10 * increase * Time.deltaTime;
        }
        if (rotate < 0)
        {
            rotate += 10 * increase * Time.deltaTime;
        }
    }

    void adjrotation2()
    {
        if (rotateY > 0)
        {
            rotateY -= 10 * increaseupward * Time.deltaTime;
        }
        if (rotateY < 0)
        {
            rotateY += 10 * increaseupward * Time.deltaTime;
        }
    }

    public void increasespeed(float inc) {
        if(increase < 70) {

            increase *= inc;
            increaseupward *= inc;
            scaledownrotation *= inc;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag.Equals("END")) {

            collision.transform.gameObject.GetComponent<Rigidbody>().useGravity = true;
            increase = 0;
            increaseupward = 0;
            FindObjectOfType<blocks>().stop();
            GetComponent<blocks>().enabled = false;
            GetComponent<Rigidbody>().useGravity = true;
            transform.GetComponent<Rigidbody>().AddForce(Random.Range(10000, 20000) * Time.deltaTime, Random.Range(10000, 20000) * Time.deltaTime, 30000*Time.deltaTime);
            collision.transform.GetComponent<Rigidbody>().AddForce(0, 0, 10000 * Time.deltaTime);

            for (int i = 0; i < collision.contactCount; i++) {
                ParticleSystem e = Instantiate(explosion, collision.GetContact(i).point, Quaternion.identity);
                e.Play();
            }

            foreach (ParticleSystem p in particles) {
                p.Stop();
            }
            
            end = true;

            Destroy(collision.gameObject);

        }
    }

}
