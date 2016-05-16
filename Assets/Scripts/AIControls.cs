using UnityEngine;
using System.Collections;

public class AIControls : MonoBehaviour
{
    Transform player;
    int movement;

    public float speed;

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

        transform.Translate(Vector2.right * movement * speed * Time.deltaTime);
    }
}
