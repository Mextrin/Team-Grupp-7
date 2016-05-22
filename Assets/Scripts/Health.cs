using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour
{
    public Gradient healthColor, regenCooldownColor;
    public float startHealth;
    float health;
    float timeBetweenHits;
    public float hitCooldown;
    public Image healthBar, cooldownBar;
    public float hpPerSec, outOfCombatCooldown;
    float healWaitTime, nextHeal;

    // Use this for initialization
    void Start()
    {
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = health / startHealth;
            healthBar.color = healthColor.Evaluate(health / startHealth);
        }

        if (cooldownBar != null)
        {
            cooldownBar.fillAmount = Mathf.Clamp(healWaitTime - Time.time, 0, outOfCombatCooldown) / outOfCombatCooldown;
            cooldownBar.color = regenCooldownColor.Evaluate(Mathf.Clamp(healWaitTime - Time.time, 0, outOfCombatCooldown) / outOfCombatCooldown);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (Time.time > healWaitTime)
        {
            if (Time.time > nextHeal)
            {
                nextHeal = Time.time + 1;

                if (health < startHealth)
                {
                    if (hpPerSec <= startHealth - health)
                        health += hpPerSec;
                    else
                        health = startHealth;

                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Projectile projectile = other.GetComponent<Projectile>();

            if (projectile != null && projectile.origin != gameObject)
            {
                if (Time.time > timeBetweenHits)
                {
                    timeBetweenHits = Time.time + hitCooldown;
                    health -= projectile.damage;
                    healWaitTime = Time.time + outOfCombatCooldown;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Projectile projectile = other.gameObject.GetComponent<Projectile>();

            if (projectile != null && projectile.origin != gameObject)
            {
                if (Time.time > timeBetweenHits)
                {
                    timeBetweenHits = Time.time + hitCooldown;
                    healWaitTime = Time.time + outOfCombatCooldown;

                    health -= projectile.damage;
                }
            }
        }
    }
}
