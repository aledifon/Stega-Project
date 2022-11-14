using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class in charge of handling the push force of the ball
/// </summary>
public class Ball : MonoBehaviour
{
    public float force;
    public Vector3 direction;
    public float timeToDestroy = 3;

    public Material mat;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);

        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction * force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //In case the tag of the collided GO is Enemy
        if (collision.collider.CompareTag("Enemy"))
        {
            //I destroy the GO which collides with this GO
            //Destroy(collision.gameObject);

            //I change the material of the GO which collides with this GO
            //GameObject cubeEnemy = collision.gameObject;
            //cubeEnemy.GetComponent<MeshRenderer>().material = mat;

            collision.gameObject.GetComponent<MeshRenderer>().material = mat;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            GameObject cubeEnemy = other.gameObject;
            cubeEnemy.GetComponent<MeshRenderer>().material = mat;
        }
    }

}
