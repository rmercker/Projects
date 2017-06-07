using UnityEngine;
using System.Collections;

public class G_Bullet : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var Health = hit.GetComponent<Sphere_Player>();
        if (Health != null)
        {
            Health.TakeDamage(10);
        }

        Destroy(gameObject);
    }
}
