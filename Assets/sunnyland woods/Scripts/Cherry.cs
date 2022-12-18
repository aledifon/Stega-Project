using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    public float force;
    public float forceTorque; // Torque force

    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        AddForce();
    }
    void AddForce()
    {
        rb2D.AddForce(Vector2.up*force);
        rb2D.AddForce(Random.Range(-1.0f,1.0f)*Vector2.right*force);
        rb2D.AddTorque(forceTorque);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        { 
            rb2D.velocity = Vector2.zero;
            rb2D.angularVelocity = 0;
            rb2D.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
