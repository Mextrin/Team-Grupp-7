using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class CharacterController : MonoBehaviour
{
    public float speed, jumpPower, distanceToGround;
    Rigidbody2D rigidbody;
    public int movement, prevMovement = 1;
    public bool isGrounded, eventReady;
    private Vector2 direction;
    public Transform ability;
    public GameObject mysticShot;
    public bool isAI;
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
            movement = 0;
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
                GameObject copy = (GameObject)Instantiate(mysticShot, transform.position, transform.rotation);
                copyScript = copy.GetComponent<Projectile>();
                copyScript.movement = prevMovement;
                copyScript.lifeTime = cooldown;
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
        }
        else
        {
                direction.y -= rigidbody.mass * Time.deltaTime;
        }

        rigidbody.velocity = new Vector2(0, direction.y);
        transform.Translate(Vector2.right * movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
}