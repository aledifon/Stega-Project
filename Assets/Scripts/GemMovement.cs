using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemMovement : MonoBehaviour
{
    public float speed;
    public int turnSpeed;
    private int speedSign = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckSpeedSign();
        Movement();
        Rotate();
    }
    void CheckSpeedSign()
    {
        if (transform.position.y >= 5.7f)
            speedSign = -1;
        else if (transform.position.y <= 5.50f)
            speedSign = 1;
    }
    void Movement()
    {
        transform.Translate(Vector3.forward * speed * speedSign * Time.deltaTime);
    }
    void Rotate()
    {
        transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
    }
}
