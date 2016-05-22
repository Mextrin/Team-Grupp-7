using UnityEngine;
using System.Collections;

public class BounceMesh : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController playerScript = other.GetComponent<CharacterController>();
            playerScript.direction.y = playerScript.jumpPower;
            playerScript.moveEffects = true;
            playerScript.movement = playerScript.prevMovement;
        }
    }
}
