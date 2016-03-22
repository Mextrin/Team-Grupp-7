using UnityEngine;
using System.Collections;

public class playerControls : MonoBehaviour
{
    public float speed, jumpPower, gravity;
    public Rigidbody2D rigidBody;
    public int movement;
    public bool isGrounded, eventReady;
    private Vector2 direction = Vector2.zero;

    public int rotation;
    public GameObject mysticShot;
    public float mysticShotDamage, mysticShotRange, mysticShotRate, mysticShotSpeed;
    
    void Start()
    {
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            movement = -1;
            rotation = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement = 1;
            rotation = -1;
        }
        else
        {
            movement = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject copy = Instantiate(mysticShot);
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
                direction.y -= gravity * Time.deltaTime;

        }

        rigidBody.velocity = new Vector2(0, direction.y);
        transform.Translate(Vector2.right * movement * speed * Time.deltaTime);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Floor")
            isGrounded = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isGrounded = false;
    }
}