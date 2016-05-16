using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour
{
    public float startHealth;
    float health;
    float timeBetweenHits;
    public float hitCooldown;
    public Image healthBar;

    // Use this for initialization
    void Start()
    {
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            healthBar.fillAmount = (health / startHealth);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            if (Time.time > timeBetweenHits)
            {
                timeBetweenHits = Time.time + hitCooldown;
                health -= other.gameObject.GetComponent<Projectile>().damage;
            }
        }
    }
}
