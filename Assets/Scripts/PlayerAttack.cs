using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject ballPrefab; //reference to the ball's Prefab
                                  //(Use the The one who is in the asset's folder!
                                  //Important! Don't try to use a GO of the Scene as Input.)
    public Transform posBall; //Output position ball.
    public float timeBetweenAttacks;

    float timer; //Time counter
    //public GameObject posBall2;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject.transform.position
        Debug.Log("PosBall: " + posBall.position);
        //Debug.Log("PosBall: " + posBall2.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;    //Time counter: 0,1,2....
        //timer = timer + Time.deltaTime
        //Debug.Log("Timer " + timer);
        if (Input.GetMouseButtonDown(0) && timer >= timeBetweenAttacks)
        {
            CreateBall();
        }
    }
    void CreateBall()
    {
        timer = 0;
        //Creating Prefab clones and storing them in a local var. at once
        GameObject cloneBallPrefab =  Instantiate(ballPrefab, posBall.position, posBall.rotation);

        //Giving to the ball the same Z-dir. of the current GO assigned to this script (in this case the player).
        cloneBallPrefab.GetComponent<Ball>().direction = transform.forward;
    }

}
