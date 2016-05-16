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
    public float mysticShotDamage, mysticShotRange, mysticShotRate, mysticShotSpeed;
    public bool isAI;
    PlayerControls controller;

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
            Projectile copyScript;
            GameObject copy = (GameObject)Instantiate(mysticShot, transform.position, transform.rotation);
            copyScript = copy.GetComponent<Projectile>();
            copyScript.movement = prevMovement;
        }

        Vector2 position = transform.position;
        position.y += 0.1f;
        Debug.DrawRay(position, -Vector2.up, Color.green, distanceToGround);
        RaycastHit2D hit = Physics2D.Raycast(position, -Vector2.up, distanceToGround);
        
        if (hit.collider != null)
            isGrounded = true;
        else
            isGrounded = false;


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
}