using UnityEngine;
using System.Collections;

public class changeTrigger : MonoBehaviour
{

    CharacterController playerScript;
    SpriteRenderer renderer;

    // Update is called once per frame
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerScript != null && playerScript.eventReady)
        {
            if (Input.GetKey(KeyCode.E))
                renderer.color = Color.red;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerScript = other.gameObject.GetComponent<CharacterController>();
            playerScript.eventReady = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerScript = other.gameObject.GetComponent<CharacterController>();
            playerScript.eventReady = false;
        }
    }
}
