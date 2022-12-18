using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnt : MonoBehaviour
{
    //Empty objects in the scene which represent the patrol points
    public Transform[] pointsObjects;
    public int speedWalking;//Patrol Ant's speed
    public GameObject cherryPrefab;//Cherries which spares the Ant when dies.

    [Header("Attack Player")]
    //Distance which the Ant will stop the patrol and will follow the player
    public float distanceToPlayer;
    GameObject player;
    public int speedAttack;//Ant's speed when it will be in Attack Mode
    public int speedAnimation;//Ant's speed animation (during pursuit Mode)
    public int damage;

    Vector2[] points;//Patrol positions (Which will get from pointsObjects)
    Vector3 posToGo;//Var. where I will save the target position of the Ant
    int i;
    int speed;

    SpriteRenderer spriteRenderer;
    Animator anim;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        //Get Points Objects (Finish this later)
        //pointsObjects = GameObject.FindGameObjectWithTag("AntPositions");
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = speedWalking;
        //Init the array
        points = new Vector2[pointsObjects.Length];
        for (int j = 0; j < pointsObjects.Length; j++)
            points[j] = pointsObjects[j].position;
        posToGo = points[i];
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= distanceToPlayer)
            AttackPlayer();
        else 
            ChangeTargetPos();

        transform.position = Vector3.MoveTowards(transform.position, posToGo, speed * Time.deltaTime);     
        Flip();     
    }
    //Change patrol position
    void ChangeTargetPos()
    {
        Debug.DrawLine(transform.position, player.transform.position, Color.green);
        //Reset speed & anim.speed in case of previous execution of AttackPlayer method
        speed = speedWalking;
        anim.speed = 1;
        //Current Target position Reached
        if (transform.position == posToGo)
        {
            //If we reach the last position then we'll reset the Idx pos.
            if (i == pointsObjects.Length-1)    i = 0;
            //Increase pos. Idx for the next position.
            else    i++;
            posToGo = points[i];  
        }
    }
    void Flip()
    {
        if (posToGo.x > transform.position.x) spriteRenderer.flipX = true;
        else if (posToGo.x < transform.position.x) spriteRenderer.flipX = false;        
    }
    void AttackPlayer()
    {
        Debug.DrawLine(transform.position, player.transform.position, Color.red);
        speed = speedAttack;
        anim.speed = speedAnimation;
        posToGo = new Vector2(player.transform.position.x, transform.position.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //The player is not on the ground
            if (!collision.collider.GetComponent<PlayerMovement>().isGrounded)
            {
                collision.collider.attachedRigidbody.AddForce(Vector2.up * 300);
                anim.SetTrigger("Death");
                Destroy(gameObject, 0.3f);
            }
            //The player is on the ground
            else
            {
                //Damage player's life
                collision.collider.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
            Death();
        }
    }
    void Death()
    {
        Loot();
        //Ant dies ("Morision") as long as the collision happened  with the Player
        anim.SetTrigger("Death");
        Destroy(gameObject, 0.3f);
    }
    void Loot()
    {
        for (int i = 0; i < Random.Range(1, 5); i++)
        {
            Instantiate(cherryPrefab, transform.position, transform.rotation);
        }
    }
}
