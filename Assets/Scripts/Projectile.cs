using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float damage, lifeTime, speed;
    public int movement;
    float direction;

    //public GameObject player;
    CharacterController spawner;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * movement * speed * Time.deltaTime);
        Destroy(gameObject, lifeTime);
    }
}
