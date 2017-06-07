using UnityEngine;
using UnityEngine.Networking;

public class Ball_cont : NetworkBehaviour
{
    private Transform tf;
    private Rigidbody rb;
    public int speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
    }

	// Update is called once per frame
	void FixedUpdate () {
        if (rb.velocity.x == 0)
        {
            Vector3 move = new Vector3(Random.Range(-5, 5) * speed, Random.Range(-5, 5) * speed, Random.Range(-5, 5) * speed);
            rb.AddForce(move);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        tf.transform.position = new Vector3(0, 0, 0);
        Vector3 move = new Vector3(Random.Range(-5, 5) * speed, Random.Range(-5, 5) * speed, Random.Range(-5, 5) * speed);
        rb.AddForce(move);
    }
}
