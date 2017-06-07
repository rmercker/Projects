using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Sphere_Player : MonoBehaviour {

    private const float maxlife = 100;

    public float angular_momentum;
    public float speed;
    public float health;

    public GameObject G_Bullet1;
    public GameObject G_Bullet2;
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;

    private Rigidbody rb;

    void Start ()
    {
        health = maxlife;
        rb = GetComponent<Rigidbody>();
	}

    void FixedUpdate()
    {
        //if ( !isLocalPlayer)
        //{
        //    return;
        //}
        if (rb.transform.position.y > -5)
        {
            float vertical = Input.GetAxis("Vertical");


            if (Input.GetKey("a") || Input.GetKey("left"))
            {
                Quaternion new_rot = Quaternion.Euler(rb.transform.eulerAngles.x, rb.transform.eulerAngles.y + -1 * angular_momentum, rb.transform.eulerAngles.z);
                rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, new_rot, Time.deltaTime * 2.0f);
            }
            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                Quaternion new_rot = Quaternion.Euler(rb.transform.eulerAngles.x, rb.transform.eulerAngles.y + angular_momentum, rb.transform.eulerAngles.z);
                rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, new_rot, Time.deltaTime * 2.0f);
            }
            if (!(Input.GetKey("a") || Input.GetKey("left") || Input.GetKey("d") || Input.GetKey("right")))
            {
                rb.angularVelocity = Vector3.zero;
            }
            // need to correlate vertical with moving and horizontal with rotation
            

            double temp = rb.transform.rotation.eulerAngles.y;
            Vector3 move = new Vector3(vertical * (float)(Math.Sin(temp * Math.PI / 180)), 0.0f, vertical * (float)(Math.Cos(temp * Math.PI / 180)));

            rb.AddForce(move * speed);
        }
        else
        {
            rb.transform.position = new Vector3(0.0f, 0.5f, 0.0f);
            rb.angularVelocity = Vector3.zero;
        }

        if ( Input.GetKeyDown("space"))
        {
            Fire();
        }


    }

    void Fire ()
    {
        var bullet1 = (GameObject)Instantiate(
            G_Bullet1,
            bulletSpawn1.position,
            bulletSpawn1.rotation);

        var bullet2 = (GameObject)Instantiate(
            G_Bullet2,
            bulletSpawn2.position,
            bulletSpawn2.rotation);

        // Add velocity to the bullet
        bullet1.GetComponent<Rigidbody>().velocity = bullet1.transform.forward * 8;
        bullet2.GetComponent<Rigidbody>().velocity = bullet2.transform.forward * 8;

        // spawn bullet on client
        //NetworkServer.Spawn(bullet);
        bullet1.GetComponent<Renderer>().enabled = true;
        bullet2.GetComponent<Renderer>().enabled = true;

        // Destroy the bullet after 2 seconds
        Destroy(bullet1, 2.0f);
        Destroy(bullet2, 2.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        Application.LoadLevel(2);
    }

    public void TakeDamage(float hit)
    {
        health -= hit;

        if (health <= 0)
        {
            // Destroy(rb);
            rb.transform.position = Vector3.zero;
            health = maxlife;
        }
    }
}
