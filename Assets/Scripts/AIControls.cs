using UnityEngine;
using System.Collections;

public class AIControls : MonoBehaviour
{
    Transform player;
    int movement, prevMovement;
    public float attackRange, attackSpeed;
    public float attackCooldown;
    float toWait;

    public GameObject shot;

    public float movementSpeed;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.position, transform.position) > attackRange)
        {

            if (player.position.x > transform.position.x)
            {
                movement = 1;
                prevMovement = 1;
            }
            else
            {
                movement = -1;
                prevMovement = -1;
            }

        }
        else
        {
            movement = 0;

            if (Time.time > toWait)
            {
                toWait = Time.time + attackCooldown;

                Projectile copyScript;
                GameObject copy = (GameObject)Instantiate(shot, transform.position, transform.rotation);
                //Physics2D.IgnoreCollision(GetComponents<BoxCollider2D>()[0], copy.GetComponent<CircleCollider2D>());
                //Physics2D.IgnoreCollision(GetComponents<BoxCollider2D>()[1], copy.GetComponent<CircleCollider2D>());
                copyScript = copy.GetComponent<Projectile>();
                copyScript.lifeTime = attackCooldown;
                copyScript.speed = attackSpeed;
                copyScript.origin = gameObject;
                copyScript.movement = prevMovement;
            }
        }

        transform.Translate(Vector2.right * movement * movementSpeed * Time.deltaTime);
    }
}
