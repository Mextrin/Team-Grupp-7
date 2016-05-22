using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public GameObject origin;
    public bool destroyOnHit;
    public float speed;
    public float offset, lifeTime;
    public int movement;
    public int damage;
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * movement * speed * Time.deltaTime);
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (destroyOnHit)
        {
            Destroy(gameObject);
        }
    }
    
}
