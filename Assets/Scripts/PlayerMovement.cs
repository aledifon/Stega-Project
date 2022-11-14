using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public int turnSpeed;

    public GameObject gameManager;
    //public GameManager gameManagerScript;

    float h, v;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();
        Movement();
        Rotate();
    }

    void InputPlayer()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }
    void Movement()
    {
        transform.Translate(Vector3.forward * speed * v * Time.deltaTime);
    }
    void Rotate()
    {
        transform.Rotate(Vector3.up * turnSpeed * h * Time.deltaTime); 
    }
    private void OnTriggerEnter(Collider other)
    {
        //In case the collided element was a coin then we
        if (other.CompareTag("Coin"))
        {
            //Access to the Game Manager component (script) to call its AddCoin method.
            gameManager.GetComponent<GameManager>().AddCoin();
            //gameManagerScript.AddCoin();
            //Destroy the element
            Destroy(other.gameObject);
        }
    }
}
