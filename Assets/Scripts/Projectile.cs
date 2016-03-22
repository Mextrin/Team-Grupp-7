using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    float damage, range, speed;
    float direction;

    public GameObject player;
    playerControls spawner;

    // Use this for initialization
    void Start()
    {
        spawner = player.GetComponent<playerControls>();
        speed = spawner.mysticShotSpeed;
        range = spawner.mysticShotRange;
        damage = spawner.mysticShotDamage;
        direction = spawner.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(speed);
        Debug.Log(direction);
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime);
    }
}
