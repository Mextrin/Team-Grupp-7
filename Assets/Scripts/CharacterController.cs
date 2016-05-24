using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class CharacterController : MonoBehaviour
{
    public float speed, jumpPower, distanceToGround;
    Rigidbody2D rigidbody;
    public int movement, prevMovement = 1;
    public bool isGrounded, eventReady;
    public Vector2 direction;
    public Vector3 spawnOffset;
    public Transform ability;
    public GameObject mysticShot;
    public bool moveEffects;
    public float cooldown;
    PlayerControls controller;
    float toWait = 0;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) || !(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (!moveEffects)
            {
                movement = 0;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                movement = -1;
                prevMovement = -1;
            }

            if (Input.GetKey(KeyCode.D))
            {
                movement = 1;
                prevMovement = 1;
            }
        }
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > toWait)
            {
                toWait = Time.time + cooldown;
                Projectile copyScript;
                GameObject copy = (GameObject)Instantiate(mysticShot, transform.position + spawnOffset * prevMovement, transform.rotation);
                copyScript = copy.GetComponent<Projectile>();
                copyScript.movement = prevMovement;
                copyScript.lifeTime = cooldown;
                copyScript.origin = gameObject;
            }
        }


    }
    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                direction.y = jumpPower;
            }
            else
                direction.y = 0;

            if (direction.x != 0)
            {
                direction.x = 0;
            }
        }
        else
        {
                direction.y -= rigidbody.mass * Time.deltaTime;
        }

        transform.localScale = new Vector3(prevMovement * 2, 2, 1);

        direction.x = movement * speed;

        rigidbody.velocity = new Vector2(direction.x, direction.y);
        transform.Translate(Vector2.right * movement * speed * Time.deltaTime);
    }
}