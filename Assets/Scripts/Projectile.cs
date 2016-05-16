using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float offset, lifeTime;
    public int movement;
    public int damage;

    //public GameObject player;
    CharacterController spawner;

    // Use this for initialization
    void Start()
    {
        transform.Translate(Vector2.right * movement * offset * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifeTime);
    }
    
}
