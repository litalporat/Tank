using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    // public float life = 3;
    [SerializeField] float force = 50f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // rb.useGravity = false;
        rb.AddForce(transform.forward* force, ForceMode.Impulse);
        // Destroy(gameObject, life);
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        // Destroy(collision.gameObject);
        // Destroy(gameObject);
        
    }
}
