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
        if (player.position.x > transform.position.x)
            movement = 1;
        else
            movement = -1;

        if (Vector2.Distance(player.position, transform.position) < attackRange)
        {
            if (Time.time > toWait)
            {
                toWait = Time.time + attackCooldown;
                Projectile copyScript;
                GameObject copy = (GameObject)Instantiate(shot, transform.position, transform.rotation);
                copyScript = copy.GetComponent<Projectile>();
                copyScript.movement = prevMovement;
                copyScript.lifeTime = attackCooldown;
                copyScript.speed = attackSpeed;
            }
        }

        transform.Translate(Vector2.right * movement * movementSpeed * Time.deltaTime);
    }
}
