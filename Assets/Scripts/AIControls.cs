using UnityEngine;
using System.Collections;

public class AIControls : MonoBehaviour
{
    Transform player;
    int movement, prevMovement;
    public float attackRange, attackSpeed;
    public float attackCooldown;
    public Vector3 spawnOffset = new Vector3(1.28f, 0);
    float toWait;
    float distanceToTarget;
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
        if (player != null)
        {

            distanceToTarget = Vector2.Distance(player.position, transform.position);

            if (player.position.x > transform.position.x)
            {
                if (distanceToTarget > attackRange)
                    movement = 1;
                prevMovement = 1;
            }
            else
            {
                if (distanceToTarget > attackRange)
                    movement = -1;
                prevMovement = -1;
            }

            if (distanceToTarget <= attackRange)
            {
                movement = 0;

                RaycastHit2D hit;
                hit = Physics2D.Raycast(transform.position + spawnOffset * prevMovement, Vector2.right * prevMovement, attackRange);

                if (hit.transform.gameObject == player.gameObject && Time.time > toWait)
                {
                    toWait = Time.time + attackCooldown;

                    Projectile copyScript;
                    GameObject copy = (GameObject)Instantiate(shot, transform.position + spawnOffset * prevMovement, transform.rotation);
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
}
